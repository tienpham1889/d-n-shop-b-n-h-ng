<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Food_Shop.Member" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="row">
        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Tài Khoản</h1>
                </div>
                <div class="form-group row">
                    <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <%-- <input type="text" class="form-control form-control-user" id="exampleFirstName" placeholder="First Name">--%>
                        <asp:TextBox ID="exampleUserName" CssClass="form-control form-control-user" placeholder="User Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ref_username" runat="server" ErrorMessage="UserName không được để trống" ForeColor="Red" ControlToValidate="exampleUserName" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">

                        <asp:TextBox ID="exampleName" CssClass="form-control form-control-user" placeholder="Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Name không được để trống" ForeColor="Red" ControlToValidate="exampleName" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:TextBox ID="exampleInputEmail" CssClass="form-control form-control-user" placeholder="Email" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Không phai email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ControlToValidate="exampleInputEmail" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <asp:TextBox ID="exampleInputPassword" CssClass="form-control form-control-user" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_pass" runat="server" ErrorMessage="Password không được để trống" ForeColor="Red" ControlToValidate="exampleInputPassword" ValidationGroup="kt"></asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:TextBox ID="exampleRepeatPassword" CssClass="form-control form-control-user" placeholder="Repeat Password" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="cv_repass" runat="server" ErrorMessage="Pass phải giống nhau" ControlToCompare="exampleInputPassword" ControlToValidate="exampleRepeatPassword" ValidationGroup="kt"></asp:CompareValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">

                        <asp:TextBox ID="examplePhone" CssClass="form-control form-control-user" placeholder="Phone" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="Label2" runat="server" Text="Label">Status:</asp:Label>
                        <asp:DropDownList CssClass="form-control form-control-user" ID="exampleStatus" runat="server">
                            <asp:ListItem Text="Đang hoạt động" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Khóa" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class=" col-lg-4 col-sm-6">

                        <asp:Label ID="Label1" runat="server" Text="Label">Role:</asp:Label>
                        <asp:DropDownList CssClass="form-control form-control-user" ID="exampleRole" runat="server">

                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">Editor</asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>
                <asp:Button ID="btn_dangky" runat="server" Text="Đăng ký" CssClass="btn btn-primary btn-user btn-block" OnClick="register_Click" ValidationGroup="kt" />
                <div runat="server" id="txtResult"></div>

                <hr>
                <div class="text-center">
                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                </div>
                <div class="text-center">
                    <a class="small" href="login.html">Already have an account? Login!</a>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Danh Sách Admin</h1>
        <%--//Tìm kiếm--%>
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
                                <th>Username</th>
                                <th>Tên Admin</th>
                                <th>Số điện thoại</th>
                                <th>Trạng thái</th>
                                <th>Loại Member</th>
                                <th>Email</th>
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
                                            <%# Eval("username") %>
                                        </td>
                                        <td>
                                            <%# Eval("name") %>
                                        </td>
                                        <td>
                                            <%# Eval("phone") %>
                                        </td>
                                        <td>
                                            <%# (Eval("status").ToString()=="1"?"Đang Hoạt Động":"Khóa")%>
                                        </td>
                                        <td>
                                            <%# (Eval("role").ToString()=="1"?"Admin":"Editor")%>
                                        </td>
                                        <td>
                                            <%# Eval("email") %>
                                        </td>
                                        <td><a href="?username=<%#Eval("username")%>"  class="btn btn-primary btn-icon-split"><span class="icon text-white-10">
                      <i class="fas fa-flag"></i>
                    </span>
                    <span class="text"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Sửa</font></font></span></a></td>
                                        <td><a href="?us=<%#Eval("username")%>"  class="btn btn-primary btn-icon-split"><span class="icon text-white-10">
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
