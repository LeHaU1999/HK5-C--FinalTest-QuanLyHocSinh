namespace HK5_LTHDT_BaoCaoDeTao
{
    partial class QuanLiTK
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
            this.grbTaiKhoan = new System.Windows.Forms.GroupBox();
            this.txtQuyen = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnLuuLai = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTaiKhoan
            // 
            this.grbTaiKhoan.Controls.Add(this.txtQuyen);
            this.grbTaiKhoan.Controls.Add(this.txtMK);
            this.grbTaiKhoan.Controls.Add(this.txtTK);
            this.grbTaiKhoan.Controls.Add(this.label3);
            this.grbTaiKhoan.Controls.Add(this.label2);
            this.grbTaiKhoan.Controls.Add(this.label1);
            this.grbTaiKhoan.Location = new System.Drawing.Point(13, 13);
            this.grbTaiKhoan.Name = "grbTaiKhoan";
            this.grbTaiKhoan.Size = new System.Drawing.Size(346, 191);
            this.grbTaiKhoan.TabIndex = 0;
            this.grbTaiKhoan.TabStop = false;
            this.grbTaiKhoan.Text = "Thông Tin Tài Khoản";
            // 
            // txtQuyen
            // 
            this.txtQuyen.Location = new System.Drawing.Point(107, 129);
            this.txtQuyen.Name = "txtQuyen";
            this.txtQuyen.Size = new System.Drawing.Size(145, 22);
            this.txtQuyen.TabIndex = 5;
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(107, 82);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(145, 22);
            this.txtMK.TabIndex = 4;
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(107, 39);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(145, 22);
            this.txtTK.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quyền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản:";
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaiKhoan,
            this.MatKhat,
            this.Quyen});
            this.dgvTaiKhoan.Location = new System.Drawing.Point(423, 12);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(510, 326);
            this.dgvTaiKhoan.TabIndex = 1;
            this.dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellContentClick);
            // 
            // btnThemTK
            // 
            this.btnThemTK.Location = new System.Drawing.Point(15, 219);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(135, 32);
            this.btnThemTK.TabIndex = 2;
            this.btnThemTK.Text = "Thêm Tài Khoản";
            this.btnThemTK.UseVisualStyleBackColor = true;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Location = new System.Drawing.Point(267, 220);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(92, 31);
            this.btnXoaTK.TabIndex = 4;
            this.btnXoaTK.Text = "Xóa";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Location = new System.Drawing.Point(167, 220);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(83, 31);
            this.btnLuuLai.TabIndex = 7;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(102, 274);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 39);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DataPropertyName = "TaiKhoan";
            this.TaiKhoan.HeaderText = "Tài Khoản";
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.ReadOnly = true;
            this.TaiKhoan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MatKhat
            // 
            this.MatKhat.DataPropertyName = "MatKhat";
            this.MatKhat.HeaderText = "Mật Khẩu";
            this.MatKhat.Name = "MatKhat";
            this.MatKhat.ReadOnly = true;
            this.MatKhat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Quyen
            // 
            this.Quyen.DataPropertyName = "Quyen";
            this.Quyen.HeaderText = "Quyền";
            this.Quyen.Name = "Quyen";
            this.Quyen.ReadOnly = true;
            this.Quyen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QuanLiTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 350);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLuuLai);
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.btnThemTK);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.grbTaiKhoan);
            this.Name = "QuanLiTK";
            this.Text = "QuanLiTK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLiTK_FormClosing);
            this.Load += new System.EventHandler(this.QuanLiTK_Load);
            this.grbTaiKhoan.ResumeLayout(false);
            this.grbTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTaiKhoan;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.TextBox txtQuyen;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Button btnLuuLai;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quyen;
    }
}