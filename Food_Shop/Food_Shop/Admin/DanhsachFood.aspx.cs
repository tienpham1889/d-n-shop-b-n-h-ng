using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Shop
{
    public partial class DanhsachFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lOGIN_ADMIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

    }
}