using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
    public partial class Product : System.Web.UI.Page
    {

        Service1Client sr = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            populateProducts(sr.getAllProducts().ToList());
        }

        public void populateProducts(dynamic list)
        {

            string display = "";
            dynamic prod = list;
            foreach (ServiceReference1.Product p in prod)
            { 
                display += "<div class='col-md-4 col-xs-6'>";
                display += "<div class='product'>";
                display += "<div class='product-img'>";
                display += "<img src='" + p.PrImage + "' alt='Image'>";
                display += "<div class='product-label'>";


                if (p.PrOldPrice == 0)
                {
                    display += "</div>";
                    display += "</div>";
                    display += "<div class='product-body'>";
                    display += "<p class='product-category'>"+p.PrCategory+"</p>";
                    display += "<h3 class='product-name'><a href='SingleProduct.aspx?Id=" + p.Id + "'>" + p.PrName + "</a></h3>";
                    display += "<h4 class='product-price'> R " + String.Format("{0:0.00}", p.PrPrice) + "</h4>";

                }
                else
                {

                    display += "<span class='sale'>" + String.Format("{0:0}", 100 - ((p.PrPrice / p.PrOldPrice) * 100)) + "%</span>";
                    display += "</div>";
                    display += "</div>";
                    display += "<div class='product-body'>";
                    display += "<p class='product-category'>" + p.PrCategory + "</p>";
                    display += "<h3 class='product-name'><a href='SingleProduct.aspx?Id="+ p.Id+ "'>" + p.PrName + "</a></h3>";
                    display += "<h4 class='product-price'> R " + String.Format("{0:0.00}", p.PrPrice) + "<del class='product-old-price'>R " + String.Format("{0:0.00}", p.PrOldPrice) + "</del></h4>";

                }

                display += "<div class='product-btns'>";
                display += "<a class='add-to-wishlist' href='SingleProduct.aspx?AddToWishListId="+ p.Id+ "'><i class='fa fa-heart-o fa_cart_wishlist '></i><span class='tooltipp'>Add to Wishlist </span></a>";

                if (Session["LoggedInID"] != null)
                {
                    display += "<a class='add-to-wishlist' href='AllProducts.aspx?AddToCartId="+p.Id+"'><i class='fa fa-shopping-cart fa_cart_wishlist '></i><span class='tooltipp'>Add to Cart</span></a>";
                }
                else
                {
                    display += "<a class='add-to-wishlist' href='login.aspx' ><i class='fa fa-shopping-cart fa_cart_wishlist '></i><span class='tooltipp'>Add to Cart</span></a>";

                }
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";

            }
            all_prods.InnerHtml = display;
            
        }


        protected void Sorter(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                populateProducts(sr.getAllProductsAlphabetically().ToList());
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                populateProducts(sr.getAllProductsByPrice().ToList());
            }

        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(price_min.Value);
            int max = Convert.ToInt32(price_max.Value);
            
            populateProducts(sr.getAllProductsPriceFiltered(min, max).ToList());
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CheckBoxList1.SelectedIndex == 0)
            {
                populateProducts(sr.getAllProductsCategoryFiltered('N').ToList());
            }
            else if (CheckBoxList1.SelectedIndex == 1)
            {

                populateProducts(sr.getAllProductsCategoryFiltered('E').ToList());
            

            }
            else if (CheckBoxList1.SelectedIndex == 2)
            {
                populateProducts(sr.getAllProductsCategoryFiltered('A').ToList());

            }
            else
            {
                populateProducts(sr.getAllProducts().ToList());
            }
        }



    }
}