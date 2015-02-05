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
        SurveyControl sc = new SurveyControl();
        List<SurveyBaseInfo> workLoad = new List<SurveyBaseInfo>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel97-03文件|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = ofd.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LockConfigPanel();
            updateWorkingStatus("正在读取输入文件");
            workLoad = sc.LoadWorkList(textBoxFilePath.Text);
            if (workLoad.Count == 0) {
                UnlockConfigPanel();
                return;
            }
            updateWorkingStatus("Excel读取完成",1);
            updateWorkLoadPanel();
            PanelTimer.Enabled = true;
        }

        private void updateWorkLoadPanel()
        {
            dataGridViewWorkList.Rows.Clear();
            foreach (SurveyBaseInfo sbi in workLoad)
            {
                String[] row = { sbi.UserName, sbi.TravelRecord.TravelDate, sbi.TravelRecord.TravelTrainNumber, sbi.TravelRecord.OnBoardStation, sbi.TravelRecord.OffBoardStation, sbi.SurveyStatus, sbi.SurveyNumber };
                dataGridViewWorkList.Rows.Add(row);
            }

        }

        private void PanelTimer_Tick(object sender, EventArgs e)
        {
            updateWorkLoadPanel();
        }

        private void LockConfigPanel()
        {
            panelConfig.Enabled = false;
            btnStart.Enabled = false;
            btnExport.Enabled = false;
        }

        public void updateWorkingStatus(String text, int statusMode = 0) 
        {
            textBoxStatus.Text = text;
            switch (statusMode) {
                case 0: textBoxStatus.BackColor = Color.White; break;
                case 1: textBoxStatus.BackColor = Color.LightGreen; break;
                case 2: textBoxStatus.BackColor = Color.LightCoral; break;
            }
        }

        private void UnlockConfigPanel() {
            panelConfig.Enabled = true;
            btnStart.Enabled = true;
            btnExport.Enabled = true;
        }

    }
}
