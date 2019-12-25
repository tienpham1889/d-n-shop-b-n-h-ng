using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Food_Shop.NguoiDung
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lOGIN_Cus"] == null)
            {
                Response.Redirect("Login_cus.aspx");
            }

            SqlConnection con = new SqlConnection(@"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog=DB_vegefoods;Integrated Security=True");
            String sQuery = "Select * from food";
            SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            decimal discount = 0;
            if (IsPostBack == false)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            decimal tong;
            int tongsp = 0;
            if (e.CommandName == "Add_To_Cart")
            {
                HiddenField hf_id = (HiddenField)e.Item.FindControl("hf_id");
                HiddenField hf_name = (HiddenField)e.Item.FindControl("hf_name");
                HiddenField hf_mota = (HiddenField)e.Item.FindControl("hf_mota");
                HiddenField hf_img = (HiddenField)e.Item.FindControl("hf_img");
                HiddenField hf_price = (HiddenField)e.Item.FindControl("hf_price");
                HiddenField hf_precent = (HiddenField)e.Item.FindControl("hf_precent");
                HiddenField hf_unit = (HiddenField)e.Item.FindControl("hf_unit");
                DataTable dt = new DataTable();
                if (Session["cart"] == null)
                {
                    dt.Columns.Add("id");
                    dt.Columns.Add("img");
                    dt.Columns.Add("name");
                    dt.Columns.Add("description");
                    dt.Columns.Add("price_promo");
                    dt.Columns.Add("unit");
                    dt.Columns.Add("precent_promo");
                    dt.Columns.Add("SoLuong");
                    dt.Columns.Add("Tong");
                }
                else
                {
                    dt = (DataTable)Session["cart"];
                }
                int iRow = checkExisted(dt, hf_id.Value);
                if (iRow != -1)
                {
                    dt.Rows[iRow]["SoLuong"] = Convert.ToInt32(dt.Rows[iRow]["SoLuong"]) + 1;
                    tong = decimal.Parse(hf_price.Value) * decimal.Parse(dt.Rows[iRow]["SoLuong"].ToString());
                    dt.Rows[iRow]["Tong"] = tong;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = hf_id.Value;
                    dr["name"] = hf_name.Value;
                    dr["description"] = hf_mota.Value;
                    dr["img"] = hf_img.Value;
                    dr["price_promo"] = hf_price.Value;
                    dr["unit"] = hf_unit.Value;
                    dr["precent_promo"] = hf_precent.Value;
                    dr["SoLuong"] = 1;
                    tong = decimal.Parse(hf_price.Value) * decimal.Parse(dr["SoLuong"].ToString());
                    dr["Tong"] = tong;
                    dt.Rows.Add(dr);
                }

                Session["cart"] = dt;
            }
        }
        private int checkExisted(DataTable dt, string id)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}