<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchased.aspx.cs" Inherits="PracXFinal.Purchased" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="section">
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row">

					<!-- Order Details -->
					<div class="col-md-12 order-details" style="margin: 2rem 0;">
						<div class="section-title text-center">
							<h3 class="title" style="color:green;" >Your purchase was Successful.<br /> Thank  you for shopping with us!</h3>
						
						</div>

						<%--<div class="text-center">

						<form id="check_out" runat="server">

						<asp:Button ID="btnInvoices" class="primary-btn btn-lg order-submit " runat="server" Text="View My Invoices" OnClick="btnPrevInvoices"/>
						</form>
						</div>--%>
						<a style="width:30%;" href="Invoice.aspx" class="primary-btn order-submit">View My Invoices</a>
					</div>
					<!-- /Order Details -->
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /SECTION -->

</asp:Content>
