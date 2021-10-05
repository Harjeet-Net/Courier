using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BL.Settings
{
    public class ClsCategoryMasterMember : ClsBaseBL
    {
        public int CategoryKey { get; set; }

        public string CategoryName { get; set; }

        public string CatVal { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }

        /****************EXtended property ****************************/

        public String Button { get; set; }

        public int RowIndex { get; set; }
    }
    public class ClsCategoryMaster : ClsCategoryMasterMember
    {

        public int AddUpdateDelete()
        {
            try
            {
                ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
                SqlParameter[] objPrams = new SqlParameter[]
                {
                        new SqlParameter("@CategoryKey",                             CategoryKey),
                        new SqlParameter("@CategoryName",                            CategoryName),
                        new SqlParameter("@CatVal",                                  CatVal),
                        new SqlParameter("@Status",                                  Status),
                        new SqlParameter("@Description",                             Description),
                        new SqlParameter("@CompanyID",                               CompanyID),

                        new SqlParameter("@UserID",                                  UserID),
                        new SqlParameter("@Action",                                  Action.ToString())
                };
                var result = objSave.ExecuteNonQuery("CategoryMasterSAVE", objPrams);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsCategoryMasterMember> GetCategoryMasterMemberList()
        {
            try
            {
                List<ClsCategoryMasterMember> objList = new List<ClsCategoryMasterMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@CategoryKey",  CategoryKey  ),
                      new SqlParameter("@CategoryName",  CategoryName  ),
                };
                IDataReader dr = objSql.ExecuteReader("CategoryMasterGET", objParam);


                while (dr.Read())
                {
                    ClsCategoryMasterMember objGet = new ClsCategoryMasterMember
                    {
                        CategoryKey = dr["CategoryKey"] is DBNull ? 0 : Convert.ToInt32(dr["CategoryKey"].ToString()),
                        CategoryName = (dr["CategoryName"] ?? "").ToString(),
                        CatVal = (dr["CatVal"] ?? "").ToString(),
                        Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString()),
                        Description = (dr["Description"] ?? "").ToString()
                    };
                    objList.Add(objGet);

                }

                return objList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<ClsCategoryMasterMember> SearchCategoryMaster()
        {
            try
            {
                List<ClsCategoryMasterMember> objList = new List<ClsCategoryMasterMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {

                        new SqlParameter("@CategoryName",CategoryName??"-1"),
                    

                };
                IDataReader dr = objSql.ExecuteReader("CategoryMasterSearch", objParam);
                int Lc = 0;
                while (dr.Read())
                {
                    ClsCategoryMasterMember objGet = new ClsCategoryMasterMember
                    {
                        CategoryKey = dr["CategoryKey"] is DBNull ? 0 : Convert.ToInt32(dr["CategoryKey"].ToString()),
                        CategoryName = (dr["CategoryName"] ?? "").ToString(),
                        CatVal = (dr["CatVal"] ?? "").ToString(),
                        Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString()),
                        Description = (dr["Description"] ?? "").ToString(),
                        Button = (dr["Button"] ?? "").ToString()
                    };
                    objList.Add(objGet);
                    objGet.RowIndex = Lc + 1;
                    Lc += 1;
                }

                return objList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<ClsCategoryMasterMember> GetOnlyRole()
        {
            try
            {
                List<ClsCategoryMasterMember> objList = new List<ClsCategoryMasterMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@CompanyID",  ClsSessionKeys.CompanyKey)
                };
                IDataReader dr = objSql.ExecuteReader("RoleSearch", objParam);
                int Lc = 0;
                while (dr.Read())
                {
                    ClsCategoryMasterMember objGet = new ClsCategoryMasterMember();

                    objGet.CategoryKey = dr["CategoryKey"] is DBNull ? 0 : Convert.ToInt32(dr["CategoryKey"].ToString());
                    objGet.CategoryName = (dr["CategoryName"] ?? "").ToString();
                    objGet.CatVal = (dr["CatVal"] ?? "").ToString();
                    objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());

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
        public static String CategoryXMLGet(List<ClsCategoryMasterMember> data)
        {
            StringBuilder objStr = new StringBuilder();
            objStr.AppendFormat("<imp>");
            foreach (ClsCategoryMasterMember obj in data)
            {
                objStr.AppendFormat(@"<det     
                                        CategoryKey		=""{0}""
                                        CategoryName	=""{1}""
                                        CatVal			=""{2}""
                                        Status			=""{3}""
                                        Description		=""{4}""
                                        CompanyID		=""{5}""
                                          />"

                                        , obj.CategoryKey
                                        , obj.CategoryName
                                        , obj.CatVal
                                        , obj.Status
                                        , obj.Description
                                        , 1


                                        );
            }
            objStr.AppendFormat("</imp>");
            return objStr.ToString();
        }


        public static DataSet Win_CategoryGet(int pinCategoryKey)
        {
            try
            {


                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@CategoryKey",  pinCategoryKey  ),

                };

                return objSql.ExecuteDataSet("CategoryMasterGET", objParam);

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }  // End Of Class

}






