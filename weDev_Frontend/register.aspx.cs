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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

            Service1Client sr = new Service1Client();

                if (pass.Value == repass.Value)
                {

                var hashed = Secrecy.HashPassword(pass.Value);

                var newUser = new User
                {
                        Name = fname.Value,
                        Surname = lname.Value,
                        Email = email.Value,
                        Password = hashed,
                        UserType = type.Value,
                        DateReg = System.DateTime.Now
                };

                    int result = sr.register(newUser);

                    if (result == 1)
                    {
                        Response.Redirect("login.aspx");

                    }
                    else if (result == -1)
                    {
                    //user not added 
                    error.Text = "User Not Added";
                    }
                    else if (result == 0)
                    {
                    //user already exists
                    error.Text = "User Already Exists";
                    }

                }
            
        }

    }
}