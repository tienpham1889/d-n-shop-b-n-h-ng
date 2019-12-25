<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Food_Shop.NguoiDung.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Đăng ký tài khoản</title>

    <!-- Custom fonts for this template-->
    <link href="~/Admin/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="~/Admin/css/sb-admin-2.min.css" rel="stylesheet">
</head>
<body class="bg-gradient-primary">
    <form id="form1" runat="server">
        <div class="container">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
                                </div>
                                <form class="user">
                                    <div class="form-group row">
                                        <div class="col-sm-6">
                                            <%--<input type="text" class="form-control form-control-user" id="txt_username" placeholder="Tên đăng nhập">--%>
                                            <asp:TextBox ID="txt_username" CssClass="form-control form-control-user" runat="server" placeholder="Tên đăng nhập"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_username" runat="server" ErrorMessage="Nhập tên đăng nhập" ForeColor="Red" ControlToValidate="txt_username"></asp:RequiredFieldValidator>
                                        </div>
                                        
                                        <div class="col-sm-6">
                                            <asp:DropDownList CssClass="form-control form-control-user" ID="drStatus" runat="server">
                                                <asp:ListItem Text="Khách mới" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Khách hàng tiềm năng" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <%--<input type="password" class="form-control form-control-user" id="txt_pass" placeholder="Password">--%>
                                            <asp:TextBox ID="txt_pass" TextMode="Password" CssClass="form-control form-control-user" runat="server" placeholder="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_pass" runat="server" ErrorMessage="Password không được để trống" ForeColor="Red" ControlToValidate="txt_pass" >
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-sm-6">
                                            <%--<input type="password" class="form-control form-control-user" id="txt_repass" placeholder="Repeat Password">--%>
                                            <asp:TextBox ID="txt_repass" TextMode="Password" CssClass="form-control form-control-user" runat="server" placeholder="Repeat Password"></asp:TextBox>
                                            <asp:CompareValidator ID="cv_repass" runat="server" ErrorMessage="Pass phải giống nhau" ControlToCompare="txt_pass" ForeColor="Red" ControlToValidate="txt_repass"></asp:CompareValidator>
                                        </div>
                                        
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <%--<input type="text" class="form-control form-control-user" id="txt_name" placeholder="Họ tên">--%>
                                            <asp:TextBox ID="txt_name" CssClass="form-control form-control-user" runat="server" placeholder="Họ tên"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Tên không được để trống" ForeColor="Red" ControlToValidate="txt_name"></asp:RequiredFieldValidator>
                                        </div>
                                        
                                        <div class="col-sm-6">
                                            <%--<input type="text" class="form-control form-control-user" id="txt_phone" placeholder="SĐT">--%>
                                            <asp:TextBox ID="txt_phone" CssClass="form-control form-control-user" runat="server" placeholder="SĐT"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_phone" runat="server" ErrorMessage="SĐT không được để trống" ForeColor="Red" ControlToValidate="txt_phone"></asp:RequiredFieldValidator>
                                        </div>
                                        
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-12">
                                            <%--<input type="text" class="form-control form-control-user" id="txt_add" placeholder="Địa chỉ">--%>
                                            <asp:TextBox ID="txt_add" CssClass="form-control form-control-user" runat="server" placeholder="Địa chỉ"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_add" runat="server" ErrorMessage="Địa chỉ không được để trống" ForeColor="Red" ControlToValidate="txt_add"></asp:RequiredFieldValidator>
                                        </div>
                                        
                                    </div>
                                    <%--<a href="#" class="btn btn-primary btn-user btn-block">Register Account
                                    </a>--%>
                                    <asp:Button ID="btn_dangky" runat="server" Text="Register Account" CssClass="btn btn-primary btn-user btn-block" OnClick="btn_dangky_Click" />
                                    <div runat="server" id="txtResult"></div>
                                    <hr>
                                    <a href="#" class="btn btn-google btn-user btn-block">
                                        <i class="fab fa-google fa-fw"></i>Register with Google
                                    </a>
                                    <a href="#" class="btn btn-facebook btn-user btn-block">
                                        <i class="fab fa-facebook-f fa-fw"></i>Register with Facebook
                                    </a>
                                </form>
                                <hr>
                                <div class="text-center">
                                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                                </div>
                                <div class="text-center">
                                    <a class="small" href="Login_cus.aspx">Already have an account? Login!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="~/Admin/vendor/jquery/jquery.min.js"></script>
        <script src="~/Admin/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="~/Admin/vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="~/Admin/js/sb-admin-2.min.js"></script>
    </form>
</body>
</html>
