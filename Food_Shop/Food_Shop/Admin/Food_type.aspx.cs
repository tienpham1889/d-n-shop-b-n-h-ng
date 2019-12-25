using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Food_Shop.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace Food_Shop
{
    public partial class Food_type : System.Web.UI.Page
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
                if (Request["type_id"] != null)
                {
                    sQuery = "select * from food_type where type_id=" + Request["type_id"];
                    SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                    DataTable sp = new DataTable();
                    lst.Fill(sp);
                    type_name.Text = sp.Rows[0]["type_name"].ToString();
                    type_pos.Text = sp.Rows[0]["type_pos"].ToString();
                    Status.SelectedValue = sp.Rows[0]["status"].ToString();
                    Image1.Visible = true;
                    Image1.ImageUrl = "img/" + sp.Rows[0]["type_img"].ToString();
                    register.Text = "Update";

                }
                if (Request["id"] != null)
                {
                    FoodType food = new FoodType();
                    if (food.DeleteFoodType(Int32.Parse(Request["id"])) > 0)
                    {
                        txtResult.InnerHtml = "Xóa thành công ";
                    }
                    else
                    {
                        txtResult.InnerHtml = "Xóa không thành công";
                    }
                }
                sQuery = "Select * from food_type";
                if (Request["key"] != null)
                {
                    sQuery = sQuery + " where type_name like '%" + Request["key"].ToString() + "%'";
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
        public void xoatrang()
        {
            type_name.Text = "";
            type_pos.Text = "";
        }
        protected void AddFood_type(object sender, EventArgs e)
        {
            if (register.Text == "Thêm loại sản phẩm")
            {
                string sTypename = type_name.Text;
                int sPos = Convert.ToInt32(type_pos.Text);
                string sImg = filehinh.FileName;
                string sUsername = Session["lOGIN"].ToString();
                DateTime sModifine = DateTime.Now;
                int iStatus = Convert.ToInt32(Status.SelectedValue);


                //txtResult.InnerHtml = "Type name: " + sTypename +"Pos: "+sPos+" Img: "+sImg+" Username: "+ sUsername+" Modifine: "+sModifine+" Status: "+iStatus;

                FoodType food_type = new FoodType(sTypename, sPos, sImg, sUsername, sModifine.ToString(), iStatus);

                if (food_type.Ktraten(sTypename))
                {
                    txtResult.InnerHtml = "Sản phẩm: " + sTypename + " đã tồn tại";
                    xoatrang();
                    type_name.Focus();
                }
                else
                {
                    if (food_type.AddFood_type() == true)
                    {
                        txtResult.InnerHtml = "THÊM THÀNH CÔNG" + sTypename;
                    }
                    else
                    {
                        txtResult.InnerHtml = "THÊM Không THÀNH CÔNG" + sTypename;
                    }
                }
            }
            else if (register.Text == "Update") 
            {
                string sTypename = type_name.Text;
                int sPos = Convert.ToInt32(type_pos.Text);
                string sImg = filehinh.FileName;
                string sUsername = Session["lOGIN"].ToString();
                DateTime sModifine = DateTime.Now;
                int iStatus = Convert.ToInt32(Status.SelectedValue);

                //txtResult.InnerHtml = "Type name: " + sTypename +"Pos: "+sPos+" Img: "+sImg+" Username: "+ sUsername+" Modifine: "+sModifine+" Status: "+iStatus;

                FoodType food_type = new FoodType(sTypename, sPos, sImg, sUsername, sModifine.ToString(), iStatus);

                if (food_type.UpdateFood_type(Int32.Parse(Request["type_id"])) == true)
                {
                    txtResult.InnerHtml = "Sửa THÀNH CÔNG " + sTypename;
                    if (filehinh.HasFile)
                    {
                        filehinh.SaveAs(Server.MapPath("../Admin/img//" + filehinh.FileName));
                    }
                    xoatrang();
                }
                else
                {
                    txtResult.InnerHtml = "Sửa không THÀNH CÔNG " + sTypename;
                }
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Food_type.aspx?key=" + txtKey.Text);
        }
    }
}