using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
    public partial class shop1 : System.Web.UI.MasterPage
    {

        Service1Client sr = new Service1Client();

        private static int subTot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            String admin = Convert.ToString(Session["AdminValue"]);
            int u_Id = Convert.ToInt32(Session["LoggedInId"]) ;
            if ( u_Id!= 0)
            {

                    
                my_cart.Visible = true;
                //string dis_cart = "";
                string disp_num_items = "";
                string disp_cart_list = "";
                string disp_cart_summary = "";
            
                sr.numItemsInCart(u_Id);

              
                int prodToAdd = Convert.ToInt32(Request.QueryString["AddToCartId"]);
                
                if (sr.numItemsInCart(u_Id) > 0)
                {
                    subTot = 0;
                    if(prodToAdd != 0)
                    {
                        var add = new Cart
                        {
                            Prod_Id = prodToAdd,
                            User_Id = Convert.ToInt32(u_Id),
                        };

                        int result = sr.addToCart(add);
                        if (result == 1)
                        {
                            
                            disp_cart_list += populateCart(u_Id, disp_cart_list);
                            //disp_cart_summary += "<small>"+ sr.numItemsInCart(u_Id)+" Item(s) selected</small>";
                            //disp_cart_summary += "<h5>SUBTOTAL: R " + String.Format("{0:0.00}",subTot)+ "</h5>";
                        }
                    }
                    else
                    {

                       
                        disp_cart_list += populateCart(u_Id, disp_cart_list);
                        //disp_cart_summary += "<small>" + sr.numItemsInCart(u_Id) + " Item(s) selected</small>";
                        //disp_cart_summary += "<h5>SUBTOTAL: R " + String.Format("{0:0.00}", subTot) + "</h5>";
                    }
                }
                else if (prodToAdd != 0)
                {
                    var add = new Cart
                    {
                        Prod_Id = prodToAdd,
                        User_Id = Convert.ToInt32(u_Id),
                    };

                    int result = sr.addToCart(add);
                    if (result == 1)
                    {
                        
                        disp_cart_list += populateCart(u_Id, disp_cart_list);

                    }
                }
                else
                {
                    //disp_cart_summary += "<small>0 Item(s) selected</small>";
                    //disp_cart_summary += "<h5>SUBTOTAL: R 0.00</h5>";
                }

                if (prodToAdd == 0)
                {
                int prodToRemove = Convert.ToInt32(Request.QueryString["RemoveFromCartId"]);

                if(prodToRemove > 0)
                {
                    var cart = new Cart
                    {
                        User_Id = u_Id,
                        Prod_Id = prodToRemove,
                    };
                        int res = sr.removeFromCart(cart);
                    if (res >0)
                    {
                            disp_num_items = "";
                            disp_cart_list = "";
                            subTot = 0;
                        disp_cart_list += populateCart(u_Id,disp_cart_list);    
                    }
                }
                }
                disp_num_items += sr.numItemsInCart(u_Id);

                disp_cart_summary += "<small>" + sr.numItemsInCart(u_Id) + " Item(s) selected</small>";
                disp_cart_summary += "<h5>SUBTOTAL: R " + String.Format("{0:0.00}", subTot) + "</h5>";

                num_cart_items.InnerHtml = disp_num_items;
                cart_list.InnerHtml = disp_cart_list;
                cart_summary.InnerHtml = disp_cart_summary;
            
                logout.Visible = true;
                login.Visible = false;
                signup.Visible = false;

                if (admin.Equals("Manager"))
                {
                    add.Visible = true;
                    edit.Visible = true;
                    remove.Visible = true;
                    report.Visible = true;
                }


            }
            
        }

    private string populateCart(int id,string disp_cart_list )
    {

            var InCart = sr.getProdsInCart(id);
             
            foreach (Cart c in InCart)
            {
                if(c != null)
                {

                var single_prod = sr.getProduct(c.Prod_Id);

                disp_cart_list += "<div class='product-widget'>";
                disp_cart_list += "<div class='product-img'>";
                disp_cart_list += "<img src='" + single_prod.PrImage + "' alt=''>";
                disp_cart_list += "</div>";
                disp_cart_list += "<div class='product-body'>";
                disp_cart_list += "<h3 class='product-name'><a href='#'>" + single_prod.PrName + "</a></h3>";

                disp_cart_list += "<h4 class='product-price'><span class='qty'>" + c.Quantity + "x</span>R " + String.Format("{0:0.00}", single_prod.PrPrice * c.Quantity) + "</h4>";

                disp_cart_list += "</div>";
               
                disp_cart_list += "<a class='delete' href='AllProducts.aspx?RemoveFromCartId=" + single_prod.Id + "' ><i class='fa fa-close'></i></a>";
               
                disp_cart_list += "</div>";

                    //if (Request.QueryString["RemoveFromCartId"]==null)
                    //{
                        subTot += (int)single_prod.PrPrice * c.Quantity;
                    //}
                    //else
                    //{
                    //    subTot -= (int)single_prod.PrPrice ;

                    //}

                }
                else
                {
                    disp_cart_list = "";
                }
            }
            return disp_cart_list;  
    }
    }
}