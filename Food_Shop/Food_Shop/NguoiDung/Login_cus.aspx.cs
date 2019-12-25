using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Food_Shop.App_Code;

namespace Food_Shop.NguoiDung
{
    public partial class Login_cus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btn_login_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            if(tendangnhap.Text == "" || pass.Text == "")
            {
                txtResult.InnerHtml = "Tên đăng nhập và Mật khẩu không được bỏ trống";
                tendangnhap.Focus();
            }
            if (cus.KiemtraDangnhap(tendangnhap.Text, StringProc.MD5Hash(pass.Text)))
            {
                txtResult.InnerHtml = "Đăng Nhập thành công";
                Session["lOGIN_Cus"] = tendangnhap.Text;
                Response.Redirect("TrangChu.aspx");
            }
            else
                txtResult.InnerHtml = "Tên đăng nhập hoặc mật khẩu không đúng";
        }
    }
    
}