<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Food_type.aspx.cs" Inherits="Food_Shop.Food_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="row">
        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Loại Sản Phẩm</h1>
                </div>
                <div class="form-group row">
                    <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <%-- <input type="text" class="form-control form-control-user" id="exampleFirstName" placeholder="First Name">--%>
                        <asp:Label ID="lbl_tenloai" runat="server" Text="Label">Tên Loại:</asp:Label>
                        <asp:TextBox ID="type_name" CssClass="form-control form-control-user" placeholder="Tên loại" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ref_name" runat="server" ErrorMessage="Tên loại sản phẩm không được để trống" forecolor="Red" ControlToValidate="type_name" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="lbl_pos" runat="server" Text="Label">Kiểu Loại:</asp:Label>
                        <asp:TextBox ID="type_pos" CssClass="form-control form-control-user" placeholder="Kiểu loại" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ref_loai" runat="server" ErrorMessage="Kiểu loại sản phẩm không được để trống" forecolor="Red" ControlToValidate="type_pos" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                    
                </div>
                <div class="form-group row">
                    <div class="col-lg-4 col-sm-6">
                      <asp:Label ID="Label2" runat="server" Text="Label">Trạng Thái:</asp:Label> 
                        <asp:DropDownList CssClass="form-control form-control-user" ID="Status" runat="server">
                          <asp:ListItem Text="Đang hoạt động" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Khóa" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="lbl_img" runat="server" Text="Label">Hình ảnh:</asp:Label>
                        <asp:FileUpload ID="filehinh" runat="server" />
                    </div>
                    <div class=" col-lg-4 col-sm-6"> 
                        <asp:Image ID="Image1" runat="server" Width="100px" Visible="False" Height="93px" />
                    </div>
                </div>
                    <asp:Button ID="register" runat="server" Text="Thêm loại sản phẩm" CssClass="btn btn-primary btn-user btn-block" OnClick="AddFood_type" ValidationGroup="kt" />
                   <div runat="server" id="txtResult" ></div>
                <hr>
            </div>
        </div>
    </div>
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Danh Sách Loại Sản Phẩm</h1>
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
                                <th>Tên Loại</th>
                                <th>Kiểu Loại</th>
                                <th>Trạng Thái</th>
                                <th>Hình ảnh</th>
                                <th>Người Thêm</th>
                                <th>Ngày</th>
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
                                            <%# Eval("type_id") %>
                                        </td>
                                        <td>
                                            <%# Eval("type_name") %>
                                        </td>
                                        <td>
                                            <%# Eval("type_pos") %>
                                        </td>
                                        
                                        <td>
                                            <%# (Eval("status").ToString()=="1"?"Đang Hoạt Động":"Khóa")%>
                                        </td>
                                        <td>
                                            <img src="img/<%# Eval("type_img") %>" style="width:50px;height:50px"/>
                                        </td>
                                        <td>
                                            <%# Eval("username") %>
                                        </td>
                                        <td>
                                            <%# Eval("modified") %>
                                        </td>
                                        <td><a href="?type_id=<%#Eval("type_id")%>"  class="btn btn-primary btn-icon-split"><span class="icon text-white-10">
                      <i class="fas fa-flag"></i>
                    </span>
                    <span class="text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Sửa</font></font></span></a></td>
                                        <td><a href="?id=<%#Eval("type_id")%>"  class="btn btn-primary btn-icon-split"><span class="icon text-white-10">
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
