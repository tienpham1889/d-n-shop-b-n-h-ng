using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Food_Shop.App_Code;

namespace Food_Shop
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public bool KiemtraDangnhap(string ten, string matkhau)
        {
            string ChuoiKetNoi = @"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog =DB_vegefoods;Integrated Security = True";
            SqlConnection conn = new SqlConnection(ChuoiKetNoi);
            conn.Open();
            string sQuery = string.Format("SELECT username, pass FROM [dbo].[member] WHERE [username]='{0}' AND [pass]='{1}'", ten,matkhau);
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool ketqua = dr.HasRows;
            dr.Close();
            conn.Close();
            return ketqua;
        }
        protected void DangNhap_Click(object sender, EventArgs e)
        {
            if (KiemtraDangnhap(tendangnhap.Text, StringProc.MD5Hash(pass.Text)))
            {
                txtResult.InnerHtml = "Thanh cong";
                Session["LOGIN_ADMIN"] = tendangnhap.Text;
                Response.Redirect("Member.aspx");
            }
            else
                txtResult.InnerHtml = "That bai";
        }
    }
}