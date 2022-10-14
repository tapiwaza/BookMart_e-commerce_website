<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="PracXFinal.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="section">
			<div class="container">
				<div class="row" runat="server">
					<!-- HEADERS-->
					<div class="col-md-2 reports-sec-header"></div>
					<div class="col-md-10 reports-sec-header" >
					<!--HEADERS-->
					<div class=" col-md-12 reports reports-title">
						<strong>PRODUCTS</strong>
					</div>
						<div class="col-md-1 reports">
						<strong>ID</strong>
					</div>
					<div class="col-md-3 reports">
						<strong>NAME</strong>
					</div>
					<div class="col-md-2 reports">
						<strong>CATEGORY</strong>
					</div>
					<div class="col-md-1 reports">
						<strong>QUANTITY</strong>
					</div>
					<div class="col-md-2 reports">
						<strong>PRICE</strong>
					</div>
					<div class="col-md-2 reports">
						<strong>OLD PRICE</strong>
					</div>
					<div class="col-md-1 reports">
						<strong>STATUS</strong>
					</div>
					</div>

					<form id="filters" runat="server">

					<div class="col-md-2 reports-sec">

					<!--SORTER-->
						<div class="aside">
							<h3 class="aside-title">Categories</h3>
								
							<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Sorter" >
								<asp:ListItem Value="0" >All Products</asp:ListItem>
								<asp:ListItem Value="1" >Novels</asp:ListItem>
										<asp:ListItem Value="2">E-books</asp:ListItem>
										<asp:ListItem Value="3">AudioBooks</asp:ListItem>
									</asp:DropDownList>

							</div>

					<!--SORTER-->
						<div class="aside">
							<h3 class="aside-title">QUANTITY</h3>
							<div class="price-filter">
								<div id="price-slider"></div>
								<div class="input-number price-min">
									<input id="price_min" class="input" Placeholder="Min Price" type="number" value="0" runat="server">
									
								</div>
								<span>-</span>
								<div class="input-number price-max">
									<input class="input" id="price_max" type="number" Placeholder="Max Price" value="100" runat="server" >
									
								</div>
								<div class="filter_btn" >

									<asp:Button ID="btnReg" runat="server" Text="SHOW" href="#" class="primary-btn btn-sm btn_filter order-submit" OnClick="btnReg_Click"/>
								</div>
						
							</div>
						</div>
					</div>


					<!--ALL PRODUCTS-->
					<div class="col-md-10 reports-sec" id="reports_sec" runat="server">
					</div>

					<!--SUMMARY HEADERS-->
						<div class="col-md-12">
					<div class="col-md-2 reports-sec-header"></div>
					<div class="col-md-10 reports-sec-header" >
					<div class=" col-md-12 reports reports-title">
						<strong>PRODUCTS SUMMARY</strong>
					</div>
						<div class="col-md-6 reports">
						<strong>CATEGORY</strong>
					</div>
					<div class="col-md-6 reports">
						<strong>TOTAL</strong>
					</div>
					
					</div>

					<!--SUMMARY INFO-->
						<div class="col-md-2 reports-sec"></div>
						<div class="col-md-10 reports-sec" id="summary_sec" runat="server">
							<div class="col-md-6 reports">
						<strong>NOVELS</strong>
					</div>
					<div class="col-md-6 reports" id="nov_tot" runat="server">
						<strong>TOTAL</strong>
					</div>
						<div class="col-md-6 reports">
						<strong>AUDIBOOKS</strong>
					</div>
					<div class="col-md-6 reports" id="audio_tot" runat="server">
						<strong>TOTAL</strong>
					</div>
							<div class="col-md-6 reports" >
						<strong>EBOOKS</strong>
					</div>
					<div class="col-md-6 reports" id="ebooks_tot" runat="server">
						<strong>TOTAL</strong>
					</div>
					<div class="col-md-6 " >
					</div>
					<div class="col-md-6 reports" id="tot_cats" runat="server">
						<strong></strong>
					</div>

					</div>
							</div>

						<!--USER HEADERS-->

					<div class="col-md-2 reports-sec-header">

					</div>
					<div class="col-md-10 reports-sec-header" >
					<div class=" col-md-12 reports reports-title">
						<strong>USERS</strong>
					</div>
						<div class="col-md-6 reports" Visble="true">
						<strong>TYPE OF USER</strong>
					</div>
					<div class="col-md-6 reports" Visble="true">
						<strong>TOTAL</strong>
					</div>
					
					</div>

						<!--USER DATA-->
							<div class="col-md-2 reports-sec">
						<!--SORTER-->
								<h3 class="aside-title">USERS</h3>
								
						<div class="aside">
							<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Date_Sorter" >
								<asp:ListItem Value="0" >All Registered Users</asp:ListItem>
								<asp:ListItem Value="1" >Today</asp:ListItem>
									</asp:DropDownList>
							</div>
							</div>

						<div class="col-md-10 reports-sec" >
							<div class="col-md-6 reports" Visible="true" >
						<strong>MANAGERS</strong>
					</div>
					<div class="col-md-6 reports" id="tot_mans" runat="server" Visible="true">
						<strong>TOTAL</strong>
					</div>
							<div class="col-md-6 reports" id="Div3" runat="server" Visible="true">
						<strong>CUSTOMERS</strong>
					</div>
					<div class="col-md-6 reports" id="tot_custs" runat="server" Visible="true">
						<strong>TOTAL</strong>
					</div>
							<div class="col-md-6 reports" id="user_reg" runat="server" Visible="true">
						<strong>REGISTERED</strong>
					</div>
					<div class="col-md-6 reports" id="user_tot" runat="server" Visible="true">
						<strong>TOTAL</strong>
					</div>
							

					</div>

						<!--HEADER FOR CUSTOMERS-->
						<div class="col-md-2 reports-sec-header">

					</div>
					<div class="col-md-10 reports-sec-header" >
					<div class=" col-md-12 reports reports-title">
						<strong>CUSTOMERS </strong>
					</div>
					
					<div class="col-md-6 reports" Visble="false">
						<strong>CUSTOMER HAS PURCHASED</strong>
					</div>
					<div class="col-md-6 reports" Visble="false">
						<strong>TOTAL</strong>
					</div>
					</div>

						<!--CUSTOMERS-->
						<div class="col-md-2 reports-sec">
							
							</div>

						<div class="col-md-10 reports-sec" >
							
							<div class="col-md-6 reports" id="bought_once" runat="server" >
						<strong>AT LEAST ONCE</strong>
					</div>
					<div class="col-md-6 reports" id="bought_once_tot" runat="server" >
						<strong>TOTAL</strong>
					</div>
							<div class="col-md-6 reports" id="once_more" runat="server">
						<strong>MORE THAN ONCE</strong>
					</div>
					<div class="col-md-6 reports" id="once_more_tot" runat="server" >
						<strong>TOTAL</strong>
					</div>

					</div>

					</form>

				<!-- /row -->
			
			<!-- /container -->
		</div>
		<!-- /SECTION -->


</asp:Content>
