<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Food_Shop.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="login" runat="server">
    <div class="p-5">
        <div class="text-center">
            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
        </div>
        <form class="user">
            <div class="form-group">
                <%--<input type="email" class="form-control form-control-user" id="exampleInputEmail" aria-describedby="emailHelp" placeholder="Enter Email Address...">--%>
                <asp:TextBox ID="tendangnhap" CssClass="form-control form-control-user" placeholder="Nhap ten dang nhap..." runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <%--<input type="password" class="form-control form-control-user" id="exampleInputPassword" placeholder="Password">--%>
                <asp:TextBox ID="pass" TextMode="Password" CssClass="form-control form-control-user" placeholder="Password" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="custom-control custom-checkbox small">
                    <input type="checkbox" class="custom-control-input" id="customCheck">
                    <label class="custom-control-label" for="customCheck">Remember Me</label>
                </div>
            </div>
            <div runat="server" id="txtResult"></div>
            <%--                    <a href="index.html" class="btn btn-primary btn-user btn-block">
                      Login
                    </a>--%>
            <asp:Button ID="btn_login" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Login" OnClick="DangNhap_Click" />
            <hr>
            <a href="index.html" class="btn btn-google btn-user btn-block">
                <i class="fab fa-google fa-fw"></i>Login with Google
                    </a>
            <a href="index.html" class="btn btn-facebook btn-user btn-block">
                <i class="fab fa-facebook-f fa-fw"></i>Login with Facebook
                    </a>
        </form>
        <hr>
        <div class="text-center">
            <a class="small" href="forgot-password.html">Forgot Password?</a>
        </div>
        <div class="text-center">
            <a class="small" href="register.html">Create an Account!</a>
        </div>
    </div>
</asp:Content>
