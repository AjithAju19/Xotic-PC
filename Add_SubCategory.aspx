<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Add_SubCategory.aspx.cs" Inherits="Add_SubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <br /><br />
    <div class="container">
        <div class="form-horizontal">
            <h2>Add Sub Category</h2>
            <hr /> 
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Sub Category Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Cssclass ="text-danger" runat="server" ErrorMessage="Please enter subcategory" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            </div>
            </div>


            <div class="form-group">
                <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Main Category"></asp:Label>
            <div class="col-md-3">

                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="SubCategory_SelectedIndexChanged" ></asp:DropDownList>      

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Cssclass ="text-danger" runat="server" ErrorMessage="Please enter main category id" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
            </div>
            </div>

            <br /><br />

            <div class="form-group">
                <div class="col-md-3"></div>
                <div class="col-md-6">

                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Add Sub Category" OnClick = "Addsubcategory_Click" />
                  
            </div>
            </div>

            </div>


         <h1>Sub Category</h1>
         <hr />

         <div class="panel panel-default">
             <div class="panel-heading">All Sub Categories</div>
        
             <asp:Repeater ID="Repeater1" runat="server">
             

             <HeaderTemplate>

                 <table class="table">
                 <thead>
                 <tr>
                     <th>#</th>
                     <th>Sub Category</th>
                     <th>Main Category</th>
                      <th>Edit</th>
                 </tr>
                 </thead>

                 <tbody>

             </HeaderTemplate>

             <ItemTemplate>

                 <tr>
                         <td><%# Eval("subcatid")%></td>
                         <td><%# Eval("subcatname")%></td>
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



</asp:Content>

