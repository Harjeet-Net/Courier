using BL.AuthenticationAndSession;
using DL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL.ReportPopup
{
    public class ClsReportPopup
    {
        public DataSet GetRportDataSource(String ReportName, string PageKey, string TranType, int TranParentLinkKey, int pinRowCount = 0)
        {
            DataSet dsResult = new DataSet();
            try
            {
                ClsSqlHelper objLoad = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objPrams = new SqlParameter[]
                {
                     new SqlParameter("@ReportName"          ,     ReportName           ),
                     new SqlParameter("@PrimaryKey"          ,     PageKey              ),
                     new SqlParameter("@TranType"            ,     TranType             ),
                     new SqlParameter("@TranParentLinkKey"   ,     TranParentLinkKey    ),
                     new SqlParameter("@RowSet"              ,     pinRowCount    ),
                     new SqlParameter("@UserID"              ,   1                  ),
                     new SqlParameter("@CompanyID"           ,  ClsSessionKeys.CompanyKey               )
                };
                dsResult = objLoad.ExecuteDataSet("Report_Popup", objPrams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsResult;
        }
        public static DataSet GetRportDataSource(String ReportName, int PageKey)
        {
            DataSet dsResult = new DataSet();
            try
            {
                ClsSqlHelper objLoad = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objPrams = new SqlParameter[]
                {
                     new SqlParameter("@ReportName"          ,     ReportName           ),
                     new SqlParameter("@PrimaryKey"          ,     PageKey              )
                };
                dsResult = objLoad.ExecuteDataSet("Report_Popup", objPrams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsResult;
        }

    }
}
