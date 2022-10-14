using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{

    public partial class WebForm1 : System.Web.UI.Page
    {
    Service1Client sr = new Service1Client();
         
        protected void Page_Load(object sender, EventArgs e)
        {

            string deal_dis = "";

            var deals_prods = sr.getAllDiscountedProducts().ToList();
            
            foreach (ServiceReference1.Product p in deals_prods)
            {

                deal_dis += "<div class='product'>";
                deal_dis += "<div class='product-img'>";
                deal_dis += "<img src='" + p.PrImage + "' alt=''>";
                deal_dis += "<div class='product-label'>";
                deal_dis += "<span class='sale'>"+ String.Format("{0:0}",100 - ((p.PrPrice/p.PrOldPrice)*100)) +"%</span>";
                deal_dis += "</div>";
                deal_dis += "</div>";
                deal_dis += "<div class='product-body'>";
                deal_dis += "<p class='product-category'>Category</p>";
                deal_dis += "<h3 class='product-name'><a href='SingleProduct.aspx?Id=" + p.Id + "'>" + p.PrName + "</a></h3>";
                deal_dis += "<h4 class='product-price'> R " + String.Format("{0:0.00}", p.PrPrice) + "<del class='product-old-price'>R " + String.Format("{0:0.00}", p.PrOldPrice) + "</del></h4>";
                
                deal_dis += "<div class='product-rating'>";

                deal_dis += "</div>";
                deal_dis += "<div class='product-btns'>";
                deal_dis += "<a class='add-to-wishlist'><i class='fa fa-heart-o fa_cart_wishlist '></i><span class='tooltipp'>Add to Wishlist</span></a>";

                if (Session["LoggedInID"] != null)
                {
                    deal_dis += "<a class='add-to-wishlist' href='AllProducts.aspx?AddToCartId=" + p.Id + "' ><i class='fa fa-shopping-cart fa_cart_wishlist '></i><span class='tooltipp'>Add to Cart</span></a>";
                }
                else
                {
                    deal_dis += "<a class='add-to-wishlist' href='login.aspx' ><i class='fa fa-shopping-cart fa_cart_wishlist '></i><span class='tooltipp'>Add to Cart</span></a>";

                }
                deal_dis += "</div>";
                deal_dis += "</div>";
                
                deal_dis += "</div>";

            }
            all_prods_deals.InnerHtml = deal_dis;

            string display = "";

            var prod = sr.getAllProducts().ToList();


            foreach (ServiceReference1.Product p in prod)
            {
                display += "<div class='product'>";
                display += "<div class='product-img'>";
                display += "<img src='" + p.PrImage + "' alt=''>";
                display += "<div class='product-label'>";

                if (p.PrOldPrice == 0)
                {
                    display += "</div>";
                    display += "</div>";
                    display += "<div class='product-body'>";
                    display += "<p class='product-category'>Category</p>";
                    display += "<h3 class='product-name'><a href='SingleProduct.aspx?Id=" + p.Id + "'>" + p.PrName + "</a></h3>";
                    display += "<h4 class='product-price'> R " + String.Format("{0:0.00}", p.PrPrice) + "</h4>";

                }
                else
                {

                display += "<span class='sale'>" + String.Format("{0:0}", 100 - ((p.PrPrice / p.PrOldPrice) * 100)) + "%</span>";
                display += "</div>";
                display += "</div>";
                display += "<div class='product-body'>";
                display += "<p class='product-category'>Category</p>";
                display += "<h3 class='product-name'><a href='SingleProduct.aspx?Id='"+ p.Id+ "'>" + p.PrName + "</a></h3>";
                display += "<h4 class='product-price'> R " + String.Format("{0:0.00}", p.PrPrice) + "<del class='product-old-price'>R " + String.Format("{0:0.00}", p.PrOldPrice) + "</del></h4>";

                }

                display += "<div class='product-rating'>";

                display += "</div>";
                display += "<div class='product-btns'>";
                display += "<a class='add-to-wishlist'><i class='fa fa-heart-o fa_cart_wishlist'></i><span class='tooltipp'>Add to Wishlist</span></a>";
                if (Session["LoggedInID"] != null)
                {
                        display += "<a class='add-to-wishlist' href='AllProducts.aspx?AddToCartId=" + p.Id + "' ><i class='fa fa-shopping-cart fa_cart_wishlist '></i><span class='tooltipp'>Add to Cart</span></a>";
                }
                else
                {
                    display += "<a class='add-to-wishlist' href='login.aspx' ><i class='fa fa-shopping-cart fa_cart_wishlist '></i><span class='tooltipp'>Add to Cart</span></a>";

                }
                
                display += "</div>";
                display += "</div>";
                
                display += "</div>";

            }

            all_prods.InnerHtml = display;
        }


    }
}