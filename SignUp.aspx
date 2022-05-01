<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<br />
		<br />
		<br />
		<br />
		<br />
		<div class=" body">
			<label class="col-xs-11">Register</label>
			<div>
				<br />
				<br />
				<div class="container">
					<label class="col-xs-11">First Name:</label>
					<div class="col-xs-11">
						<asp:TextBox ID="Textbox1" runat="server" Class="form-control" MaxLength="30" placeholder="Enter your first name"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Please enter your first name" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
					</div>
					<label class="col-xs-11">Last Name:</label>
					<div class="col-xs-11">
						<asp:TextBox ID="TextBox2" runat="server" Class="form-control" MaxLength="30" placeholder="Enter your last name"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Please enter last name" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
					</div>
					<label class="col-xs-11">Email:</label>
					<div class="col-xs-11">
						<asp:TextBox ID="TextBox3" runat="server" Class="form-control" MaxLength="30" placeholder="Enter your email id"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Please enter your email" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
					</div>
					<label class="col-xs-11">Password:</label>
					<div class="col-xs-11">
						<asp:TextBox ID="TextBox4" runat="server" Class="form-control" TextMode="Password" MaxLength="30" placeholder="Enter your password"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Please enter your password" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
					</div>
					<label class="col-xs-11">Confirm Password:</label>
					<div class="col-xs-11">
						<asp:TextBox ID="TextBox5" runat="server" Class="form-control" TextMode="Password" MaxLength="30" placeholder="Enter your password"></asp:TextBox>
					<asp:CompareValidator ID="CompareValidator1" ControlToCompare="TextBox4" ControlToValidate="TextBox5" runat="server" ErrorMessage="Passwords do not match"></asp:CompareValidator>
					</div>
					<label class="col-xs-11"></label>
					<div class="col-xs-11">
						<asp:Button ID="Button1" runat="server" Text="Sign Up" Class="btn btn-success" OnClick="Signup_Click" /> </div>
				</div>
			</div>
		</div>
		<br />
		<br />
		<br />
		<br /> </asp:Content>