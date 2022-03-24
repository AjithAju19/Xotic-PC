<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Add_Product.aspx.cs" Inherits="Add_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">


    <div class="container">
        <div class="form-horizontal">

            <br /><br /><br />

            <h2>Add Product</h2>
            <hr />

            <div class="form-group">
                <asp:Label ID="Label1" runat="server"  CssClass="col-md-2 control-label" Text="Product Name"></asp:Label>
            
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox1" CssClass ="form-control" runat="server"></asp:TextBox>
                </div>
            
            
            </div>

             <div class="form-group">
                <asp:Label ID="Label2" runat="server"  CssClass="col-md-2 control-label" Text="Price"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            
            </div>



            <div class="form-group">
                <asp:Label ID="Label3" runat="server"  CssClass="col-md-2 control-label" Text="Selling Price"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
            
            </div>


            <div class="form-group">
                <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Description"></asp:Label>
            <div class="col-md-3">
                
              <asp:TextBox ID="TextBox4" TextMode="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
                
            </div>
            
            
            </div>


             <div class="form-group">
                <asp:Label ID="Label15" CssClass="col-md-2 control-label" runat="server" Text="Manufacturer"></asp:Label>
            <div class="col-md-3">
                
               <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                
            </div>
            
            
            </div>


            <div class="form-group">
                <asp:Label ID="Label5" CssClass="col-md-2 control-label" runat="server" Text="Category"></asp:Label>
            <div class="col-md-3">
                
               <asp:DropDownList ID="ddl2" CssClass="form-control" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="ddl2_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
            
            
            </div>



            <div class="form-group">
                <asp:Label ID="Label6" CssClass="col-md-2 control-label" runat="server" Text=" Sub Category"></asp:Label>
            <div class="col-md-3">
                
               <asp:DropDownList ID="ddl3" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddl3_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
            
            
            </div>


            <div class="form-group">
                <asp:Label ID="Label7" CssClass="col-md-2 control-label" runat="server" Text="Upload Image"></asp:Label>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
              
                
            </div>
            
            
            </div>

             <div class="form-group">
                <asp:Label ID="Label8" CssClass="col-md-2 control-label" runat="server" Text="Upload Image"></asp:Label>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload2" CssClass="form-control" runat="server" />
              
                
            </div>
            
            
            </div>

             <div class="form-group">
                <asp:Label ID="Label9" CssClass="col-md-2 control-label" runat="server" Text="Upload Image"></asp:Label>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload3" CssClass="form-control" runat="server" />
              
                
            </div>
            
            
            </div>

             <div class="form-group">
                <asp:Label ID="Label10" CssClass="col-md-2 control-label" runat="server" Text="Upload Image"></asp:Label>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload4" CssClass="form-control" runat="server" />
              
                
            </div>
            
            
            </div>


             <div class="form-group">
                <asp:Label ID="Label11" CssClass="col-md-2 control-label" runat="server" Text="Upload Image"></asp:Label>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUpload5" CssClass="form-control" runat="server" />
              
                
            </div>
            
            
            </div>


            <div class="form-group">
                <asp:Label ID="Label12" CssClass="col-md-2 control-label" runat="server" Text="Free Delivery"></asp:Label>
            <div class="col-md-3">
                <asp:CheckBox ID = "CheckBox1" runat="server"></asp:CheckBox>
                
            </div>
            
            
            </div>


            <div class="form-group">
                <asp:Label ID="Label13" CssClass="col-md-2 control-label" runat="server" Text="30 Days Return"></asp:Label>
            <div class="col-md-3">
                <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox>
                
            </div>
            
            
            </div>


             <div class="form-group">
                <asp:Label ID="Label14" CssClass="col-md-2 control-label" runat="server" Text="COD"></asp:Label>
            <div class="col-md-3">
                <asp:CheckBox ID="CheckBox3" runat="server"></asp:CheckBox>
                
            </div>
            
            
            </div>


            
            <div class="form-group">
                <div class="col-md-3"></div>
                <div class="col-md-6">

                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Add product;" OnClick = "Addproduct_Click" />
                   
            </div>
            </div>




        </div>
    </div>


</asp:Content>

