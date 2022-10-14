<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="PracXFinal.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="section">

	<div class="container allprods">
		<div class="row">
		
			<form id="d" runat="server" >
			<div id="aside" class="col-md-3">
						
						<!-- aside Widget -->
						<div class="aside">
							<h3 class="aside-title">Categories</h3>

								<asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" AutoPostBack="true" >
									<asp:ListItem Value="0">
										Novels
									</asp:ListItem>
									<asp:ListItem Value="1">
										E-books
									</asp:ListItem>
									<asp:ListItem Value="2">
										AudioBooks
									</asp:ListItem>
								</asp:CheckBoxList>

							</div>
						
						<div class="aside">
							<h3 class="aside-title">Price</h3>
							<div class="price-filter">
								<div id="price-slider"></div>
								<div class="input-number price-min">
									<input id="price_min" class="input" Placeholder="Min Price" type="number" value="100" runat="server">
									
								</div>
								<span>-</span>
								<div class="input-number price-max">
									<input class="input" id="price_max" type="number" Placeholder="Max Price" value="5000" runat="server" >
									
								</div>
								<div class="filter_btn" >

									<asp:Button ID="btnReg" runat="server" Text="Filter" href="#" class="primary-btn btn-sm btn_filter order-submit" OnClick="btnSort_Click"/>
								</div>
						
							</div>
						</div>

				</div>
	<div id="store" class="col-md-9" >

	<div class="store-filter clearfix">
							<div class="store-sort">
								<label>
									Sort By:
								</label>
								<span>

									<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Sorter" >
										<asp:ListItem Value="0" >Name</asp:ListItem>
										<asp:ListItem Value="1">Price</asp:ListItem>
									</asp:DropDownList>
								</span>
							</div>
						</div>
	<div class="row" id="all_prods" runat="server" >
	</div>

	</div> 
	</form>

		</div>
	</div>
	</div>

</asp:Content>
