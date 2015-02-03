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
            if (ofd.ShowDialog() == DialogResult.OK) {
                textBoxFilePath.Text = ofd.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            workLoad = sc.LoadWorkList(textBoxFilePath.Text);
            updateWorkLoadPanel();
            PanelTimer.Enabled = true;
        }

        private void updateWorkLoadPanel() {
            dataGridViewWorkList.Rows.Clear();
            foreach (SurveyBaseInfo sbi in workLoad)
            {
                String[] row = { sbi.UserName, sbi.TravelRecord.TravelDate,sbi.TravelRecord.TravelTrainNumber,sbi.TravelRecord.OnBoardStation,sbi.TravelRecord.OffBoardStation,sbi.SurveyStatus,sbi.SurveyNumber };
                dataGridViewWorkList.Rows.Add(row);
            }

        }

        private void PanelTimer_Tick(object sender, EventArgs e)
        {
            updateWorkLoadPanel();
        }


    }
}
