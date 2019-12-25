using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.App_Code
{
    public class CTHD
    {
        private int _Order_id;
        public int Order_id
        {
            get { return _Order_id; }
            set { _Order_id = value; }
        }
        private int _Food_id;
        public int Food_id
        {
            get { return _Food_id; }
            set { _Food_id = value; }
        }
        private int _Quan;
        public int Quan
        {
            get { return _Quan; }
            set { _Quan = value; }
        }
        private string _Unit;
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private decimal _Total;
        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public bool AddCTHD(DataTable dt, int id_them)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog=DB_vegefoods;Integrated Security=True");
            con.Open();
            string sQuery = "select @@identity";
            SqlCommand com = new SqlCommand(sQuery,con );
            int id = Int32.Parse(com.ExecuteNonQuery().ToString());
            int numofrow = 0;
            sQuery = "INSERT INTO [dbo].[order_detail]([order_id],[food_id],[quan],[unit],[price],[total])VALUES(@oderid,@fooid,@quan,@unit,@price,@total)";
            SqlParameter[] paras = new SqlParameter[6];
            paras[0] = new SqlParameter("@oderid", id);
            paras[1] = new SqlParameter("@fooid", dt.Rows[id_them]["id"]);
            paras[2] = new SqlParameter("@price", dt.Rows[id_them]["price_promo"]);
            paras[3] = new SqlParameter("@quan", dt.Rows[id_them]["SoLuong"]);
            paras[4] = new SqlParameter("@unit", dt.Rows[id_them]["unit"]);
            paras[5] = new SqlParameter("@total", dt.Rows[id_them]["Tong"]);
            com = new SqlCommand(sQuery, con);
            com.Parameters.AddRange(paras);
            numofrow = com.ExecuteNonQuery();
            return DataProvider.executeNonQuery(sQuery, paras);
        }
        public CTHD(int order_id, int foodid, int quan, string unit, decimal price, decimal total)
        {
            _Order_id = order_id;
            _Food_id = foodid;
            _Quan = quan;
            _Unit = unit;
            _Price = price;
            _Total = total;
        }
        public CTHD()
        {
            _Order_id = 0;
            _Food_id = 0;
            _Quan = 0;
            _Unit = "";
            _Price = 0;
            _Total = 0;
        }
    }
}