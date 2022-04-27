<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Update_SubCategory.aspx.cs" Inherits="Update_SubCategory" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<div class=" container">
			<br />
			<br />
			<br />
			<br />
			<br />
			<br />
			<div class="well-sm">
				<h3>Edit Sub Category</h3></div>
			<div class="row">
				<div class="col-md-8">
					<div class="row">
						<div class="col-md-3">
							<div class="form-group">
								<label>Enter SubCatID:</label>
								<asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true" ontextchanged="txtID_TextChanged"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:Button ID="btnUpdateSubCategory" CssClass="btn btn-primary" runat="server" Text="UPDATE" onclick="btnUpdateSubCategory_Click" /> </div>
						</div>
						<div class="col-md-3">
							<label>Select Category:</label>
							<asp:DropDownList ID="ddlMainCategory" CssClass="form-control" runat="server"> </asp:DropDownList>
						</div>
						<div class="col-md-3">
							<label>Sub Category:</label>
							<asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<h3>All  SubCategories</h3>
				<div>
					<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
						<Columns>
							<asp:BoundField DataField="maincatid" HeaderText="CatID" />
							<asp:BoundField DataField="subcatid" HeaderText="SubCatID" />
							<asp:BoundField DataField="subcatname" HeaderText="SubCatName" />
							<asp:BoundField DataField="catname" HeaderText="CatName" /> </Columns>
					</asp:GridView>
				</div>
			</div>
		</div>
	</asp:Content>