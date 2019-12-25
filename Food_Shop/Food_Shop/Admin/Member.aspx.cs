using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Food_Shop.App_Code;

namespace Food_Shop
{
    public partial class Member : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lOGIN_ADMIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog=DB_vegefoods;Integrated Security=True");
                string sQuery = "";
                if (Request["username"] != null)
                {
                    sQuery = "select * from member where username='" + Request["username"] + "'";
                    SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                    DataTable sp = new DataTable();
                    lst.Fill(sp);
                    exampleUserName.Text = sp.Rows[0]["username"].ToString();
                    exampleName.Text = sp.Rows[0]["name"].ToString();
                    examplePhone.Text = sp.Rows[0]["phone"].ToString();
                    exampleStatus.SelectedValue = sp.Rows[0]["status"].ToString();
                    exampleRole.SelectedValue = sp.Rows[0]["role"].ToString();
                    exampleInputEmail.Text = sp.Rows[0]["email"].ToString();
                    btn_dangky.Text = "Update";

                }
                if(Request["us"] != null)
                {
                    sQuery = "select * from member where username='" + Request["us"] + "'";
                    SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                    DataTable sp = new DataTable();
                    lst.Fill(sp);
                    exampleUserName.Text = sp.Rows[0]["username"].ToString();
                    string ten = exampleUserName.Text;
                    Account acc = new Account();
                    if (acc.DeleteMember(ten)>0)
                    {
                        txtResult.InnerHtml = "Xóa thành công " + ten;
                        Response.Redirect("Member.aspx");
                    }
                    else
                    {
                        txtResult.InnerHtml = "Xóa không thành công";
                    }
                }
                sQuery = "Select * from member";
                if (Request["key"] != null)
                {
                    sQuery = sQuery + " where name like '%" + Request["key"].ToString() + "%'";
                }
                SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int so_item_1trang = 10;
                int so_trang = dt.Rows.Count / so_item_1trang + (dt.Rows.Count % so_item_1trang == 0 ? 0 : 1);
                int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
                int from = (page - 1) * 10;
                int to = page * 10 - 1;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (i < from || i > to)
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                DataTable dtPage = new DataTable();
                dtPage.Columns.Add("index");
                dtPage.Columns.Add("active");
                for (int i = 1; i <= so_trang; i++)
                {
                    DataRow dr = dtPage.NewRow();
                    dr["index"] = i;

                    if ((Request["page"] == null && i == 1) || (Request["page"] != null && Convert.ToInt32(Request["page"]) == i))
                        dr["active"] = 1;
                    else
                        dr["active"] = 0;
                    dtPage.Rows.Add(dr);
                }
                Repeater2.DataSource = dtPage;
                Repeater2.DataBind();
            }
            
        }
        public void blank()
        {
            exampleUserName.Text = "";
            exampleName.Text = "";
            examplePhone.Text = "";
            exampleInputEmail.Text = "";
        }
        protected void register_Click(object sender, EventArgs e)
        {
            if (btn_dangky.Text == "Đăng ký")
            {
                string sUsername = exampleUserName.Text;
                string sName = exampleName.Text;
                string sPass = exampleInputPassword.Text;
                string sRepeatPage = exampleRepeatPassword.Text;
                string sPhone = examplePhone.Text;
                string sEmail = exampleInputEmail.Text;
                int iRole = Convert.ToInt32(exampleRole.SelectedValue);
                int iStatus = Convert.ToInt32(exampleStatus.SelectedValue);


                //txtResult.InnerHtml = "User name: " + sUsername +"Pass: "+sPass+" RePass: "+sRepeatPage+" Phone: "+ sPhone+" Email: "+sEmail+" Role: "+iRole+" Status: "+iStatus;

                Account acc = new Account(sUsername, sName, sPass, sPhone, iRole, iStatus, sEmail);
                if (acc.Ktraten(sUsername))
                {
                    txtResult.InnerHtml = "Username: " + sUsername + " da ton tai";
                    blank();
                    exampleUserName.Focus();
                }
                else
                {
                    if (acc.AddMember() == true)
                    {
                        txtResult.InnerHtml = "THÊM THÀNH CÔNG" + sUsername;
                    }
                }
            }
            else if(btn_dangky.Text=="Update")
            {
                string sUsername = exampleUserName.Text;
                string sName = exampleName.Text;
                string sPass = exampleInputPassword.Text;
                string sRepeatPage = exampleRepeatPassword.Text;
                string sPhone = examplePhone.Text;
                string sEmail = exampleInputEmail.Text;
                int iRole = Convert.ToInt32(exampleRole.SelectedValue);
                int iStatus = Convert.ToInt32(exampleStatus.SelectedValue);


                //txtResult.InnerHtml = "User name: " + sUsername +"Pass: "+sPass+" RePass: "+sRepeatPage+" Phone: "+ sPhone+" Email: "+sEmail+" Role: "+iRole+" Status: "+iStatus + "Name:"+sName;

                Account acc = new Account(sUsername, sName, sPass, sPhone, iRole, iStatus, sEmail);
                if (acc.UpdateMember(sUsername))
                {
                    txtResult.InnerHtml = "Sửa THÀNH CÔNG " + sUsername;
                    blank();
                }
                else
                {
                    txtResult.InnerHtml = "Sửa không THÀNH CÔNG";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member.aspx?key=" + txtKey.Text);
        }
    }
}