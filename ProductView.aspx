<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <br /><br /><br />


    <div style ="padding-top: 50px">
        <div class ="col-md-5">
            <div style ="max-width:480px" class="thumbnail">
                
                <!-- proImage slider -->
                
                

<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
      <li data-target="#carousel-example-generic" data-slide-to="3"></li>
      <li data-target="#carousel-example-generic" data-slide-to="4"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">

      <asp:Repeater ID="rptrImage" runat="server">

          <ItemTemplate>

    <div class="item <%# GetActiveImgClass(Container.ItemIndex) %>">

      <img src ="Images/<%# Eval("pid")%>/<%# Eval("pname")%><%# Eval("Extension")%> " alt="<%# Eval("pname")%><%# Eval("Extension")%>" /> 
      
    </div>

    </ItemTemplate>
     </asp:Repeater>

  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
                
                <!-- proImage slider -->
                    
            </div>
        </div>

        <div class ="col-md-5">

            <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound ="rptrProductDetails_ItemDataBound">
                <ItemTemplate>
            <div class ="divDet1">
            <h1 class ="proNameView"><%# Eval("pname") %> </h1>
            <span class ="proOgPrice"><%# Eval("price") %></span>
            <span class ="proPriceDiscountView"> <%# string.Format("{0}",Convert.ToInt64(Eval("price")) - Convert.ToInt64(Eval("sellingprice"))) %> off</span>
        
            <p class ="proPriceView"> <%# Eval("sellingprice") %> </p>
        
        </div>

            <div class="divDet1">
          
               <asp:Button ID="btnAddtoCart" runat="server" CssClass="mainButton" Text="ADD TO CART" onClick="btnAddtoCart_Click"/>

                <asp:Label ID="lblError" CssClass ="text-danger" runat="server"></asp:Label>
            
            </div>

            <div class="divDet1">
                <h5 class ="h5size"> Description </h5>

                <p> <%# Eval("pdesc") %></p>


            </div>

            <div>
                <p> <%# ((int)Eval("freedelivery") == 1) ? "Free Delivery" : "" %></p>
                <p> <%# ((int)Eval("30dayret") == 1) ? "30 Day Return" : "" %></p>
                <p> <%# ((int)Eval("cod") == 1) ? "Cash on Delivery" : "" %></p>
            </div>

        </ItemTemplate>
    </asp:Repeater>

       </div>
    </div>

</asp:Content>

