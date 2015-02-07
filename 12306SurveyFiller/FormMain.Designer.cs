﻿namespace SurveyFiller
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dataGridViewWorkList = new System.Windows.Forms.DataGridView();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.travelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upBoundStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offBoundStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surveyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.PanelTimer = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.radioButtonAllGood = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.panelConfig = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkList)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(520, 11);
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
            this.dataGridViewWorkList.Location = new System.Drawing.Point(19, 267);
            this.dataGridViewWorkList.Name = "dataGridViewWorkList";
            this.dataGridViewWorkList.RowTemplate.Height = 23;
            this.dataGridViewWorkList.Size = new System.Drawing.Size(633, 199);
            this.dataGridViewWorkList.TabIndex = 2;
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
            // textBoxFilePath
            // 
            this.textBoxFilePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilePath.Location = new System.Drawing.Point(121, 15);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(392, 22);
            this.textBoxFilePath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "任务列表（每5秒刷新一次）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Excel文件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "满意度选择";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(19, 142);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 37);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PanelTimer
            // 
            this.PanelTimer.Enabled = true;
            this.PanelTimer.Interval = 5000;
            this.PanelTimer.Tick += new System.EventHandler(this.PanelTimer_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(129, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "当前状态";
            // 
            // radioButtonAllGood
            // 
            this.radioButtonAllGood.AutoSize = true;
            this.radioButtonAllGood.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonAllGood.Location = new System.Drawing.Point(215, 49);
            this.radioButtonAllGood.Name = "radioButtonAllGood";
            this.radioButtonAllGood.Size = new System.Drawing.Size(79, 23);
            this.radioButtonAllGood.TabIndex = 9;
            this.radioButtonAllGood.Text = "全部满意";
            this.radioButtonAllGood.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonNormal.Location = new System.Drawing.Point(121, 49);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(79, 23);
            this.radioButtonNormal.TabIndex = 10;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "一般评价";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(330, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 21);
            this.label10.TabIndex = 11;
            this.label10.Text = "省份/城市";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(417, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 25);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "上海";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(488, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 21);
            this.label11.TabIndex = 13;
            this.label11.Text = "/";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(509, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 25);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "上海";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(19, 185);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(85, 37);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "导出结果";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.Color.White;
            this.textBoxStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.Location = new System.Drawing.Point(204, 97);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(387, 25);
            this.textBoxStatus.TabIndex = 17;
            this.textBoxStatus.TabStop = false;
            this.textBoxStatus.Text = "等待输入配置文件";
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Controls.Add(this.btnBrowse);
            this.panelConfig.Controls.Add(this.textBoxFilePath);
            this.panelConfig.Controls.Add(this.label4);
            this.panelConfig.Controls.Add(this.textBox3);
            this.panelConfig.Controls.Add(this.radioButtonAllGood);
            this.panelConfig.Controls.Add(this.label11);
            this.panelConfig.Controls.Add(this.radioButtonNormal);
            this.panelConfig.Controls.Add(this.textBox2);
            this.panelConfig.Controls.Add(this.label10);
            this.panelConfig.Location = new System.Drawing.Point(13, 10);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(609, 78);
            this.panelConfig.TabIndex = 18;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 480);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewWorkList);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkList)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dataGridViewWorkList;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn travelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn upBoundStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn offBoundStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn surveyNumber;
        private System.Windows.Forms.Timer PanelTimer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButtonAllGood;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Panel panelConfig;
    }
}