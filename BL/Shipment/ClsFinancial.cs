using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BL.Shipment
{
	public class ClsFinancialMember : ClsBaseBL
	{
		public int Id { get; set; }

		public int TenentID { get; set; }

		public int LocationId { get; set; }

		public long AirwayBillNo { get; set; }

		public int MySerial { get; set; }

		public decimal? AgreedAmount { get; set; }

		public decimal? PaidAmount { get; set; }

		public int? ExpenseType { get; set; }

		public string Reference { get; set; }

		public string Remarks { get; set; }

		public string Reason { get; set; }

		public int PaymentStatus { get; set; }

		public string PaymentStatusDescription { get; set; }

		public int? TransactionType { get; set; }

		public string TransactionDescription { get; set; }

		public int? Cashier { get; set; }

		public DateTime? From { get; set; }

		public DateTime? To { get; set; }

		public int? TotalPayment { get; set; }

		public int? OpeningBalance { get; set; }

		public int? ClosingBalance { get; set; }

		public bool? Status { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public int? UpdatedBy { get; set; }
	}
	public class ClsFinancial : ClsFinancialMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@Id",                                      Id),
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@LocationId",                              LocationId),
						new SqlParameter("@AirwayBillNo",                            AirwayBillNo),
						new SqlParameter("@MySerial",                                MySerial),
						new SqlParameter("@AgreedAmount",                            AgreedAmount),
						new SqlParameter("@PaidAmount",                              PaidAmount),
						new SqlParameter("@ExpenseType",                             ExpenseType),
						new SqlParameter("@Reference",                               Reference),
						new SqlParameter("@Remarks",                                 Remarks),
						new SqlParameter("@Reason",                                  Reason),
						new SqlParameter("@PaymentStatus",                           PaymentStatus),
						new SqlParameter("@PaymentStatusDescription",                PaymentStatusDescription),
						new SqlParameter("@TransactionType",                         TransactionType),
						new SqlParameter("@TransactionDescription",                  TransactionDescription),
						new SqlParameter("@Cashier",                                 Cashier),
						new SqlParameter("@From",                                    From),
						new SqlParameter("@To",                                      To),
						new SqlParameter("@TotalPayment",                            TotalPayment),
						new SqlParameter("@OpeningBalance",                          OpeningBalance),
						new SqlParameter("@ClosingBalance",                          ClosingBalance),
						new SqlParameter("@Status",                                  Status),
						new SqlParameter("@UpdatedDate",                             UpdatedDate),
						new SqlParameter("@UpdatedBy",                               UpdatedBy),
				//		new SqlParameter("@CompanyID",                               CompanyID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("FinancialSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsFinancialMember> GetFinancial()
		{
			try
			{
				List<ClsFinancialMember> objList = new List<ClsFinancialMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@Id",  Id  ),
					
				};
				IDataReader dr = objSql.ExecuteReader("FinancialGet", objParam);
				while (dr.Read())
				{
					ClsFinancialMember objGet = new ClsFinancialMember();

					objGet.Id = dr["Id"] is DBNull ? 0 : Convert.ToInt32(dr["Id"].ToString());
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.LocationId = dr["LocationId"] is DBNull ? 0 : Convert.ToInt32(dr["LocationId"].ToString());
				//	objGet.AirwayBillNo = dr["AirwayBillNo"] is DBNull ? 0 : Convert.ToUInt64(dr["AirwayBillNo"].ToString());
					objGet.MySerial = dr["MySerial"] is DBNull ? 0 : Convert.ToInt32(dr["MySerial"].ToString());
					objGet.AgreedAmount = dr["AgreedAmount"] is DBNull ? 0 : Convert.ToDecimal(dr["AgreedAmount"].ToString());
					objGet.PaidAmount = dr["PaidAmount"] is DBNull ? 0 : Convert.ToDecimal(dr["PaidAmount"].ToString());
					objGet.ExpenseType = dr["ExpenseType"] is DBNull ? 0 : Convert.ToInt32(dr["ExpenseType"].ToString());
					objGet.Reference = (dr["Reference"] ?? "").ToString();
					objGet.Remarks = (dr["Remarks"] ?? "").ToString();
					objGet.Reason = (dr["Reason"] ?? "").ToString();
					objGet.PaymentStatus = dr["PaymentStatus"] is DBNull ? 0 : Convert.ToInt32(dr["PaymentStatus"].ToString());
					objGet.TransactionType = dr["TransactionType"] is DBNull ? 0 : Convert.ToInt32(dr["TransactionType"].ToString());
					objGet.Cashier = dr["Cashier"] is DBNull ? 0 : Convert.ToInt32(dr["Cashier"].ToString());
					if (dr["From"] != DBNull.Value)
						objGet.From = Convert.ToDateTime(dr["From"].ToString());
					if (dr["To"] != DBNull.Value)
						objGet.To = Convert.ToDateTime(dr["To"].ToString());
					objGet.TotalPayment = dr["TotalPayment"] is DBNull ? 0 : Convert.ToInt32(dr["TotalPayment"].ToString());
					objGet.OpeningBalance = dr["OpeningBalance"] is DBNull ? 0 : Convert.ToInt32(dr["OpeningBalance"].ToString());
					objGet.ClosingBalance = dr["ClosingBalance"] is DBNull ? 0 : Convert.ToInt32(dr["ClosingBalance"].ToString());
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
