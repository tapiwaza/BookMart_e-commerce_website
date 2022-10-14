using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashPass;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
	public partial class Login : System.Web.UI.Page
	{
           Service1Client sr = new Service1Client();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var hashed = Secrecy.HashPassword(pass.Value);
            User result = sr.Login(email.Value, hashed);

            if (result != null)
            {
                Session["LoggedInID"] = result.Id;
                Session["AdminValue"] = result.UserType;
                Response.Redirect("index.aspx");
            }
            else
            {
                //show that they dont have an account
                error.Text = "Account does not exist please Register";
            }
        }
    }
}