using BL.Common;
using CommonEntity;
using DL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BL.AuthenticationAndSession
{
    public class ClsUserMasterMember: ClsBaseBL
    {
   
        public int UserMasterKey { get; set; }

        public string UserCode { get; set; }

        public string UserFullName { get; set; }

        public string UserImage { get; set; }

        public byte[] UserImageByte { get; set; }

        public int? PositionKey { get; set; }

        public string AllowToAccessLogin { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public bool? UserActive { get; set; }

        public int? UserRoleKey { get; set; }

        public int? RouteKey { get; set; }

        public int? VehicleKey { get; set; }
        [JsonIgnore]
        public String ByteToIMage { get; set; }

        /****************EXtended property ****************************/

        public String Button { get; set; }

        public int RowIndex { get; set; }
        public string RouteKeyName { get; set; }
        public string VehicleKeyName { get; set; }
        public string UserRoleName { get; set; }
        public String RouteCollection { get; set; }
        public DataTable DtDriver2Route { get; set; }
    }


    public class ClsUserMaster : ClsUserMasterMember
    {
        public static int AuthenticateUser(string pinUserName, String pinUserPassword, String pinCOmpanyCode)
        {
            try
            {
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@UserName"                    ,pinUserName  ),
                      new SqlParameter("@UserPassword"                ,pinUserPassword  ),
                      new SqlParameter("@CompanyCode"                 ,pinCOmpanyCode  )
                };

                return FNC.Conv(objSql.ExecuteScalar("UserAutehnticate", objParam), enDataType.INT);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int AddUpdateDelete()
        {
            try
            {
                ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
                SqlParameter[] objPrams = new SqlParameter[]
                {
                        new SqlParameter("@UserMasterKey",                           UserMasterKey),
                        new SqlParameter("@UserCode",                                UserCode),
                        new SqlParameter("@UserFullName",                            UserFullName),
                        new SqlParameter("@UserImage",                               UserImage),
                        new SqlParameter("@UserImageByte",                           SqlDbType.VarBinary,-1),
                        new SqlParameter("@PositionKey",                             PositionKey),
                        new SqlParameter("@AllowToAccessLogin",                      AllowToAccessLogin),
                        new SqlParameter("@UserName",                                UserName),
                        new SqlParameter("@UserPassword",                            UserPassword),
                        new SqlParameter("@UserActive",                              UserActive),
                        new SqlParameter("@UserRoleKey",                             UserRoleKey),
                        new SqlParameter("@RouteKeys",                               RouteCollection),
                        new SqlParameter("@VehicleKey",                              VehicleKey),
                        new SqlParameter("@UserID",                                  UserID),
                        new SqlParameter("@Action",                                  Action.ToString())
                };
                objPrams[4].Value = UserImageByte;
                var result = objSave.ExecuteNonQuery("UserMasterSAVE", objPrams);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClsUserMasterMember> GetUserMaster()
        {
            try
            {
                List<ClsUserMasterMember> objList = new List<ClsUserMasterMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@UserMasterKey",  UserMasterKey  ),

                };
                DataSet  ds = objSql.ExecuteDataSet("UserMasterGET", objParam);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ClsUserMasterMember objGet = new ClsUserMasterMember();
                    {
                        objGet.UserMasterKey = dr["UserMasterKey"] is DBNull ? 0 : Convert.ToInt32(dr["UserMasterKey"].ToString());
                        objGet.UserCode = (dr["UserCode"] ?? "").ToString();
                        objGet.UserFullName = (dr["UserFullName"] ?? "").ToString();
                        objGet.PositionKey = dr["PositionKey"] is DBNull ? 0 : Convert.ToInt32(dr["PositionKey"].ToString());
                        objGet.AllowToAccessLogin = (dr["AllowToAccessLogin"] ?? "").ToString();
                        objGet.UserName = (dr["UserName"] ?? "").ToString();
                        objGet.UserPassword = (dr["UserPassword"] ?? "").ToString();
                        objGet.UserActive = dr["UserActive"] is DBNull ? false : Convert.ToBoolean(dr["UserActive"].ToString());
                        objGet.UserRoleKey = dr["UserRoleKey"] is DBNull ? 0 : Convert.ToInt32(dr["UserRoleKey"].ToString());
                        objGet.RouteKey = dr["RouteKey"] is DBNull ? 0 : Convert.ToInt32(dr["RouteKey"].ToString());
                        objGet.VehicleKey = dr["VehicleKey"] is DBNull ? 0 : Convert.ToInt32(dr["VehicleKey"].ToString());
                        objGet.UserImage = (dr["UserImage"] ?? "").ToString();
                        objGet.RouteKeyName = (dr["RouteKeyName"] ?? "").ToString();
                        objGet.VehicleKeyName = (dr["VehicleKeyName"] ?? "").ToString();
                        objGet.UserRoleName = (dr["UserRoleName"] ?? "").ToString();
                        objGet.UserImageByte = String.IsNullOrEmpty(dr["UserImageByte"].ToString()) ? null : (byte[])dr["UserImageByte"];
                    };

                    objGet.ByteToIMage = String.IsNullOrEmpty(dr["UserImageByte"].ToString()) ? "" : "data:image/png;base64," + Convert.ToBase64String(objGet.UserImageByte, 0, objGet.UserImageByte.Length);
                    //objGet.DtDriver2Route = ds.Tables[1];

                    objList.Add(objGet);
                }

                return objList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public List<ClsUserMasterMember> SearchUserMaster()
        {
            try
            {
                List<ClsUserMasterMember> objList = new List<ClsUserMasterMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@UserMasterKey",  UserMasterKey  ),

                };
                IDataReader dr = objSql.ExecuteReader("UserMasterSEARCH", objParam);
                int Lc = 0;
                while (dr.Read())
                {
                    ClsUserMasterMember objGet = new ClsUserMasterMember();
                    {
                        
                        objGet.UserCode = (dr["UserCode"] ?? "").ToString();
                        objGet.UserFullName = (dr["UserFullName"] ?? "").ToString();
                        objGet.PositionKey = dr["PositionKey"] is DBNull ? 0 : Convert.ToInt32(dr["PositionKey"].ToString());
                        objGet.AllowToAccessLogin = (dr["AllowToAccessLogin"] ?? "").ToString();
                        objGet.UserName = (dr["UserName"] ?? "").ToString();
                        objGet.UserPassword = (dr["UserPassword"] ?? "").ToString();
                        objGet.UserActive = dr["UserActive"] is DBNull ? false : Convert.ToBoolean(dr["UserActive"].ToString());
                        objGet.UserRoleKey = dr["UserRoleKey"] is DBNull ? 0 : Convert.ToInt32(dr["UserRoleKey"].ToString());
                        objGet.RouteKey = dr["RouteKey"] is DBNull ? 0 : Convert.ToInt32(dr["RouteKey"].ToString());
                        objGet.VehicleKey = dr["VehicleKey"] is DBNull ? 0 : Convert.ToInt32(dr["VehicleKey"].ToString());
                        objGet.UserImage = (dr["UserImage"] ?? "").ToString();
                        objGet.RouteKeyName = (dr["RouteKeyName"] ?? "").ToString();
                        objGet.VehicleKeyName = (dr["VehicleKeyName"] ?? "").ToString();
                        objGet.UserRoleName = (dr["UserRoleName"] ?? "").ToString();

                        objGet.Button = (dr["Button"] ?? "").ToString();
                        objList.Add(objGet);
                        objGet.RowIndex = Lc + 1;
                        Lc += 1;

                    };
                 //   objGet.ByteToIMage = String.IsNullOrEmpty(dr["UserImageByte"].ToString()) ? "" : "data:image/png;base64," + Convert.ToBase64String(objGet.UserImageByte, 0, objGet.UserImageByte.Length);

                   
                }

                return objList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }  // End Of Class

}
