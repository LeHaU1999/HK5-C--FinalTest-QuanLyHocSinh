namespace HK5_LTHDT_BaoCaoDeTao
{
    partial class MainForm
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
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLHS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLMH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEXIT = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mnuQLTK = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQLHS,
            this.mnuQLDiem,
            this.mnuQLMH,
            this.mnuEXIT});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuQLTK});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(86, 24);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(216, 26);
            this.mnuDangXuat.Text = "Đăng Xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuQLHS
            // 
            this.mnuQLHS.Name = "mnuQLHS";
            this.mnuQLHS.Size = new System.Drawing.Size(134, 24);
            this.mnuQLHS.Text = "Quản Lí Học Sinh";
            this.mnuQLHS.Click += new System.EventHandler(this.mnuQLHS_Click);
            // 
            // mnuQLDiem
            // 
            this.mnuQLDiem.Name = "mnuQLDiem";
            this.mnuQLDiem.Size = new System.Drawing.Size(111, 24);
            this.mnuQLDiem.Text = "Quản Lí Điểm";
            this.mnuQLDiem.Click += new System.EventHandler(this.mnuQLDiem_Click);
            // 
            // mnuQLMH
            // 
            this.mnuQLMH.Name = "mnuQLMH";
            this.mnuQLMH.Size = new System.Drawing.Size(136, 24);
            this.mnuQLMH.Text = "Quản Lí Môn Học";
            this.mnuQLMH.Click += new System.EventHandler(this.mnuQLMH_Click);
            // 
            // mnuEXIT
            // 
            this.mnuEXIT.Name = "mnuEXIT";
            this.mnuEXIT.Size = new System.Drawing.Size(59, 24);
            this.mnuEXIT.Text = "Thoát";
            this.mnuEXIT.Click += new System.EventHandler(this.mnuEXIT_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HK5_LTHDT_BaoCaoDeTao.Properties.Resources.LogoESGD;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(13, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 434);
            this.panel1.TabIndex = 1;
            // 
            // mnuQLTK
            // 
            this.mnuQLTK.Name = "mnuQLTK";
            this.mnuQLTK.Size = new System.Drawing.Size(216, 26);
            this.mnuQLTK.Text = "Quản Lí Tài Khoản";
            this.mnuQLTK.Click += new System.EventHandler(this.mnuQLTK_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuQLHS;
        private System.Windows.Forms.ToolStripMenuItem mnuQLDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuQLMH;
        private System.Windows.Forms.ToolStripMenuItem mnuEXIT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuQLTK;
    }
}

