using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracXFinal
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoggedInID"] = null;
            Session["AddToCartId"] = null;
            Session["AdminValue"] = null;
            Response.Redirect("index.aspx");
        }
    }
}