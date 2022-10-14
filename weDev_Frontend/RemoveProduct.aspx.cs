using PracXFinal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracXFinal
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                pid.Value = "" + id;
            }
        }

        protected void btnRemP_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(pid.Value);

            int result = sr.removeProduct(id);

            if (result == 1)
            {
                //product Edited
                lblProductMessage1.Text = "Product Removed!";

            }
            else if (result == -1)
            {
                //product not Edited 
                lblProductMessage1.Text = "Product NOT Removed!";
            }
            else if (result == 0)
            {
                //Edited does not exist
                //make sure backend adds if product doesnt exist return 0 
                lblProductMessage1.Text = "Product NOT Removed!/nProduct Does Not Exists";

            }
        }
    }
}