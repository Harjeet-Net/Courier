using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Vendor
{
    public class ClsVendorMember : ClsBaseBL
	{
		public int ID { get; set; }

		public int TenentID { get; set; }

		public string VendorName { get; set; }

		public bool? Status { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public int? UpdatedBy { get; set; }
	}
	public class ClsVendor : ClsVendorMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@ID",                                      ID),
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@VendorName",                              VendorName),
						new SqlParameter("@Status",                                  Status),
						new SqlParameter("@UpdatedDate",                             UpdatedDate),
						new SqlParameter("@UpdatedBy",                               UpdatedBy),
					//	new SqlParameter("@CompanyID",                               CompanyID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("VendorSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsVendorMember> GetVendor()
		{
			try
			{
				List<ClsVendorMember> objList = new List<ClsVendorMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@ID",  ID  ),
					
				};
				IDataReader dr = objSql.ExecuteReader("VendorGet", objParam);
				while (dr.Read())
				{
					ClsVendorMember objGet = new ClsVendorMember();

					objGet.ID = dr["ID"] is DBNull ? 0 : Convert.ToInt32(dr["ID"].ToString());
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.VendorName = (dr["VendorName"] ?? "").ToString();
					objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
					if (dr["UpdatedDate"] != DBNull.Value)
						objGet.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
					objGet.UpdatedBy = dr["UpdatedBy"] is DBNull ? 0 : Convert.ToInt32(dr["UpdatedBy"].ToString());
					objList.Add(objGet);
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
