using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Food_Shop.NguoiDung
{
    public partial class GioHang : System.Web.UI.Page
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
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                
            }
        }

        protected void link_btn_xoa_Click(object sender, EventArgs e)
        {

        }

        protected void btn_len_don_hang_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

    }
}