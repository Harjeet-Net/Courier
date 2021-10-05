using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Shipment
{
	public class ClsAirWayBillImportExcel : ClsBaseBL
	{
		public int TempID { get; set; }

		public DateTime AWBDate { get; set; }

		public string AirwayBillNo { get; set; }

		public string AWBType { get; set; }

		public string DriverName { get; set; }

		public string ShipperName { get; set; }

		public string ConsigneeName { get; set; }

		public string ConsigneeAdd1 { get; set; }

		public string ConsigneeAdd2 { get; set; }

		public string ConsigneeAdd3 { get; set; }

		public string ConsigneeCityId { get; set; }

		public string ConsigneeTelephone { get; set; }

		public string ConsigneePCS { get; set; }

		public float ConsigneeWeight { get; set; }

		public float ConsigneeNetAmount { get; set; }

	}

	public class ClsAirWayBillImportExcelMaster : ClsAirWayBillImportExcel
	{

		public int InsertUpdate_AirWayBill_Temp_Import_Excel()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
					new SqlParameter("@AirwayBillNo",AirwayBillNo),
					new SqlParameter("@AWBDate",AWBDate),						
					new SqlParameter("@AWBType",AWBType),
					new SqlParameter("@DriverName",DriverName),
					new SqlParameter("@ShipperName",ShipperName),
					new SqlParameter("@ConsigneeName",ConsigneeName),
					new SqlParameter("@ConsigneeAdd1",ConsigneeAdd1),
					new SqlParameter("@ConsigneeAdd2",ConsigneeAdd2),
					new SqlParameter("@ConsigneeAdd3",ConsigneeAdd3),
					new SqlParameter("@ConsigneeCityId",ConsigneeCityId),
                    new SqlParameter("@ConsigneeTelephone",ConsigneeTelephone),
				    new SqlParameter("@ConsigneePCS",ConsigneePCS),
					new SqlParameter("@ConsigneeWeight",ConsigneeWeight),
					new SqlParameter("@ConsigneeNetAmount",ConsigneeNetAmount),						
					new SqlParameter("@UserID",UserID)
				};
				var result = objSave.ExecuteNonQuery("sp_Insert_Update_tbl_AirWayBill_Temp_Import_Excel", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable GetAirWayBillTempByUserID()
		{
			try
			{
				List<ClsAirWayBillImportExcel> objList = new List<ClsAirWayBillImportExcel>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@UserID",  UserID),

				};
				IDataReader dr = objSql.ExecuteReader("sp_Select_tbl_AirWayBill_Temp_By_UserID", objParam);
				DataTable dt = new DataTable();
				dt.Load(dr);
				return dt;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public List<ClsAirWayBillImportExcel> GetAirWayBillImportList()
		{
			try
			{
				List<ClsAirWayBillImportExcel> objList = new List<ClsAirWayBillImportExcel>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@UserID",  UserID),

				};
				IDataReader dr = objSql.ExecuteReader("sp_Select_tbl_AirWayBill_Temp_By_UserID", objParam);
				while (dr.Read())
				{
					ClsAirWayBillImportExcel objGet = new ClsAirWayBillImportExcel();

					objGet.TempID = dr["TempID"] is DBNull ? 0 : Convert.ToInt32(dr["TempID"].ToString());

					if (dr["AWBDate"] != DBNull.Value)
					{
						objGet.AWBDate = Convert.ToDateTime(dr["AWBDate"].ToString());
					}
					objGet.AirwayBillNo = (dr["AirwayBillNo"] ?? "").ToString();
					objGet.AWBType = (dr["AWBType"] ?? "").ToString();
					objGet.DriverName = (dr["DriverName"] ?? "").ToString();
					objGet.ShipperName = (dr["ShipperName"] ?? "").ToString();
					objGet.ConsigneeName = (dr["ConsigneeName"] ?? "").ToString();
					objGet.ConsigneeAdd1 = (dr["ConsigneeAdd1"] ?? "").ToString();
					objGet.ConsigneeAdd2 = (dr["ConsigneeAdd2"] ?? "").ToString();
					objGet.ConsigneeAdd3 = (dr["ConsigneeAdd3"] ?? "").ToString();
					objGet.ConsigneeCityId = (dr["ConsigneeCityId"] ?? "").ToString();
					objGet.ConsigneeTelephone = (dr["ConsigneeTelephone"] ?? "").ToString();
					objGet.ConsigneePCS = (dr["ConsigneePCS"] ?? "").ToString();
					objGet.ConsigneeWeight = dr["ConsigneeWeight"] is DBNull ? 0 : float.Parse(dr["ConsigneeWeight"].ToString());
					objGet.ConsigneeNetAmount = dr["ConsigneeNetAmount"] is DBNull ? 0 : float.Parse(dr["ConsigneeNetAmount"].ToString());
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