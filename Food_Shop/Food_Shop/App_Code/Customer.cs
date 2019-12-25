using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.App_Code
{
    public class Customer
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private string _Pass;
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }
        public bool Ktraten(string ten)
        {
            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = string.Format("SELECT * FROM [dbo].[customer] WHERE [username]='{0}'", ten);
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool ketqua = dr.HasRows;
            dr.Close();
            conn.Close();
            return ketqua;
        }
        public bool KiemtraDangnhap(string ten, string matkhau)
        {
            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = string.Format("SELECT username, password FROM [dbo].[customer] WHERE [username]='{0}' AND [password]='{1}'", ten, matkhau);
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool ketqua = dr.HasRows;
            dr.Close();
            conn.Close();
            return ketqua;
        }
        public bool AddCustomer()
        {
            String sQuery = "INSERT INTO [dbo].[customer]([username],[password],[name],[phone],[address],[status],[created])VALUES(@username,@pass,@name,@phone,@add,@status,@created)";

            SqlParameter[] sqlParas = {
                    new SqlParameter("@username",SqlDbType.VarChar,50) {Value = this.Username },
                    new SqlParameter("@pass",SqlDbType.VarChar,255){Value =  StringProc.MD5Hash(this.Pass) },
                    new SqlParameter("@name",SqlDbType.NVarChar,255) {Value = this.Name },
                    new SqlParameter("@phone",SqlDbType.VarChar,255) {Value = this.Phone},
                    new SqlParameter("@add",SqlDbType.NVarChar,300) {Value = this.Address},
                    new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                    new SqlParameter("@created",SqlDbType.DateTime){Value = this.Created}
                    };
            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public Customer(string username, string pass, string name, string phone, string add, int status, string created)
        {
            _Username = username;
            _Pass = pass;
            _Name = name;
            _Phone = phone;
            _Address = add;
            _Status = status;
            _Created = Convert.ToDateTime(created);
        }
        public Customer(string username, string pass)
        {
            _Username = username;
            _Pass = pass;
        }
        public Customer()
        {
            _Username = "";
            _Pass = "";
            _Name = "";
            _Phone = "";
            _Address = "";
            _Status = 0;
        }
    }
}