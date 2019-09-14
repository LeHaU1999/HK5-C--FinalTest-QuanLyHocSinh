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
    public partial class frmQLMonHoc : Form
    {
        public frmQLMonHoc()
        {
            InitializeComponent();
        }
        KetNoiCSDL_BaoCaoDeTaiDataContext dt = new KetNoiCSDL_BaoCaoDeTaiDataContext();
        //dong form
        private void btnCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //dua du lieu vao combobox 'CHONMON'
        private void frmQLMonHoc_Load(object sender, EventArgs e)
        {
            
            cboChonMon.DisplayMember = "TenMon";
            cboChonMon.ValueMember = "MaMon";
            cboChonMon.DataSource = dt.MonHoc_SelectAll();
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("text", cboChonMon.DataSource, "MaMon");
            txtTenMon.DataBindings.Clear();
            txtTenMon.DataBindings.Add("text", cboChonMon.DataSource, "TenMon");
        }

        //dua du lieu vao datagirdview
        private void btnXemMonHoc_Click(object sender, EventArgs e)
        {
            dgvDanhSachMonHoc.DataSource = dt.MonHoc_SelectAll();
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("text", dgvDanhSachMonHoc.DataSource, "MaMon");
            txtTenMon.DataBindings.Clear();
            txtTenMon.DataBindings.Add("text", dgvDanhSachMonHoc.DataSource, "TenMon");
        }

        //tim kiem mon hoc
        private void txtTimKhiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSachMonHoc.DataSource = dt.MonHocs.Where(x => x.TenMon.Contains(txtTimKhiem.Text)).ToList();
        }

        // them mon hoc
        Boolean adMH = false;
        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtMaMon.Enabled = true;
            txtMaMon.Focus();
            adMH = true;
        }

        //luu mon hoc
        private void btnLuuMonHoc_Click(object sender, EventArgs e)
        {
            if(adMH==true)
            {
                dt.MonHoc_InSert(txtMaMon.Text, txtTenMon.Text);
                adMH = false;
                frmQLMonHoc_Load(sender, e);
            }
            else
            {
                dt.MonHoc_Update(txtMaMon.Text, txtTenMon.Text);
                frmQLMonHoc_Load(sender, e);
            }
            MessageBox.Show("ĐÃ LƯU THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //xoa mon hoc
        private void btnXoaMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                dt.MonHoc_Delete(cboChonMon.SelectedValue.ToString());
                frmQLMonHoc_Load(sender, e);
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("KHÔNG XÓA ĐƯỢC ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
