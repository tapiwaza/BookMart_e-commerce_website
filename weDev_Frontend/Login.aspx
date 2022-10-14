<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PracXFinal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- SECTION -->
		<div class="section" runat="server" >
			<!-- container -->
			<div class="container" runat="server" >
				<!-- row -->
				<div class="row" runat="server" >

					<div class="col-md-7" runat="server" >
						<!-- Billing Details -->
					<form id="log_in" runat="server" >
						<div class="billing-details" >
							<div class="section-title" >
								<h3 class="title">Log In</h3>
							</div>
							
							<div class="form-group" >
								<input class="input" type="email" name="email" placeholder="Email" id="email" required="required" runat="server">
							</div>
							<div class="form-group" >
								<input class="input" type="password" name="pass" placeholder="Password" id="pass" required="required" runat="server">
							</div>
						</div>
						
						<asp:Label ID="error" runat="server" Text=""></asp:Label>
						<!-- /Billing Details -->
						<asp:Button ID="btnLogin" runat="server" Text="Log In" href="#" class="primary-btn order-submit" OnClick="btnLogin_Click"/>

					</form>
					</div>
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /SECTION -->

</asp:Content>
