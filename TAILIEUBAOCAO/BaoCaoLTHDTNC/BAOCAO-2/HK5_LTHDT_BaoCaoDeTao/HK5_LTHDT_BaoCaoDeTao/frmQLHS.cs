using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HK5_LTHDT_BaoCaoDeTao
{
    public partial class frmQLHS : Form
    {
        public frmQLHS()
        {
            InitializeComponent();
        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }

        //Ket Noi CSDL
        KetNoiCSDL_BaoCaoDeTaiDataContext dt = new KetNoiCSDL_BaoCaoDeTaiDataContext();

        //Dong Form
        private void btnCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Dua du lieu 'NIEN KHOA' vào cbChonNK, txtMaNK, txtTenNk
        private void frmQLHS_Load(object sender, EventArgs e)
        {
            cbChonNK.DataSource = dt.NienKhoa_SelectAll();
            cbChonNK.DisplayMember = "TenNK"; 
            cbChonNK.ValueMember = "MaNK";
            txtMaNK.DataBindings.Clear();
            txtMaNK.DataBindings.Add("text", cbChonNK.DataSource, "MaNK");
            txtTenNK.DataBindings.Clear();
            txtTenNK.DataBindings.Add("text", cbChonNK.DataSource, "TenNK");

        }

        //Dua du lien 'KHOI' vào cbChonKhoi, txtMaKhoi, txtTenKhoi
        private void cbChonNK_SelectedIndexChanged(object sender, EventArgs e)
        { 
           cbChonKhoi.DisplayMember = "TenKhoi";
           cbChonKhoi.ValueMember = "MaKhoi";
           cbChonKhoi.DataSource = dt.khoi_SelectAll();
           txtMaKhoi.DataBindings.Clear();
           txtMaKhoi.DataBindings.Add("text", cbChonKhoi.DataSource, "MaKhoi");
           txtTenKhoi.DataBindings.Clear();
           txtTenKhoi.DataBindings.Add("text", cbChonKhoi.DataSource, "TenKhoi");
           cbChonLop.Text = "";
           
        }

        //Dua du lieu 'LOP' vao cbChonLop, txtMaLop, txtTenLop
        private void cbChonKhoi_SelectedIndexChanged(object sender, EventArgs e) 
        {
            cbChonLop.ValueMember = "MaLop";
            cbChonLop.DisplayMember = "TenLop";
            cbChonLop.DataSource = dt.Lop_SelectMaNK_MaKhoi(cbChonNK.SelectedValue.ToString(),cbChonKhoi.SelectedValue.ToString());
            txtMaLop.DataBindings.Clear();
            txtMaLop.DataBindings.Add("Text", cbChonLop.DataSource, "MaLop");
            txtTenLop.DataBindings.Clear();
            txtTenLop.DataBindings.Add("Text", cbChonLop.DataSource, "TenLop");          
        }


        //Them NK
        Boolean adNK = false;
        private void btnThemNK_Click(object sender, EventArgs e)
        {
            txtMaNK.Text = "";
            txtTenNK.Text = "";
            txtMaNK.Enabled = true;
            txtMaNK.Focus();
            adNK = true;
        }
        //Luu NK
        private void btnLuuNK_Click(object sender, EventArgs e)
        {
            if(adNK)
            {
                dt.NienKhoa_InSert(txtMaNK.Text, txtTenNK.Text);
                txtMaNK.Enabled = true;
                adNK = false;
                cbChonNK_SelectedIndexChanged(sender, e);
            }
            else
            {
                dt.NienKhoa_Update(txtMaNK.Text, txtTenNK.Text);
                cbChonNK_SelectedIndexChanged(sender, e);
            }
            //frmQLHS_Load(sender, e);
            MessageBox.Show("ĐÃ LƯU THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbChonNK_SelectedIndexChanged(sender, e);
        }
        //Xoa NK
        private void btnXoaNK_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Lop_Delete(txtMaKhoi.Text);
                //dt.Lop_Delete(cbChonKhoi.SelectedValue.ToString());
                dt.NienKhoa_Delete(txtMaNK.Text);
                frmQLHS_Load(sender, e);
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không Xóa Được");
            }

        }


        //Them Lop
        Boolean adLop = false;
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtMaLop.Enabled = true;
            txtMaLop.Focus();
            adLop = true;
        }
        //Luu Lop
        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (adLop)
                {
                    dt.Lop_Insert(txtMaLop.Text, txtTenLop.Text, txtMaKhoi.Text, txtMaNK.Text);
                    txtMaLop.Enabled = true;
                    adLop = false;
                    cbChonKhoi_SelectedIndexChanged(sender, e);
                }
                else
                {
                    dt.Lop_Update(txtMaLop.Text, txtTenLop.Text);
                    cbChonKhoi_SelectedIndexChanged(sender, e);
                }
               
                MessageBox.Show("ĐÃ LƯU THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbChonLop_SelectedIndexChanged(sender, e);
            }
            catch
            {
                MessageBox.Show("Mã Lớp Đã Tồn Tại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Xoa Lop
        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            dt.Lop_Delete(txtMaLop.Text);
            //frmQLHS_Load(sender, e);
            MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // dua du lieu 'HOC SINH' vao datagirdview
        private void cbChonLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dgvDanhSachHS.DataSource = dt.HocSinh_SelectMaLop(txtMaLop.Text);
            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "MaHS");
            txtTenHS.DataBindings.Clear();         
            txtTenHS.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "TenHS");
            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "GioiTinh");
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text",dgvDanhSachHS.DataSource, "NgaySinh");
            txtNoiSinh.DataBindings.Clear();
            txtNoiSinh.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "NoiSinh");
            txtDanToc.DataBindings.Clear();
            txtDanToc.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "DanToc");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "SDT");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "DiaChi");
            
        }


        //Them HS
        Boolean adHS = false;
        private void btnThemHS_Click(object sender, EventArgs e)
        {
            txtMaHS.Text = "";
            txtTenHS.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtGioiTinh.Text = "";
            txtNoiSinh.Text = "";
            txtSDT.Text = "";
            txtDanToc.Text = "";
            txtMaHS.Enabled = true;
            txtMaHS.Focus();
            adHS = true;
        }
        //Luu HS
        private void btnLuuHS_Click(object sender, EventArgs e)
        {
            try
            {
                if (adHS)
                {
                    dt.HocSinh_Insert(txtMaHS.Text, txtTenHS.Text, txtMaLop.Text, txtGioiTinh.Text, txtSDT.Text, dtpNgaySinh.Value, txtNoiSinh.Text, txtDanToc.Text, txtDiaChi.Text);

                    adHS = false;
                    cbChonLop_SelectedIndexChanged(sender, e);

                }
                else
                {
                    dt.HocSinh_Update(txtMaHS.Text, txtTenHS.Text, txtGioiTinh.Text, txtSDT.Text, dtpNgaySinh.Value, txtNoiSinh.Text, txtDanToc.Text, txtDiaChi.Text);
                    //bChonLop_SelectedIndexChanged(sender, e);
                }
                //frmQLHS_Load(sender, e);
                MessageBox.Show("ĐÃ LƯU THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHS.Enabled = true;
            }
            catch
            {
                MessageBox.Show("MÃ HỌC SINH ĐÃ TỒN TẠI !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Xoa HS
        private void btnXoaHS_Click(object sender, EventArgs e)
        {
            dt.HocSinh_Delete(txtMaHS.Text);
            //dgvDanhSachHS.Refresh();
            cbChonLop_SelectedIndexChanged(sender, e);
            //frmQLHS_Load(sender, e);
            MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //tim kiem HS
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSachHS.DataSource = dt.HocSinhs.Where(x => x.TenHS.Contains(txtTimKiem.Text)).ToList();
            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "MaHS");
            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "TenHS");
            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "GioiTinh");
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "NgaySinh");
            txtNoiSinh.DataBindings.Clear();
            txtNoiSinh.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "NoiSinh");
            txtDanToc.DataBindings.Clear();
            txtDanToc.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "DanToc");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "SDT");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachHS.DataSource, "DiaChi");
        }

        //xuat bao cao bang excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            //khoi tao workbook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            app.Visible = true;

            //do du lien vao sheet
            worksheet.Cells[1, 2] = "DANH SÁCH HỌC SINH";
            worksheet.Cells[3, 2] = "Mã LỚP:  "+txtMaLop.Text;
            worksheet.Cells[4, 2] = "lỚP:     " + txtTenLop.Text;
            worksheet.Cells[5, 2] = "Mã NK:   "+ txtMaNK.Text;
            worksheet.Cells[6, 2] = "Niên Khóa: "+ txtTenNK.Text;

            
            worksheet.Cells[8, 1] = "STT";
            worksheet.Cells[8, 2] = "STT";
            worksheet.Cells[8, 3] = "Mã HS     ";
            worksheet.Cells[8, 4] = "Tên HS    ";
            worksheet.Cells[8, 5] = "MaLop";
            worksheet.Cells[8, 6] = "Giới Tinh ";
            worksheet.Cells[8, 7] = "SĐT       ";
            worksheet.Cells[8, 8] = "Ngày Sinh ";
            worksheet.Cells[8, 9] = "Nơi Sinh  ";
            worksheet.Cells[8, 10] = "Dân Tộc   ";
            worksheet.Cells[8, 11] ="Địa Chỉ";

            
            for (int i = 0; i < dgvDanhSachHS.RowCount ; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    worksheet.Cells[i + 9, 1] = i + 1;
                    worksheet.Cells[i + 9, j + 2] = dgvDanhSachHS.Rows[i].Cells[j].Value;
                }
            }
        }

        //xuat bao cao bang crysta report
        private void btnCrystal_Click(object sender, EventArgs e)
        {

            if (dgvDanhSachHS.RowCount > 0)
            {
                //String Text1 = "TB-HK1: " + lblDTB_DTBHK1.Text.ToString();
               // String Text2 = "TB-HK2: " + lblDTB_DTBHK2.Text.ToString();
                //String Text3 = "TBCN: " + lblDTBCN.Text.ToString();
                DataTable dt = new DataTable();
                dt = dgvDanhSachHS.DataSource as DataTable;
                CrystalReport5 cos = new CrystalReport5();
                cos.SetDataSource(dt);
                //cos.SetParameterValue("text1", Text1);
                //cos.SetParameterValue("text2", Text2);
                //cos.SetParameterValue("text3", Text3);
                Form1 frm = new Form1();
                frm.crystalReportViewer1.ReportSource = cos;
                frm.ShowDialog();


            }
            else
            {
                MessageBox.Show("Ko co gi ca");
            }
        }

        //dang STT cho dgv
        private void dgvDanhSachHS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvDanhSachHS.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvDanhSachHS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
