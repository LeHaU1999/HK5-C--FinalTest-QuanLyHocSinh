using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace HK5_LTHDT_BaoCaoDeTao
{
    public partial class QuanLiTK : Form
    {
        public QuanLiTK()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmm;
        string str = @"Data Source=DESKTOP-RT97DOV\SQLEXPRESS;Initial Catalog=HK5_BaoCaoDeTai_QLHS_nf;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            cmm = con.CreateCommand();
            cmm.CommandText = "SELECT*FROM dbo.NguoiDung";
            adapter.SelectCommand = cmm;
            table.Clear();
            adapter.Fill(table);
            dgvTaiKhoan.DataSource = table;
        }




        KetNoiCSDL_BaoCaoDeTaiDataContext dt = new KetNoiCSDL_BaoCaoDeTaiDataContext();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Boolean TK = false;
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            
            txtTK.Text = "";
            txtMK.Text = "";
            txtQuyen.Text = "";
            btnLuuLai.Enabled = true;
            txtTK.Focus();
            txtTK.Enabled = true;
            
        }
    


        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            try
            {
                cmm = con.CreateCommand();
                cmm.CommandText = "INSERT INTO NguoiDung VALUES('" + txtTK.Text + "','" + txtMK.Text + "','" + txtQuyen.Text + "')";
                cmm.ExecuteNonQuery();
                loaddata();
            }
            catch
            {
                MessageBox.Show("ĐÃ LUU ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
            try
            {
                if (TK==true)
                {
                     dt.NguoiDung_InSert(txtTK.Text,txtMK.Text,txtQuyen.Text);
                   
                    TK = false;
                MessageBox.Show("fuk", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                else
                {
                //dt.NguoiDung_Update(txtTK.Text, txtMK.Text,txtQuyen.Text);            
                
            }
            MessageBox.Show("ĐÃ LƯU THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
              MessageBox.Show("Tài Khoản Đã Tồn Tại!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            try
            {
                dt.NguoiDung_Delete(txtTK.Text);
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QuanLiTK_Load(sender, e);
                /*
                cmm = con.CreateCommand();
                cmm.CommandText = "DELETE FROM NguoiDung WHERE '" + txtTK.Text + "'";
                cmm.ExecuteNonQuery();
                loaddata();
                */
            }
            catch
            {
                MessageBox.Show("ĐÃ XÓA ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
            dt.NguoiDung_Delete(txtTK.Text);
            
           MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
           */
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            /*
            dgvTaiKhoan.DataSource = dt.NguoiDung_SelectAll();
            txtTK.DataBindings.Clear();
            txtTK.DataBindings.Add("text", dgvTaiKhoan.DataSource, "TaiKhoan");
            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("text", dgvTaiKhoan.DataSource, "MatKhat");
            txtQuyen.DataBindings.Clear();
            txtQuyen.DataBindings.Add("text", dgvTaiKhoan.DataSource, "Quyen");
            btnLuuLai.Enabled = false;
            */           
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTaiKhoan.CurrentRow.Index;
            txtTK.Text = dgvTaiKhoan.Rows[i].Cells[0].Value.ToString();
            txtMK.Text = dgvTaiKhoan.Rows[i].Cells[1].Value.ToString();
            txtQuyen.Text = dgvTaiKhoan.Rows[i].Cells[2].Value.ToString();
        }

        private void QuanLiTK_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loaddata();
        }

        private void QuanLiTK_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        
    }
}
