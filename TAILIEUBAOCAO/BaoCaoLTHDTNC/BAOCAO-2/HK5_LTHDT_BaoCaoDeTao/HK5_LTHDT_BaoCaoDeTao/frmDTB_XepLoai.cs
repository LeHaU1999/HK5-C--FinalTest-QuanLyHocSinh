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
    public partial class frmDTB_XepLoai : Form
    {
        public frmDTB_XepLoai()
        {
            InitializeComponent();
        }

        //Ket noi CSDL
        KetNoiCSDL_BaoCaoDeTaiDataContext dt = new KetNoiCSDL_BaoCaoDeTaiDataContext();

        //dong form
        private void btnCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //du lieu NK
        private void frmDTB_XepLoai_Load(object sender, EventArgs e)
        {
            cboChonNK.DataSource = dt.NienKhoa_SelectAll();
            cboChonNK.DisplayMember = "TenNK";
            cboChonNK.ValueMember = "MaNK";
            
        }
        //du lieu KHOI
        private void cboChonNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChonKhoi.DataSource = dt.khoi_SelectAll();
            cboChonKhoi.DisplayMember = "TenKhoi";
            cboChonKhoi.ValueMember = "MaKhoi";
        }
        //du lieu LOP
        private void cboChonKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChonLop.ValueMember = "MaLop";
            cboChonLop.DisplayMember = "TenLop";
            cboChonLop.DataSource = dt.Lop_SelectMaNK_MaKhoi(cboChonNK.SelectedValue.ToString(), cboChonKhoi.SelectedValue.ToString());
            lblMaLop_ML.DataBindings.Clear();
            lblMaLop_ML.DataBindings.Add("Text", cboChonLop.DataSource, "MaLop");
        }

        private void cboChonLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var r in dt.HocSinh_SelectAll())
            {
                lblMaHS_HS.Text = r.MaHS;
                lblTenHS_HS.Text = r.TenHS;
                lblGioiTinh_HS.Text = r.GioiTinh;
            }
            /*
            foreach ( var r in dt.HocSinh_SelectMaHS(lblMaHS.Text))
            {
                dgvBangDiemTB.DataSource = dt.HocSinh_SelectMaHS(lblMaHS.Text);
                lblMaHS_HS.Text = r.MaHS;
                lblTenHS_HS.Text = r.TenHS;
                lblGioiTinh_HS.Text = r.GioiTinh;
            }*/
            var table = new DataTable();
            DataColumnCollection col = table.Columns;
            if (!col.Contains("MaHS"))
                table.Columns.Add("MaHS", typeof(string));

            if (!col.Contains("TenHS"))
                table.Columns.Add("TenHS", typeof(string));

            if (!col.Contains("GioiTinh"))
                table.Columns.Add("GioiTinh", typeof(string));

            if (!col.Contains("Toan"))
                table.Columns.Add("Toan", typeof(string));

            if (!col.Contains("NguVan"))
                table.Columns.Add("NguVan", typeof(string));

            if (!col.Contains("TiengAnh"))
                table.Columns.Add("TiengAnh", typeof(string));

            if (!col.Contains("HoaHoc"))
                table.Columns.Add("HoaHoc", typeof(string));

            if (!col.Contains("SinhHoc"))
                table.Columns.Add("SinhHoc", typeof(string));

            if (!col.Contains("VatLy"))
                table.Columns.Add("VatLy", typeof(string));

            if (!col.Contains("LichSu"))
                table.Columns.Add("LichSu", typeof(string));

            if (!col.Contains("DiaLy"))
                table.Columns.Add("DiaLy", typeof(string));

            if (!col.Contains("GDCD"))
                table.Columns.Add("GDCD", typeof(string));

            if (!col.Contains("TinHoc"))
                table.Columns.Add("TinHoc", typeof(string));

            if (!col.Contains("TheDuc"))
                table.Columns.Add("TheDuc", typeof(string));

            double DTB_Toan = 0;
            double DTB_VN = 0;
            double DTB_TiengAnh = 0;
            double DTB_Sinh = 0;
            double DTB_Hoa = 0;
            double DTB_Ly = 0;
            double DTB_Su = 0;
            double DTB_Dia = 0;
            double DTB_GDCD = 0;
            double DTB_TinHoc = 0;
            double DTB_TheDuc = 0;

            foreach(var n in dt.HocSinh_SelectMaLop(cboChonLop.SelectedValue.ToString()))
            {
                DataRow r = table.NewRow();
                r["MaHS"] = n.MaHS;
                r["TenHS"] = n.TenHS;
                r["GioiTinh"] = n.GioiTinh;

                

                
                 foreach(var mh in dt.MonHoc_SelectAll())
                 {
                     foreach(var dtb in dt.BangDiemMon_TimKiem(n.MaHS,mh.MaMon))
                     {
                         if(n.MaHS == dtb.MaHS & mh.MaMon == dtb.MaMon)
                         {
                             DTB_Toan += (Convert.ToDouble(dtb.KTMieng)) ;
                             DTB_VN += (Convert.ToInt32(dtb.KTMieng));
                            //double t = Math.Round(DTB_Toan / 1, 2);
                             r["Toan"] = DTB_Toan;
                             r["NguVan"] = DTB_VN;
                         }
                     }
                 }

                 
                /*
                    foreach (var dm in dt.BangDiemMon_UpdateDTB(lblMaHS.Text,lblMaLop.Text,Toan.ValueType())
                    {
                    DTB_Toan = Convert.ToInt32(dm.TBMon);
                           
                    r["Toan"] = DTB_Toan;
                        
                    }
                      */

                table.Rows.Add(r);
            }
           
            dgvBangDiemTB.DataSource = table;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvBangDiemTB.DataSource = dt.HocSinhs.Where(x => x.TenHS.Contains(txtTimKiem.Text)).ToList();
            cboChonLop_SelectedIndexChanged(sender, e);
            lblMaHS_HS.DataBindings.Clear();
            lblMaHS_HS.DataBindings.Add("Text", dgvBangDiemTB.DataSource, "MaHS");
            lblTenHS_HS.DataBindings.Clear();
            lblTenHS_HS.DataBindings.Add("Text", dgvBangDiemTB.DataSource, "TenHS");
            lblGioiTinh_HS.DataBindings.Clear();
            lblGioiTinh_HS.DataBindings.Add("Text", dgvBangDiemTB.DataSource, "GioiTinh");
        }

        
    }
}
