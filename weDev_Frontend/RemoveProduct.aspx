<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemoveProduct.aspx.cs" Inherits="PracXFinal.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     

		<!-- SECTION -->
		<div class="section">
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row" runat="server">

					<div class="col-md-7" runat="server">
						<!-- Billing Details -->
						<div class="billing-details" runat="server">
							<div class="section-title">
								<h3 class="title">Remove Product</h3>
							</div>
							<div class="form-group" runat="server">
								<input class="input" type="text" name="pid" placeholder="Product ID" id="pid" required="required" runat="server">
							</div>
							
						</div>
						<!-- /Billing Details -->

						<!-- <a href="#" class="primary-btn order-submit">Register</a> -->
						<form id="RemoveProd"  runat="server">

						<asp:Button ID="btnRemP" runat="server" Text="Remove product" href="#" class="primary-btn order-submit" OnClick="btnRemP_Click"/>
							<asp:Label ID="lblProductMessage1" runat="server" Text=""></asp:Label>
						</form>
							
						
					</div>

					
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /SECTION -->

</asp:Content>
