<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Add_Category.aspx.cs" Inherits="Add_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <br /><br /><br /><br />

     <div class="container">
        <div class="form-horizontal">
            <h2>Add Category</h2>
            <hr /> 
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Category Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Cssclass ="text-danger" runat="server" ErrorMessage="Please enter category" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            </div>
            </div>



            <div class="form-group">
                <div class="col-md-3"></div>
                <div class="col-md-6">

                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Add Category" OnClick = "Addcategory_Click" />
                  
            </div>
            </div>


            <h1>Category</h1>
         <hr />

         <div class="panel panel-default">
             <div class="panel-heading">All Categories</div>
        
             <asp:Repeater ID="Repeater1" runat="server">
             

             <HeaderTemplate>

                 <table class="table">
                 <thead>
                 <tr>
                     <th>#</th>
                     <th>Category</th>
                      <th>Edit</th>
                 </tr>
                 </thead>

                 <tbody>

             </HeaderTemplate>

             <ItemTemplate>

                 <tr>
                         <td><%# Eval("catid")%></td>
                         <td><%# Eval("catname")%></td>
                         <td>Edit</td>
                     </tr>

             </ItemTemplate>

              <FooterTemplate>

                  </tbody>
             </table>

              </FooterTemplate>

                 </asp:Repeater>

         </div>

         </div>


            </div>



            </div>

         

</asp:Content>

