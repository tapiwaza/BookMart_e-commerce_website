using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
    public partial class SingleProduct : System.Web.UI.Page
    {
        private static int id =0 ;
		Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        { 

			string display = "";

			id = Convert.ToInt32(Request.QueryString["Id"]);

            if(id != 0)
            {

			var p = sr.getProduct(id);

            display += "<div class='col-md-6'>";
            display += "<div id='product-main-img'>";
            display += "<div class='product-preview sing_prod'>";
            display += "<img src='" + p.PrImage + "' alt=''>";
            display += "</div>";

            //display += "<div class='product-preview'>";
            //display += "<img src='./img/product03.png' alt=''>";
            //display += "</div>";

            //display += "<div class='product-preview'>";
            //display += "<img src='./img/product06.png' alt=''>";
            //display += "</div>";

            ////				<div class="product-preview">
            ////					<img src = "./img/product08.png" alt="">
            ////				</div>
            display += "</div>";
            display += "</div>";

            display += "<div class='col-md-6 sing_prod'>";
            display += "<div class='product-details'>";
            display += "<h2 class='product-name'>"+p.PrName+"</h2>";
            display += "<div>";
            display += "<div class='product-rating'>";

            display += "</div>";

            display += "</div>";
            display += "<div>";
            if(p.PrOldPrice == 0)
                {

                    display += "<h3 class='product-price'> R " + String.Format("{0:0.00}",p.PrPrice,2) + "</h3>";
                }
                else
                {
                    display += "<h3 class='product-price'> R " + String.Format("{0:0.00}",p.PrPrice,2) + "<del class='product-old-price'> R " + String.Format("{0,0:00}",p.PrOldPrice) + "</del></h3>";

                }
            display += "<span class='product-available'>In Stock</span>";
            display += "</div>";
            display += "<p>" + p.PrDescription + "</p>";

            display += "<div class='product-options'>";

            display += "</div>";

            //display += "<div class='add-to-cart'>";
            //display += "<div class='qty-label'>";
            //display += "Qty";
            //display += "<div class='input-number'>";
            //display += "<input type='number'>";
            //display += "<span class='qty-up'>+</span>";
            //display += "<span class='qty-down'>-</span>";
            //display += "</div>";
            //display += "</div>";
            //display += "</div>";

            display += "<ul class='product-btns'>";
            display += "<li><a href='#'><i class='fa fa-heart-o'></i> add to wishlist</a></li>";
            display += "<li><a href='AllProducts.aspx?AddToCartId=" + p.Id + "'class='add-to-cart-a'><i class='fa fa-shopping-cart fa_cart_wishlist'></i>Add to cart</a></li>";
            display += "</ul>";
            //display += "<asp:Button class='primary-btn  order-submit' ID='btn_Buy' runat='server' Text='Buy Now' OnClick='btnBuyNow'/>";
            //display += "<a href='#' class='primary-btn order-submit'>Buy Now</a>";
            display += "</div>";
            display += "</div>";

            single_prod.InnerHtml = display;

             if (Session["AdminValue"] != null)
                {
                    if (Session["AdminValue"].Equals("Manager"))
                    {
                        btnEditP.Visible = true;
                        btnRemP.Visible = true;
                    }
                    else
                    {
                        btnEditP.Visible = false;
                        btnRemP.Visible = false;
                    }
                }
            }
            else
            {
                

                Response.Redirect("index.aspx");
            }
        }

        protected void btnEditP_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx?Id="+id);
        }

        protected void btnRemP_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemoveProduct.aspx?Id=" + id);
        }

        //protected void btnBuyNow(object sender, EventArgs e)
        //{

        //}
    }
}