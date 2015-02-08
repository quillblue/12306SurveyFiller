using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SurveyFiller
{
    public partial class FormMain : Form
    {
        WebControl wc = WebControl.Instance();
        SurveyControl sc = new SurveyControl();
        ValidationCodeProcessing vcp = new ValidationCodeProcessing();
        List<SurveyBaseInfo> workLoad = new List<SurveyBaseInfo>();

        public FormMain()
        {
            InitializeComponent();
        }

        #region ButtonsClickResponse
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel97-03文件|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = ofd.FileName;
                ReadWorkLoad();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (workLoad.Count == 0) { ReadWorkLoad(); }
            LockConfigPanel();
            int i = 1;
            int opinion = radioButtonAllGood.Checked ? 0 : 1;
            String province = textBoxProvince.Text + "/" + textBoxCity.Text;
            foreach (SurveyBaseInfo sbi in workLoad)
            {
                if (sbi.SurveyNumber.Contains("重试"))
                {
                    sbi.UpdateStatus("等待", "");
                }
            }
            UpdateWorkLoadPanel();
            foreach (SurveyBaseInfo sbi in workLoad)
            {
                if (sbi.SurveyStatus == "等待" || sbi.SurveyNumber.Contains("重试"))
                {
                    sbi.UpdateStatus("进行中", "");
                    UpdateWorkLoadPanel();
                    UpdateWorkingStatus("【第" + i + "张问卷】正在进行短信验证");

                    String fetchResult = FetchValidationCode(sbi.UserName);
                    if (fetchResult.Length != 4)
                    {
                        sbi.UpdateStatus("失败", fetchResult);
                        UpdateWorkLoadPanel();
                        UpdateWorkingStatus("【第" + i + "张问卷】短信验证失败", 2);
                    }
                    else
                    {
                        FormSMCheck fsmc = new FormSMCheck(sbi.UserName, fetchResult);
                        fsmc.ShowDialog();
                        if (fsmc.DialogResult == DialogResult.Cancel)
                        {
                            sbi.UpdateStatus("失败", "[可重试]用户中断了操作");
                            UpdateWorkLoadPanel();
                            UpdateWorkingStatus("【第" + i + "张问卷】用户中断操作", 2);
                        }
                        else
                        {
                            UpdateWorkingStatus("【第" + i + "张问卷】正在提交");
                            String response = sc.FillSurvey(sbi, opinion, province);
                            if (response[0] == 'E')
                            {
                                UpdateWorkingStatus("提交第" + i + "张问卷失败，失败原因：" + response.Substring(1), 2);
                                sbi.UpdateStatus("失败", response.Substring(1));
                                UpdateWorkLoadPanel();
                            }
                            else
                            {
                                UpdateWorkingStatus("提交第" + i + "张问卷成功", 1);
                                sbi.UpdateStatus("成功", response.Substring(1));
                                UpdateWorkLoadPanel();
                            }
                        }
                    }
                }
                i++;
            }
            UnlockConfigPanel();
            UpdateWorkingStatus("全部处理完毕，若存在标有[可重试]的失败条目，可再次点击开始|重试按钮重试");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region LockAndUnlockCanvas
        private void LockConfigPanel()
        {
            panelConfig.Enabled = false;
            btnStart.Enabled = false;
            btnExport.Enabled = false;
        }

        private void UnlockConfigPanel()
        {
            panelConfig.Enabled = true;
            btnStart.Enabled = true;
            btnExport.Enabled = true;
        }
        #endregion

        #region CanvasDrawing
        private void UpdateWorkingStatus(String text, int statusMode = 0)
        {
            textBoxStatus.Text = text;
            switch (statusMode)
            {
                case 0: textBoxStatus.BackColor = Color.White; break;
                case 1: textBoxStatus.BackColor = Color.LightGreen; break;
                case 2: textBoxStatus.BackColor = Color.LightCoral; break;
            }
            this.Update();
        }

        private void UpdateWorkLoadPanel()
        {
            dataGridViewWorkList.Rows.Clear();
            foreach (SurveyBaseInfo sbi in workLoad)
            {
                String[] row = { sbi.UserName, sbi.TravelRecord.TravelDate, sbi.TravelRecord.TravelTrainNumber, sbi.TravelRecord.OnBoardStationDisplay, sbi.TravelRecord.OffBoardStationDisplay, sbi.SurveyStatus, sbi.SurveyNumber };
                dataGridViewWorkList.Rows.Add(row);
            }
            for (int i = 0; i < dataGridViewWorkList.Rows.Count; i++)
            {
                switch (dataGridViewWorkList.Rows[i].Cells[5].Value.ToString())
                {
                    case "失败": dataGridViewWorkList.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral; break;
                    case "成功": dataGridViewWorkList.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen; break;
                    case "进行中": dataGridViewWorkList.Rows[i].DefaultCellStyle.BackColor = Color.Yellow; break;
                    default: dataGridViewWorkList.Rows[i].DefaultCellStyle.BackColor = Color.White; break;
                }

            }
            this.Update();
        }
        #endregion

        #region BusinessLogic
        private String FetchValidationCode(String userName)
        {
            Boolean fetched = false;
            String fetchedSeqNo = "";
            while (!fetched)
            {
                fetchedSeqNo = vcp.FetchValidationCode(userName);
                if (fetchedSeqNo.Length == 4)
                {
                    fetched = true;
                }
                else
                {
                    if (fetchedSeqNo.Contains("重试"))
                    {
                        UpdateWorkingStatus("短信发送频率超过限制，将在30秒后重试", 2);
                        System.Threading.Thread.Sleep(30000);
                    }
                    else
                    {
                        return fetchedSeqNo;
                    }
                }
            }
            return fetchedSeqNo;
        }

        private void ReadWorkLoad()
        {
            UpdateWorkingStatus("正在读取输入文件");
            workLoad = sc.LoadWorkList(textBoxFilePath.Text);
            if (workLoad.Count == 0)
            {
                UnlockConfigPanel();
                UpdateWorkingStatus("Excel读取失败或内容为空", 2);
                return;
            }
            UpdateWorkingStatus("Excel读取完成", 1);
            UpdateWorkLoadPanel();
        }
        #endregion
    }
}
