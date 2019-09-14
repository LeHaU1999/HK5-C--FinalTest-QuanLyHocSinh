using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace HK5_LTHDT_BaoCaoDeTao
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        //ket noi csdl
        //KetNoiCSDL_BaoCaoDeTaiDataContext dt = new KetNoiCSDL_BaoCaoDeTaiDataContext();
        ConnectToSQL con = new ConnectToSQL();
        
        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            dt = con.GetData("SELECT * FROM dbo.NguoiDung WHERE TaiKhoan='" + txtTDN.Text + "' AND MatKhat=" + txtMK.Text + "");
            if (dt.Rows.Count>0)
            {
                MessageBox.Show("Đang Nhập Thànhh Công ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainForm frmMain = new MainForm(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                frmMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đang Nhập Thất Bại !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }




            //--------------------------------------------------------------------------------------
            /*
           
                var dangnhap = (from NguoiDung in dt.NguoiDungs
                                where NguoiDung.TaiKhoan == txtTDN.Text.Trim() && NguoiDung.MatKhat == txtMK.Text
                                select NguoiDung).SingleOrDefault();
                if (dangnhap == null)
                {
                    MessageBox.Show("Đang Nhập Thất Bại. Vui Lòng Xem LẠi ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Đang Nhập Thành Công ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainForm frmMain = new MainForm();
                    frmMain.ShowDialog();
                }
            */
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTDN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
