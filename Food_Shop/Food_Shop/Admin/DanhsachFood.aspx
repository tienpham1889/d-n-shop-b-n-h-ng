<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DanhsachFood.aspx.cs" Inherits="Food_Shop.DanhsachFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
             <div class="container-fluid">

          <!-- Page Heading -->
          <h1 class="h3 mb-2 text-gray-800">Danh sách Sản Phẩm</h1>

          <!-- DataTales Example -->
          <div class="card shadow mb-4">
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
                          <th>Loại</th>
                          <th>Trạng thái</th>
                          <th>Người Thêm</th>
                          <th>Thời gian</th>
                        </tr>
                     
                  </thead> 
                    <tbody>
        </HeaderTemplate>
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
                    <%# Eval("status") %>
                </td>
                <td>
                    <%# Eval("username") %>
                </td>
                <td>
                    <%# Eval("modified") %>
                </td>
               </tr>
        </ItemTemplate>
        <FooterTemplate>
             </tbody>
                </table>
              </div>
            </div>
          </div>
        
        </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_vegefoodsConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [id], [name], [description], [price], [price_promo], [img], [unit], [precent_promo], [type], [status], [username], [modified] FROM [food]">
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
  <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

  <!-- Page level custom scripts -->
  <script src="js/demo/datatables-demo.js"></script>
</asp:Content>
