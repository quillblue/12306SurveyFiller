namespace SurveyFiller
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DelayTimer = new System.Windows.Forms.Timer(this.components);
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dataGridViewWorkList = new System.Windows.Forms.DataGridView();
            this.panelCheckSM = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCheckSMSubmit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSMCheckSeq = new System.Windows.Forms.Label();
            this.labelSMCheckUserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.travelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upBoundStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offBoundStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surveyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkList)).BeginInit();
            this.panelCheckSM.SuspendLayout();
            this.SuspendLayout();
            // 
            // DelayTimer
            // 
            this.DelayTimer.Interval = 1000;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(546, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(59, 26);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dataGridViewWorkList
            // 
            this.dataGridViewWorkList.AllowUserToAddRows = false;
            this.dataGridViewWorkList.AllowUserToDeleteRows = false;
            this.dataGridViewWorkList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewWorkList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userName,
            this.travelDate,
            this.trainNo,
            this.upBoundStation,
            this.offBoundStation,
            this.status,
            this.surveyNumber});
            this.dataGridViewWorkList.Location = new System.Drawing.Point(19, 274);
            this.dataGridViewWorkList.Name = "dataGridViewWorkList";
            this.dataGridViewWorkList.RowTemplate.Height = 23;
            this.dataGridViewWorkList.Size = new System.Drawing.Size(656, 199);
            this.dataGridViewWorkList.TabIndex = 2;
            // 
            // panelCheckSM
            // 
            this.panelCheckSM.BackColor = System.Drawing.Color.LightGray;
            this.panelCheckSM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCheckSM.Controls.Add(this.label8);
            this.panelCheckSM.Controls.Add(this.btnCheckSMSubmit);
            this.panelCheckSM.Controls.Add(this.textBox1);
            this.panelCheckSM.Controls.Add(this.label7);
            this.panelCheckSM.Controls.Add(this.labelSMCheckSeq);
            this.panelCheckSM.Controls.Add(this.labelSMCheckUserName);
            this.panelCheckSM.Controls.Add(this.label6);
            this.panelCheckSM.Controls.Add(this.label5);
            this.panelCheckSM.Controls.Add(this.label1);
            this.panelCheckSM.Location = new System.Drawing.Point(428, 103);
            this.panelCheckSM.Name = "panelCheckSM";
            this.panelCheckSM.Size = new System.Drawing.Size(247, 156);
            this.panelCheckSM.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "短信验证";
            // 
            // btnCheckSMSubmit
            // 
            this.btnCheckSMSubmit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckSMSubmit.Location = new System.Drawing.Point(170, 96);
            this.btnCheckSMSubmit.Name = "btnCheckSMSubmit";
            this.btnCheckSMSubmit.Size = new System.Drawing.Size(45, 25);
            this.btnCheckSMSubmit.TabIndex = 7;
            this.btnCheckSMSubmit.Text = "确定";
            this.btnCheckSMSubmit.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(96, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "123456";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(2, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "短信验证码";
            // 
            // labelSMCheckSeq
            // 
            this.labelSMCheckSeq.AutoSize = true;
            this.labelSMCheckSeq.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSMCheckSeq.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelSMCheckSeq.Location = new System.Drawing.Point(93, 72);
            this.labelSMCheckSeq.Name = "labelSMCheckSeq";
            this.labelSMCheckSeq.Size = new System.Drawing.Size(63, 17);
            this.labelSMCheckSeq.TabIndex = 4;
            this.labelSMCheckSeq.Text = "quillqian";
            // 
            // labelSMCheckUserName
            // 
            this.labelSMCheckUserName.AutoSize = true;
            this.labelSMCheckUserName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSMCheckUserName.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelSMCheckUserName.Location = new System.Drawing.Point(93, 54);
            this.labelSMCheckUserName.Name = "labelSMCheckUserName";
            this.labelSMCheckUserName.Size = new System.Drawing.Size(63, 17);
            this.labelSMCheckUserName.TabIndex = 3;
            this.labelSMCheckUserName.Text = "quillqian";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "验证码序列号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "乘车人用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "请在15分钟内输入相应手机上收到的验证码";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilePath.Location = new System.Drawing.Point(133, 23);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(407, 22);
            this.textBoxFilePath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "任务列表（每5秒刷新一次）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Excel文件路径";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "满意度选择";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(546, 55);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(59, 26);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // userName
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.userName.DefaultCellStyle = dataGridViewCellStyle1;
            this.userName.DividerWidth = 1;
            this.userName.Frozen = true;
            this.userName.HeaderText = "乘车人";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.userName.Width = 80;
            // 
            // travelDate
            // 
            this.travelDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.travelDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.travelDate.DividerWidth = 1;
            this.travelDate.Frozen = true;
            this.travelDate.HeaderText = "乘车日期";
            this.travelDate.Name = "travelDate";
            this.travelDate.ReadOnly = true;
            this.travelDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.travelDate.Width = 80;
            // 
            // trainNo
            // 
            this.trainNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.trainNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.trainNo.DividerWidth = 1;
            this.trainNo.Frozen = true;
            this.trainNo.HeaderText = "车次";
            this.trainNo.Name = "trainNo";
            this.trainNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.trainNo.Width = 60;
            // 
            // upBoundStation
            // 
            this.upBoundStation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.upBoundStation.DefaultCellStyle = dataGridViewCellStyle4;
            this.upBoundStation.DividerWidth = 1;
            this.upBoundStation.HeaderText = "上车站";
            this.upBoundStation.Name = "upBoundStation";
            this.upBoundStation.Width = 80;
            // 
            // offBoundStation
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.offBoundStation.DefaultCellStyle = dataGridViewCellStyle5;
            this.offBoundStation.DividerWidth = 1;
            this.offBoundStation.HeaderText = "下车站";
            this.offBoundStation.Name = "offBoundStation";
            this.offBoundStation.Width = 80;
            // 
            // status
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle6;
            this.status.DividerWidth = 1;
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.Width = 60;
            // 
            // surveyNumber
            // 
            this.surveyNumber.DividerWidth = 1;
            this.surveyNumber.HeaderText = "问卷编号/备注";
            this.surveyNumber.Name = "surveyNumber";
            this.surveyNumber.Width = 150;
            // 
            // PanelTimer
            // 
            this.PanelTimer.Interval = 5000;
            this.PanelTimer.Tick += new System.EventHandler(this.PanelTimer_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 487);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.panelCheckSM);
            this.Controls.Add(this.dataGridViewWorkList);
            this.Controls.Add(this.btnBrowse);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkList)).EndInit();
            this.panelCheckSM.ResumeLayout(false);
            this.panelCheckSM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer DelayTimer;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dataGridViewWorkList;
        private System.Windows.Forms.Panel panelCheckSM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSMCheckUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSMCheckSeq;
        private System.Windows.Forms.Button btnCheckSMSubmit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn travelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn upBoundStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn offBoundStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn surveyNumber;
        private System.Windows.Forms.Timer PanelTimer;
    }
}