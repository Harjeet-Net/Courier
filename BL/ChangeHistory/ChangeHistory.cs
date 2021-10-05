using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class clsChangeHistoryMember : ClsBaseBL
    {
        public int RowIndex { get; set; }

        public string TableName { get; set; }

        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        public string Action { get; set; }
    }
    public class clsChangeHistory : clsChangeHistoryMember
    {

        public int AddUpdateDelete()
        {
            try
            {
                ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
                SqlParameter[] objPrams = new SqlParameter[]
                {
                        new SqlParameter("@RowIndex",                                RowIndex),
                        new SqlParameter("@TableName",                               TableName),
                        new SqlParameter("@FieldName",                               FieldName),
                        new SqlParameter("@OldValue",                                OldValue),
                        new SqlParameter("@NewValue",                                NewValue),
                        new SqlParameter("@UserName",                                UserName),
                        new SqlParameter("@ChangeDate",                              ChangeDate),
                        new SqlParameter("@Action",                                  Action),
                        new SqlParameter("@CompanyID",                               CompanyID),
                        new SqlParameter("@UserID",                                  UserID),
                        new SqlParameter("@Action",                                  Action.ToString())
                };
                var result = objSave.ExecuteNonQuery("ChangeHistorySave", objPrams);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsChangeHistoryMember> GetChangeHistoryMemberList()
        {
            try
            {
                List<clsChangeHistoryMember> objList = new List<clsChangeHistoryMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@RowIndex",  RowIndex  ),

                      new SqlParameter("@CompanyID", CompanyID),
                      new SqlParameter("@UserID", UserID),
                      new SqlParameter("@Action", Action.ToString())
                };
                IDataReader dr = objSql.ExecuteReader("ChangeHistoryGet", objParam);
                while (dr.Read())
                {
                    clsChangeHistoryMember objGet = new clsChangeHistoryMember();

                    objGet.RowIndex = dr["RowIndex"] is DBNull ? 0 : Convert.ToInt32(dr["RowIndex"].ToString());
                    objGet.TableName = (dr["TableName"] ?? "").ToString();
                    objGet.FieldName = (dr["FieldName"] ?? "").ToString();
                    objGet.OldValue = (dr["OldValue"] ?? "").ToString();
                    objGet.NewValue = (dr["NewValue"] ?? "").ToString();
                    objGet.UserName = (dr["UserName"] ?? "").ToString();
                    if (dr["ChangeDate"] != DBNull.Value)
                        objGet.ChangeDate = Convert.ToDateTime(dr["ChangeDate"].ToString());
                    objGet.Action = (dr["Action"] ?? "").ToString();
                    objList.Add(objGet);
                }

                return objList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        public DataSet Report_ChangeHistory()
        {
            try
            {
                List<clsChangeHistoryMember> objList = new List<clsChangeHistoryMember>();
                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@RowIndex",  RowIndex  ),
                };
                return objSql.ExecuteDataSet("Report_ChangeHistory", objParam);

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        public DataSet ChangeHistoryReportSearch(string pinFromDate, string pinToDate, string pinModuleName, int pinUserID)
        {
            try
            {
                List<clsChangeHistoryMember> objList = new List<clsChangeHistoryMember>();

                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@UserID",  pinUserID  ),
                      new SqlParameter("@ModuleName",pinModuleName),
                      new SqlParameter("@FromDate",  pinFromDate  ),
                      new SqlParameter("@ToDate",  pinToDate  ),

                };
                return objSql.ExecuteDataSet("ChangeHistoryReportSearch", objParam);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataSet ImportLogReport(string pinFromDate, string pinToDate, string pinModuleName, string pinUserID)
        {
            try
            {
                List<clsChangeHistoryMember> objList = new List<clsChangeHistoryMember>();

                ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
                SqlParameter[] objParam = new SqlParameter[]
                {
                      new SqlParameter("@UserID",  pinUserID  ),
                      new SqlParameter("@ModuleName",pinModuleName),
                      new SqlParameter("@FromDate",  pinFromDate  ),
                      new SqlParameter("@ToDate",  pinToDate  ),

                };
                return objSql.ExecuteDataSet("ImportLogReport", objParam);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }



    }  // End Of Class



}
