using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
    public partial class CheckOut : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
         private static int total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string disp_tot = "";
            int u_Id = Convert.ToInt32(Session["LoggedInId"]);
            if(u_Id != 0)
            {
               string display = "";
                string disp_shipping = "";
                string disp_discount = "";
                string tax = "";
                int numItems = sr.numItemsInCart(u_Id);
                if (!IsPostBack)
                {

                    if (numItems > 0)
                    {
                        var InCart = sr.getProdsInCart(u_Id);
                        display = "";
                        total = 0;
                        foreach (Cart c in InCart)
                        {
                            var single_prod = sr.getProduct(c.Prod_Id);
                            display += "<div class='order-col'>";
                            display += "<div>"+ c.Quantity+"x "+ single_prod.PrName+"</div>";
                            display += "<div> R " + String.Format("{0:0.00}",single_prod.PrPrice* c.Quantity) + "</div>";
                            display += "</div>";
                            total += (int)single_prod.PrPrice * c.Quantity;
                        }

                        

                        btnCheck_Out.Visible = true;
                        if (total > 2500)
                        {
                            disp_discount += "<div>Discount</div>";
                            double discount =  (total * 0.2);
                            disp_discount += "<div><strong> R " + String.Format("{0:0.00}", discount    ) + "</strong></div>";
                            total -= (int)discount;
                        }
                        else
                        {
                            disp_discount = "";
                        }

                        tax += "<div>Tax (15%)</div>";
                        double taxes = total * 0.15;
                        tax += "<div><strong> R " + String.Format("{0:0.00}", taxes) + "</strong></div>";
                        total += (int)taxes;

                        disp_tot += "<div><strong>TOTAL</strong></div>";
                        disp_tot += "<div><strong class='order-total'> R " + String.Format("{0:0.00}", total ) + "</strong></div>";
                    
                        if(numItems > 3)
                        {
                            disp_shipping += "<div>Shiping</div>";
                            disp_shipping += "<div><strong>FREE</strong></div>";
                        }
                        else
                        {
                            disp_shipping += "<div>Shiping</div>";
                            disp_shipping += "<div><strong> R "+ String.Format("{0:0.00}",numItems*56,3)+"</strong></div>";
                        }

                        
                        shipping_cost.InnerHtml = disp_shipping;
                        discount.InnerHtml = disp_discount;
                    }
                    else
                    {
                            display += "<div class='order-col'>";
                            display += "<div>No Products Added</div>";
                            display += "<div>R 0.00</div>";
                            display += "</div>";

                            disp_tot += "<div><strong>TOTAL</strong></div>";
                            disp_tot += "<div><strong class='order-total'>R 0.00</strong></div>";
                    }
                    tot_tax.InnerHtml = tax;
                order_prods.InnerHtml += display;
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }

            my_total.InnerHtml = disp_tot;
        }

        protected void btnCheckOut(object sender, EventArgs e)
        {
            int user_Id = Convert.ToInt32(Session["LoggedInId"]);
            int quantity  = 0;
                var InCart = sr.getProdsInCart(user_Id);
                foreach (Cart c in InCart)
                {
                    var single_prod = sr.getProduct(c.Prod_Id);
                    quantity += c.Quantity;
                    //total += (int)single_prod.PrPrice * c.Quantity;
                }

            var newInv = new ServiceReference1.Invoice
            {
                User_Id = user_Id,
                Quantity = quantity,
                Total_ = total,
                Date = System.DateTime.Now

            };
            int res = sr.purchase(newInv);
            if(res == 1)
            {
                Response.Redirect("Purchased.aspx");
            }
            else
            {

            }
        }
    }
}