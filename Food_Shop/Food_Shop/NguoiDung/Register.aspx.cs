using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Food_Shop.App_Code;

namespace Food_Shop.NguoiDung
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void blank()
        {
            txt_username.Text = "";
            txt_pass.Text = "";
            txt_add.Text = "";
            txt_name.Text = "";
            txt_phone.Text = "";
            txt_repass.Text = "";
        }

        protected void btn_dangky_Click(object sender, EventArgs e)
        {
            string sUsername = txt_username.Text;
            string sName = txt_name.Text;
            string sPass = txt_pass.Text;
            string sPhone = txt_phone.Text;
            string sAddress = txt_add.Text;
            int iStatus = Convert.ToInt32(drStatus.SelectedValue);
            DateTime sCreated= DateTime.Now;


            //txtResult.InnerHtml = "User name: " + sUsername +"Pass: "+sPass+" RePass: "+sRepeatPage+" Phone: "+ sPhone+" Email: "+sEmail+" Role: "+iRole+" Status: "+iStatus;

            Customer cus = new Customer(sUsername, sPass, sName, sPhone, sAddress, iStatus, sCreated.ToString());
            if (cus.Ktraten(sUsername))
            {
                txtResult.InnerHtml = "Username: " + sUsername + " da ton tai";
                blank();
                txt_username.Focus();
            }
            else
            {
                if (cus.AddCustomer() == true)
                {
                    txtResult.InnerHtml = "THÊM THÀNH CÔNG" + sUsername;
                    Response.Redirect("Login_cus.aspx");
                }
                else
                {
                    txtResult.InnerHtml = "THÊM Không THÀNH CÔNG" + sUsername;
                }
            }
        }
    }
}