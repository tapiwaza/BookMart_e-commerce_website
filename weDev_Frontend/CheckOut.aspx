<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="PracXFinal.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="section">
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row">

					<%--<div class="col-md-7">
						

						
					</div>--%>

					<!-- Order Details -->
					<div class="col-md-12 order-details">
						<div class="section-title text-center">
							<h3 class="title">Your Order</h3>
						</div>
						<div class="order-summary">
							<div class="order-col">
								<div><strong>PRODUCT</strong></div>
								<div><strong>TOTAL</strong></div>
							</div>
							<div class="order-products" id="order_prods" runat="server">
								
								
							</div>
							<div class="order-col" id="shipping_cost" runat="server">
								<%--<div>Shiping</div>
								<div><strong>FREE</strong></div>--%>
							</div>
							<div class="order-col" id="discount" runat="server">
								<%--<div>Discount</div>
								<div><strong>R 100</strong></div>--%>
							</div>
							<div class="order-col" id="tot_tax" runat="server">
								<%--<div>Discount</div>
								<div><strong>R 100</strong></div>--%>
							</div>
							<div class="order-col" id="my_total" runat="server">
								
							</div>
						</div>
						<div class="payment-method">
							<div class="input-radio">
								<input type="radio" name="payment" id="payment-1">
								<label for="payment-1">
									<span></span>
									Direct Bank Transfer
								</label>
								<div class="caption">
									<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								</div>
							</div>
							<div class="input-radio">
								<input type="radio" name="payment" id="payment-2">
								<label for="payment-2">
									<span></span>
									Cheque Payment
								</label>
								<div class="caption">
									<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								</div>
							</div>
							<div class="input-radio">
								<input type="radio" name="payment" id="payment-3">
								<label for="payment-3">
									<span></span>
									Paypal System
								</label>
								<div class="caption">
									<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								</div>
							</div>
						</div>
						<div class="input-checkbox">
							<input type="checkbox" id="terms">
							<label for="terms">
								<span></span>
								I've read and accept the <a href="#">terms & conditions</a>
							</label>
						</div>
						<!-- Order notes -->
						<div class="order-notes">
							<textarea class="input" placeholder="Order Notes"></textarea>
						</div>
						<!-- /Order notes -->
						<%--<a href="#" class="primary-btn order-submit">Place order</a>--%>
						<form id="check_out" runat="server">

						<asp:Button ID="btnCheck_Out" class="primary-btn btn-lg order-submit checkout-btn" runat="server" Text="CheckOut" OnClick="btnCheckOut" Visible="false" />
						</form>
						
					</div>
					<!-- /Order Details -->
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /SECTION -->

</asp:Content>
