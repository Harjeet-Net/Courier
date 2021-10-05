using CommonEntity;
using System;
using System.Web;
using System.Web.Security;
using System.Linq;
namespace BL.AuthenticationAndSession
{
    public class ClsAuthenticateUsers
    {
        public static void AuthenticateUser(string pinUserName, string pinPassword, bool rememberUserName, string pinBranchCode)
        {
            if (pinBranchCode is null)
            {
                throw new ArgumentNullException(nameof(pinBranchCode));
            }

            try
            {
                if (pinUserName.Length.Equals(0) || pinPassword.Length.Equals(0))
                {
                    throw new Exception("Please enter user name and password.");
                }
                // for this demo purpose, I am storing user details into xml file
                ClsSessionMember thisSessionUser = new ClsSessionMember();
                HttpContext.Current.Session.Remove("SessionData");

                pinBranchCode = ClsSessionKeys.CompanyCode;

                int UserKey = ClsUserMaster.AuthenticateUser(pinUserName, pinPassword, pinBranchCode);
         
               


                if (UserKey > 0)
                {
                    ClsUserMaster objUser = new ClsUserMaster
                    {
                        UserMasterKey = UserKey
                    };
                    var LstUser = objUser.GetUserMaster();
                    ClsSessionMember objUsers = new ClsSessionMember();

                    foreach (var UserData in LstUser)
                    {
                        HttpContext.Current.Session["userName"] = UserData.UserName;
                        thisSessionUser.UserID = UserData.UserMasterKey;
                        thisSessionUser.UserName = UserData.UserName;
                        thisSessionUser.UserFullName = UserData.UserFullName;
                        thisSessionUser.UserImage = UserData.ByteToIMage;
                        thisSessionUser.UserRoleId = FNC.Conv(UserData.UserRoleKey, enDataType.INT);
                        thisSessionUser.UserRoleName = UserData.UserRoleName;
                  //      thisSessionUser.CompanyName = Company.CompanyName;



                    }
                }
                else // wrong username and password
                {
                    // do nothing, Login control will automatically show the failure message
                    // if you are not using Login control, show the failure message explicitely
                    throw new Exception("<h3 class='text-red text-center'>Invalied user name , password or user is in active.</h3>");
                }


                //var Profile = UserData.Profile;
                HttpContext.Current.Session["SessionData"] = thisSessionUser;
                //HttpContext.Current.Application["CompanyLogo"] = Profile.Logo;
                //HttpContext.Current.Application["CompanyName"] = Profile.CompanyName;
                // Create forms authentication ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, // Ticket version
                pinUserName,// Username to be associated with this ticket
                DateTime.Now, // Date/time ticket was issued
                DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
                rememberUserName, // if user has chcked rememebr me then create persistent cookie
                thisSessionUser.UserRoleName, // store the user data, in this case roles of the user
                FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.

                // To give more security it is suggested to hash it
                string hashCookies = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket

                // Add the cookie to the response, user browser
                HttpContext.Current.Response.Cookies.Add(cookie);

                // Get the requested page from the url
                string returnUrl = null;// Request.QueryString["ReturnUrl"];
                                        // check if it exists, if not then redirect to default page
                if (returnUrl == null) { 
                    returnUrl = "~/Home.aspx";
                    var CurrentRole = thisSessionUser.UserRoleName;
                    //if (CurrentRole.Equals("SUPERVISOR (OPERATIONS)"))
                    //{
                    //    returnUrl = "~/Pages/RowDataImport";
                    //}
                    //else if (CurrentRole.Equals("DATA ENTRY"))
                    //{
                    //    returnUrl = "~/Pages/CallCentreStaffCalling";
                    //}
                    //else if (CurrentRole.Equals("DELIVERY SUPERVISOR"))
                    //{
                    //    returnUrl = "~/Pages/RouteWiseDeliveryAllocation";
                    //}
                    //else if (CurrentRole.Equals("DELIVERY PERSON"))
                    //{
                    //    returnUrl = "~/Pages/DeliveryMaster";
                    //}
                }


                HttpContext.Current.Response.Redirect(returnUrl, false);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
