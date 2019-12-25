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
    public partial class Food : System.Web.UI.Page
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
                if (Request["food_id"] != null)
                {
                    sQuery = "select * from food where id=" + Request["food_id"];
                    SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                    DataTable sp = new DataTable();
                    lst.Fill(sp);
                    txt_tensp.Text = sp.Rows[0]["name"].ToString();
                    txt_mota.Text = sp.Rows[0]["description"].ToString();
                    txtgia.Text = sp.Rows[0]["price"].ToString();
                    txt_giagiam.Text = sp.Rows[0]["price_promo"].ToString();
                    drloai.SelectedValue = sp.Rows[0]["type"].ToString();
                    drDonvi.SelectedValue = sp.Rows[0]["unit"].ToString();
                    drStatus.SelectedValue = sp.Rows[0]["status"].ToString();
                    Image1.Visible = true;
                    Image1.ImageUrl = "img/" + sp.Rows[0]["img"].ToString();
                    register.Text = "Update";

                }
                if (Request["id"] != null)
                {
                    sQuery = "select * from food where id=" + Request["id"];
                    SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                    DataTable sp = new DataTable();
                    lst.Fill(sp);
                    int id = Int32.Parse(sp.Rows[0]["id"].ToString());
                    Food2 food = new Food2();
                    if (food.DeleteFood(id) > 0)
                    {
                        txtResult.InnerHtml = "Xóa thành công ";
                    }
                    else
                    {
                        txtResult.InnerHtml = "Xóa không thành công";
                    }
                }
                sQuery = "Select * from food";
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
        public void xoatrang()
        {
            txt_tensp.Text = "";
            txt_mota.Text = "";
            txt_giagiam.Text = "";
            txtgia.Text = "";
        }
        protected void ThemSP_Click(object sender, EventArgs e)
        {
            if (register.Text == "Thêm sản phẩm")
            {
                string sName = txt_tensp.Text;
                string sMota = txt_mota.Text;
                decimal sGia = Convert.ToDecimal(txtgia.Text);
                decimal sGiaGiam = Convert.ToDecimal(txt_giagiam.Text);
                string simg = fhinhfood.FileName;
                string sDonvi = drDonvi.SelectedValue;
                int sLoai = Convert.ToInt32(drloai.SelectedValue);
                decimal phantram = ((sGia-sGiaGiam)*100)/sGia;
                string sUsername = Session["lOGIN_ADMIN"].ToString();
                DateTime sModifine = DateTime.Now;
                int iStatus = Convert.ToInt32(drStatus.SelectedValue);

                Food2 food = new Food2(sName, sMota, sGia, sGiaGiam, simg, sDonvi,phantram ,sLoai, iStatus, sUsername, sModifine.ToString());
                if (food.Ktraten(sName))
                {
                    txtResult.InnerHtml = "Sản phẩm: " + sName + " đã tồn tại";
                    xoatrang();
                    txt_tensp.Focus();
                }
                else
                {
                    if (food.AddFood() == true)
                    {
                        txtResult.InnerHtml = "THÊM THÀNH CÔNG" + sName;
                        if (fhinhfood.HasFile)
                        {
                            fhinhfood.SaveAs(Server.MapPath("../Admin/img//" + fhinhfood.FileName));
                        }
                        xoatrang();
                    }
                    else
                    {
                        txtResult.InnerHtml = "THÊM Không THÀNH CÔNG" + sName;
                    }
                }

            }
            else if (register.Text == "Update")
            {
                string sName = txt_tensp.Text;
                string sMota = txt_mota.Text;
                decimal sGia = Convert.ToDecimal(txtgia.Text);
                decimal sGiaGiam = Convert.ToDecimal(txt_giagiam.Text);
                string simg = fhinhfood.FileName;
                string sDonvi = drDonvi.SelectedValue;
                decimal phantram = ((sGia - sGiaGiam) * 100) / sGia;
                int sLoai = Convert.ToInt32(drloai.SelectedValue);
                string sUsername = Session["lOGIN_ADMIN"].ToString();
                DateTime sModifine = DateTime.Now;
                int iStatus = Convert.ToInt32(drStatus.SelectedValue);
                SqlConnection con = new SqlConnection(@"Data Source=MR-TIEN\SQLEXPRESS;Initial Catalog=DB_vegefoods;Integrated Security=True");
                string sQuery = "select * from food where id=" + Request["food_id"];
                SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                DataTable sp = new DataTable();
                lst.Fill(sp);
                int id = Int32.Parse(sp.Rows[0]["id"].ToString());
                Food2 food = new Food2(sName, sMota, sGia, sGiaGiam, simg, sDonvi, phantram ,sLoai, iStatus, sUsername, sModifine.ToString());
                if (food.UpdateFood(id))
                {
                    txtResult.InnerHtml = "Sửa THÀNH CÔNG " + sName;
                    register.Text = "Thêm sản phẩm";
                    if (fhinhfood.HasFile)
                    {
                        fhinhfood.SaveAs(Server.MapPath("../Admin/img//" + fhinhfood.FileName));
                    }
                    xoatrang();
                    
                }
                else
                {
                    txtResult.InnerHtml = "Sửa khong THÀNH CÔNG ";
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Food.aspx?key=" + txtKey.Text);
        }
    }
   
}