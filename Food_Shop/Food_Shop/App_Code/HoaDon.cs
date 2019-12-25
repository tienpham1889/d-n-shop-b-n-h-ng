using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.App_Code
{
    public class HoaDon
    {
        private string _cusname;
        public string Cus_name
        {
            get { return _cusname; }
            set { _cusname = value; }
        }
        private string _cusphone;
        public string Cus_phone
        {
            get { return _cusphone; }
            set { _cusphone = value; }
        }
        private string _cusadd;
        public string Cus_add
        {
            get { return _cusadd; }
            set { _cusadd = value; }
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
        private DateTime _modified;
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }
        private int _quan;

        public int quan
        {
            get { return _quan; }
            set { _quan = value; }
        }
        private decimal _sum;

        public decimal sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        public void AddHD(DataTable dt , ref int dem)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog=DB_vegefoods;Integrated Security=True");
            con.Open();
            String sQuery = String.Format("INSERT INTO [dbo].[order]([cus_name],[cus_phone],[cus_add],[quan],[sum],[status],[username],[modified])VALUES(N'{0}','{1}',N'{2}',{3},{4},{5},'{6}','{7}')", Cus_name, Cus_phone, Cus_add, quan, sum, Status, Username, Modified.ToString());
            SqlCommand com = new SqlCommand(sQuery, con);
            com.ExecuteNonQuery();
            sQuery = "select @@identity";
            com = new SqlCommand(sQuery, con);
            int id = Convert.ToInt32(com.ExecuteScalar().ToString());
            int numofrow = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                sQuery = "INSERT INTO [dbo].[order_detail]([order_id],[food_id],[quan],[unit],[price],[total])VALUES(@oderid,@fooid,@quan,@unit,@price,@total)";
                SqlParameter[] paras = new SqlParameter[6];
                paras[0] = new SqlParameter("@oderid", id);
                paras[1] = new SqlParameter("@fooid", dt.Rows[i]["id"]);
                paras[2] = new SqlParameter("@price", dt.Rows[i]["price_promo"]);
                paras[3] = new SqlParameter("@quan", dt.Rows[i]["SoLuong"]);
                paras[4] = new SqlParameter("@unit", dt.Rows[i]["unit"]);
                paras[5] = new SqlParameter("@total", dt.Rows[i]["Tong"]);
                com = new SqlCommand(sQuery, con);
                com.Parameters.AddRange(paras);
                numofrow = com.ExecuteNonQuery();
            }
            dem = numofrow;
            con.Close();

        }
        public HoaDon(string cus_name, string cus_phone, string cus_add, int quan, decimal sum, int status, string username, string sModifine)
        {
            _cusname = cus_name;
            _cusphone = cus_phone;
            _cusadd = cus_add;
            _quan = quan;
            _sum = sum;
            _Status = status;
            _Username = username;
            _modified = Convert.ToDateTime(sModifine);
        }
    }
}