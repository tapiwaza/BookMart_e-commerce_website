using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracXFinal.ServiceReference1;

namespace PracXFinal
{
    public partial class Report : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            var prods = sr.getAllProducts();

            popProds(prods);

            int numNovs = sr.getNumOfNovels();

            nov_tot.InnerHtml = numNovs.ToString();

            int numEbooks = sr.getNumOfEbooks();

            ebooks_tot.InnerHtml = numEbooks.ToString();

            int numAudioBooks = sr.getNumOfAudioBooks();

            audio_tot.InnerHtml = numAudioBooks.ToString();

            tot_cats.InnerHtml = (numAudioBooks + numEbooks + numNovs).ToString();

            user_tot.InnerHtml = sr.getAllRegisteredUsers().ToString();

            tot_mans.InnerHtml = sr.getAllRegManagers().ToString();

            tot_custs.InnerHtml = sr.getAllRegCustomers().ToString();

            bought_once_tot.InnerHtml = sr.numOfUsersWithTrans().ToString();

            once_more_tot.InnerHtml = sr.numOfUsersWithTrans().ToString();

        }

      

        public void popProds(dynamic list)
        {
            string disp = "";

            var prods = list;

            foreach (PracXFinal.ServiceReference1.Product p in prods)
            {
                disp += "<div class='col-md-1 reports'>";
                disp += "<strong>" + p.Id + "</strong>";
                disp += "</div>";
                disp += "<div class='col-md-3 reports'>";
                disp += "<strong>" + p.PrName + "</strong>";
                disp += "</div>";
                disp += "<div class='col-md-2 reports'>";
                disp += "<strong>" + p.PrCategory + "</strong>";
                disp += "</div>";
                disp += "<div class='col-md-1 reports'>";
                disp += "<strong>" + p.PrQuantity + "</strong>";
                disp += "</div>";
                disp += "<div class='col-md-2 reports'>";
                disp += "<strong> R " + String.Format("{0:0.00}", p.PrPrice) + "</strong>";
                disp += "</div>";
                disp += "<div class='col-md-2 reports'>";
                disp += "<strong> R " + String.Format("{0:0.00}", p.PrOldPrice) + "</strong>";
                disp += "</div>";
                disp += "<div class='col-md-1 reports'>";
                disp += "<strong>" + p.PrStatus + "</strong>";
                disp += "</div>";

            }

            reports_sec.InnerHtml = disp;
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(price_min.Value);
            int max = Convert.ToInt32(price_max.Value);

            popProds(sr.getAllProductsQuantityFiltered(min, max));
        }

        protected void Sorter(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex == 0)
            {
                popProds(sr.getAllProducts().ToList());

            }
            if (DropDownList1.SelectedIndex == 1)
            {
                popProds(sr.getAllProductsCategoryFiltered('N').ToList());
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                popProds(sr.getAllProductsCategoryFiltered('E').ToList());
            }
            else if(DropDownList1.SelectedIndex == 3)
            {
                popProds(sr.getAllProductsCategoryFiltered('A').ToList());
            }

        }

        protected void Date_Sorter(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex == 0)
            {
                user_tot.InnerHtml = sr.getAllRegisteredUsers().ToString();

                tot_mans.InnerHtml = sr.getAllRegManagers().ToString();

                tot_custs.InnerHtml = sr.getAllRegCustomers().ToString();

            }
            if (DropDownList2.SelectedIndex == 1)
            {
                user_tot.InnerHtml = sr.numOfRegisteredUsers(System.DateTime.Now).ToString();

                tot_mans.InnerHtml = sr.numOfRegManagers(System.DateTime.Now).ToString();

                tot_custs.InnerHtml = sr.numOfCustomers(System.DateTime.Now).ToString();

            }
            //else if (DropDownList2.SelectedIndex == 2)
            //{
            //    user_tot.InnerHtml = sr.numOfRegisteredUsers(System.DateTime.Now).ToString();

            //    tot_mans.InnerHtml = sr.numOfRegManagers(System.DateTime.Now).ToString();

            //    tot_custs.InnerHtml = sr.numOfCustomers(System.DateTime.Now).ToString();
            //}

        }
    }
}