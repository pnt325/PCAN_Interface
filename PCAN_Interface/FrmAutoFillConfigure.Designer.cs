namespace PCAN_Interface
{
    partial class FrmAutoFillConfigure
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
            this.lsvData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbResId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbSendID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbRes0 = new System.Windows.Forms.TextBox();
            this.chbData0 = new System.Windows.Forms.CheckBox();
            this.txbRes1 = new System.Windows.Forms.TextBox();
            this.chbData1 = new System.Windows.Forms.CheckBox();
            this.txbRes2 = new System.Windows.Forms.TextBox();
            this.chbData2 = new System.Windows.Forms.CheckBox();
            this.txbRes3 = new System.Windows.Forms.TextBox();
            this.chbData3 = new System.Windows.Forms.CheckBox();
            this.txbRes4 = new System.Windows.Forms.TextBox();
            this.txbRes5 = new System.Windows.Forms.TextBox();
            this.txbRes6 = new System.Windows.Forms.TextBox();
            this.txbRes7 = new System.Windows.Forms.TextBox();
            this.chbData4 = new System.Windows.Forms.CheckBox();
            this.chbData5 = new System.Windows.Forms.CheckBox();
            this.chbData6 = new System.Windows.Forms.CheckBox();
            this.chbData7 = new System.Windows.Forms.CheckBox();
            this.txbSend0 = new System.Windows.Forms.TextBox();
            this.txbSend4 = new System.Windows.Forms.TextBox();
            this.txbSend1 = new System.Windows.Forms.TextBox();
            this.txbSend5 = new System.Windows.Forms.TextBox();
            this.txbSend2 = new System.Windows.Forms.TextBox();
            this.txbSend6 = new System.Windows.Forms.TextBox();
            this.txbSend3 = new System.Windows.Forms.TextBox();
            this.txbSend7 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemoveSel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvData
            // 
            this.lsvData.CheckBoxes = true;
            this.lsvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvData.FullRowSelect = true;
            this.lsvData.GridLines = true;
            this.lsvData.HideSelection = false;
            this.lsvData.Location = new System.Drawing.Point(13, 12);
            this.lsvData.Name = "lsvData";
            this.lsvData.Size = new System.Drawing.Size(646, 251);
            this.lsvData.TabIndex = 0;
            this.lsvData.UseCompatibleStateImageBehavior = false;
            this.lsvData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Response ID";
            this.columnHeader1.Width = 151;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Send ID";
            this.columnHeader3.Width = 131;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Send Data";
            this.columnHeader4.Width = 339;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Respone ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Send ID";
            // 
            // txbResId
            // 
            this.txbResId.Location = new System.Drawing.Point(109, 301);
            this.txbResId.MaxLength = 3;
            this.txbResId.Name = "txbResId";
            this.txbResId.Size = new System.Drawing.Size(62, 26);
            this.txbResId.TabIndex = 2;
            this.txbResId.Text = "000";
            this.txbResId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Respone Data";
            // 
            // txbSendID
            // 
            this.txbSendID.Location = new System.Drawing.Point(109, 337);
            this.txbSendID.MaxLength = 3;
            this.txbSendID.Name = "txbSendID";
            this.txbSendID.Size = new System.Drawing.Size(62, 26);
            this.txbSendID.TabIndex = 2;
            this.txbSendID.Text = "000";
            this.txbSendID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Send Data";
            // 
            // txbRes0
            // 
            this.txbRes0.Enabled = false;
            this.txbRes0.Location = new System.Drawing.Point(296, 301);
            this.txbRes0.MaxLength = 2;
            this.txbRes0.Name = "txbRes0";
            this.txbRes0.Size = new System.Drawing.Size(40, 26);
            this.txbRes0.TabIndex = 2;
            this.txbRes0.Text = "00";
            this.txbRes0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbData0
            // 
            this.chbData0.AutoSize = true;
            this.chbData0.Location = new System.Drawing.Point(305, 274);
            this.chbData0.Name = "chbData0";
            this.chbData0.Size = new System.Drawing.Size(22, 21);
            this.chbData0.TabIndex = 3;
            this.chbData0.UseVisualStyleBackColor = true;
            // 
            // txbRes1
            // 
            this.txbRes1.Enabled = false;
            this.txbRes1.Location = new System.Drawing.Point(342, 301);
            this.txbRes1.MaxLength = 2;
            this.txbRes1.Name = "txbRes1";
            this.txbRes1.Size = new System.Drawing.Size(40, 26);
            this.txbRes1.TabIndex = 2;
            this.txbRes1.Text = "00";
            this.txbRes1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbData1
            // 
            this.chbData1.AutoSize = true;
            this.chbData1.Location = new System.Drawing.Point(351, 274);
            this.chbData1.Name = "chbData1";
            this.chbData1.Size = new System.Drawing.Size(22, 21);
            this.chbData1.TabIndex = 3;
            this.chbData1.UseVisualStyleBackColor = true;
            // 
            // txbRes2
            // 
            this.txbRes2.Enabled = false;
            this.txbRes2.Location = new System.Drawing.Point(388, 301);
            this.txbRes2.MaxLength = 2;
            this.txbRes2.Name = "txbRes2";
            this.txbRes2.Size = new System.Drawing.Size(40, 26);
            this.txbRes2.TabIndex = 2;
            this.txbRes2.Text = "00";
            this.txbRes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbData2
            // 
            this.chbData2.AutoSize = true;
            this.chbData2.Location = new System.Drawing.Point(397, 274);
            this.chbData2.Name = "chbData2";
            this.chbData2.Size = new System.Drawing.Size(22, 21);
            this.chbData2.TabIndex = 3;
            this.chbData2.UseVisualStyleBackColor = true;
            // 
            // txbRes3
            // 
            this.txbRes3.Enabled = false;
            this.txbRes3.Location = new System.Drawing.Point(434, 301);
            this.txbRes3.MaxLength = 2;
            this.txbRes3.Name = "txbRes3";
            this.txbRes3.Size = new System.Drawing.Size(40, 26);
            this.txbRes3.TabIndex = 2;
            this.txbRes3.Text = "00";
            this.txbRes3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbData3
            // 
            this.chbData3.AutoSize = true;
            this.chbData3.Location = new System.Drawing.Point(443, 274);
            this.chbData3.Name = "chbData3";
            this.chbData3.Size = new System.Drawing.Size(22, 21);
            this.chbData3.TabIndex = 3;
            this.chbData3.UseVisualStyleBackColor = true;
            // 
            // txbRes4
            // 
            this.txbRes4.Enabled = false;
            this.txbRes4.Location = new System.Drawing.Point(480, 301);
            this.txbRes4.MaxLength = 2;
            this.txbRes4.Name = "txbRes4";
            this.txbRes4.Size = new System.Drawing.Size(40, 26);
            this.txbRes4.TabIndex = 2;
            this.txbRes4.Text = "00";
            this.txbRes4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbRes5
            // 
            this.txbRes5.Enabled = false;
            this.txbRes5.Location = new System.Drawing.Point(526, 301);
            this.txbRes5.MaxLength = 2;
            this.txbRes5.Name = "txbRes5";
            this.txbRes5.Size = new System.Drawing.Size(40, 26);
            this.txbRes5.TabIndex = 2;
            this.txbRes5.Text = "00";
            this.txbRes5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbRes6
            // 
            this.txbRes6.Enabled = false;
            this.txbRes6.Location = new System.Drawing.Point(572, 301);
            this.txbRes6.MaxLength = 2;
            this.txbRes6.Name = "txbRes6";
            this.txbRes6.Size = new System.Drawing.Size(40, 26);
            this.txbRes6.TabIndex = 2;
            this.txbRes6.Text = "00";
            this.txbRes6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbRes7
            // 
            this.txbRes7.Enabled = false;
            this.txbRes7.Location = new System.Drawing.Point(618, 301);
            this.txbRes7.MaxLength = 2;
            this.txbRes7.Name = "txbRes7";
            this.txbRes7.Size = new System.Drawing.Size(40, 26);
            this.txbRes7.TabIndex = 2;
            this.txbRes7.Text = "00";
            this.txbRes7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbData4
            // 
            this.chbData4.AutoSize = true;
            this.chbData4.Location = new System.Drawing.Point(489, 274);
            this.chbData4.Name = "chbData4";
            this.chbData4.Size = new System.Drawing.Size(22, 21);
            this.chbData4.TabIndex = 3;
            this.chbData4.UseVisualStyleBackColor = true;
            // 
            // chbData5
            // 
            this.chbData5.AutoSize = true;
            this.chbData5.Location = new System.Drawing.Point(535, 274);
            this.chbData5.Name = "chbData5";
            this.chbData5.Size = new System.Drawing.Size(22, 21);
            this.chbData5.TabIndex = 3;
            this.chbData5.UseVisualStyleBackColor = true;
            // 
            // chbData6
            // 
            this.chbData6.AutoSize = true;
            this.chbData6.Location = new System.Drawing.Point(581, 274);
            this.chbData6.Name = "chbData6";
            this.chbData6.Size = new System.Drawing.Size(22, 21);
            this.chbData6.TabIndex = 3;
            this.chbData6.UseVisualStyleBackColor = true;
            // 
            // chbData7
            // 
            this.chbData7.AutoSize = true;
            this.chbData7.Location = new System.Drawing.Point(627, 274);
            this.chbData7.Name = "chbData7";
            this.chbData7.Size = new System.Drawing.Size(22, 21);
            this.chbData7.TabIndex = 3;
            this.chbData7.UseVisualStyleBackColor = true;
            // 
            // txbSend0
            // 
            this.txbSend0.Location = new System.Drawing.Point(296, 333);
            this.txbSend0.MaxLength = 2;
            this.txbSend0.Name = "txbSend0";
            this.txbSend0.Size = new System.Drawing.Size(40, 26);
            this.txbSend0.TabIndex = 2;
            this.txbSend0.Text = "00";
            this.txbSend0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend4
            // 
            this.txbSend4.Location = new System.Drawing.Point(480, 333);
            this.txbSend4.MaxLength = 2;
            this.txbSend4.Name = "txbSend4";
            this.txbSend4.Size = new System.Drawing.Size(40, 26);
            this.txbSend4.TabIndex = 2;
            this.txbSend4.Text = "00";
            this.txbSend4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend1
            // 
            this.txbSend1.Location = new System.Drawing.Point(342, 333);
            this.txbSend1.MaxLength = 2;
            this.txbSend1.Name = "txbSend1";
            this.txbSend1.Size = new System.Drawing.Size(40, 26);
            this.txbSend1.TabIndex = 2;
            this.txbSend1.Text = "00";
            this.txbSend1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend5
            // 
            this.txbSend5.Location = new System.Drawing.Point(526, 333);
            this.txbSend5.MaxLength = 2;
            this.txbSend5.Name = "txbSend5";
            this.txbSend5.Size = new System.Drawing.Size(40, 26);
            this.txbSend5.TabIndex = 2;
            this.txbSend5.Text = "00";
            this.txbSend5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend2
            // 
            this.txbSend2.Location = new System.Drawing.Point(388, 333);
            this.txbSend2.MaxLength = 2;
            this.txbSend2.Name = "txbSend2";
            this.txbSend2.Size = new System.Drawing.Size(40, 26);
            this.txbSend2.TabIndex = 2;
            this.txbSend2.Text = "00";
            this.txbSend2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend6
            // 
            this.txbSend6.Location = new System.Drawing.Point(572, 333);
            this.txbSend6.MaxLength = 2;
            this.txbSend6.Name = "txbSend6";
            this.txbSend6.Size = new System.Drawing.Size(40, 26);
            this.txbSend6.TabIndex = 2;
            this.txbSend6.Text = "00";
            this.txbSend6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend3
            // 
            this.txbSend3.Location = new System.Drawing.Point(434, 333);
            this.txbSend3.MaxLength = 2;
            this.txbSend3.Name = "txbSend3";
            this.txbSend3.Size = new System.Drawing.Size(40, 26);
            this.txbSend3.TabIndex = 2;
            this.txbSend3.Text = "00";
            this.txbSend3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSend7
            // 
            this.txbSend7.Location = new System.Drawing.Point(618, 333);
            this.txbSend7.MaxLength = 2;
            this.txbSend7.Name = "txbSend7";
            this.txbSend7.Size = new System.Drawing.Size(40, 26);
            this.txbSend7.TabIndex = 2;
            this.txbSend7.Text = "00";
            this.txbSend7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(570, 381);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemove.Location = new System.Drawing.Point(476, 381);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(88, 30);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(382, 381);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 30);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSel
            // 
            this.btnRemoveSel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveSel.Location = new System.Drawing.Point(12, 381);
            this.btnRemoveSel.Name = "btnRemoveSel";
            this.btnRemoveSel.Size = new System.Drawing.Size(171, 30);
            this.btnRemoveSel.TabIndex = 4;
            this.btnRemoveSel.Text = "Remove Selected";
            this.btnRemoveSel.UseVisualStyleBackColor = true;
            // 
            // FrmAutoFillConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 423);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRemoveSel);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chbData7);
            this.Controls.Add(this.chbData3);
            this.Controls.Add(this.chbData6);
            this.Controls.Add(this.chbData2);
            this.Controls.Add(this.chbData5);
            this.Controls.Add(this.chbData1);
            this.Controls.Add(this.chbData4);
            this.Controls.Add(this.chbData0);
            this.Controls.Add(this.txbSendID);
            this.Controls.Add(this.txbSend7);
            this.Controls.Add(this.txbRes7);
            this.Controls.Add(this.txbSend3);
            this.Controls.Add(this.txbRes3);
            this.Controls.Add(this.txbSend6);
            this.Controls.Add(this.txbRes6);
            this.Controls.Add(this.txbSend2);
            this.Controls.Add(this.txbRes2);
            this.Controls.Add(this.txbSend5);
            this.Controls.Add(this.txbRes5);
            this.Controls.Add(this.txbSend1);
            this.Controls.Add(this.txbRes1);
            this.Controls.Add(this.txbSend4);
            this.Controls.Add(this.txbRes4);
            this.Controls.Add(this.txbSend0);
            this.Controls.Add(this.txbRes0);
            this.Controls.Add(this.txbResId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvData);
            this.Name = "FrmAutoFillConfigure";
            this.Text = "Auto fill configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbResId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbSendID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbRes0;
        private System.Windows.Forms.CheckBox chbData0;
        private System.Windows.Forms.TextBox txbRes1;
        private System.Windows.Forms.CheckBox chbData1;
        private System.Windows.Forms.TextBox txbRes2;
        private System.Windows.Forms.CheckBox chbData2;
        private System.Windows.Forms.TextBox txbRes3;
        private System.Windows.Forms.CheckBox chbData3;
        private System.Windows.Forms.TextBox txbRes4;
        private System.Windows.Forms.TextBox txbRes5;
        private System.Windows.Forms.TextBox txbRes6;
        private System.Windows.Forms.TextBox txbRes7;
        private System.Windows.Forms.CheckBox chbData4;
        private System.Windows.Forms.CheckBox chbData5;
        private System.Windows.Forms.CheckBox chbData6;
        private System.Windows.Forms.CheckBox chbData7;
        private System.Windows.Forms.TextBox txbSend0;
        private System.Windows.Forms.TextBox txbSend4;
        private System.Windows.Forms.TextBox txbSend1;
        private System.Windows.Forms.TextBox txbSend5;
        private System.Windows.Forms.TextBox txbSend2;
        private System.Windows.Forms.TextBox txbSend6;
        private System.Windows.Forms.TextBox txbSend3;
        private System.Windows.Forms.TextBox txbSend7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemoveSel;
    }
}