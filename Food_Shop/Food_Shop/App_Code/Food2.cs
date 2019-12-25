using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.App_Code
{
    public class Food2
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private decimal _Price;

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private decimal _Price_promo;

        public decimal Price_promo
        {
            get { return _Price_promo; }
            set { _Price_promo = value; }
        }

        private decimal _Precent;
        private decimal Precent
        {
            get { return _Precent; }
            set { _Precent = value; }
        }
        private string _Img;

        public string Img
        {
            get { return _Img; }
            set { _Img = value; }
        }
        private string _Unit;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        private int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private DateTime _Modified;

        public DateTime Modified
        {
            get { return _Modified; }
            set { _Modified = value; }
        }

        public bool AddFood()
        {
                String sQuery = "INSERT INTO [dbo].[food]([name],[description],[price],[price_promo],[img],[unit],[precent_promo],[type],[status],[username],[modified])VALUES(@name,@mota,@gia,@giagiam,@img,@donvi,@phantram,@loai,@trangthai,@username,@modifine)";

                SqlParameter[] sqlParas = {
                    new SqlParameter("@name",SqlDbType.NVarChar,255) {Value = this.Name },
                    new SqlParameter("@mota",SqlDbType.NVarChar,255){Value =  this.Description },
                    new SqlParameter("@gia",SqlDbType.Decimal) {Value = this.Price },
                    new SqlParameter("@giagiam",SqlDbType.Decimal) {Value = this.Price_promo },
                    new SqlParameter("@img",SqlDbType.VarChar,255) {Value = this.Img},  
                    new SqlParameter("@donvi",SqlDbType.NVarChar,10) {Value = this.Unit},
                    new SqlParameter("@phantram",SqlDbType.Decimal) {Value = this.Precent },
                    new SqlParameter("@loai",SqlDbType.Int) {Value = this.Type},
                    new SqlParameter("@trangthai",SqlDbType.Int) {Value = this.Status},
                    new SqlParameter("@username",SqlDbType.VarChar,50) {Value = this.Username},
                    new SqlParameter("@modifine",SqlDbType.DateTime) {Value = this.Modified.ToString()}
                    };
                return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public bool UpdateFood(int id)
        {
            String sQuery = "UPDATE [dbo].[food]SET [name] = @name,[description] = @mota,[price] = @gia,[price_promo] = @giagiam,[img] = @img,[unit] = @donvi,[precent_promo] = @phantram,[type] = @loai,[status] = @trangthai,[username] = @username,[modified] = @modifine WHERE id =@id";

            SqlParameter[] sqlParas = {
                    new SqlParameter("@id",SqlDbType.Int) {Value =id },
                    new SqlParameter("@name",SqlDbType.NVarChar,50) {Value = this.Name },
                    new SqlParameter("@mota",SqlDbType.NVarChar,255){Value =  this.Description },
                    new SqlParameter("@gia",SqlDbType.Decimal) {Value = this.Price },
                    new SqlParameter("@giagiam",SqlDbType.Decimal) {Value = this.Price_promo },
                    new SqlParameter("@img",SqlDbType.VarChar,255) {Value = this.Img},
                    new SqlParameter("@donvi",SqlDbType.NVarChar,10) {Value = this.Unit},
                    new SqlParameter("@phantram",SqlDbType.Decimal) {Value = this.Precent },
                    new SqlParameter("@loai",SqlDbType.Int) {Value = this.Type},
                    new SqlParameter("@trangthai",SqlDbType.Int) {Value = this.Status},
                    new SqlParameter("@username",SqlDbType.VarChar,50) {Value = this.Username},
                    new SqlParameter("@modifine",SqlDbType.DateTime) {Value = this.Modified.ToString()}
                    };
            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public int DeleteFood(int id)
        {

            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = "DELETE FROM [dbo].[food]WHERE id=" + id;
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
            string sQuery = string.Format("SELECT * FROM [dbo].[food] WHERE [name]=N'{0}'", ten);
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool ketqua = dr.HasRows;
            dr.Close();
            conn.Close();
            return ketqua;
        }
        public Food2(string sName, string sMota, decimal sGia, decimal sGiaGiam, string sImg, string sDonVi, decimal phantram ,int sLoai, int sStatus, string sUsername, string sModifine)
        {
            _Name = sName;
            _Description = sMota;
            _Price = sGia;
            _Price_promo = sGiaGiam;
            _Img = sImg;
            _Unit = sDonVi;
            _Precent = phantram;
            _Type = sLoai;
            _Status = sStatus;
            _Username = sUsername;
            _Modified = Convert.ToDateTime(sModifine);
        }
        public Food2()
        {
            _Name = "";
            _Description = "";
            _Price = 0;
            _Price_promo = 0;
            _Precent = 0;
            _Img = "";
            _Username = "";
        }
    }
}