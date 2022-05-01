<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Update_Product.aspx.cs" Inherits="Update_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <div class="container">
			<div class="form-horizontal">
				<br />
				<br />
				<br />
				<h2>Update Product details</h2>
				<hr />
				<div class="form-group">
					<asp:Label ID="Label16" runat="server" CssClass="col-md-2 control-label" Text="Product ID"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="pid" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Product Name"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Selling Price"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Description"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox4" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
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
						<asp:DropDownList ID="ddl2" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl2_SelectedIndexChanged"></asp:DropDownList>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="Label6" CssClass="col-md-2 control-label" runat="server" Text=" Sub Category"></asp:Label>
					<div class="col-md-3">
						<asp:DropDownList ID="ddl3" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddl3_SelectedIndexChanged"></asp:DropDownList>
					</div>
				</div>
				
				
				<div class="form-group">
					<asp:Label ID="Label12" CssClass="col-md-2 control-label" runat="server" Text="Free Delivery"></asp:Label>
					<div class="col-md-3">
						<asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
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
						<asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Update Details" OnClick="Updateproduct_Click" /> </div>
				</div>
			</div>
		</div>

</asp:Content>

