using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace BL.Cashier
{
	public enum EnCashierPage
	{
		DayBegin,
		DayClose,
	}
	public class ClsCashierMember : ClsBaseBL
	{
		public int CashierId { get; set; }

		public string ExpenseType { get; set; }

		public string ShiftType { get; set; }

		public string EmployeeName { get; set; }

		public decimal CashAmount { get; set; }

		public decimal ChequeAmount { get; set; }

		public decimal CashReceive { get; set; }

		public DateTime DateandTime { get; set; }

		public string PageType { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }



	}
	public class ClsCashier : ClsCashierMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@CashierId",                               CashierId),
						new SqlParameter("@ExpenseType",                             ExpenseType),
						new SqlParameter("@ShiftType",                               ShiftType),
						new SqlParameter("@EmployeeName",                            EmployeeName),
						new SqlParameter("@CashAmount",                              CashAmount),
						new SqlParameter("@ChequeAmount",                            ChequeAmount),
						new SqlParameter("@CashReceive",                             CashReceive),
						new SqlParameter("@DateandTime",                             DateandTime),
						new SqlParameter("@PageType",                                PageType),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("CashierSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsCashierMember> GetCashier()
		{
			try
			{
				List<ClsCashierMember> objList = new List<ClsCashierMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@CashierId",  CashierId  )
					
				};
				IDataReader dr = objSql.ExecuteReader("CashierGet", objParam);
				while (dr.Read())
				{
					ClsCashierMember objGet = new ClsCashierMember();

					objGet.CashierId = dr["CashierId"] is DBNull ? 0 : Convert.ToInt32(dr["CashierId"].ToString());
					objGet.ExpenseType = (dr["ExpenseType"] ?? "").ToString();
					objGet.ShiftType = (dr["ShiftType"] ?? "").ToString();
					objGet.EmployeeName = (dr["EmployeeName"] ?? "").ToString();
					objGet.CashAmount = dr["CashAmount"] is DBNull ? 0 : Convert.ToDecimal(dr["CashAmount"].ToString());
					objGet.ChequeAmount = dr["ChequeAmount"] is DBNull ? 0 : Convert.ToDecimal(dr["ChequeAmount"].ToString());
					objGet.CashReceive = dr["CashReceive"] is DBNull ? 0 : Convert.ToDecimal(dr["CashReceive"].ToString());
					if (dr["DateandTime"] != DBNull.Value)
						objGet.DateandTime = Convert.ToDateTime(dr["DateandTime"].ToString());
					objGet.PageType = (dr["PageType"] ?? "").ToString();
					objList.Add(objGet);
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public List<ClsCashierMember> SearchCashier()
		{
			try
			{
				List<ClsCashierMember> objList = new List<ClsCashierMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@ExpenseType",  ExpenseType)

				};
				IDataReader dr = objSql.ExecuteReader("CashierSearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					ClsCashierMember objGet = new ClsCashierMember();

					objGet.CashierId = dr["CashierId"] is DBNull ? 0 : Convert.ToInt32(dr["CashierId"].ToString());
					objGet.ExpenseType = (dr["ExpenseType"] ?? "").ToString();
					objGet.ShiftType = (dr["ShiftType"] ?? "").ToString();
					objGet.EmployeeName = (dr["EmployeeName"] ?? "").ToString();
					objGet.CashAmount = dr["CashAmount"] is DBNull ? 0 : Convert.ToDecimal(dr["CashAmount"].ToString());
					objGet.ChequeAmount = dr["ChequeAmount"] is DBNull ? 0 : Convert.ToDecimal(dr["ChequeAmount"].ToString());
					objGet.CashReceive = dr["CashReceive"] is DBNull ? 0 : Convert.ToDecimal(dr["CashReceive"].ToString());
					if (dr["DateandTime"] != DBNull.Value)
						objGet.DateandTime = Convert.ToDateTime(dr["DateandTime"].ToString());
					objGet.PageType = (dr["PageType"] ?? "").ToString();
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
