using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.App_Code
{
    public class FoodType
    {
        private int _Type_Id;

        public int Type_Id
        {
            get { return _Type_Id; }
            set { _Type_Id = value; }
        }
        private string _Type_Name;

        public string Type_Name
        {
            get { return _Type_Name; }
            set { _Type_Name = value; }
        }
        private string _Type_Img;

        public string Type_Img
        {
            get { return _Type_Img; }
            set { _Type_Img = value; }
        }
        private int _Type_Pos;

        public int Type_Pos
        {
            get { return _Type_Pos; }
            set { _Type_Pos = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private DateTime _Modified;

        public DateTime Modified
        {
            get { return _Modified; }
            set { _Modified = value; }
        }
        public bool AddFood_type()
        {
            String sQuery = "INSERT INTO [dbo].[food_type]([type_name],[type_pos],[type_img],[status],[username],[modified])VALUES(@typename,@typepos,@img,@status,@username,@mofine)";

            SqlParameter[] sqlParas = {
                    new SqlParameter("@typename",SqlDbType.NVarChar,50) {Value = this.Type_Name },
                    new SqlParameter("@typepos",SqlDbType.Int){Value =  this.Type_Pos },
                    new SqlParameter("@img",SqlDbType.VarChar,255) {Value = this.Type_Img },
                    new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                    new SqlParameter("@username",SqlDbType.VarChar,50) {Value = this.UserName},
                    new SqlParameter("@mofine",SqlDbType.DateTime) {Value = Modified.ToString()}
                    };
            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public bool UpdateFood_type(int id)
        {
            String sQuery = "UPDATE[dbo].[food_type]SET[type_name] = @typename,[type_pos] = @typepos,[type_img] = @img,[status] = @status,[username] = @username,[modified] = @mofine WHERE [type_id]=@id";

            SqlParameter[] sqlParas = {
                    new SqlParameter("@id",SqlDbType.Int) {Value =id },
                    new SqlParameter("@typename",SqlDbType.NVarChar,50) {Value = this.Type_Name },
                    new SqlParameter("@typepos",SqlDbType.Int){Value =  this.Type_Pos },
                    new SqlParameter("@img",SqlDbType.VarChar,255) {Value = this.Type_Img },
                    new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                    new SqlParameter("@username",SqlDbType.VarChar,50) {Value = this.UserName},
                    new SqlParameter("@mofine",SqlDbType.DateTime) {Value = Modified.ToString()}
                    };
            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public int DeleteFoodType(int id)
        {

            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = "DELETE FROM [dbo].[food_type]WHERE type_id=" + id;
            SqlCommand com = new SqlCommand(sQuery, conn);
            int numofrow = com.ExecuteNonQuery();
            conn.Close();
            return numofrow;
        }
        public bool Ktraten(string ten)
        {
            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = string.Format("SELECT * FROM [dbo].[food_type] WHERE [type_name]=N'{0}'", ten);
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool ketqua = dr.HasRows;
            dr.Close();
            conn.Close();
            return ketqua;
        }
        public FoodType(string sTypename, int sTypepos, string sImg, string sUsername, string sModifine, int iStatus)
        {
            _Type_Name = sTypename;
            _Type_Pos = sTypepos;
            _Type_Img = sImg;
            _UserName = sUsername;
            _Modified = Convert.ToDateTime(sModifine);
            _Status = iStatus;
        }
        public FoodType()
        {
            _Type_Name = "";
            _Type_Pos = 0;
            _Type_Img = "";
            _UserName = "";
            _Status = 1;
        }
    }
}