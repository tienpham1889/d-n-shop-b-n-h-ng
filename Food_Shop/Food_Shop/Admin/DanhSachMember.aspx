<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachMember.aspx.cs" Inherits="Food_Shop.DanhSachSanPham" %>
<asp:Content ID="css" ContentPlaceHolderID="css" runat="server">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
 </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main_container" runat="server">

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
             <div class="container-fluid">

          <!-- Page Heading -->
          <h1 class="h3 mb-2 text-gray-800">Tables</h1>
          <p class="mb-4">DataTables is a third party plugin that is used to generate the demo table below. For more information about DataTables, please visit the <a target="_blank" href="https://datatables.net">official DataTables documentation</a>.</p>

          <!-- DataTales Example -->
          <div class="card shadow mb-4">
            <div class="card-header py-3">
              <h6 class="m-0 font-weight-bold text-primary">DataTables Example</h6>
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
                        </tr>
                     
                  </thead> 
                    <tbody>
        </HeaderTemplate>
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
                    <%# Eval("status") %>
                </td>
                <td>
                    <%# Eval("role") %>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:DB_vegefoodsConnectionString %>" DeleteCommand="DELETE FROM [member] WHERE [username] = @original_username AND (([name] = @original_name) OR ([name] IS NULL AND @original_name IS NULL)) AND (([phone] = @original_phone) OR ([phone] IS NULL AND @original_phone IS NULL)) AND (([role] = @original_role) OR ([role] IS NULL AND @original_role IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL)) AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL))" InsertCommand="INSERT INTO [member] ([username], [name], [phone], [role], [status], [email]) VALUES (@username, @name, @phone, @role, @status, @email)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [username], [name], [phone], [role], [status], [email] FROM [member]" UpdateCommand="UPDATE [member] SET [name] = @name, [phone] = @phone, [role] = @role, [status] = @status, [email] = @email WHERE [username] = @original_username AND (([name] = @original_name) OR ([name] IS NULL AND @original_name IS NULL)) AND (([phone] = @original_phone) OR ([phone] IS NULL AND @original_phone IS NULL)) AND (([role] = @original_role) OR ([role] IS NULL AND @original_role IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL)) AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_name" Type="String" />
            <asp:Parameter Name="original_phone" Type="String" />
            <asp:Parameter Name="original_role" Type="Int32" />
            <asp:Parameter Name="original_status" Type="Int32" />
            <asp:Parameter Name="original_email" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="role" Type="Int32" />
            <asp:Parameter Name="status" Type="Int32" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="role" Type="Int32" />
            <asp:Parameter Name="status" Type="Int32" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_name" Type="String" />
            <asp:Parameter Name="original_phone" Type="String" />
            <asp:Parameter Name="original_role" Type="Int32" />
            <asp:Parameter Name="original_status" Type="Int32" />
            <asp:Parameter Name="original_email" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
   
                        
                   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" runat="server">
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
  <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

  <!-- Page level custom scripts -->
  <script src="js/demo/datatables-demo.js"></script>
</asp:Content>
