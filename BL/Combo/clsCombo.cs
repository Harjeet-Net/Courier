using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace BL
{
    public class ClsCombo : ClsBaseBL
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
        /// <summary>
        /// Develop By: Faisal
        /// </summary>
        /// <param name="comboname"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<ClsCombo> ComboGet(String comboname, string condition = "")
        {
            try
            {

                List<ClsCombo> objCatList = new List<ClsCombo>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@comboname", comboname),
                      new SqlParameter("@condition", condition)
                };
                IDataReader r = objSql.ExecuteReader("ComboGet", objParam);

                while (r.Read())
                {

                    objCatList.Add(new ClsCombo
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

                List<ClsCombo> objCatList = new List<ClsCombo>();
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
