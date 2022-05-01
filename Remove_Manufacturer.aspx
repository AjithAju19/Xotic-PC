<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Remove_Manufacturer.aspx.cs" Inherits="Remove_Manufacturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
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
								<label>Enter Manufacturer ID:</label>
								<asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
							</div>
							<div class="form-group"> </div>
						</div>
						<div class="col-md-6">
							
							<div class="form-group">
								<asp:Button ID="btnUpdateBrand" CssClass="btn btn-primary " runat="server" Text="Remove" onclick="btnRemoveManufacturer_Click" /> </div>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<h3>All Manufacturer</h3>
				<div>
					<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
						<Columns>
							<asp:BoundField DataField="mid" HeaderText="Manufacturer ID" />
							<asp:BoundField DataField="mname" HeaderText="Manufaturer Name" /> </Columns>
					</asp:GridView>
				</div>
			</div>
		</div>



</asp:Content>

