using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.UserMaster
{
	public class clsUserMasterMember : ClsBaseBL
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
		public string RoleName {get;set;}
		public int UnAssignedPatient { get; set; }
		public int AssignedPatient { get; set; }
		public string XML { get; set; }
	}
	public class clsUserMaster : clsUserMasterMember
	{

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
						new SqlParameter("@UserImageByte",                           UserImageByte),
						new SqlParameter("@PositionKey",                             PositionKey),
						new SqlParameter("@AllowToAccessLogin",                      AllowToAccessLogin),
						new SqlParameter("@UserName",                                UserName),
						new SqlParameter("@UserPassword",                            UserPassword),
						new SqlParameter("@UserActive",                              UserActive),
						new SqlParameter("@UserRoleKey",                             UserRoleKey),
						new SqlParameter("@RouteKey",                                RouteKey),
						new SqlParameter("@VehicleKey",                              VehicleKey),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("UserMasterSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsUserMasterMember> GetUserMasterMemberList()
		{
			try
			{
				List<clsUserMasterMember> objList = new List<clsUserMasterMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@UserMasterKey",  UserMasterKey  ),

					  new SqlParameter("@CompanyID", CompanyID),
					  new SqlParameter("@UserID", UserID),
					  new SqlParameter("@Action", Action.ToString())
				};
				IDataReader dr = objSql.ExecuteReader("UserMasterGet", objParam);
				while (dr.Read())
				{
					clsUserMasterMember objGet = new clsUserMasterMember();

					objGet.UserMasterKey = dr["UserMasterKey"] is DBNull ? 0 : Convert.ToInt32(dr["UserMasterKey"].ToString());
					objGet.UserCode = (dr["UserCode"] ?? "").ToString();
					objGet.UserFullName = (dr["UserFullName"] ?? "").ToString();
					objGet.UserImage = (dr["UserImage"] ?? "").ToString();
			//		objGet.UserImageByte
					objGet.PositionKey = dr["PositionKey"] is DBNull ? 0 : Convert.ToInt32(dr["PositionKey"].ToString());
					objGet.AllowToAccessLogin = (dr["AllowToAccessLogin"] ?? "").ToString();
					objGet.UserName = (dr["UserName"] ?? "").ToString();
					objGet.UserPassword = (dr["UserPassword"] ?? "").ToString();
					objGet.UserActive = dr["UserActive"] is DBNull ? false : Convert.ToBoolean(dr["UserActive"].ToString());
					objGet.UserRoleKey = dr["UserRoleKey"] is DBNull ? 0 : Convert.ToInt32(dr["UserRoleKey"].ToString());
					objGet.RouteKey = dr["RouteKey"] is DBNull ? 0 : Convert.ToInt32(dr["RouteKey"].ToString());
					objGet.VehicleKey = dr["VehicleKey"] is DBNull ? 0 : Convert.ToInt32(dr["VehicleKey"].ToString());
					objList.Add(objGet);
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		
		public DataSet EmployeeByRoleGet(string sRoleName,int iRouteKey=0)
		{
			try
			{
				clsUserMasterMember objList = new clsUserMasterMember();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{

					new SqlParameter("@RoleName",  sRoleName  ),
					new SqlParameter("@RouteKey",  iRouteKey  ),
				};
				DataSet ds = objSql.ExecuteDataSet("EmployeeByRoleGet", objParam);
				

				return ds;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public int CustomerDataEntryAllocationSave(String sSource ,int iRouteKey=0)
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@XML",                           XML),
						new SqlParameter("@Source",                           sSource),
						new SqlParameter("@RouteKey",                           iRouteKey),
						new SqlParameter("@UserID",                           ClsSessionKeys.UserID),
				};
				var result = objSave.ExecuteNonQuery("CustomerDataEntryAllocation", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}  // End Of Class


}
