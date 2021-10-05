using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Shipment
{
    public class ClsInvoiceDetailMember : ClsBaseBL
	{
		public int InvoiceDetailKey { get; set; }
		public int AirwayBillKey { get; set; }

		public int InvoiceKey { get; set; }

		public string ItemDescription { get; set; }

		public int ManufactureFrom { get; set; }

		public string CommodityCode { get; set; }

		public int Quantity { get; set; }

		public string QunatityUnit { get; set; }

		public decimal ItemValue { get; set; }

		public string Currencey { get; set; }

		public decimal NetWeight { get; set; }

		public string NetWeightUnit { get; set; }

		public decimal GrossWeight { get; set; }

		public string GrossWeightUnit { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }

	}
	public class ClsInvoiceDetail : ClsInvoiceDetailMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@InvoiceDetailKey",                        InvoiceDetailKey),						
						new SqlParameter("@ItemDescription",                         ItemDescription),
						new SqlParameter("@ManufactureFrom",                         ManufactureFrom),
						new SqlParameter("@CommodityCode",                           CommodityCode),
						new SqlParameter("@Quantity",                                Quantity),
						new SqlParameter("@QunatityUnit",                            QunatityUnit),
						new SqlParameter("@ItemValue",                               ItemValue),
						new SqlParameter("@Currencey",                               Currencey),
						new SqlParameter("@NetWeight",                               NetWeight),
						new SqlParameter("@NetWeightUnit",                           NetWeightUnit),
						new SqlParameter("@GrossWeight",                             GrossWeight),
						new SqlParameter("@GrossWeightUnit",                         GrossWeightUnit),
						new SqlParameter("@AirwayBillKey",                           AirwayBillKey),
						//new SqlParameter("@CompanyID",                               CompanyID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("InvoiceDetailSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsInvoiceDetailMember> GetInvoiceDetail()
		{
			try
			{
				List<ClsInvoiceDetailMember> objList = new List<ClsInvoiceDetailMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@InvoiceDetailKey",  InvoiceDetailKey  ),
				
				};
				IDataReader dr = objSql.ExecuteReader("InvoiceDetailGET", objParam);
				while (dr.Read())
				{
					ClsInvoiceDetailMember objGet = new ClsInvoiceDetailMember();
					//objGet.AirwayBillKey = dr["AirwayBillKey"] is DBNull ? 0 : Convert.ToInt32(dr["AirwayBillKey"].ToString());
					objGet.InvoiceDetailKey = dr["InvoiceDetailKey"] is DBNull ? 0 : Convert.ToInt32(dr["InvoiceDetailKey"].ToString());					
					objGet.ItemDescription = (dr["ItemDescription"] ?? "").ToString();
					objGet.ManufactureFrom = dr["ManufactureFrom"] is DBNull ? 0 : Convert.ToInt32(dr["ManufactureFrom"].ToString());
					objGet.CommodityCode = (dr["CommodityCode"] ?? "").ToString();
					objGet.Quantity = dr["Quantity"] is DBNull ? 0 : Convert.ToInt32(dr["Quantity"].ToString());
					objGet.QunatityUnit = (dr["QunatityUnit"] ?? "").ToString();
					objGet.ItemValue = dr["ItemValue"] is DBNull ? 0 : Convert.ToDecimal(dr["ItemValue"].ToString());
					objGet.Currencey = (dr["Currencey"] ?? "").ToString();
					objGet.NetWeight = dr["NetWeight"] is DBNull ? 0 : Convert.ToDecimal(dr["NetWeight"].ToString());
					objGet.NetWeightUnit = (dr["NetWeightUnit"] ?? "").ToString();
					objGet.GrossWeight = dr["GrossWeight"] is DBNull ? 0 : Convert.ToDecimal(dr["GrossWeight"].ToString());
					objGet.GrossWeightUnit = (dr["GrossWeightUnit"] ?? "").ToString();
					objGet.InvoiceKey = dr["InvoiceKey"] is DBNull ? 0 : Convert.ToInt32(dr["InvoiceKey"].ToString());
					objList.Add(objGet);
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public List<ClsInvoiceDetailMember> SearchInvoiceDetail()
		{
			try
			{
				List<ClsInvoiceDetailMember> objList = new List<ClsInvoiceDetailMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@AirwayBillKey",  AirwayBillKey  ),

				};
				IDataReader dr = objSql.ExecuteReader("InvoiceDetailSEARCH", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					ClsInvoiceDetailMember objGet = new ClsInvoiceDetailMember();
					//objGet.AirwayBillKey = dr["AirwayBillKey"] is DBNull ? 0 : Convert.ToInt32(dr["AirwayBillKey"].ToString());
					objGet.InvoiceDetailKey = dr["InvoiceDetailKey"] is DBNull ? 0 : Convert.ToInt32(dr["InvoiceDetailKey"].ToString());					
					objGet.ItemDescription = (dr["ItemDescription"] ?? "").ToString();
					objGet.ManufactureFrom = dr["ManufactureFrom"] is DBNull ? 0 : Convert.ToInt32(dr["ManufactureFrom"].ToString());
					objGet.CommodityCode = (dr["CommodityCode"] ?? "").ToString();
					objGet.Quantity = dr["Quantity"] is DBNull ? 0 : Convert.ToInt32(dr["Quantity"].ToString());
					objGet.QunatityUnit = (dr["QunatityUnit"] ?? "").ToString();
					objGet.ItemValue = dr["ItemValue"] is DBNull ? 0 : Convert.ToDecimal(dr["ItemValue"].ToString());
					objGet.Currencey = (dr["Currencey"] ?? "").ToString();
					objGet.NetWeight = dr["NetWeight"] is DBNull ? 0 : Convert.ToDecimal(dr["NetWeight"].ToString());
					objGet.NetWeightUnit = (dr["NetWeightUnit"] ?? "").ToString();
					objGet.GrossWeight = dr["GrossWeight"] is DBNull ? 0 : Convert.ToDecimal(dr["GrossWeight"].ToString());
					objGet.GrossWeightUnit = (dr["GrossWeightUnit"] ?? "").ToString();
					objGet.InvoiceKey = dr["InvoiceKey"] is DBNull ? 0 : Convert.ToInt32(dr["InvoiceKey"].ToString());
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
