using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Shipment
{
    public class clsAirWayMainMember : ClsBaseBL
	{
		public int TranID { get; set; }

		public string TranNo { get; set; }

		public DateTime TranDate { get; set; }

		public string TranType { get; set; }

		public int CustomerKey { get; set; }

		public string CompanyName { get; set; }

		public int? DepartmentKey { get; set; }

		public int? AddressKey { get; set; }

		public int ReciverKey { get; set; }

		public string ReciverKeyCompanyName { get; set; }

		public int? ReciverDepartmentKey { get; set; }

		public int ReciverAddressKey { get; set; }

		public int? PackingTypeKey { get; set; }

		public string InvoiceType { get; set; }

		public string Attachment1 { get; set; }

		public string Attachment2 { get; set; }

		public string ShipmentDescription { get; set; }

		public string ShipmentPurpose { get; set; }

		public string ShipmentRefrence { get; set; }

		public string InvoiceNumber { get; set; }

		public string Carrier { get; set; }

		public string OwnShipmentRefNo { get; set; }

		public string PackageMarks { get; set; }

		public string EeceiverReferenceNo { get; set; }

		public string ExportType { get; set; }

		public string ReasonForExport { get; set; }

		public string PlaceOfDestination { get; set; }

		public int? CustomerOfTrade { get; set; }

		public string PaymentTerms { get; set; }

		public string PickupType { get; set; }

		public string PickupWindow { get; set; }

		public string Deliverytype { get; set; }

		public string DeliveryWindow { get; set; }

		public int VendorKey { get; set; }

		public int DriverKey { get; set; }

		public int VehicleKey { get; set; }
		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }

		public String SenderName { get; set; }

		public String ReceiverName { get; set; }

		public String SenderAddressName { get; set; }
		public String Senderemail { get; set; }	
		public String Senderreferencenumber	  { get; set; }
		public String SenderPACI		  { get; set; }
		public String SenderCountry	  { get; set; }
		public String SenderState		  { get; set; }
		public String SenderCity		  { get; set; }
		public String Senderpostcode		  { get; set; }
		public String senderMobile	  { get; set; }
		public String senderAltCont	  { get; set; }
		public String ReceiverAddressName { get; set; }
		public String Reciveremail				{ get; set; }
		public String ReciverRreferencenumber	{ get; set; }
		public String ReciverRpaci				{ get; set; }
		public String ReceiverCountry	{ get; set; }
		public String ReceiverState	{ get; set; }
		public String ReceiverCity	{ get; set; }
		public String ReciverRpostcode			{ get; set; }
		public String ReciverRmobileno			{ get; set; }
		public String ReciverRotherno			{ get; set; }

		public String PackingTypeName { get; set; }


		public string XML { get; set; }

	}
	public class clsAirWayMain : clsAirWayMainMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@TranID",                                  TranID),
						new SqlParameter("@TranDate",                                TranDate),
						new SqlParameter("@TranType",                                TranType),
						new SqlParameter("@CustomerKey",                             CustomerKey),
						new SqlParameter("@CompanyName",                             CompanyName),
						new SqlParameter("@DepartmentKey",                           DepartmentKey),
						new SqlParameter("@AddressKey",                              AddressKey),
						new SqlParameter("@ReciverKey",                              ReciverKey),
						new SqlParameter("@ReciverKeyCompanyName",                   ReciverKeyCompanyName),
						new SqlParameter("@ReciverDepartmentKey",                    ReciverDepartmentKey),
						new SqlParameter("@ReciverAddressKey",                       ReciverAddressKey),
                        new SqlParameter("@PackingTypeKey",                          PackingTypeKey),
						new SqlParameter("@InvoiceType",                             InvoiceType),
						new SqlParameter("@Attachment1",                             Attachment1),
						new SqlParameter("@Attachment2",                             Attachment2),
						new SqlParameter("@ShipmentDescription",                     ShipmentDescription),
						new SqlParameter("@ShipmentPurpose",                         ShipmentPurpose),
						new SqlParameter("@ShipmentRefrence",                        ShipmentRefrence),
						new SqlParameter("@ExportType",                              ExportType),
						new SqlParameter("@ReasonForExport",                         ReasonForExport),
						new SqlParameter("@PlaceOfDestination",                      PlaceOfDestination),
						new SqlParameter("@CustomerOfTrade",                         CustomerOfTrade),
						new SqlParameter("@PaymentTerms",                            PaymentTerms),
						new SqlParameter("@PickupType",                              PickupType),
						new SqlParameter("@PickupWindow",                            PickupWindow),
						new SqlParameter("@Deliverytype",                            Deliverytype),
						new SqlParameter("@DeliveryWindow",                          DeliveryWindow),
						new SqlParameter("@CompanyID",                               1),
						new SqlParameter("@VendorKey",                               VendorKey),
						new SqlParameter("@DriverKey",                               DriverKey),
						new SqlParameter("@VehicleKey",                              VehicleKey),
						
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteScalar("AirWayMainSave", objPrams);
				return Convert.ToInt32(result) ;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsAirWayMainMember> GetAirWayMainMemberList()
		{
			try
			{
				List<clsAirWayMainMember> objList = new List<clsAirWayMainMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@TranID",  TranID  ),

				};
				IDataReader dr = objSql.ExecuteReader("AirWayMainGet", objParam);
				while (dr.Read())
				{
					clsAirWayMainMember objGet = new clsAirWayMainMember();

					objGet.TranID = dr["TranID"] is DBNull ? 0 : Convert.ToInt32(dr["TranID"].ToString());
					objGet.TranNo = (dr["TranNo"] ?? "").ToString();
					if (dr["TranDate"] != DBNull.Value)
						objGet.TranDate = Convert.ToDateTime(dr["TranDate"].ToString());
					objGet.TranType = (dr["TranType"] ?? "").ToString();
					
					objGet.CustomerKey = dr["CustomerKey"] is DBNull ? 0 : Convert.ToInt32(dr["CustomerKey"].ToString());
					objGet.SenderName = (dr["SenderName"] ?? "").ToString();
					objGet.CompanyName = (dr["CompanyName"] ?? "").ToString();
					objGet.DepartmentKey = dr["DepartmentKey"] is DBNull ? 0 : Convert.ToInt32(dr["DepartmentKey"].ToString());
					objGet.AddressKey = dr["SenderAddresskey"] is DBNull ? 0 : Convert.ToInt32(dr["SenderAddresskey"].ToString());
					objGet.SenderAddressName = (dr["SenderAddressName"] ?? "").ToString();
					objGet.Senderemail			 = (dr["Senderemail"] ?? "").ToString();
					objGet.Senderreferencenumber = (dr["Senderreferencenumber"] ?? "").ToString();
					objGet.SenderPACI		 = (dr["SenderPACI"] ?? "").ToString();
					objGet.SenderCountry	 = (dr["SenderCountry"] ?? "").ToString();
					objGet.SenderState	 = (dr["SenderState"] ?? "").ToString();
					objGet.SenderCity		 = (dr["SenderCity"] ?? "").ToString();
					objGet.Senderpostcode		 = (dr["Senderpostcode"] ?? "").ToString();
					objGet.senderMobile	 = (dr["senderMobile"] ?? "").ToString();
					objGet.senderAltCont = (dr["senderAltCont"] ?? "").ToString();
					objGet.PackingTypeName = (dr["PackingTypeName"] ?? "").ToString();
					objGet.ReciverKey = dr["ReciverKey"] is DBNull ? 0 : Convert.ToInt32(dr["ReciverKey"].ToString());
					objGet.ReceiverAddressName = (dr["ReceiverAddressName"] ?? "").ToString();
					objGet.ReceiverName = (dr["ReceiverName"] ?? "").ToString(); 
					objGet.ReciverKeyCompanyName = (dr["ReciverKeyCompanyName"] ?? "").ToString();
					objGet.ReciverDepartmentKey = dr["ReciverDepartmentKey"] is DBNull ? 0 : Convert.ToInt32(dr["ReciverDepartmentKey"].ToString());
					objGet.ReciverAddressKey = dr["ReciverAddressKey"] is DBNull ? 0 : Convert.ToInt32(dr["ReciverAddressKey"].ToString());
					objGet.PackingTypeKey = dr["PackingTypeKey"] is DBNull ? 0 : Convert.ToInt32(dr["PackingTypeKey"].ToString());
					objGet.Reciveremail = (dr["CompanyName"] ?? "").ToString();
					objGet.ReciverRreferencenumber	= (dr["ReciverRreferencenumber"] ?? "").ToString();
					objGet.ReciverRpaci				= (dr["ReciverRpaci"] ?? "").ToString();
					objGet.ReceiverCountry= (dr["ReceiverCountry"] ?? "").ToString();
					objGet.ReceiverState	= (dr["ReceiverState"] ?? "").ToString();
					objGet.ReceiverCity	= (dr["ReceiverCity"] ?? "").ToString();
					objGet.ReciverRpostcode			= (dr["ReciverRpostcode"] ?? "").ToString();
					objGet.ReciverRmobileno			= (dr["ReciverRmobileno"] ?? "").ToString();
					objGet.ReciverRotherno=(dr["ReciverRotherno"] ?? "").ToString();
					
					objGet.InvoiceType = (dr["InvoiceType"] ?? "").ToString();
					objGet.Attachment1 = (dr["Attachment1"] ?? "").ToString();
					objGet.Attachment2 = (dr["Attachment2"] ?? "").ToString();
					objGet.ShipmentDescription = (dr["ShipmentDescription"] ?? "").ToString();
					objGet.ShipmentPurpose = (dr["ShipmentPurpose"] ?? "").ToString();
					objGet.ShipmentRefrence = (dr["ShipmentRefrence"] ?? "").ToString();
					objGet.ExportType = (dr["ExportType"] ?? "").ToString();
					objGet.ReasonForExport = (dr["ReasonForExport"] ?? "").ToString();
					objGet.PlaceOfDestination = (dr["PlaceOfDestination"] ?? "").ToString();
					objGet.CustomerOfTrade = dr["CustomerOfTrade"] is DBNull ? 0 : Convert.ToInt32(dr["CustomerOfTrade"].ToString());
					objGet.PaymentTerms = (dr["PaymentTerms"] ?? "").ToString();
					objGet.PickupType = (dr["PickupType"] ?? "").ToString();
					objGet.PickupWindow = (dr["PickupWindow"] ?? "").ToString();
					objGet.Deliverytype = (dr["Deliverytype"] ?? "").ToString();
					objGet.DeliveryWindow = (dr["DeliveryWindow"] ?? "").ToString();
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

		public List<clsAirWayMainMember> SearchAirWayMain()
		{
			try
			{
				List<clsAirWayMainMember> objList = new List<clsAirWayMainMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@TranType",  TranType  ),

				};
				IDataReader dr = objSql.ExecuteReader("AirWayMainSearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					clsAirWayMainMember objGet = new clsAirWayMainMember();

					objGet.TranID = dr["TranID"] is DBNull ? 0 : Convert.ToInt32(dr["TranID"].ToString());
					objGet.TranNo = (dr["TranNo"] ?? "").ToString();
					if (dr["TranDate"] != DBNull.Value)
						objGet.TranDate = Convert.ToDateTime(dr["TranDate"].ToString());
					objGet.TranType = (dr["TranType"] ?? "").ToString();
					objGet.SenderName = (dr["SenderName"] ?? "").ToString();
					objGet.ReceiverName = (dr["ReceiverName"] ?? "").ToString();
					objGet.PickupType = (dr["PickupType"] ?? "").ToString();
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

		public int AirWayMainVendorUpdate()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@TranID",                                  TranID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@VendorKey",                                VendorKey),					
						//new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteScalar("AirWayMainVendorUpdate", objPrams);
				return Convert.ToInt32(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int AirWayMainDriverUpdate()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@TranID",                                  TranID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@DriverKey",                                DriverKey),
						new SqlParameter("@VehicleKey",                                VehicleKey),
						//new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteScalar("AirWayMainDriverUpdate", objPrams);
				return Convert.ToInt32(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public DataSet Report_AwbAirWayBill(int iAirWayKey)
		{
			try
			{
				List<clsChangeHistoryMember> objList = new List<clsChangeHistoryMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]

				{
					  new SqlParameter("@TranID",       iAirWayKey),
		
				};
				return objSql.ExecuteDataSet("Report_AwbAirWayBill", objParam);
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public int CourierImportSave(String sXML, string sFileName)
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@XML",                                     sXML),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@SheetName",                                sFileName),					
						
				};
				var result = objSave.ExecuteNonQuery("CourierImportSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}  // End Of Class



}