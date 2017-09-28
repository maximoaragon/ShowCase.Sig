namespace ShowCase.Sig
{
    partial class frmSignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignature));
            this.SigPlusNET1 = new Topaz.SigPlusNET();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnGetSignature = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbWaiver = new System.Windows.Forms.GroupBox();
            this.cbWaive = new System.Windows.Forms.CheckBox();
            this.cbWaiverReason = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbWaiver.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SigPlusNET1
            // 
            this.SigPlusNET1.BackColor = System.Drawing.Color.White;
            this.SigPlusNET1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SigPlusNET1.ForeColor = System.Drawing.Color.Black;
            this.SigPlusNET1.Location = new System.Drawing.Point(0, 0);
            this.SigPlusNET1.Name = "SigPlusNET1";
            this.SigPlusNET1.Size = new System.Drawing.Size(284, 103);
            this.SigPlusNET1.TabIndex = 0;
            this.SigPlusNET1.Text = "SigPlusNET1";
            this.SigPlusNET1.PenUp += new System.EventHandler(this.SigPlusNET1_PenUp);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInfo.Location = new System.Drawing.Point(12, 26);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(95, 13);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "Signee ... Hello";
            // 
            // btnGetSignature
            // 
            this.btnGetSignature.Location = new System.Drawing.Point(199, 26);
            this.btnGetSignature.Name = "btnGetSignature";
            this.btnGetSignature.Size = new System.Drawing.Size(97, 32);
            this.btnGetSignature.TabIndex = 8;
            this.btnGetSignature.Text = "Get Signature";
            this.btnGetSignature.UseVisualStyleBackColor = true;
            this.btnGetSignature.Click += new System.EventHandler(this.btnGetSignature_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.SigPlusNET1);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 103);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(77, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 53);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gbWaiver
            // 
            this.gbWaiver.Controls.Add(this.cbWaive);
            this.gbWaiver.Controls.Add(this.cbWaiverReason);
            this.gbWaiver.Location = new System.Drawing.Point(12, 180);
            this.gbWaiver.Name = "gbWaiver";
            this.gbWaiver.Size = new System.Drawing.Size(284, 44);
            this.gbWaiver.TabIndex = 11;
            this.gbWaiver.TabStop = false;
            this.gbWaiver.Text = "Waive";
            // 
            // cbWaive
            // 
            this.cbWaive.AutoSize = true;
            this.cbWaive.Location = new System.Drawing.Point(23, 19);
            this.cbWaive.Name = "cbWaive";
            this.cbWaive.Size = new System.Drawing.Size(15, 14);
            this.cbWaive.TabIndex = 1;
            this.cbWaive.UseVisualStyleBackColor = true;
            // 
            // cbWaiverReason
            // 
            this.cbWaiverReason.FormattingEnabled = true;
            this.cbWaiverReason.Location = new System.Drawing.Point(44, 14);
            this.cbWaiverReason.Name = "cbWaiverReason";
            this.cbWaiverReason.Size = new System.Drawing.Size(219, 21);
            this.cbWaiverReason.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(45, 230);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(97, 32);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipShown += new System.EventHandler(this.notifyIcon1_BalloonTipShown);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem1.Text = "Restore";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem2.Text = "Exit";
            // 
            // frmSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 266);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.gbWaiver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnGetSignature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSignature";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signature";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSignature_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSignature_FormClosed);
            this.Load += new System.EventHandler(this.frmSignature_Load);
            this.ResizeBegin += new System.EventHandler(this.frmSignature_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.frmSignature_ResizeEnd);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbWaiver.ResumeLayout(false);
            this.gbWaiver.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Topaz.SigPlusNET SigPlusNET1;
        internal System.Windows.Forms.Label lblInfo;
        internal System.Windows.Forms.Button btnGetSignature;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbWaiver;
        private System.Windows.Forms.CheckBox cbWaive;
        private System.Windows.Forms.ComboBox cbWaiverReason;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

