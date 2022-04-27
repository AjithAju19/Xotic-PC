<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<br />
		<br />
		<br />
		<br />
		<div class="container">
			<div class="form-horizontal">
				<h2>Login Form</h2>
				<hr />
				<div class="form-group">
					<asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="UserName"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Cssclass="text-danger" runat="server" ErrorMessage="Please enter your email" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Password"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Please enter your password" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-5">
						<asp:CheckBox ID="CheckBox2" runat="server" />
						<asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Remember me"></asp:Label>
					</div>
					<div class="col-md-6"> </div>
				</div>
				<div class="form-group">
					<div class="col-md-3"></div>
					<div class="col-md-6">
						<asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Login &raquo;" OnClick="Login_Click" />
						<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignUp.aspx">Sign Up</asp:HyperLink>
					</div>
				</div>
				<!--
            <div class="form-group">
                <div class="col-md-3"></div>
                <div class="col-md-6">

                    <asp:Label ID="Label3" CssClass="text-danger" runat="server" Text="Label"></asp:Label>
            </div>
            </div>
            --></div>
		</div>
		<br />
		<br />
		<br />
		<br /> </asp:Content>