<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Remove_Product.aspx.cs" Inherits="Remove_Product" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<br />
		<br />
		<br />
		<br />
		<div class="container">
			<div class="form-horizontal">
				<h2>Remove a product </h2>
				<hr />
				<div class="form-group">
					<asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="PID"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Cssclass="text-danger" runat="server" ErrorMessage="Please enter PID" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-3"></div>
					<div class="col-md-6">
						<asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Remove" OnClick="btnRemoveProduct_Click" /> </div>
				</div>
				<hr />
				<h3>All Products</h3>
				<div>
					<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
						<Columns>
							<asp:BoundField DataField="pid" HeaderText="PID" />
							<asp:BoundField DataField="pcatid" HeaderText="PCatID" />
							<asp:BoundField DataField="psubcatid" HeaderText="PSubCatID" />
							<asp:BoundField DataField="pname" HeaderText="PName" /> </Columns>
					</asp:GridView>
				</div>
			</div>
		</div>
	</asp:Content>