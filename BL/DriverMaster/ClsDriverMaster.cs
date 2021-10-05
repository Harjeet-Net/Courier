using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.DriverMaster
{
	public class ClsDriverMember : ClsBaseBL
	{
		public int Id { get; set; }

	//	public string PageType { get; set; }

		public int TenentID { get; set; }

		public string DriverName { get; set; }

		public string MobileNumber { get; set; }

		public string VehicleType { get; set; }

		public string EmailId { get; set; }

		public string Nationality { get; set; }

		public string Address { get; set; }

		public string Country { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string ZipCode { get; set; }

		public bool? Status { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public int? UpdatedBy { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }

	}
	public class ClsDriver : ClsDriverMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@Id",                                      Id),
				//		new SqlParameter("@PageType",                                PageType),
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@DriverName",                              DriverName),
						new SqlParameter("@MobileNumber",                            MobileNumber),
						new SqlParameter("@VehicleType",                             VehicleType),
						new SqlParameter("@EmailId",                                 EmailId),
						new SqlParameter("@Nationality",                             Nationality),
						new SqlParameter("@Address",                                 Address),
						new SqlParameter("@Country",                                 Country),
						new SqlParameter("@City",                                    City),
						new SqlParameter("@State",                                   State),
						new SqlParameter("@ZipCode",                                 ZipCode),
						new SqlParameter("@Status",                                  Status),
						new SqlParameter("@UpdatedDate",                             UpdatedDate),
						new SqlParameter("@UpdatedBy",                               UpdatedBy),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("DriverSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsDriverMember> GetDriver()
		{
			try
			{
				List<ClsDriverMember> objList = new List<ClsDriverMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@Id",  Id  )
				};
				IDataReader dr = objSql.ExecuteReader("DriverGet", objParam);
				while (dr.Read())
				{
					ClsDriverMember objGet = new ClsDriverMember();

					objGet.Id = dr["Id"] is DBNull ? 0 : Convert.ToInt32(dr["Id"].ToString());
		//			objGet.PageType = (dr["PageType"] ?? "").ToString();
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.DriverName = (dr["DriverName"] ?? "").ToString();
					objGet.MobileNumber = (dr["MobileNumber"] ?? "").ToString();
					objGet.VehicleType = (dr["VehicleType"] ?? "").ToString();
					objGet.EmailId = (dr["EmailId"] ?? "").ToString();
					objGet.Nationality = (dr["Nationality"] ?? "").ToString();
					objGet.Address = (dr["Address"] ?? "").ToString();
					objGet.Country = (dr["Country"] ?? "").ToString();
					objGet.City = (dr["City"] ?? "").ToString();
					objGet.State = (dr["State"] ?? "").ToString();
					objGet.ZipCode = (dr["ZipCode"] ?? "").ToString();
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

		public List<ClsDriverMember> SearchDriver()
		{
			try
			{
				List<ClsDriverMember> objList = new List<ClsDriverMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@DriverName",  DriverName  )
				};
				IDataReader dr = objSql.ExecuteReader("DriverSearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					ClsDriverMember objGet = new ClsDriverMember();

					objGet.Id = dr["Id"] is DBNull ? 0 : Convert.ToInt32(dr["Id"].ToString());
					//			objGet.PageType = (dr["PageType"] ?? "").ToString();
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.DriverName = (dr["DriverName"] ?? "").ToString();
					objGet.MobileNumber = (dr["MobileNumber"] ?? "").ToString();
					objGet.VehicleType = (dr["VehicleType"] ?? "").ToString();
					objGet.EmailId = (dr["EmailId"] ?? "").ToString();
					objGet.Nationality = (dr["Nationality"] ?? "").ToString();
					objGet.Address = (dr["Address"] ?? "").ToString();
					objGet.Country = (dr["Country"] ?? "").ToString();
					objGet.City = (dr["City"] ?? "").ToString();
					objGet.State = (dr["State"] ?? "").ToString();
					objGet.ZipCode = (dr["ZipCode"] ?? "").ToString();
					objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
					if (dr["UpdatedDate"] != DBNull.Value)
						objGet.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
					objGet.UpdatedBy = dr["UpdatedBy"] is DBNull ? 0 : Convert.ToInt32(dr["UpdatedBy"].ToString());
					objGet.Button = (dr["Button"] ?? "").ToString();

					objList.Add(objGet);
					objGet.RowIndex = Lc + 1;
					Lc += 1;
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

	}  

}
