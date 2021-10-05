using DL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL.ViewLog
{
	public class ClsViewLog
	{
		public static String ViewLog(String sTable, string sFromDate, String sToDate)
		{
			try
			{

				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@Table",  sTable  ),
					  new SqlParameter("@FromDate",  sFromDate  ),
					  new SqlParameter("@ToDate",  sToDate  ),

				};
				String Result = objSql.ExecuteScalar("Client_ViewLog", objParam).ToString();

				return Result;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		public static DataSet ViewLogDs(String sTable,string sFromDate, String sToDate)
		{
			try
			{

				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@Table",  sTable  ),
					  new SqlParameter("@FromDate",  sFromDate  ),
					  new SqlParameter("@ToDate",  sToDate  ),

				};
				var Result = objSql.ExecuteDataSet("Client_ViewLog", objParam);

				return Result;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
	}
}
