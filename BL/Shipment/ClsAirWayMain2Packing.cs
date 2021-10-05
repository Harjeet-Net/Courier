using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Shipment
{
    public class ClsAirWayMain2PackingMember:ClsBaseBL
    {
		public int A2PKey { get; set; }

		public int AirwayBillKey { get; set; }

		public int PackingKey { get; set; }

		public int Qty { get; set; }

		public decimal Weight { get; set; }

		public string UOM { get; set; }

		public decimal? DL { get; set; }

		public decimal? DW { get; set; }

		public decimal? DH { get; set; }

		public string Mode { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }
		public string PackingKeyName { get; set; }
	}
	public class ClsAirWayMain2Packing : ClsAirWayMain2PackingMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@A2PKey",                                  A2PKey),
						new SqlParameter("@AirwayBillKey",                           AirwayBillKey),
						new SqlParameter("@PackingKey",                              PackingKey),
						new SqlParameter("@Qty",                                     Qty),
						new SqlParameter("@Weight",                                  Weight),
						new SqlParameter("@UOM",                                     UOM),
						new SqlParameter("@DL",                                      DL),
						new SqlParameter("@DW",                                      DW),
						new SqlParameter("@DH",                                      DH),
						new SqlParameter("@CompanyID",                               CompanyID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("AirWayMain2PackingSAVE", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsAirWayMain2PackingMember> GetAirWayMain2Packing()
		{
			try
			{
				List<ClsAirWayMain2PackingMember> objList = new List<ClsAirWayMain2PackingMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@A2PKey",  A2PKey  ),
 				};
				IDataReader dr = objSql.ExecuteReader("AirWayMain2PackingGET", objParam);
				while (dr.Read())
				{
					ClsAirWayMain2PackingMember objGet = new ClsAirWayMain2PackingMember();

					objGet.A2PKey = dr["A2PKey"] is DBNull ? 0 : Convert.ToInt32(dr["A2PKey"].ToString());
					objGet.AirwayBillKey = dr["AirwayBillKey"] is DBNull ? 0 : Convert.ToInt32(dr["AirwayBillKey"].ToString());
					objGet.PackingKey = dr["PackingKey"] is DBNull ? 0 : Convert.ToInt32(dr["PackingKey"].ToString());
					objGet.Qty = dr["Qty"] is DBNull ? 0 : Convert.ToInt32(dr["Qty"].ToString());
					objGet.Weight = dr["Weight"] is DBNull ? 0 : Convert.ToDecimal(dr["Weight"].ToString());
					objGet.UOM = (dr["UOM"] ?? "").ToString();
					objGet.DL = dr["DL"] is DBNull ? 0 : Convert.ToDecimal(dr["DL"].ToString());
					objGet.DW = dr["DW"] is DBNull ? 0 : Convert.ToDecimal(dr["DW"].ToString());
					objGet.DH = dr["DH"] is DBNull ? 0 : Convert.ToDecimal(dr["DH"].ToString());
					objList.Add(objGet);
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public List<ClsAirWayMain2PackingMember> SearchAirWayMain2Packing()
		{
			try
			{
				List<ClsAirWayMain2PackingMember> objList = new List<ClsAirWayMain2PackingMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@AirwayBillKey",  AirwayBillKey  ),
 				};
				IDataReader dr = objSql.ExecuteReader("AirWayMain2PackingSEARCH", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					ClsAirWayMain2PackingMember objGet = new ClsAirWayMain2PackingMember();

					objGet.A2PKey = dr["A2PKey"] is DBNull ? 0 : Convert.ToInt32(dr["A2PKey"].ToString());
					objGet.AirwayBillKey = dr["AirwayBillKey"] is DBNull ? 0 : Convert.ToInt32(dr["AirwayBillKey"].ToString());
					objGet.PackingKey = dr["PackingKey"] is DBNull ? 0 : Convert.ToInt32(dr["PackingKey"].ToString());
					objGet.Qty = dr["Qty"] is DBNull ? 0 : Convert.ToInt32(dr["Qty"].ToString());
					objGet.Weight = dr["Weight"] is DBNull ? 0 : Convert.ToDecimal(dr["Weight"].ToString());
					objGet.UOM = (dr["UOM"] ?? "").ToString();
					objGet.PackingKeyName = (dr["PackingKeyName"] ?? "").ToString();
					objGet.DL = dr["DL"] is DBNull ? 0 : Convert.ToDecimal(dr["DL"].ToString());
					objGet.DW = dr["DW"] is DBNull ? 0 : Convert.ToDecimal(dr["DW"].ToString());
					objGet.DH = dr["DH"] is DBNull ? 0 : Convert.ToDecimal(dr["DH"].ToString());
					objGet.Button = (dr["Button"] ?? "").ToString();
					objGet.RowIndex = Lc + 1;
					objList.Add(objGet);					
					Lc += 1;



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
