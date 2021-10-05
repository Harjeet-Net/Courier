using BL.Settings;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BL.Common
{
    public class clsCombo : ClsBaseBL
    {


        public String ComboID
        {
            get;
            set;
        }

        public String ComboValue
        {
            get;
            set;
        }

        public List<clsCombo> ComboGet(String comboname, string condition = "")
        {
            try
            {

                List<clsCombo> objCatList = new List<clsCombo>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@comboname", comboname),
                      new SqlParameter("@condition", condition)
                };
                IDataReader r = objSql.ExecuteReader("ComboGet", objParam);
                List<ClsCategoryMasterMember> objList = new List<ClsCategoryMasterMember>();
                while (r.Read())
                {

                    objCatList.Add(new clsCombo
                    {
                        ComboID = (r["ComboID"] ?? "").ToString(),
                        ComboValue = (r["ComboValue"] ?? "").ToString()
                    });
                }
                return objCatList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ComboGetDs(String comboname, string condition = "")
        {
            try
            {

                List<clsCombo> objCatList = new List<clsCombo>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@comboname", comboname),
                      new SqlParameter("@condition", condition)
                };
                return objSql.ExecuteDataSet("ComboGet", objParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
