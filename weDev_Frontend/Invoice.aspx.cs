using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PracXFinal.ServiceReference1;

namespace PracXFinal
{

    public partial class Invoice : System.Web.UI.Page
    {
    Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int user_Id = Convert.ToInt32(Session["LoggedInID"]);
            if(user_Id != 0)
            {
                var invs = sr.existingInvoices(user_Id);

				string disp_invs = "";
                disp_invs += "<div class='title' style='margin-bottom:5rem;'>";
                disp_invs += "<h3>INVOICES</h3>";
                disp_invs += "</div>";

                foreach(ServiceReference1.Invoice i in invs)
                {
                    if (i != null)
                    {


                        disp_invs += "<div class='col-md-12 order-details'>";
                        disp_invs += "<div class='order-summary'>";
                        disp_invs += "<div class='order-col'>";
                        disp_invs += "<div><h3 class='title'>Invoice : #" + i.Id + "</h3></div>";
                        disp_invs += "<div><h5 class='title'>Date : " + i.Date + "</h5></div>";
                        disp_invs += "</div>";
                        disp_invs += "<div class='order-col'>";
                        disp_invs += "<div><strong>ITEMS</strong></div>";
                        disp_invs += "<div>" + i.Quantity + " Item(s) </div > ";
                        disp_invs += "<div><strong>TOTAL</strong></div>";
                        disp_invs += "<div> R " + i.Total_ + ".00 </div > ";
                        disp_invs += "</div>";
                         
                        disp_invs += "</div>";
                        disp_invs += "</div>";
                    }
                    else
                    {
                        disp_invs += "<div class='col-md-12 order-details text-center'>";
                        disp_invs += "<div class='order-summary' style='display:flex;justify-content:center;align-items:center;'>";
                        disp_invs += "<div class='title'>";
                        disp_invs += "<h3>You have no previous Invoices</h3>";
                        disp_invs += "</div>";
                        disp_invs += "</div>";
                        disp_invs += "</div>";
                    }
                }

                invoices.InnerHtml = disp_invs;
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}