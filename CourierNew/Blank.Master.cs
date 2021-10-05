using BL.AuthenticationAndSession;
using System;

namespace CourierNew
{
    public partial class Blank : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUniversalDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCompany.Text = ClsSessionKeys.CompanyKey.ToString();

            //txtFromDate.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            //txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}