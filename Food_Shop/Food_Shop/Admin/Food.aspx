<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Food.aspx.cs" Inherits="Food_Shop.Food" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="row">
        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Sản Phẩm</h1>
                </div>
                <div class="form-group row">
                    <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <%-- <input type="text" class="form-control form-control-user" id="exampleFirstName" placeholder="First Name">--%>
                        <asp:Label ID="Label1" runat="server" Text="Label">Tên sản phẩm:</asp:Label>
                        <asp:TextBox ID="txt_tensp" CssClass="form-control form-control-user" placeholder="Ten san pham" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ref_username" runat="server" ErrorMessage="Ten san pham không được để trống" forecolor="Red" ControlToValidate="txt_tensp" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="Label8" runat="server" Text="Label">Mô tả:</asp:Label>
                        <asp:TextBox ID="txt_mota" CssClass="form-control form-control-user" placeholder="Mo ta" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Mô tả không được để trống" forecolor="Red" ControlToValidate="txt_mota" ValidationGroup="kt">

                        </asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="Label4" runat="server" Text="Label">Giá:</asp:Label>
                        <asp:TextBox ID="txtgia" CssClass="form-control form-control-user" placeholder="Gia" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_gia" runat="server" ErrorMessage="Gia san pham không được để trống" forecolor="Red" ControlToValidate="txtgia" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="Label3" runat="server" Text="Label">Giá giảm:</asp:Label>
                        <asp:TextBox ID="txt_giagiam" CssClass="form-control form-control-user" placeholder="Gia giam"  runat="server"></asp:TextBox>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="lbl_img" runat="server" Text="Label">Hình ảnh:</asp:Label>
                        <asp:FileUpload ID="fhinhfood" runat="server" />
                    </div>
                    <div class=" col-lg-4 col-sm-6"> 
                        <asp:Image ID="Image1" runat="server" Width="100px" Visible="False" Height="93px" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="Label6" runat="server" Text="Label">Loại:</asp:Label>
                        <asp:DropDownList CssClass="form-control form-control-user" ID="drloai" runat="server" DataSourceID="SqlDataSource1" DataTextField="type_name" DataValueField="type_pos">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_vegefoodsConnectionString %>" SelectCommand="SELECT [type_name], [type_pos] FROM [food_type]"></asp:SqlDataSource>
                    </div>
                   <div class=" col-lg-4 col-sm-6">
                      <asp:Label ID="Label7" runat="server" Text="Label">Đơn vị:</asp:Label>  
                       <asp:DropDownList CssClass="form-control form-control-user" ID="drDonvi" runat="server">
                          <asp:ListItem Text="VND" Value="VND"></asp:ListItem>
                            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                      <asp:Label ID="Label2" runat="server" Text="Label">Trạng Thái:</asp:Label>  
                        <asp:DropDownList CssClass="form-control form-control-user" ID="drStatus" runat="server">
                          <asp:ListItem Text="Đang hoạt động" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Khóa" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                    <asp:Button ID="register" runat="server" Text="Thêm sản phẩm" CssClass="btn btn-primary btn-user btn-block" OnClick="ThemSP_Click" ValidationGroup="kt" />
                   <div runat="server" id="txtResult" ></div>
       
                <hr>
                <div class="text-center">
                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                </div>
                <div class="text-center">
                    <a class="small" href="login.html">Already have an account? Login!</a>
                </div>
        </div>
    </div>
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Danh Sách Sản Phẩm</h1>
        <div class="col-sm-4">
            <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="btnSearch_Click" Text="Tìm Kiếm" CssClass="btn btn-info waves-effect waves-light" />
        </div>
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Danh Sách</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Tên sản phẩm</th>
                                <th>Mô tả</th>
                                <th>Giá</th>
                                <th>Giá giảm</th>
                                <th>Hình ảnh</th>
                                <th>Đơn vị</th>
                                <th>% Giảm</th>
                                <th>Loại sản phẩm</th>
                                <th>Trạng Thái</th>
                                <th>Người Thêm</th>
                                <th>Thời gian</th>
                                <th>

                                </th>
                                <th></th>
                            </tr>

                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">

                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("id") %>
                                        </td>
                                        <td>
                                            <%# Eval("name") %>
                                        </td>
                                        <td>
                                            <%# Eval("description") %>
                                        </td>
                                        <td>
                                            <%# Eval("price") %>
                                        </td>
                                        <td>
                                            <%# Eval("price_promo") %>
                                        </td>
                                        <td>
                                            <img src="img/<%# Eval("img") %>" style="width:50px;height:50px"/>
                                        </td>
                                        <td>
                                             <%# (Eval("unit").ToString()=="1"?"VND":"USD")%>
                                        </td>
                                        <td>
                                            <%# Eval("precent_promo") %>
                                        </td>
                                        <td>
                                            <%# Eval("type") %>
                                        </td>
                                        <td>
                                            <%# (Eval("status").ToString()=="1"?"Đang Hoạt Động":"Khóa")%>
                                        </td>
                                        
                                        <td>
                                            <%# Eval("username") %>
                                        </td>
                                        <td>
                                            <%# Eval("modified") %>
                                        </td>
                                        <td><a href="?food_id=<%#Eval("id")%>"  class="btn btn-primary btn-icon-split"><span class="icon text-white-10">
                      <i class="fas fa-flag"></i>
                    </span>
                    <span class="text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Sửa</font></font></span></a></td>
                                        <td><a href="?id=<%#Eval("id")%>"  class="btn btn-primary btn-icon-split"><span class="icon text-white-10">
                      <i class="fas fa-flag"></i>
                    </span>
                    <span class="text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Xóa</font></font></span></a></td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div>
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <a href="?page=<%#Eval("index") %><% if (Request["key"] != null) Response.Write("&key=" + Request["key"]); %><% if (Request["id"] != null) Response.Write("&id=" + Request["id"]); %>" style="background-color:<%# (Eval("active").ToString()=="1"?"yellow":"white")%>"><%#Eval("index") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">

</asp:Content>
