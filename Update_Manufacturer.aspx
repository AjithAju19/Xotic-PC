<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Update_Manufacturer.aspx.cs" Inherits="Update_Manufacturer" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<br />
		<br />
		<br />
		<br />
		<div class="container">
			<div class="row">
				<div class="col-md-6">
					<div class="row">
						<div class="col-md-6">
							<div class="form-group">
								<label>Enter ID:</label>
								<asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true" ontextchanged="txtID_TextChanged"></asp:TextBox>
							</div>
							<div class="form-group"> </div>
						</div>
						<div class="col-md-6">
							<div class="form-group">
								<label>Enter Manufacturer Name:</label>
								<asp:TextBox ID="txtUpdateBrandName" CssClass="form-control" runat="server"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:Button ID="btnUpdateBrand" CssClass="btn btn-primary " runat="server" Text="UPDATE" onclick="btnUpdateBrand_Click" /> </div>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<h3>All Categories</h3>
				<div>
					<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
						<Columns>
							<asp:BoundField DataField="mid" HeaderText="MID" />
							<asp:BoundField DataField="mname" HeaderText="Manufacturer Name" /> </Columns>
					</asp:GridView>
				</div>
			</div>
		</div>
	</asp:Content>