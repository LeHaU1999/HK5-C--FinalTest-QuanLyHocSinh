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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string TDN = "", MK = "", quyen = "";
        public MainForm(string TDN, string MK, string quyen)
        {
            InitializeComponent();
            this.TDN = TDN;
            this.MK = MK;
            this.quyen = quyen;
        }




        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void mnuQLHS_Click(object sender, EventArgs e)
        {
            frmQLHS frm = new frmQLHS();
            frm.ShowDialog();
        }

        private void mnuQLDiem_Click(object sender, EventArgs e)
        {
            frmQLDiem frm = new frmQLDiem();
            frm.ShowDialog();
        }

        private void mnuEXIT_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuQLTK_Click(object sender, EventArgs e)
        {
            if(quyen=="admin")
            {
                mnuQLTK.Enabled = true;
                MessageBox.Show("Chào ADMIN ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QuanLiTK qltk = new QuanLiTK();
                qltk.Show();
            }
            else
            {
                mnuQLTK.Enabled = false;
                MessageBox.Show(" Người Dùng Không Có Quyền Truy Cập ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuQLMH_Click(object sender, EventArgs e)
        {
            frmQLMonHoc frm = new frmQLMonHoc();
            frm.ShowDialog();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
        }

       
    }
}
