using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Common
{
    public class clsFillComboByCode
    {
        public String ComboVal { get; set; }
        public String ComboText { get; set; }
        public String Code { get; set; }

        public List<clsFillComboByCode> FillComboList(String key)
        {
            try
            {
                List<clsFillComboByCode> objList = new List<clsFillComboByCode>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                       new SqlParameter("@Source",  Code  )
                      ,new SqlParameter("@Key"   ,  key  )
                };
                var ds = objSql.ExecuteDataSet("RentalCombo", objParam);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsFillComboByCode objGet = new clsFillComboByCode();
                    objGet.ComboVal = (dr["ComboVal"] ?? "").ToString();
                    objGet.ComboText = (dr["ComboText"] ?? "").ToString();
                    objGet.Code = (dr["Code"] ?? "").ToString();
                    objList.Add(objGet);
                }
                return objList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }



    }
}
