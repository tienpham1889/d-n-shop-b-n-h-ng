﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/TrangChu.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Food_Shop.NguoiDung.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- END nav -->

    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_1.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span> <span>Checkout</span></p>
                    <h1 class="mb-0 bread">Checkout</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-7 ftco-animate">
                    <form action="#" class="billing-form">
                        <h3 class="mb-4 billing-heading">Thông tin khách hàng</h3>
                        <div class="row align-items-end">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="firstname">Họ và tên</label>
                                    <%--<input type="text" class="form-control" placeholder="">--%>
                                    <asp:TextBox ID="txt_cus_name" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ref_cus_name" runat="server" ErrorMessage="Tên không được bỏ trống" ForeColor="Red" ControlToValidate="txt_cus_name"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="phone">Số điện thoại</label>
                                    <%--<input type="text" class="form-control" placeholder="">--%>
                                    <asp:TextBox ID="txt_phone" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ref_phone" runat="server" ErrorMessage="SĐT không được bỏ trống" ForeColor="Red" ControlToValidate="txt_phone"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="streetaddress">Địa chỉ</label>
                                    <%--<input type="text" class="form-control" placeholder="">--%>
                                    <asp:TextBox ID="txt_add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ref_add" runat="server" ErrorMessage="Địa chỉ không được bỏ trống" ForeColor="Red" ControlToValidate="txt_add"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Label">Trạng Thái:</asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="drStatus" runat="server">
                                        <asp:ListItem Text="Khách mới" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Khách cũ" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </form>
                    <!-- END -->
                </div>
                <div class="col-xl-5">
                    <div class="row mt-5 pt-3">
                        <div class="col-md-12 d-flex mb-5">
                            <div class="cart-detail cart-total p-3 p-md-4">
                                <h3 class="billing-heading mb-4">Cart Total</h3>
                                <p class="d-flex">
                                    <span>Subtotal</span>
                                    <asp:Label ID="lab_subtong" runat="server" Text="0"></asp:Label>
                                </p>
                                <p class="d-flex">
                                    <span>Quantity</span>
                                    <asp:Label ID="lab_quan" runat="server" Text="0"></asp:Label>
                                </p>
                                <hr>
                                <p class="d-flex total-price">
                                    <span>Total</span>
                                    <asp:Label ID="txt_tongcong" runat="server" Text="0"></asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="cart-detail p-3 p-md-4">
                                <p>
                                    <asp:LinkButton ID="btn_checkout" CssClass="btn btn-primary py-3 px-4" runat="server" OnClick="btn_checkout_Click">Đặt hàng</asp:LinkButton>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .col-md-8 -->
            </div>
        </div>
    </section>
    <!-- .section -->

    <section class="ftco-section ftco-no-pt ftco-no-pb py-5 bg-light">
        <div class="container py-4">
            <div class="row d-flex justify-content-center py-5">
                <div class="col-md-6">
                    <h2 style="font-size: 22px;" class="mb-0">Subcribe to our Newsletter</h2>
                    <span>Get e-mail updates about our latest shops and special offers</span>
                </div>
                <div class="col-md-6 d-flex align-items-center">
                    <form action="#" class="subscribe-form">
                        <div class="form-group d-flex">
                            <input type="text" class="form-control" placeholder="Enter email address">
                            <input type="submit" value="Subscribe" class="submit px-3">
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
    <footer class="ftco-footer ftco-section">
        <div class="container">
            <div class="row">
                <div class="mouse">
                    <a href="#" class="mouse-icon">
                        <div class="mouse-wheel"><span class="ion-ios-arrow-up"></span></div>
                    </a>
                </div>
            </div>
            <div class="row mb-5">
                <div class="col-md">
                    <div class="ftco-footer-widget mb-4">
                        <h2 class="ftco-heading-2">Vegefoods</h2>
                        <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <ul class="ftco-footer-social list-unstyled float-md-left float-lft mt-5">
                            <li class="ftco-animate"><a href="#"><span class="icon-twitter"></span></a></li>
                            <li class="ftco-animate"><a href="#"><span class="icon-facebook"></span></a></li>
                            <li class="ftco-animate"><a href="#"><span class="icon-instagram"></span></a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-md">
                    <div class="ftco-footer-widget mb-4 ml-md-5">
                        <h2 class="ftco-heading-2">Menu</h2>
                        <ul class="list-unstyled">
                            <li><a href="#" class="py-2 d-block">Shop</a></li>
                            <li><a href="#" class="py-2 d-block">About</a></li>
                            <li><a href="#" class="py-2 d-block">Journal</a></li>
                            <li><a href="#" class="py-2 d-block">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="ftco-footer-widget mb-4">
                        <h2 class="ftco-heading-2">Help</h2>
                        <div class="d-flex">
                            <ul class="list-unstyled mr-l-5 pr-l-3 mr-4">
                                <li><a href="#" class="py-2 d-block">Shipping Information</a></li>
                                <li><a href="#" class="py-2 d-block">Returns &amp; Exchange</a></li>
                                <li><a href="#" class="py-2 d-block">Terms &amp; Conditions</a></li>
                                <li><a href="#" class="py-2 d-block">Privacy Policy</a></li>
                            </ul>
                            <ul class="list-unstyled">
                                <li><a href="#" class="py-2 d-block">FAQs</a></li>
                                <li><a href="#" class="py-2 d-block">Contact</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md">
                    <div class="ftco-footer-widget mb-4">
                        <h2 class="ftco-heading-2">Have a Questions?</h2>
                        <div class="block-23 mb-3">
                            <ul>
                                <li><span class="icon icon-map-marker"></span><span class="text">203 Fake St. Mountain View, San Francisco, California, USA</span></li>
                                <li><a href="#"><span class="icon icon-phone"></span><span class="text">+2 392 3929 210</span></a></li>
                                <li><a href="#"><span class="icon icon-envelope"></span><span class="text">info@yourdomain.com</span></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">

                    <p>
                        <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                        Copyright &copy;<script>document.write(new Date().getFullYear());</script>
                        All rights reserved | This template is made with <i class="icon-heart color-danger" aria-hidden="true"></i>by <a href="https://colorlib.com" target="_blank">Colorlib</a>
                        <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                    </p>
                </div>
            </div>
        </div>
    </footer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script>
        $(document).ready(function () {

            var quantitiy = 0;
            $('.quantity-right-plus').click(function (e) {

                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity').val());

                // If is not undefined

                $('#quantity').val(quantity + 1);


                // Increment

            });

            $('.quantity-left-minus').click(function (e) {
                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity').val());

                // If is not undefined

                // Increment
                if (quantity > 0) {
                    $('#quantity').val(quantity - 1);
                }
            });

        });
    </script>
</asp:Content>
