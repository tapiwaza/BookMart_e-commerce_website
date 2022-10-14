using PracXFinal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracXFinal
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddP_Click(object sender, EventArgs e)
        {
            Service1Client sr = new Service1Client();

            var newProduct = new ServiceReference1.Product
            {
                PrName = pname.Value,
                PrDescription = pdesc.Value,
                PrCategory = pcat.Value,
                PrQuantity = Convert.ToInt32(pquant.Value),
                PrPrice = Convert.ToDecimal(pprice.Value),
                PrOldPrice = Convert.ToDecimal(poprice.Value),
                PrStatus =  pstatus.Value,
                PrImage = imagelink.Value

            };

            int result = sr.addProduct(newProduct);

            if (result == 1)
            {
                //product added
                lblProductMessage1.Text = "Product Added!";

            }
            else if (result == -1)
            {
                //product not added 
                lblProductMessage1.Text = "Product NOT Added!";
            }
            else if (result == 0)
            {
                //product already exists
                lblProductMessage1.Text = "Product NOT Added!/nProduct Already Exists";
                
            }


        }
    }
}