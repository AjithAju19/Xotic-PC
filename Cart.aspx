<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <br /><br /><br /><br /><br />
    
    <div class="container">
    <div style ="padding-top:50px">
        <br /><br />
        <div class="col-md-9" >
            <h4 class="proNameViewCart" runat="server" id="noofitems"> </h4>
            

            <asp:Repeater ID="rptrCartProducts" runat="server">
                    <ItemTemplate>
                        <div class="media my-3" style="border: 1px solid #eaeaec;">
                            <div class="align-self-center mr-3">
                                <a href="ProductView.aspx?PID=<%#Eval("pid") %>" target="_blank">
                                <!--    <img src="Images/1025/XOTICPCGY15THINGAMINGLAPTOP02.jpg" width ="100" class="media-object"/> -->

                                    
                                    
                                </a>
                            </div>
                            <div class="media-body">
                                <h5 class="media-heading proNameViewCart"><%#Eval("pname") %></h5>
                                
                                <span class="proPriceView"><%#Eval("sellingprice") %></span>
                                <span class="proOgPriceView"><%#Eval("price") %></span>
                                <p>
                                    <asp:Button  ID="btnRemoveItem" OnClick="btnRemoveItem_Click" CssClass="removeButton" runat="server" Text="REMOVE" />
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-3 pt-5" runat="server" id="divPriceDetails">
                <div style="border-bottom: 1px solid #eaeaec;">
                    <h5 class="proNameViewCart">PRICE DETAILS</h5>
                    <div>
                        <label>Cart Total</label>
                        <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                    </div>
                    <div>
                        <label>Cart Discount</label>
                        <span class="float-right priceGreen" id="spanDiscount" runat="server"></span>
                    </div>
                </div>
                <br /><br />
                <div>
                    <div class="proPriceView">
                        <label>Total</label>
                        <span class="float-right" id="spanTotal" runat="server"></span>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="btnBuyNow" OnClick="btnBuyNow_Click" CssClass="buyNowBtn" runat="server" Text="BUY NOW" BackColor="#20BD99" ForeColor="White" BorderColor="#14CDA8" />
                    </div>
                </div>
            </div>
        </div>
       </div>
        <br /><br /><br /><br /><br />
</asp:Content>
            
