using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
    public partial class MyCart : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LoggedInID"] != null)
            {

                
            }
        }
    }
}