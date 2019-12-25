using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Food_Shop.NguoiDung
{
    public partial class ChiTietSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog=DB_vegefoods;Integrated Security=True");
                con.Open();
                string sQuery = "";
                if (Request["id"] != null)
                {
                    sQuery = "Select * from food where id = ' "+ Request["id"] +"'";
                    SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    food_title.Text = dt.Rows[0]["name"].ToString();
                    img.ImageUrl = "~/Admin/img/" + dt.Rows[0]["img"].ToString();
                    price_food.Text = "$ "+dt.Rows[0]["price_promo"].ToString();
                    des_food.Text = dt.Rows[0]["description"].ToString();
                    lbl_unit.Text = dt.Rows[0]["unit"].ToString();
                }
            }
        }

        protected void Add_to_cart_Click(object sender, EventArgs e)
        {
            decimal tong;
            DataTable dt = new DataTable();
            if (Session["cart"] == null)
            {

                dt.Columns.Add("id");
                dt.Columns.Add("img");
                dt.Columns.Add("name");
                dt.Columns.Add("description");
                dt.Columns.Add("price_promo");
                dt.Columns.Add("unit");
                dt.Columns.Add("SoLuong");
                dt.Columns.Add("Tong");
            }
            else
            {
                dt = (DataTable)Session["cart"];
            }
            string tien = price_food.Text.Substring(2);
            string hinhanh = img.ImageUrl.Substring(11);
            DataRow dr = dt.NewRow();
            dr["id"] = Int32.Parse(Request["id"].ToString());
            dr["name"] = food_title.Text;
            dr["description"] = des_food.Text;
            dr["img"] = hinhanh;
            dr["price_promo"] = decimal.Parse(tien);
            dr["unit"] = lbl_unit.Text.ToString();
            dr["SoLuong"] = 1;
            tong = decimal.Parse(tien) * decimal.Parse(dr["SoLuong"].ToString());
            dr["Tong"] = tong;
            dt.Rows.Add(dr);

            Session["cart"] = dt;
        }
    }
}