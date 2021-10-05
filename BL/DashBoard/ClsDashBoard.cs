using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BL.DashBoard
{
    public class ClsDashBoard : ClsBaseBL
    {
		public DataSet DashBoard(String sFromDate ,String sToDate)
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@FromDate",                 sFromDate),
						new SqlParameter("@ToDate",                   sToDate ),
						new SqlParameter("@UserID",                   UserID)
				};
				var result = objSave.ExecuteDataSet("DashBoard", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
