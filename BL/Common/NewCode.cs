using DL;
using System;
using System.Data.SqlClient;
namespace BL
{
    public enum EnNewCode
    {
        Candidate,
        Enrollment,
        Invoice,
        Pos,
        Stock

    }

    public class ClsNewCode
    {

        public static String NewCodeGet(EnNewCode pinSource)
        {
            try
            {


                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@Source", pinSource.ToString())
                };
                return objSql.ExecuteScalar("NewCodeGet", objParam).ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}