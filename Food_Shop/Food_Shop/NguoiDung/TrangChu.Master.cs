using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Food_Shop.NguoiDung
{
    public partial class TrangChu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int dem = 0;
            if (Session["cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cart"];
                decimal tongcong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongcong = tongcong + decimal.Parse(dt.Rows[i]["Tong"].ToString());
                    dem++;
                }
            }
            lab_sosp.Text = "[" + dem + "]";

        }
    }
}