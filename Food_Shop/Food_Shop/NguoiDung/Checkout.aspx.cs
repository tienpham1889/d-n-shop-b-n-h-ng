using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Food_Shop.App_Code;

namespace Food_Shop.NguoiDung
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lOGIN_Cus"] == null)
            {
                Response.Redirect("Login_cus.aspx");
            }
            if (Session["cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cart"];
                decimal tongcong = 0;
                int dem = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongcong = tongcong + decimal.Parse(dt.Rows[i]["Tong"].ToString());
                    dem++;
                }
                lab_subtong.Text = "$" + tongcong.ToString();
                lab_quan.Text = dem.ToString();
                txt_tongcong.Text = "$" + tongcong.ToString();
            }

        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                DataTable data = new DataTable();
                data = (DataTable)Session["cart"];
                int dem = 0;
                string Cus_name = txt_cus_name.Text;
                string Cus_phone = txt_phone.Text;
                string Cus_add = txt_add.Text;
                int Status = Convert.ToInt32(drStatus.SelectedValue);
                string username = Session["lOGIN_Cus"].ToString();
                string chuoi = txt_tongcong.Text.Substring(1);
                decimal sum = decimal.Parse(chuoi);
                int quan = Int32.Parse(lab_quan.Text);
                DateTime sModifine = DateTime.Now;
                //String sQuery = String.Format("INSERT INTO [dbo].[order]([cus_name],[cus_phone],[cus_add],[quan],[sum],[status],[username],[modified])VALUES('{0}','{1}','{2}',{3},{4},{5},'{6}','{7}')", Cus_name, Cus_phone, Cus_add, quan, sum, Status, username, sModifine.ToString());
                //SqlCommand com = new SqlCommand(sQuery, con);
                //com.ExecuteNonQuery();
                HoaDon hd = new HoaDon(Cus_name, Cus_phone, Cus_add, quan, sum, Status, username, sModifine.ToString());
                hd.AddHD(data, ref dem);
                if(dem > 0)
                {
                    Response.Redirect("TrangChu.aspx");
                    Response.Write("<script>('Dat hang thanh cong')</script>");
                }
                // sQuery = "select @@identity";
                // com = new SqlCommand(sQuery, con);
                //int id = Convert.ToInt32(com.ExecuteScalar().ToString());
                //int numofrow =0;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    sQuery = "INSERT INTO [dbo].[order_detail]([order_id],[food_id],[quan],[unit],[price],[total])VALUES(@oderid,@fooid,@quan,@unit,@price,@total)";
                //    SqlParameter[] paras = new SqlParameter[6];
                //    paras[0] = new SqlParameter("@oderid", id);
                //    paras[1] = new SqlParameter("@fooid", dt.Rows[i]["id"]);
                //    paras[2] = new SqlParameter("@price", dt.Rows[i]["price_promo"]);
                //    paras[3] = new SqlParameter("@quan", dt.Rows[i]["SoLuong"]);
                //    paras[4] = new SqlParameter("@unit", dt.Rows[i]["unit"]);
                //    paras[5] = new SqlParameter("@total", dt.Rows[i]["Tong"]);
                //    com = new SqlCommand(sQuery, con);
                //    com.Parameters.AddRange(paras);
                //    numofrow= com.ExecuteNonQuery();
                //}
                Session["cart"] = null;
            }
        }
    }
}