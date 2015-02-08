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
    public partial class FormSMCheck : Form
    {
        public FormSMCheck(String userName, String seqNo)
        {
            InitializeComponent();
            labelSMCheckUserName.Text = userName;
            labelSMCheckSeq.Text = seqNo;
        }

        private void textBoxVC_TextChanged(object sender, EventArgs e)
        {
            btnCheckSMSubmit.Enabled = textBoxVC.Text.Length == 6;
        }

        private void btnCheckSMSubmit_Click(object sender, EventArgs e)
        {
            ValidationCodeProcessing vcp = new ValidationCodeProcessing();
            String sendResult = vcp.SendValidationRequest(labelSMCheckUserName.Text, labelSMCheckSeq.Text, textBoxVC.Text);
            if (sendResult == "ok")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else { labelSMCheckErrorText.Text = sendResult; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
