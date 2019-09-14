using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HK5_LTHDT_BaoCaoDeTao
{
    class ConnectToSQL
    {
        #region Availible
        private SqlConnection conn;
        private SqlCommand cmm;
        private string StrCon = null;
        private string error;

        private string Error
        {
            get { return error; }
            set { error = value; }
        }

        public SqlConnection Connection
        {
            get { return conn; }
        }

        public SqlCommand CMD
        {
            get { return cmm; }
            set { cmm = value; }
        }
        #endregion
        #region Contrustor
        public  ConnectToSQL()
        {
            StrCon = @"Data Source=DESKTOP-RT97DOV\SQLEXPRESS;Initial Catalog=HK5_BaoCaoDeTai_QLHS_nf;Integrated Security=True";
            conn = new SqlConnection(StrCon);


        }
        #endregion
        #region methods
        public bool OpenConn()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool CloseConn()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public DataTable GetData(string sql)
        {
            cmm = new SqlCommand();
            DataTable dt = new DataTable();
            cmm.CommandText = sql;
            cmm.CommandType = CommandType.Text;
            cmm.Connection = conn;
            try
            {
                this.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmm);
                sda.Fill(dt);
            }
            catch(Exception ex)
            {
                string max = ex.Message;
                cmm.Dispose();
                this.CloseConn();
            }
            return dt;
        }

        public bool SetData(string sql)
        {
            cmm = new SqlCommand();
            DataTable dt = new DataTable();
            cmm.CommandText = sql;
            cmm.CommandType = CommandType.Text;
            cmm.Connection = conn;
            try
            {
                this.OpenConn();
                cmm.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                string max = ex.Message;
                cmm.Dispose();
                this.CloseConn();
            }
            return false;
        }
        #endregion
    }
}
