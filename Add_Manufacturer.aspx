<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Add_Manufacturer.aspx.cs" Inherits="Add_Manufacturer" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
		<br />
		<br />
		<br />
		<br />
		<div class="container">
			<div class="form-horizontal">
				<h2>Add Manufacturer</h2>
				<hr />
				<div class="form-group">
					<asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Manufacturer"></asp:Label>
					<div class="col-md-3">
						<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Cssclass="text-danger" runat="server" ErrorMessage="Please enter manufacturer name" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<div class="col-md-3"></div>
					<div class="col-md-6">
						<asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Add" OnClick="Addmanufacturer_Click" /> </div>
					<h1>Manufacturer</h1>
					<hr />
					<h3>All Manufacturers</h3>
					<div>
						<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
							<Columns>
								<asp:BoundField DataField="mid" HeaderText="MID" />
								<asp:BoundField DataField="mname" HeaderText="Manufacturer Name" /> </Columns>
						</asp:GridView>
					</div>
					<!--
         <div class="panel panel-default">
             <div class="panel-heading">All Manufacturers</div>
            
        
             <asp:Repeater ID="Repeater1" runat="server">
             

             <HeaderTemplate>

                 <table class="table">
                 <thead>
                 <tr>
                     <th>#</th>
                     <th>Manufacturer</th>
                   <!--   <th>Edit</th>  
                 </tr>
                 </thead>

                 <tbody>

             </HeaderTemplate>

             <ItemTemplate>

                 <tr>
                         <td><%# Eval("mid")%></td>
                         <td><%# Eval("mname")%></td>
                         <td>Edit</td>
                     </tr>

             </ItemTemplate>

              <FooterTemplate>

                  </tbody>
             </table>

              </FooterTemplate>

                 </asp:Repeater>
    --></div>
			</div>
		</div>
	</asp:Content>