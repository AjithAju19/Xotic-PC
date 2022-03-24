<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forgot_Password.aspx.cs" Inherits="Forgot_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

<br /><br /><br /><br />

    <div class ="container">
        <div class="form-horizontal">
            <h2>Recover Password</h2>
            <hr />
            <h3>Please Enter Your Email Address, we will send you the recovery link for your password</h3>

            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Your Email Address"></asp:Label>
            
            <div class="col-md-3">
                <asp:TextBox ID="TextBox1" CssClass ="form-control"  runat="server"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Enter your email" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            
            </div>
            
            </div>

            <div class="form-group">

                <div class="col-md-2">

                </div>
                <div class ="col-md-6">
                   
                    <asp:Button ID="Button1" runat="server" CssClass="btn-default" Text="Send Mail" OnClick="SendEmail_Click" />
                
                </div>
            </div>

        </div>
    </div>




</asp:Content>

