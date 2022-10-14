using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracXFinal
{
    public partial class Purchased : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrevInvoices(object sender, EventArgs e)
        {
            Response.Redirect("Invoices.apsx");
        }
    }
}