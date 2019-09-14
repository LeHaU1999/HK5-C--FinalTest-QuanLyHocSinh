using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace HK5_LTHDT_BaoCaoDeTao
{
    public partial class frmQLDiem : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder cmm;
        public frmQLDiem()
        {
            InitializeComponent();
        }
        //Ket Noi CSDL
        KetNoiCSDL_BaoCaoDeTaiDataContext dt = new KetNoiCSDL_BaoCaoDeTaiDataContext();

        //Dong Form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //dua du lieu NK vao combobox NIEN KHOA
        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            // dua du lieu nien khoa vao cboChonNK
            try
            {
                cboChonNK.DataSource = dt.NienKhoa_SelectAll();
                cboChonNK.DisplayMember = "TenNK";
                cboChonNK.ValueMember = "MaNK";
                lblMaNK_NK.DataBindings.Clear();
                lblMaNK_NK.DataBindings.Add("Text", cboChonNK.DataSource, "MaNK");
                cboChonKhoi.Text = "";
            }
            catch
            {
                MessageBox.Show("Loi ", "Thoong Baos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // cap nhat diem
            /*
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-RT97DOV\SQLEXPRESS;Initial Catalog=HK5_BaoCaoDeTai_QLHS_nf;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT KTMieng,KT15L1,KT15L2,KT45L1,KT45L2,KTHK1,KTHK2 FROM dbo.BangDiemMon",con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "loi");
                dgvDanhSachDiemHS.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi Ket Noi \n" + ex.Message, "Thoong Baos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        //Dua  du lieu Khoi vao combobox KHOI
        private void cboChonNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChonKhoi.DisplayMember = "TenKhoi";
            cboChonKhoi.ValueMember = "MaKhoi";
            cboChonKhoi.DataSource = dt.khoi_SelectAll();
            cboChonKhoi_SelectedIndexChanged(sender, e);
            lblMaKhoi_MK.DataBindings.Clear();
            lblMaKhoi_MK.DataBindings.Add("Text", cboChonKhoi.DataSource, "MaKhoi");
        }

        //Dua Du lieu Lop vao combobox LOP
        private void cboChonKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChonLop.ValueMember = "MaLop";
            cboChonLop.DisplayMember = "TenLop";
            cboChonLop.DataSource = dt.Lop_SelectMaNK_MaKhoi(cboChonNK.SelectedValue.ToString(), cboChonKhoi.SelectedValue.ToString());
            lblMaLop_ML.DataBindings.Clear();
            lblMaLop_ML.DataBindings.Add("Text", cboChonLop.DataSource, "MaLop");
            lblTenLop_TL.DataBindings.Clear();
            lblTenLop_TL.DataBindings.Add("Text", cboChonLop.DataSource, "TenLop");
        }

        // Dua Danh Sach Lop vao treview 
        private void cboChonLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            trvDanhSachLop.Nodes.Clear();
                foreach (var r in dt.HocSinh_SelectMaLop(cboChonLop.SelectedValue.ToString()))
                {
                    TreeNode tree = new TreeNode();
                    tree.Name = r.MaHS;
                    tree.Text = r.TenHS;
                    trvDanhSachLop.Nodes.Add(tree);
                }
            trvDanhSachLop.ExpandAll();

            
        }


        // dua du lieu diem vao data girdview 
        private void trvDanhSachLop_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            foreach(var r in dt.HocSinh_SelectMaHS(e.Node.Name))
            {
                lblMaHS_HS.Text = e.Node.Name;
                lblTenHS_HS.Text = r.TenHS;
                lblGioiTinh_HS.Text = r.GioiTinh;
            }
            
            var table = new DataTable();                //tao bang ao
            DataColumnCollection col = table.Columns;
            if (!col.Contains("MaMon"))
                table.Columns.Add("MaMon", typeof(string));

            if (!col.Contains("TenMon"))
                table.Columns.Add("TenMon", typeof(string));

            if (!col.Contains("KTMieng"))
                table.Columns.Add("KTMieng", typeof(string));

            if (!col.Contains("KT15L1"))
                table.Columns.Add("KT15L1", typeof(string));

            if (!col.Contains("KT15L2"))
                table.Columns.Add("KT15L2", typeof(string));

            if (!col.Contains("KT45L1"))
                table.Columns.Add("KT45L1", typeof(string));

            if (!col.Contains("KT45L2"))
                table.Columns.Add("KT45L2", typeof(string));

            if (!col.Contains("KTHK1"))
                table.Columns.Add("KTHK1", typeof(string));

            if (!col.Contains("HK2L2"))
                table.Columns.Add("KTHK2", typeof(string));
            
            if (!col.Contains("TB-HK1"))
                table.Columns.Add("TBMHK1", typeof(string));

            if (!col.Contains("TB-HK2"))
                table.Columns.Add("TBMHK2", typeof(string));

            if (!col.Contains("TB-CN"))
                table.Columns.Add("TBMCN", typeof(string));

            double KTM = 0;
            double KT15L1= 0;
            double KT15L2 = 0;
            double KT45L1 = 0;
            double KT45L2 = 0;
            double HK1 = 0;
            double HK2 = 0;

            foreach (var n in dt.MonHoc_SelectAll())
            {
               DataRow r = table.NewRow();            
               r["TenMon"] = n.TenMon;
               r["MaMon"] = n.MaMon;
                foreach (var m in dt.BangDiemMon_SelectAll())
                {
                    if (m.MaHS == e.Node.Name & n.MaMon == m.MaMon)
                    {
                        r["KTMieng"] = m.KTMieng;
                        KTM += Convert.ToInt32(m.KTMieng);                      

                        r["KT15L1"] = m.KT15L1;
                        KT15L1 += Convert.ToInt32(m.KT15L1);

                        r["KT15L2"] = m.KT15L2;
                        KT15L2 += Convert.ToInt32(m.KT15L2);

                        r["KT45L1"] = m.KT45L1;
                        KT45L1 += Convert.ToInt32(m.KT45L1);

                        r["KT45L2"] = m.KT45L2;
                        KT45L2 += Convert.ToInt32(m.KT45L2);

                        r["KTHK1"] = m.KTHK1;
                        HK1 += Convert.ToInt32(m.KTHK1);

                        r["KTHK2"] = m.KTHK2;
                        HK2 += Convert.ToInt32(m.KTHK2);

                        
                        double TongHK1 = 0;
                        TongHK1 += Convert.ToInt32(m.KTMieng) + Convert.ToInt32(m.KT15L1) + Convert.ToInt32(m.KT45L1) * 2 + Convert.ToInt32(m.KTHK1) * 3;
                        double TBHK1 = Math.Round(TongHK1 / 7, 2);
                        r["TBMHK1"] = TBHK1;

                        double TongHK2 = 0;
                        TongHK2 += Convert.ToInt32(m.KT15L2) + Convert.ToInt32(m.KT45L2) * 2 + Convert.ToInt32(m.KTHK2) * 3;
                        double TBHK2 = Math.Round(TongHK2 / 6, 2);
                        r["TBMHK2"] = TBHK2;

                        double Tong = 0;
                        Tong += TBHK1 + TBHK2 * 2;
                        double TBM = Math.Round(Tong / 3, 2);
                        r["TBMCN"] = TBM;
                     
                    }
                }
                table.Rows.Add(r);                               
            }
            dgvDanhSachDiemHS.DataSource = table;
        }

        private void trvDanhSachLop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void btnDTB_XepLoai_Click(object sender, EventArgs e)
        {
            frmDTB_XepLoai frm = new frmDTB_XepLoai();
            frm.Show();
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
            worksheet.Cells[1, 2] = "BẢNG ĐIỂM CHI TIẾT HỌC SINH";

            worksheet.Cells[3, 2] = "Mã HS:     " + lblMaHS_HS.Text;
            worksheet.Cells[4, 2] = "Tên HS:    " + lblTenHS_HS.Text;
            worksheet.Cells[5, 2] = "Giới Tinh: " + lblGioiTinh_HS.Text;
            worksheet.Cells[3, 5] = "TB-HK1: " + lblDTB_DTBHK1.Text;
            worksheet.Cells[4, 5] = "TB-HK2: " + lblDTB_DTBHK2.Text;
            worksheet.Cells[5, 5] = "TBCN: " + lblDTBCN.Text;
            worksheet.Cells[6, 5] = "Xếp Loại: " + lblXepLoai_XL.Text;


            worksheet.Cells[8, 1] = "STT";
            worksheet.Cells[8, 2] = "STT";
            worksheet.Cells[8, 3] = "Mã Môn";
            worksheet.Cells[8, 4] = "Tên Môn";
            worksheet.Cells[8, 5] = "Miệng";
            worksheet.Cells[8, 6] = "15p L1";
            worksheet.Cells[8, 7] = "15p L2";
            worksheet.Cells[8, 8] = "45p L1";
            worksheet.Cells[8, 9] = "45p L2";
            worksheet.Cells[8, 10] = "HK1";
            worksheet.Cells[8, 11] = "HK2";
            worksheet.Cells[8, 12] = "TBMHK1";
            worksheet.Cells[8, 13] = "TBMHK2";
            worksheet.Cells[8, 14] = "TBMCN";


            for (int i=0 ; i< dgvDanhSachDiemHS.RowCount ;i++)
            {
                for(int j=0; j< 13;j++)
                {
                    worksheet.Cells[i + 9, 1] = i + 1;
                    worksheet.Cells[i + 9, j + 2] = dgvDanhSachDiemHS.Rows[i].Cells[j].Value;
                }
            }

        }

        //xuat bao cao bang crystal report
        private void btnCrystal_Click(object sender, EventArgs e)
        {
            if(dgvDanhSachDiemHS.RowCount>0)
            {
                String Text1 = "TB-HK1: " + lblDTB_DTBHK1.Text.ToString();
                String Text2 = "TB-HK2: " + lblDTB_DTBHK2.Text.ToString();
                String Text3 = "TBCN: " + lblDTBCN.Text.ToString();
                DataTable dt = new DataTable();
                dt = dgvDanhSachDiemHS.DataSource as DataTable;
                CrystalReport4 cos = new CrystalReport4();
                cos.SetDataSource(dt);
                cos.SetParameterValue("text1", Text1);
                cos.SetParameterValue("text2", Text2);
                cos.SetParameterValue("text3", Text3);
                Form2 frm = new Form2();
                frm.crystalReportViewer1.ReportSource = cos;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ko co gi ca");
            }
        }
      
        // tinh dien trung binh HK1 HK2 TBCN + Xep Loai 
        private void btnDTB_XepLoai_Click_1(object sender, EventArgs e)
        {
            try
            {
               double cn = 0,hk1=0, hk2=0,s1=0 ,s2=0,s3=0, tbhk1=0, tbhk2 = 0, tbcn = 0;
               for (int i = 0; i < dgvDanhSachDiemHS.Rows.Count; i++)
               {
                    //TBCN
                    double.TryParse(dgvDanhSachDiemHS.Rows[i].Cells[12].Value.ToString(), out s1);
                    cn = cn + s1;

                    //TB-HK1
                    double.TryParse(dgvDanhSachDiemHS.Rows[i].Cells[10].Value.ToString(), out s2);
                    hk1 = hk1 + s2;

                    //TB-HK2
                    double.TryParse(dgvDanhSachDiemHS.Rows[i].Cells[11].Value.ToString(), out s3);
                    hk2 = hk2 + s3;

               }
                tbcn = cn / dgvDanhSachDiemHS.Rows.Count;
                double tbm1 = Math.Round(tbcn, 2);
                lblDTBCN.Text = tbm1.ToString();

                tbhk1 = hk1 / dgvDanhSachDiemHS.Rows.Count;
                double tbm2 = Math.Round(tbhk1, 2);
                lblDTB_DTBHK1.Text = tbm2.ToString();

                tbhk2 = hk2 / dgvDanhSachDiemHS.Rows.Count;
                double  tbm3= Math.Round(tbhk2, 2);
                lblDTB_DTBHK2.Text = tbm3.ToString();

                if (tbm1 >= 9)
                {
                    lblXepLoai_XL.Text = "Xuất Sắc";
                }
                else if(9 > tbm1 & tbm1 >= 8)
                {
                    lblXepLoai_XL.Text = "Giỏi";
                }
                else if (8 > tbm1 & tbm1 >= 6.5)
                {
                    lblXepLoai_XL.Text = "Khá";
                }
                else if (6.5 > tbm1 & tbm1 >= 5.0)
                {
                    lblXepLoai_XL.Text = "Trung Bình";
                }
                else if (5 > tbm1 & tbm1 >= 4.0)
                {
                    lblXepLoai_XL.Text = "Yếu";
                }
                else if (tbm1 < 4)
                {
                    lblXepLoai_XL.Text = "Kém";
                }
            }
            catch
            {
                MessageBox.Show(" !!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        // xu ly cap nhat diem
        Boolean CND = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            //if (CND==true)
           // {
               // dt.BangDiemMon_Insert(lblMaHS_HS.Text, txtmamon.Text, Convert.ToDouble(txtMieng.ToString()), Convert.ToDouble(txt15p.ToString()), Convert.ToDouble(txt15pL2.ToString()), Convert.ToDouble(txt45p.ToString()), Convert.ToDouble(txt45pL2.ToString()), Convert.ToDouble(txtHK1.ToString()), Convert.ToDouble(txtHK2.ToString()));

                //CND = false;
                //cbChonLop_SelectedIndexChanged(sender, e);

            //}
            //else
            //{
                //dt.HocSinh_Update(txtMaHS.Text, txtTenHS.Text, txtGioiTinh.Text, txtSDT.Text, dtpNgaySinh.Value, txtNoiSinh.Text, txtDanToc.Text, txtDiaChi.Text);
                //dt.BangDiemMon_Update(lblMaHS_HS.Text, txtmamon.Text, Convert.ToDouble(txtMieng.ToString()), Convert.ToDouble(txt15p.ToString()), Convert.ToDouble(txt15pL2.ToString()), Convert.ToDouble(txt45p.ToString()), Convert.ToDouble(txt45pL2.ToString()), Convert.ToDouble(txtHK1.ToString()), Convert.ToDouble(txtHK2.ToString()));
                //MessageBox.Show(" !!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //bChonLop_SelectedIndexChanged(sender, e);
            //}

            //cmm1 = con1.CreateCommand();
            // cmm1.CommandText = "INSERT INTO dbo.BangDiemMon VALUES('" + txtMieng.Text+","+txt15p.Text+","+txt15pL2.Text+","+txt45p.Text+","+txt45pL2+","+txtHK1.Text+","+txtHK2.Text+"')";
            // cmm1.ExecuteNonQuery();
            //loaddata();

            /* catch
             {
                 MessageBox.Show("ĐÃ LUU ^-^ !!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             */


        }

        // STT cho dgv
        private void dgvDanhSachDiemHS_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvDanhSachDiemHS.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        


        SqlConnection con1;
        SqlCommand cmm1;
        string str = @"Data Source=DESKTOP-RT97DOV\SQLEXPRESS;Initial Catalog=HK5_BaoCaoDeTai_QLHS_nf;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            cmm1 = con.CreateCommand();
            cmm1.CommandText = "SELECT*FROM BangDiemMon";
            adapter.SelectCommand = cmm1;
            table.Clear();
            adapter.Fill(table);
            dgvDanhSachDiemHS.DataSource = table;
        }

        private void dgvDanhSachDiemHS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDanhSachDiemHS.CurrentRow.Index;
            txtTenMon.Text = dgvDanhSachDiemHS.Rows[i].Cells[2].Value.ToString();
            txtMieng.Text = dgvDanhSachDiemHS.Rows[i].Cells[3].Value.ToString();
            txt15p.Text = dgvDanhSachDiemHS.Rows[i].Cells[4].Value.ToString();
            txt15pL2.Text = dgvDanhSachDiemHS.Rows[i].Cells[5].Value.ToString();
            txt45p.Text = dgvDanhSachDiemHS.Rows[i].Cells[6].Value.ToString();
            txt45pL2.Text = dgvDanhSachDiemHS.Rows[i].Cells[7].Value.ToString();
            txtHK1.Text = dgvDanhSachDiemHS.Rows[i].Cells[8].Value.ToString();
            txtHK2.Text = dgvDanhSachDiemHS.Rows[i].Cells[9].Value.ToString();
        }
    }
}
