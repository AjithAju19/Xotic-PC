<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<form>
			<div class="container">
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<div class="panel panel-primary">
					<div class="panel-heading">
						<h2>My Order Information</h2> </div>
					<div class="panel-body">
						<div class="row">
							<div class="col-md-12">
								<div class="">
									<asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="6" CellSpacing="5">
										<FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
										<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
										<PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
										<RowStyle BackColor="White" ForeColor="#330099" />
										<SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
										<SortedAscendingCellStyle BackColor="#FEFCEB" />
										<SortedAscendingHeaderStyle BackColor="#AF0101" />
										<SortedDescendingCellStyle BackColor="#F6F0C0" />
										<SortedDescendingHeaderStyle BackColor="#7E0000" /> </asp:GridView>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div>
					<asp:Button ID="btnPdf" OnClick="btnPdf_Click" CssClass="buyNowBtn" runat="server" Text="Generate PDF" BackColor="#20BD99" ForeColor="White" BorderColor="#14CDA8" /> </div>
			</div>
		</form>
	</asp:Content>