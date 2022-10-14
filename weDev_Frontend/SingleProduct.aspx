<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingleProduct.aspx.cs" Inherits="PracXFinal.SingleProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
    
    <div class="section">
		
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row" id="single_prod" runat="server" >
					<!-- Product main img -->
					<%--<div class="col-md-6">
						<div id="product-main-img">
							<div class="product-preview">
								<img src="./img/product01.png" alt="">
							</div>

							<div class="product-preview">
								<img src="./img/product03.png" alt="">
							</div>

							<div class="product-preview">
								<img src="./img/product06.png" alt="">
							</div>

							<div class="product-preview">
								<img src="./img/product08.png" alt="">
							</div>
						</div>
					</div>--%>

					<!-- Product details -->
					<%--<div class="col-md-6">
						<div class="product-details">
							<h2 class="product-name">product name goes here</h2>
							<div>
								<div class="product-rating">
									
								</div>
								
							</div>
							<div>
								<h3 class="product-price">$980.00 <del class="product-old-price">$990.00</del></h3>
								<span class="product-available">In Stock</span>
							</div>
							<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>

							<div class="product-options">
								
							</div>

							<div class="add-to-cart">
								<div class="qty-label">
									Qty
									<div class="input-number">
										<input type="number">
										<span class="qty-up">+</span>
										<span class="qty-down">-</span>
									</div>
								</div>
								<button class="add-to-cart-a"><i class="fa fa-shopping-cart"></i> add to cart</button>
							</div>

							<ul class="product-btns">
								<li><a href="#"><i class="fa fa-heart-o"></i> add to wishlist</a></li>
							</ul>
							</div>
					</div>--%>
					<!-- /Product details -->
					
					

					
				</div>
				<!-- /row -->
				<asp:Button ID="btnEditP" runat="server" Text="Edit This Product" href="#" class="primary-btn order-submit" visible="false" OnClick="btnEditP_Click"/>
				<asp:Button ID="btnRemP" runat="server" Text="Remove This Product" href="#" class="primary-btn order-submit" visible="false" OnClick="btnRemP_Click"/>
			</div>
			<!-- /container -->
		</div>
		<!-- /SECTION -->

	</form>
    

</asp:Content>
