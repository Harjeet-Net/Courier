using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Autosugess
{
    public class clsAutoSgges : ClsBaseBL
    {
        public string Name
        {
            get;
            set;
        }

        public DataTable GetAuto(string prefixText, int count, string contextKey)
        {
            List<string> AutoSuggess = new List<string>();
            ClsSqlHelper objSql = new    ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
            DataTable dtAutoComp = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objParam = new SqlParameter[5];
                objParam[0] = new SqlParameter("@TableName", contextKey);
                objParam[1] = new SqlParameter("@Prefix", prefixText);
                objParam[2] = new SqlParameter("@count", count);
                objParam[3] = new SqlParameter("@CompanyID", 1);
                objParam[4] = new SqlParameter("@UserID", 1);
                ds = objSql.ExecuteDataSet("uspAutoSugges", objParam);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dtAutoComp = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtAutoComp;
        }



        //public DataSet GetAssigneeStock(string ItemID, string fromparty, string toparty, string transaction)
        //{

        //	ClsSqlHelper objSql = new ClsSqlHelper();
        //	DataSet dtAutoComp = new DataSet();
        //	try
        //	{
        //		clsItemMaster objItem = new clsItemMaster();
        //		dtAutoComp = objItem.GetAssigneeStock(ItemID, fromparty, toparty, transaction);
        //		if (dtAutoComp != null)
        //		{
        //			if (dtAutoComp.Tables.Count > 0)
        //			{
        //				return dtAutoComp;
        //			}
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //	return null; ;
        //}

        //public DataSet GetQtyAndStockOnEditTransaction(string ItemID, string TranParty, string schemeID, string stockTransferDetailID)
        //{

        //	ClsSqlHelper objSql = new ClsSqlHelper();
        //	DataSet dtAutoComp = new DataSet();
        //	try
        //	{
        //		clsItemMaster objItem = new clsItemMaster();
        //		dtAutoComp = objItem.GetQtyAndStockOnEditTransaction(ItemID, TranParty, schemeID, stockTransferDetailID);
        //		if (dtAutoComp != null)
        //		{
        //			if (dtAutoComp.Tables.Count > 0)
        //			{
        //				return dtAutoComp;
        //			}
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //	return null; ;
        //}
    }
}
