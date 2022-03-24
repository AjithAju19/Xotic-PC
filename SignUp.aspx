<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    
    <br /><br /><br /><br /><br />
    <div>
    <div class ="center-page">

        <label class="col-xs-11">First Name:</label>
        <div class ="col-xs-11">
        <asp:TextBox ID="Textbox1" runat="server" Class = "form-control" MaxLength="30"  placeholder ="Enter your first name"></asp:TextBox>
        </div>

        <label class="col-xs-11">Last Name:</label>
        <div class ="col-xs-11">
        <asp:TextBox ID="TextBox2" runat="server" Class = "form-control" MaxLength="30" placeholder ="Enter your last name"></asp:TextBox>
        </div>

        <label class="col-xs-11">Email:</label>
        <div class ="col-xs-11">
        <asp:TextBox ID="TextBox3" runat="server" Class = "form-control" MaxLength="30" placeholder ="Enter your email id"></asp:TextBox>
        </div>

        <label class="col-xs-11">Password:</label>
        <div class ="col-xs-11">
        <asp:TextBox ID="TextBox4" runat="server" Class = "form-control" TextMode = "Password" MaxLength="30" placeholder ="Enter your password"></asp:TextBox>
        </div>

        <label class="col-xs-11"></label>

        <div class ="col-xs-11">
            <asp:Button ID="Button1" runat="server" Text="Sign Up" Class ="btn btn-success" OnClick="Signup_Click" />
        </div>
    
    </div>
    </div>


</asp:Content>

