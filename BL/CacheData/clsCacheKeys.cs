using BL.AuthenticationAndSession;
using BL.Settings;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL
{
    public class ClsCacheKeys
    {
        public static String CacheManufacturerKey
        {
            get
            {
                return "CacheManufacturerKey";
            }
        }

        public static string CacheSupplierItemKey
        {
            get
            {
                return "CacheSupplierItemKey" + ClsSessionKeys.UserID.ToString();
            }
        }

        public static string CacheItem2Storage
        {
            get
            {
                return "CacheItem2Storage" + ClsSessionKeys.UserID.ToString();
            }
        }
        public static string CacheCategoryKey
        {
            get
            {
                return "CacheCategoryKey" + ClsSessionKeys.UserID.ToString();
            }
        }

        public static string CacheItemProcessKey
        {
            get
            {
                return "CacheItemProcessKey" + ClsSessionKeys.UserID.ToString();
            }
        }

        public static String CacheRoleKey
        {
            get
            {
                return "CacheRoleKey";// + ClsSessionKeys.UserID.ToString();
            }
        }
        public static String CacheRoleTabKey
        {
            get
            {
                return "CacheRoleTabKey" + ClsSessionKeys.UserID.ToString();
            }
        }
        public static String CacheItemSubGroup
        {
            get
            {
                return "CacheItemSubGroup" + ClsSessionKeys.UserID.ToString();
            }
        }



        public static String CacheAddresses
        {
            get
            {
                return "CacheAddresses" + ClsSessionKeys.UserID.ToString();
            }
        }

        public static String CacheContact
        {
            get
            {
                return "CacheContact" + ClsSessionKeys.UserID.ToString();
            }
        }
        public static String CacheCustContactRefes
        {
            get
            {
                return "CacheCustContactRefes" + ClsSessionKeys.UserID.ToString();
            }
        }
        public static String CacheItemCustomerKey
        {
            get
            {
                return "CacheItemCustomerKey" + ClsSessionKeys.UserID.ToString();
            }
        }
        public static String CacheWorld
        {
            get
            {
                return "CacheWorld" + ClsSessionKeys.CompanyKey.ToString();
            }
        }

        public static String CacheDefaultFieldsShowKey
        {
            get
            {
                return "CacheDefaultFieldsShowKey" + ClsSessionKeys.CompanyKey.ToString();
            }
        }
        public static String CacheConfigurationKey
        {
            get
            {
                return "CacheConfigurationKey" + ClsSessionKeys.CompanyKey.ToString();
            }
        }
        public static String CacheBannerMain
        {
            get
            {
                return "CacheBannerMain" + ClsSessionKeys.CompanyKey.ToString();
            }
        }
        public static String CacheCompanyKey
        {
            get
            {
                return "CacheCompanyKey" + ClsSessionKeys.CompanyKey.ToString();
            }
        }
        public static String ParentLinkKey
        {
            get
            {
                return "ParentLinkKey" + ClsSessionKeys.UserID.ToString();
            }
        }
        public static String CacheNoteDetail
        {
            get
            {
                return ClsSessionKeys.UserID.ToString() + "NoteDetail";
            }
        }
    }
    public static class ClsCacheData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enRole"></param>
        /// <returns></returns>
        public static Boolean IsAllowToAccess(enUserRoles enRole, enRoleType enRoleType)
        {
            try
            {

                var objUser = ClsSessionData.GetLoginUserDataFromSession();
                if (objUser == null)
                {
                    return false;
                }
                if (objUser.UserRoleName.Replace(" ","").ToUpper().Contains("SUPERADMIN") )
                {
                    return true;
                }
                ClsRoles objRoels = new ClsRoles();
                List<ClsRolesMember> objList = (List<ClsRolesMember>)objRoels.GetRolesList(0, false);

                if (objList != null)
                {
                    var Permission = false;
                    if (enRoleType.Add == enRoleType)
                    {
                        Permission = objList.Any(x => x.MenuId.Equals((int)enRole) && x.Add.Equals(true) && x.RoleId.Equals(objUser.UserRoleId));
                    }
                    else if (enRoleType.Edit == enRoleType)
                    {
                        Permission = objList.Any(x => x.MenuId.Equals((int)enRole) && x.Edit.Equals(true) && x.RoleId.Equals(objUser.UserRoleId));
                    }
                    else if (enRoleType.Delete == enRoleType)
                    {
                        Permission = objList.Any(x => x.MenuId.Equals((int)enRole) && x.Delete.Equals(true) && x.RoleId.Equals(objUser.UserRoleId));
                    }
                    else if (enRoleType.View == enRoleType)
                    {

                        Permission = objList.Any(x => x.MenuId.Equals((int)enRole) && x.View.Equals(true) && x.RoleId.Equals(objUser.UserRoleId));
                    }
                    else if (enRoleType.ViewLog == enRoleType)
                    {
                        Permission = objList.Any(x => x.MenuId.Equals((int)enRole) && x.ViewLog.Equals(true) && x.RoleId.Equals(objUser.UserRoleId));
                    }
                    else if (enRoleType.Print == enRoleType)
                    {
                        Permission = objList.Any(x => x.MenuId.Equals((int)enRole) && x.Print.Equals(true) && x.RoleId.Equals(objUser.UserRoleId));
                    }

                    return Permission;
                }
                else
                {
                    HttpContext.Current.Response.Redirect("Pages/Login.aspx");
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
