namespace HK5_LTHDT_BaoCaoDeTao
{
    partial class frmQLMonHoc
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
            this.grbMonHoc = new System.Windows.Forms.GroupBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.btnXemMonHoc = new System.Windows.Forms.Button();
            this.btnThemMonHoc = new System.Windows.Forms.Button();
            this.btnLuuMonHoc = new System.Windows.Forms.Button();
            this.btnXoaMonHoc = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKhiem = new System.Windows.Forms.TextBox();
            this.dgvDanhSachMonHoc = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboChonMon = new System.Windows.Forms.ComboBox();
            this.btnCLOSE = new System.Windows.Forms.Button();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbMonHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMonHoc
            // 
            this.grbMonHoc.Controls.Add(this.btnCLOSE);
            this.grbMonHoc.Controls.Add(this.cboChonMon);
            this.grbMonHoc.Controls.Add(this.label1);
            this.grbMonHoc.Controls.Add(this.txtTimKhiem);
            this.grbMonHoc.Controls.Add(this.lblTimKiem);
            this.grbMonHoc.Controls.Add(this.btnXoaMonHoc);
            this.grbMonHoc.Controls.Add(this.txtTenMon);
            this.grbMonHoc.Controls.Add(this.btnLuuMonHoc);
            this.grbMonHoc.Controls.Add(this.txtMaMon);
            this.grbMonHoc.Controls.Add(this.btnThemMonHoc);
            this.grbMonHoc.Controls.Add(this.lblMaMon);
            this.grbMonHoc.Controls.Add(this.btnXemMonHoc);
            this.grbMonHoc.Controls.Add(this.lblTenMon);
            this.grbMonHoc.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMonHoc.Location = new System.Drawing.Point(13, 13);
            this.grbMonHoc.Name = "grbMonHoc";
            this.grbMonHoc.Size = new System.Drawing.Size(555, 271);
            this.grbMonHoc.TabIndex = 0;
            this.grbMonHoc.TabStop = false;
            this.grbMonHoc.Text = "Thông Tin Môn Học";
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(21, 120);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(82, 22);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Text = "Tên Môn:";
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Location = new System.Drawing.Point(21, 73);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(78, 22);
            this.lblMaMon.TabIndex = 1;
            this.lblMaMon.Text = "Mã Môn:";
            // 
            // txtMaMon
            // 
            this.txtMaMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaMon.Enabled = false;
            this.txtMaMon.Location = new System.Drawing.Point(118, 73);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(121, 29);
            this.txtMaMon.TabIndex = 2;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(118, 120);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(213, 29);
            this.txtTenMon.TabIndex = 3;
            // 
            // btnXemMonHoc
            // 
            this.btnXemMonHoc.Location = new System.Drawing.Point(24, 215);
            this.btnXemMonHoc.Name = "btnXemMonHoc";
            this.btnXemMonHoc.Size = new System.Drawing.Size(194, 35);
            this.btnXemMonHoc.TabIndex = 1;
            this.btnXemMonHoc.Text = "Xem Môn Học";
            this.btnXemMonHoc.UseVisualStyleBackColor = true;
            this.btnXemMonHoc.Click += new System.EventHandler(this.btnXemMonHoc_Click);
            // 
            // btnThemMonHoc
            // 
            this.btnThemMonHoc.Location = new System.Drawing.Point(386, 34);
            this.btnThemMonHoc.Name = "btnThemMonHoc";
            this.btnThemMonHoc.Size = new System.Drawing.Size(129, 34);
            this.btnThemMonHoc.TabIndex = 2;
            this.btnThemMonHoc.Text = "Thêm";
            this.btnThemMonHoc.UseVisualStyleBackColor = true;
            this.btnThemMonHoc.Click += new System.EventHandler(this.btnThemMonHoc_Click);
            // 
            // btnLuuMonHoc
            // 
            this.btnLuuMonHoc.Location = new System.Drawing.Point(386, 104);
            this.btnLuuMonHoc.Name = "btnLuuMonHoc";
            this.btnLuuMonHoc.Size = new System.Drawing.Size(129, 33);
            this.btnLuuMonHoc.TabIndex = 3;
            this.btnLuuMonHoc.Text = "Lưu";
            this.btnLuuMonHoc.UseVisualStyleBackColor = true;
            this.btnLuuMonHoc.Click += new System.EventHandler(this.btnLuuMonHoc_Click);
            // 
            // btnXoaMonHoc
            // 
            this.btnXoaMonHoc.Location = new System.Drawing.Point(386, 168);
            this.btnXoaMonHoc.Name = "btnXoaMonHoc";
            this.btnXoaMonHoc.Size = new System.Drawing.Size(129, 35);
            this.btnXoaMonHoc.TabIndex = 4;
            this.btnXoaMonHoc.Text = "Xóa";
            this.btnXoaMonHoc.UseVisualStyleBackColor = true;
            this.btnXoaMonHoc.Click += new System.EventHandler(this.btnXoaMonHoc_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(21, 173);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(86, 22);
            this.lblTimKiem.TabIndex = 5;
            this.lblTimKiem.Text = "Tìm Kiếm:";
            // 
            // txtTimKhiem
            // 
            this.txtTimKhiem.Location = new System.Drawing.Point(118, 168);
            this.txtTimKhiem.Name = "txtTimKhiem";
            this.txtTimKhiem.Size = new System.Drawing.Size(213, 29);
            this.txtTimKhiem.TabIndex = 6;
            this.txtTimKhiem.TextChanged += new System.EventHandler(this.txtTimKhiem_TextChanged);
            // 
            // dgvDanhSachMonHoc
            // 
            this.dgvDanhSachMonHoc.AllowUserToAddRows = false;
            this.dgvDanhSachMonHoc.AllowUserToDeleteRows = false;
            this.dgvDanhSachMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMon,
            this.TenMon});
            this.dgvDanhSachMonHoc.Location = new System.Drawing.Point(13, 326);
            this.dgvDanhSachMonHoc.Name = "dgvDanhSachMonHoc";
            this.dgvDanhSachMonHoc.ReadOnly = true;
            this.dgvDanhSachMonHoc.RowTemplate.Height = 24;
            this.dgvDanhSachMonHoc.Size = new System.Drawing.Size(555, 191);
            this.dgvDanhSachMonHoc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn Môn:";
            // 
            // cboChonMon
            // 
            this.cboChonMon.FormattingEnabled = true;
            this.cboChonMon.Location = new System.Drawing.Point(118, 31);
            this.cboChonMon.Name = "cboChonMon";
            this.cboChonMon.Size = new System.Drawing.Size(121, 30);
            this.cboChonMon.TabIndex = 8;
            // 
            // btnCLOSE
            // 
            this.btnCLOSE.Location = new System.Drawing.Point(386, 226);
            this.btnCLOSE.Name = "btnCLOSE";
            this.btnCLOSE.Size = new System.Drawing.Size(129, 39);
            this.btnCLOSE.TabIndex = 9;
            this.btnCLOSE.Text = "CLOSE";
            this.btnCLOSE.UseVisualStyleBackColor = true;
            this.btnCLOSE.Click += new System.EventHandler(this.btnCLOSE_Click);
            // 
            // MaMon
            // 
            this.MaMon.DataPropertyName = "MaMon";
            this.MaMon.HeaderText = "Mã Môn";
            this.MaMon.MinimumWidth = 100;
            this.MaMon.Name = "MaMon";
            this.MaMon.ReadOnly = true;
            this.MaMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TenMon
            // 
            this.TenMon.DataPropertyName = "TenMon";
            this.TenMon.HeaderText = "Tên Môn";
            this.TenMon.MinimumWidth = 200;
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            this.TenMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenMon.Width = 200;
            // 
            // frmQLMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 534);
            this.Controls.Add(this.dgvDanhSachMonHoc);
            this.Controls.Add(this.grbMonHoc);
            this.Name = "frmQLMonHoc";
            this.Text = "Quản Lí Môn Học";
            this.Load += new System.EventHandler(this.frmQLMonHoc_Load);
            this.grbMonHoc.ResumeLayout(false);
            this.grbMonHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMonHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMonHoc;
        private System.Windows.Forms.TextBox txtTimKhiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Button btnXoaMonHoc;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Button btnLuuMonHoc;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Button btnThemMonHoc;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.Button btnXemMonHoc;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.DataGridView dgvDanhSachMonHoc;
        private System.Windows.Forms.ComboBox cboChonMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCLOSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
    }
}