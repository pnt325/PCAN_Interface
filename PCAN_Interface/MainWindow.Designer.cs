namespace PCAN_Interface
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpInitialize = new System.Windows.Forms.GroupBox();
            this.LstBaudRate = new System.Windows.Forms.ListBox();
            this.ButStartStop = new System.Windows.Forms.Button();
            this.LblBaudRate = new System.Windows.Forms.Label();
            this.LstDevices = new System.Windows.Forms.ListBox();
            this.LblListOfDevices = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbSendMonitor = new System.Windows.Forms.CheckBox();
            this.lsvMessage = new PCAN_Interface.CusComponents.ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbSystemMsg = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSendData7 = new System.Windows.Forms.TextBox();
            this.txbSendData0 = new System.Windows.Forms.TextBox();
            this.txbSendData6 = new System.Windows.Forms.TextBox();
            this.txbSendData1 = new System.Windows.Forms.TextBox();
            this.txbSendData5 = new System.Windows.Forms.TextBox();
            this.txbSendData2 = new System.Windows.Forms.TextBox();
            this.txbSendData4 = new System.Windows.Forms.TextBox();
            this.txbSendData3 = new System.Windows.Forms.TextBox();
            this.chbEnableAutoFill = new System.Windows.Forms.CheckBox();
            this.btnShowResponseData = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.GrpInitialize.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.testToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1247, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(144, 34);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(58, 29);
            this.testToolStripMenuItem1.Text = "Test";
            // 
            // GrpInitialize
            // 
            this.GrpInitialize.Controls.Add(this.LstBaudRate);
            this.GrpInitialize.Controls.Add(this.ButStartStop);
            this.GrpInitialize.Controls.Add(this.LblBaudRate);
            this.GrpInitialize.Enabled = false;
            this.GrpInitialize.Location = new System.Drawing.Point(252, 54);
            this.GrpInitialize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GrpInitialize.Name = "GrpInitialize";
            this.GrpInitialize.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GrpInitialize.Size = new System.Drawing.Size(372, 172);
            this.GrpInitialize.TabIndex = 11;
            this.GrpInitialize.TabStop = false;
            this.GrpInitialize.Text = "Initialize";
            // 
            // LstBaudRate
            // 
            this.LstBaudRate.FormattingEnabled = true;
            this.LstBaudRate.ItemHeight = 20;
            this.LstBaudRate.Location = new System.Drawing.Point(8, 60);
            this.LstBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LstBaudRate.Name = "LstBaudRate";
            this.LstBaudRate.Size = new System.Drawing.Size(270, 104);
            this.LstBaudRate.TabIndex = 5;
            // 
            // ButStartStop
            // 
            this.ButStartStop.Location = new System.Drawing.Point(286, 60);
            this.ButStartStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButStartStop.Name = "ButStartStop";
            this.ButStartStop.Size = new System.Drawing.Size(75, 31);
            this.ButStartStop.TabIndex = 6;
            this.ButStartStop.Text = "Start";
            this.ButStartStop.UseVisualStyleBackColor = true;
            // 
            // LblBaudRate
            // 
            this.LblBaudRate.AutoSize = true;
            this.LblBaudRate.Location = new System.Drawing.Point(8, 25);
            this.LblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBaudRate.Name = "LblBaudRate";
            this.LblBaudRate.Size = new System.Drawing.Size(139, 20);
            this.LblBaudRate.TabIndex = 4;
            this.LblBaudRate.Text = "Select Baud Rate:";
            // 
            // LstDevices
            // 
            this.LstDevices.FormattingEnabled = true;
            this.LstDevices.ItemHeight = 20;
            this.LstDevices.Location = new System.Drawing.Point(16, 75);
            this.LstDevices.Name = "LstDevices";
            this.LstDevices.Size = new System.Drawing.Size(228, 144);
            this.LstDevices.TabIndex = 10;
            // 
            // LblListOfDevices
            // 
            this.LblListOfDevices.AutoSize = true;
            this.LblListOfDevices.Location = new System.Drawing.Point(16, 54);
            this.LblListOfDevices.Name = "LblListOfDevices";
            this.LblListOfDevices.Size = new System.Drawing.Size(154, 20);
            this.LblListOfDevices.TabIndex = 13;
            this.LblListOfDevices.Text = "PCAN USB Devices:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbSendMonitor);
            this.groupBox1.Controls.Add(this.lsvMessage);
            this.groupBox1.Controls.Add(this.ButClear);
            this.groupBox1.Location = new System.Drawing.Point(16, 235);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(608, 382);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Monitor Window";
            // 
            // chbSendMonitor
            // 
            this.chbSendMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSendMonitor.AutoSize = true;
            this.chbSendMonitor.Location = new System.Drawing.Point(436, 348);
            this.chbSendMonitor.Name = "chbSendMonitor";
            this.chbSendMonitor.Size = new System.Drawing.Size(161, 24);
            this.chbSendMonitor.TabIndex = 38;
            this.chbSendMonitor.Text = "Send and monitor";
            this.chbSendMonitor.UseVisualStyleBackColor = true;
            this.chbSendMonitor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lsvMessage
            // 
            this.lsvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvMessage.FullRowSelect = true;
            this.lsvMessage.GridLines = true;
            this.lsvMessage.HideSelection = false;
            this.lsvMessage.Location = new System.Drawing.Point(4, 28);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(594, 308);
            this.lsvMessage.TabIndex = 37;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data";
            this.columnHeader2.Width = 334;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cycle time(ms)";
            this.columnHeader3.Width = 138;
            // 
            // ButClear
            // 
            this.ButClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButClear.Enabled = false;
            this.ButClear.Location = new System.Drawing.Point(9, 345);
            this.ButClear.Name = "ButClear";
            this.ButClear.Size = new System.Drawing.Size(75, 29);
            this.ButClear.TabIndex = 36;
            this.ButClear.Text = "Clear";
            this.ButClear.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbSystemMsg);
            this.groupBox2.Location = new System.Drawing.Point(16, 625);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 300);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Message";
            // 
            // txbSystemMsg
            // 
            this.txbSystemMsg.Location = new System.Drawing.Point(4, 25);
            this.txbSystemMsg.Multiline = true;
            this.txbSystemMsg.Name = "txbSystemMsg";
            this.txbSystemMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbSystemMsg.Size = new System.Drawing.Size(594, 269);
            this.txbSystemMsg.TabIndex = 0;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(1014, 125);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(112, 35);
            this.btnSendMsg.TabIndex = 39;
            this.btnSendMsg.Text = "send";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.send_msg_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbLog);
            this.groupBox3.Location = new System.Drawing.Point(638, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(588, 715);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(6, 25);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(576, 677);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(634, 77);
            this.txbId.MaxLength = 3;
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(79, 26);
            this.txbId.TabIndex = 41;
            this.txbId.Text = "123";
            this.txbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Send ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Send Message (Hex only)";
            // 
            // txbSendData7
            // 
            this.txbSendData7.Location = new System.Drawing.Point(949, 129);
            this.txbSendData7.MaxLength = 2;
            this.txbSendData7.Name = "txbSendData7";
            this.txbSendData7.Size = new System.Drawing.Size(39, 26);
            this.txbSendData7.TabIndex = 51;
            this.txbSendData7.Text = "00";
            this.txbSendData7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData0
            // 
            this.txbSendData0.Location = new System.Drawing.Point(634, 129);
            this.txbSendData0.MaxLength = 2;
            this.txbSendData0.Name = "txbSendData0";
            this.txbSendData0.Size = new System.Drawing.Size(39, 26);
            this.txbSendData0.TabIndex = 52;
            this.txbSendData0.Text = "00";
            this.txbSendData0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData6
            // 
            this.txbSendData6.Location = new System.Drawing.Point(904, 129);
            this.txbSendData6.MaxLength = 2;
            this.txbSendData6.Name = "txbSendData6";
            this.txbSendData6.Size = new System.Drawing.Size(39, 26);
            this.txbSendData6.TabIndex = 53;
            this.txbSendData6.Text = "00";
            this.txbSendData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData1
            // 
            this.txbSendData1.Location = new System.Drawing.Point(679, 129);
            this.txbSendData1.MaxLength = 2;
            this.txbSendData1.Name = "txbSendData1";
            this.txbSendData1.Size = new System.Drawing.Size(39, 26);
            this.txbSendData1.TabIndex = 54;
            this.txbSendData1.Text = "00";
            this.txbSendData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData5
            // 
            this.txbSendData5.Location = new System.Drawing.Point(859, 129);
            this.txbSendData5.MaxLength = 2;
            this.txbSendData5.Name = "txbSendData5";
            this.txbSendData5.Size = new System.Drawing.Size(39, 26);
            this.txbSendData5.TabIndex = 55;
            this.txbSendData5.Text = "00";
            this.txbSendData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData2
            // 
            this.txbSendData2.Location = new System.Drawing.Point(724, 129);
            this.txbSendData2.MaxLength = 2;
            this.txbSendData2.Name = "txbSendData2";
            this.txbSendData2.Size = new System.Drawing.Size(39, 26);
            this.txbSendData2.TabIndex = 56;
            this.txbSendData2.Text = "00";
            this.txbSendData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData4
            // 
            this.txbSendData4.Location = new System.Drawing.Point(814, 129);
            this.txbSendData4.MaxLength = 2;
            this.txbSendData4.Name = "txbSendData4";
            this.txbSendData4.Size = new System.Drawing.Size(39, 26);
            this.txbSendData4.TabIndex = 57;
            this.txbSendData4.Text = "00";
            this.txbSendData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSendData3
            // 
            this.txbSendData3.Location = new System.Drawing.Point(769, 129);
            this.txbSendData3.MaxLength = 2;
            this.txbSendData3.Name = "txbSendData3";
            this.txbSendData3.Size = new System.Drawing.Size(39, 26);
            this.txbSendData3.TabIndex = 58;
            this.txbSendData3.Text = "00";
            this.txbSendData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbEnableAutoFill
            // 
            this.chbEnableAutoFill.AutoSize = true;
            this.chbEnableAutoFill.Location = new System.Drawing.Point(739, 77);
            this.chbEnableAutoFill.Name = "chbEnableAutoFill";
            this.chbEnableAutoFill.Size = new System.Drawing.Size(146, 24);
            this.chbEnableAutoFill.TabIndex = 60;
            this.chbEnableAutoFill.Text = "Enable Auto Fill";
            this.chbEnableAutoFill.UseVisualStyleBackColor = true;
            this.chbEnableAutoFill.CheckedChanged += new System.EventHandler(this.chbEnableAutoFill_CheckedChanged);
            // 
            // btnShowResponseData
            // 
            this.btnShowResponseData.Location = new System.Drawing.Point(1029, 882);
            this.btnShowResponseData.Name = "btnShowResponseData";
            this.btnShowResponseData.Size = new System.Drawing.Size(197, 37);
            this.btnShowResponseData.TabIndex = 61;
            this.btnShowResponseData.Text = "Show Response Data";
            this.btnShowResponseData.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 934);
            this.Controls.Add(this.btnShowResponseData);
            this.Controls.Add(this.chbEnableAutoFill);
            this.Controls.Add(this.txbSendData7);
            this.Controls.Add(this.txbSendData0);
            this.Controls.Add(this.txbSendData6);
            this.Controls.Add(this.txbSendData1);
            this.Controls.Add(this.txbSendData5);
            this.Controls.Add(this.txbSendData2);
            this.Controls.Add(this.txbSendData4);
            this.Controls.Add(this.txbSendData3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblListOfDevices);
            this.Controls.Add(this.GrpInitialize);
            this.Controls.Add(this.LstDevices);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "PCAN Inteface";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GrpInitialize.ResumeLayout(false);
            this.GrpInitialize.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.GroupBox GrpInitialize;
        private System.Windows.Forms.ListBox LstBaudRate;
        private System.Windows.Forms.Button ButStartStop;
        private System.Windows.Forms.Label LblBaudRate;
        private System.Windows.Forms.ListBox LstDevices;
        private System.Windows.Forms.Label LblListOfDevices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbSystemMsg;
        private CusComponents.ListViewNF lsvMessage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox chbSendMonitor;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSendData7;
        private System.Windows.Forms.TextBox txbSendData0;
        private System.Windows.Forms.TextBox txbSendData6;
        private System.Windows.Forms.TextBox txbSendData1;
        private System.Windows.Forms.TextBox txbSendData5;
        private System.Windows.Forms.TextBox txbSendData2;
        private System.Windows.Forms.TextBox txbSendData4;
        private System.Windows.Forms.TextBox txbSendData3;
        private System.Windows.Forms.CheckBox chbEnableAutoFill;
        private System.Windows.Forms.Button btnShowResponseData;
    }
}

