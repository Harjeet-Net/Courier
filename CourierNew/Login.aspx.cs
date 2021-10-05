using BL.AuthenticationAndSession;
using CommonEntity;
using System;
using System.Web;

namespace CourierNew
{
    public partial class Login : ClsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    // String En = FNC.EncryptData(@"Data Source=IMRAN\SQL2008R2;Initial Catalog=WINROMS;User ID=sa;Password=sa");

                }

                ltMsg.Text = "";
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString()); }

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            txtUserId.Text = "";
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

        }


        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public string RequestSite
        {
            get { return HttpContext.Current.Request.Url.AbsoluteUri.ToString(); }
        }

        protected void BtnLogin_Click1(object sender, EventArgs e)
        {

            string userName = txtUserId.Text;
            string password = txtPassword.Text;// FNC.EncryptData( txtPassword.Text);
            String branchcode = "001";

            try
            {
                ClsAuthenticateUsers.AuthenticateUser(userName, password, false, branchcode);
            }
            catch (Exception ex) { ltMsg.Text = ex.Message.ToString(); }

        }
    }
}