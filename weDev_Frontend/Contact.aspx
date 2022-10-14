<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PracXFinal.Contact" %>

    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<form runat="server" id="send">
    	<!-- SECTION -->
		<div class="section" runat="server" >
			<!-- container -->
			<div class="container" runat="server" >
				<!-- row -->
				<div class="row" runat="server" >

					<div class="col-md-7" runat="server" >
						<!-- Billing Details -->
						<div class="billing-details" runat="server">
							<div class="section-title" runat="server">
								<h3 class="title">Get In Touch</h3>
							</div>
							
							<div class="form-group col-md-4" runat="server">
							<button runat="server" href="mailto:email@gmail.com" id="btn_Email_Us" class=" primary-btn order-submit btn-lg" title="Search">
								<i class="fa-solid fa-envelope"></i> Email Us
							</button>
							</div>
							<div class="form-group col-md-4" runat="server">
								<button runat="server" href="#" id="btn_Phone_Us" class=" primary-btn order-submit btn-lg" title="Search">
								<i class="fa-solid fa-phone"></i> Phone
							</button>
							</div>
							<div class="title_h4_message col-md-12">

								<h4>Send a Message</h4>
							</div>
							<div class="form-group col-md-4" runat="server">
								<input class="input" type="text" name="name" placeholder="Name" id="name" required="required" runat="server">
							</div>
							<div class="form-group col-md-4" runat="server">
								<input class="input" type="email" name="email" placeholder="Email" id="email" required="required" runat="server">
							</div>
							<div class="form-group col-md-4" runat="server">
								<input class="input" type="password" name="contact_num" placeholder="Phone Number" id="number" required="required" runat="server">
							</div>
							<div class="col-md-12">
								<textarea id="TextArea1" cols="130" rows="12"></textarea>
							</div>
							<div class="form-group col-md-12 send_message" runat="server">
								<button runat="server" href="#" id="btn_Send_Message" class=" primary-btn order-submit btn-lg" title="Search">
								 Send Message
							</button>
							</div>
						</div>
					</div>
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /SECTION -->
	</form>

</asp:Content>
