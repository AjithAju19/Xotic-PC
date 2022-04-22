<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <br /><br /><br /><br />

    <h3>View all products</h3>

    <div class ="body">
    <div class ="row" style ="padding-top : 50px">
        <asp:Repeater ID ="Repeater1" runat="server">
        <ItemTemplate>
        <div class ="col-sm-3 col-md-3">

            <a href ="ProductView.aspx?pid=<%# Eval("pid")%> " style ="text-decoration:none">

            <div class ="thumbnail">

               

                <img src ="Images/<%# Eval("pid")%>/<%# Eval("ImageName")%><%# Eval("Extension")%> " alt="<%# Eval("ImageName")%><%# Eval("Extension")%>"  onerror ="this.src = 'Images/noimg.png' "/> 
                <div class="caption">
                    <div class="probrand"><%# Eval("mname") %></div>
                    
                    <div class="proName"><%# Eval("pname") %> </div>
                     <div class ="proPrice">
                         <span class ="proOgPrice"><%# Eval("price") %></span><%# Eval("sellingprice") %>
                        <span class ="proPriceDiscount">(<%# Eval("Discount") %> Discount)</span>
                     </div>
                </div>

            </div>
        </div>
        </a>
    </ItemTemplate>
    </asp:Repeater>
    </div>
    </div>

    <br /><br /><br /><br />
</asp:Content>

