using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace BL.Settings
{
    public class ClsRolesMember : ClsBaseBL
    {
        public int PermissionKey { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public bool Add { get; set; }

        public bool Edit { get; set; }

        public bool Delete { get; set; }

        public bool View { get; set; }

        public bool ViewLog { get; set; }

        public bool Print { get; set; }

        public string RoleName { get; set; }

        public string MenuName { get; set; }

        public int ModuleID { get; set; }

    }
    public class ClsRoles : ClsRolesMember
    {

        public DataSet ROL_GetUserPerMission(int iRoleId)
        {
            try
            {
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                     new SqlParameter("@RoleId"                ,iRoleId  ),

                };
                return objSql.ExecuteDataSet("UserPermissionGet", objParam);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<ClsRolesMember> GetRolesList(int iRoleId, bool bRemoveCache)
        {
            try
            {
                if (bRemoveCache)
                {
                    HttpContext.Current.Cache.Remove(ClsCacheKeys.CacheRoleKey);
                }
                if (System.Web.HttpContext.Current.Cache[ClsCacheKeys.CacheRoleKey] != null)
                {
                    return (List<ClsRolesMember>)HttpContext.Current.Cache[ClsCacheKeys.CacheRoleKey];
                }


                var ds = ROL_GetUserPerMission(iRoleId);

                List<ClsRolesMember> lstRole = new List<ClsRolesMember>();

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ClsRolesMember objGet = new ClsRolesMember();
                        objGet.PermissionKey = dr["PermissionKey"] is DBNull ? 0 : Convert.ToInt32(dr["PermissionKey"].ToString());
                        objGet.RoleId = dr["RoleId"] is DBNull ? 0 : Convert.ToInt32(dr["RoleId"].ToString());
                        objGet.MenuId = dr["MenuId"] is DBNull ? 0 : Convert.ToInt32(dr["MenuId"].ToString());
                        objGet.Add = dr["Add"] is DBNull ? false : Convert.ToBoolean(dr["Add"].ToString());
                        objGet.Edit = dr["Edit"] is DBNull ? false : Convert.ToBoolean(dr["Edit"].ToString());
                        objGet.Delete = dr["Delete"] is DBNull ? false : Convert.ToBoolean(dr["Delete"].ToString());
                        objGet.View = dr["View"] is DBNull ? false : Convert.ToBoolean(dr["View"].ToString());
                        objGet.ViewLog = dr["ViewLog"] is DBNull ? false : Convert.ToBoolean(dr["ViewLog"].ToString());
                        objGet.Print = dr["Print"] is DBNull ? false : Convert.ToBoolean(dr["Print"].ToString());
                        objGet.ModuleID = dr["ModuleID"] is DBNull ? 0 : Convert.ToInt32(dr["ModuleID"].ToString());
                        objGet.MenuId = dr["MenuId"] is DBNull ? 0 : Convert.ToInt32(dr["MenuId"].ToString());


                        objGet.MenuName = (dr["MenuName"] ?? "").ToString();
                        objGet.RoleName = (dr["RoleName"] ?? "").ToString();
                        lstRole.Add(objGet);
                    }
                }

                HttpContext.Current.Cache.Insert(ClsCacheKeys.CacheRoleKey, lstRole, null, DateTime.MaxValue, TimeSpan.FromHours(24));

                return lstRole;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public int AddUpdateDelete(String sXML)
        {
            try
            {
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@XML",  sXML),
                      new SqlParameter("@ModuleID", ModuleID),
                      new SqlParameter("@RoleId", RoleId) ,
                      new SqlParameter("@UserID", ClsSessionKeys.UserID)
                };
                return objSql.ExecuteNonQuery("UserPermissionUpdate", objParam);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}
