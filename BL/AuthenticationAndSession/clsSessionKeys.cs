using System;
using System.Configuration;
using System.Web;


namespace BL.AuthenticationAndSession
{
    public class ClsSessionMember
    {
        public int CompanyID { get; set; }

        public String CompanyCode { get; set; }

        public String CompanyName { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

        public string AppVersion { get; set; }

        public string Version { get; set; }

        public decimal MinorVersion { get; set; }

        public string UserImage { get; set; }

        public string UserPhone1 { get; set; }

        public string UserPhone2 { get; set; }

        public string SenderMailID { get; set; }

        public String UserFullName { get; set; }

        public int Themekey { get; set; }

        public int ProcessKey { get; set; }

        public String ProcessName { get; set; }

        public string SenderMailPassword { get; set; }

        public int? BranchID { get; set; }

        public string BranchCode { get; set; }


    }

    public class ClsSessionData
    {
        public static ClsSessionMember GetLoginUserDataFromSession()
        {
            try
            {
                var objUser = HttpContext.Current.Session["SessionData"] as ClsSessionMember;
                if (objUser == null)
                {
                    HttpContext.Current.Response.Redirect("~/login");
                }
                return objUser;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public static class ClsSessionKeys
    {


        public static String SenderEmailID
        {
            get { return ClsSessionData.GetLoginUserDataFromSession().SenderMailID; }
        }

        public static String SenderPassword
        {
            get { return ClsSessionData.GetLoginUserDataFromSession().SenderMailPassword; }
        }
        public static Boolean IsSuperAdmin()
        {
            var objUser = ClsSessionData.GetLoginUserDataFromSession();
            if (objUser == null)
            {
                HttpContext.Current.Response.Redirect("~/Pages/login.aspx");
            }
            else
            {
                if (objUser.UserRoleName.Equals("SuperVisor"))
                {
                    return true;
                }
            }
            return false;
        }
        public static int CompanyKey
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["CompanyID"].ToString());
            }

        }
        public static String CompanyCode
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyCode"].ToString();// clsSessionData.GetLoginUserDataFromSession().CompanyCode;
            }
        }
        public static String CompanyName
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().CompanyName;
            }
        }
        public static int UserID
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().UserID;
            }

        }


        public static String ImageUploadPathFTP
        {
            get
            {
                return "ftp://images.sensesoftech.com/" + ClsSessionKeys.CompanyCode;
            }
        }
        public static String ImageUploadPathWeb
        {
            get
            {
                return "http://images.sensesoftech.com/" + ClsSessionKeys.CompanyCode;
            }
        }
        public static String UserRoleName
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().UserRoleName;
            }

        }
        public static String UserFullName
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().UserFullName;
            }

        }
        public static int RoleID
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().UserRoleId;
            }

        }
        public static String UserImage
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().UserImage;
            }

        }
    }
}
