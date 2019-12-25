using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.App_Code
{
    public class Account
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
        private int _Role;

        public int Role
        {
            get { return _Role; }
            set { _Role = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public bool Ktraten(string ten)
        {
            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = string.Format("SELECT * FROM [dbo].[member] WHERE [username]='{0}'", ten);      
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool ketqua = dr.HasRows;
            dr.Close();
            conn.Close();
            return ketqua;
        }
        public bool AddMember()
        {
            String sQuery = "INSERT INTO [dbo].[member]([username],[pass],[name],[phone],[role],[status],[email]) VALUES (@us,@pass,@name,@phone,@role,@status,@email)";

            SqlParameter[] sqlParas = {
                    new SqlParameter("@us",SqlDbType.VarChar,50) {Value = this.Username },
                    new SqlParameter("@pass",SqlDbType.VarChar,255)
                    {Value =  StringProc.MD5Hash(this.Pass) },
                    new SqlParameter("@name",SqlDbType.NVarChar,200) {Value = this.Name },
                    new SqlParameter("@phone",SqlDbType.VarChar,20) {Value = this.Phone},
                    new SqlParameter("@role",SqlDbType.Int) {Value = this.Role},
                    new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                    new SqlParameter("@email",SqlDbType.VarChar,50){Value = this.Email}
                    };
            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }  
        public bool UpdateMember(string ten)
        {
            String sQuery = "UPDATE [dbo].[member]SET [username] = @us,[pass] = @pass,[name] = @name,[phone] = @phone,[role] = @role,[status] = @status,[email] = @email WHERE username='" + ten + "'";

            SqlParameter[] sqlParas = {
                    new SqlParameter("@us",SqlDbType.VarChar,50) {Value = this.Username },
                    new SqlParameter("@pass",SqlDbType.VarChar,255)
                    {Value =  StringProc.MD5Hash(this.Pass) },
                    new SqlParameter("@name",SqlDbType.NVarChar,200) {Value = this.Name },
                    new SqlParameter("@phone",SqlDbType.VarChar,20) {Value = this.Phone},
                    new SqlParameter("@role",SqlDbType.Int) {Value = this.Role},
                    new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                    new SqlParameter("@email",SqlDbType.VarChar,50){Value = this.Email}
                    };
            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public int DeleteMember(string ten)
        {
            
            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = "DELETE FROM [dbo].[member]WHERE username='" + ten + "'";
            SqlCommand com = new SqlCommand(sQuery, conn);
            int numofrow = com.ExecuteNonQuery();
            conn.Close();
            return numofrow;
        }
        public Account()
        {
            _Username = "";
            _Pass = "";
            _Name = "";
            _Phone = "";
            _Email = "";
            _Role = 0;
            _Status = 0;
        }
        public Account(string sUsername, string sName, string sPass, string sPhone, int iRole, int iStatus, string sEmail)
        {
            _Username = sUsername;
            _Pass = sPass;
            _Name = sName;
            _Phone = sPhone;
            _Email = sEmail;
            _Role = iRole;
            _Status = iStatus;
        }

    }
}