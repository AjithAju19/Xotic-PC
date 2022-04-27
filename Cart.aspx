<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<br />
		<br />
		<br />
		<br />
		<br />
		<div class="container">
			<br />
			<br />
			<button id="btnCart2" runat="server" class="btn btn-primary navbar-btn pull-right" onserverclick="btnCart2_ServerClick" type="button"> Cart <span id="CartBadge" runat="server" class="badge">0</span> </button>
			<div style="padding-top:50px">
				<br />
				<br />
				<div class="col-md-9">
					<h4 class="proNameViewCart" runat="server" id="noofitems"> </h4>
					<div id="divQtyError" runat="server" class="alert alert-success alert-dismissible fade in h4"> <a href="#" class="close" data-dismiss="alert" aria-label="close"> &times;</a> <strong>Oops! </strong>Quantity cannot be less than 1. </div>
					<asp:Repeater ID="rptrCartProducts" OnItemCommand="rptrCartProducts_ItemCommand" runat="server">
						<ItemTemplate>
							<div class="media my-3" style="border: 1px solid #eaeaec;">
								<div class="align-self-center mr-3">
									<a href="ProductView.aspx?PID=<%#Eval(" pid ") %>" target="_blank">
										<!--    <img src="Images/1025/XOTICPCGY15THINGAMINGLAPTOP02.jpg" width ="100" class="media-object"/> --></a>
								</div>
								<div class="media-body">
									<h5 class="media-heading proNameViewCart"><%#Eval("pname") %></h5> <span class="proPriceView"><%#Eval("sellingprice") %></span> <span class="proOgPriceView"><%#Eval("price") %></span>
									<div class="pull-right form-inline">
										<asp:Label ID="lblQty" runat="server" Text="Qty:" Font-Size="Large"></asp:Label>
										<asp:Button ID="BtnMinus" CssClass="BtnMinus" CommandArgument='<%# Eval("PID") %>' CommandName="DoMinus" ForeColor="Black" Font-Size="Large" runat="server" Text="-" />&nbsp
										<asp:TextBox ID="txtQty" CssClass="txtQty" runat="server" Width="40" Font-Size="Large" TextMode="SingleLine" ForeColor="Black" Style="text-align: center" Text='<%# Eval("Qty") %>'></asp:TextBox>&nbsp
										<asp:Button ID="BtnPlus" CssClass="BtnPlus" CommandArgument='<%# Eval("PID") %>' CommandName="DoPlus" runat="server" Text="+" Font-Size="Large" ForeColor="Black" />&nbsp&nbsp&nbsp </div>
									<br />
									<p>
										<asp:Button CommandArgument='<%#Eval("CartID") %>' CommandName="RemoveThisCart" ID="btnRemoveCart" CssClass="removeButton" runat="server" Text="Remove" />
										<br /> <span class="proNameViewCart pull-right">SubTotal: <%# Eval("SubSAmount","{0:0.00}") %></span> </p>
								</div>
							</div>
						</ItemTemplate>
					</asp:Repeater>
				</div>
				<div class="col-md-3 pt-5" runat="server" id="divAmountSect">
					<div style="border-bottom: 1px solid #eaeaec;">
						<h5 class="proNameViewCart">PRICE DETAILS</h5>
						<div>
							<label>Cart Total</label> <span class="float-right priceGray" id="spanCartTotal" runat="server"></span> </div>
						<div>
							<label>Cart Discount</label> <span class="float-right priceGreen" id="spanDiscount" runat="server"></span> </div>
					</div>
					<br />
					<br />
					<div>
						<div class="proPriceView">
							<label>Total</label> <span class="float-right" id="spanTotal" runat="server"></span> </div>
						<br />
						<!-- <div>
                        <asp:Button ID="btnBuyNow" OnClick="btnBuyNow_Click" CssClass="buyNowBtn" runat="server" Text="BUY NOW" BackColor="#20BD99" ForeColor="White" BorderColor="#14CDA8" />
                    </div> -->
						<div>
							<asp:Button ID="btnPlaceOrder" OnClick="btnPlaceOrder_Click" CssClass="buyNowBtn" runat="server" Text="Place Order" BackColor="#20BD99" ForeColor="White" BorderColor="#14CDA8" /> </div>
					</div>
				</div>
			</div>
		</div>
		<br />
		<br />
		<br />
		<br />
		<br /> </asp:Content>