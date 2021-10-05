using CommonEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DL
{
    /// <summary>
    /// This class is used to define method for sql execution
    /// </summary>
    public class ClsSqlHelper
    {
        int i;
        protected string strConnectionString = "";
        protected string dbConnectionKey = string.Empty;
        public static int instances = 0;
        public ClsSqlHelper()
        {
            //dbConnectionKey = "GetConnectionString";
            //strConnectionString = ConfigurationManager.ConnectionStrings["GetConnectionString"].ToString();

        }


        public ClsSqlHelper(bool isHHADB)
        {
            if (isHHADB)
            {
                dbConnectionKey = "GetConnectionString";
                strConnectionString = ConfigurationManager.ConnectionStrings["GetConnectionString"].ToString();
            }
            else
            {
                dbConnectionKey = "CRUDConnectionString";
                strConnectionString = ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ToString();
            }

        }
        public static int GetActiveInstances()
        {
            return instances;
        }
        /// <summary>
        /// Author: Imran A Shaikh
        /// Date: 12-Jul-2103
        /// Purpose: Assign DB conncetion string based on the parameter passed.
        /// Task Id: 71010
        /// </summary>
        /// <param name="dbType"></param>
        public ClsSqlHelper(Helper.DBCONNTYPE dbType)
        {

            switch (dbType)
            {

                case Helper.DBCONNTYPE.GetConnectionString:
                    dbConnectionKey = "GetConnectionString";
                    strConnectionString =  ConfigurationManager.ConnectionStrings["GetConnectionString"].ToString().Replace("B1E8F3D884828370","WINROMS");
                    break;
                case Helper.DBCONNTYPE.SaveAndDeleteConnectionString:
                    dbConnectionKey = "CRUDConnectionString";
                    strConnectionString = ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ToString();
                    break;
                case Helper.DBCONNTYPE.GetConnectionStringEncrypt:
                    dbConnectionKey = "GetConnectionString";
                    strConnectionString = FNC.DecryptData(ConfigurationManager.AppSettings["GetConnectionString"].ToString());
                    break;
                case Helper.DBCONNTYPE.SaveAndDeleteConnectionStringEncrypt:
                    dbConnectionKey = "CRUDConnectionString";
                    strConnectionString = FNC.DecryptData(ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ToString());
                    break;
            }
 
        }

        /// <summary>
        /// Execute SQL using ExecuteNonQuery method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string pinQuery)
        {

            int retval = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);

            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;

                try
                {
                    retval = db.ExecuteNonQuery(dbCommand);

                }
                catch (SqlException sqlex)
                {
                    throw sqlex;
                }

            }

            return retval;
        }
        /// <summary>
        /// Execute SQL using ExecuteNonQuery method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <param name="pinParameter"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string pinQuery, params SqlParameter[] pinParameter)
        {
            bool IsOutParam = false;

            int retval = 0;
            int OutParamIndex = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;
                for (i = 0; i <= pinParameter.Length - 1; i++)
                {
                    if (pinParameter[i].Direction.ToString() == "Input")
                    {
                        db.AddInParameter(dbCommand, pinParameter[i].ParameterName, pinParameter[i].DbType, pinParameter[i].Value);
                    }
                    else
                    {
                        IsOutParam = true;
                        OutParamIndex = i;
                        db.AddOutParameter(dbCommand, pinParameter[i].ParameterName, pinParameter[i].DbType, pinParameter[i].Size);
                    }
                }
                try
                {

                    if (IsOutParam == true)
                    {
                        db.ExecuteNonQuery(dbCommand);
                        retval = Convert.ToInt32(db.GetParameterValue(dbCommand, pinParameter[OutParamIndex].ToString()));
                    }
                    else
                    {
                        retval = db.ExecuteNonQuery(dbCommand);
                    }


                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 2601)
                    {
                        var Data = sqlex.Message.Split('(')[1].Split(')')[0];
                        if (Data != null && Data.Length > 0)
                        {
                            throw new Exception(Data + " already exists in system.");
                        }
                        throw new Exception("Duplicate Entry Not Allowed In System.");
                    }
                    throw sqlex;
                }

            }

            return retval;
        }

        /// <summary>
        /// Execute SQL using ExecuteNonQuery method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <returns></returns>
        public ArrayList ExecuteNonQuerySqlMessage(string pinQuery)
        {

            ArrayList Arr = new ArrayList();
            int retval = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;
                try
                {
                    retval = db.ExecuteNonQuery(dbCommand);
                    Arr.Add(retval);

                }
                catch (SqlException sqlex)
                {
                    Arr.Add(retval);
                    Arr.Add(sqlex.Errors[1].Message.ToString());

                    return Arr;
                }
            }

            return Arr;
        }
        /// <summary>
        /// Execute SQL using ExecuteNonQuery method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <param name="pinParameter"></param>
        /// <returns></returns>
        public ArrayList ExecuteNonQuerySqlMessage(string pinQuery, params SqlParameter[] pinParameter)
        {
            ArrayList Arr = new ArrayList();
            int retval = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;
                for (i = 0; i <= pinParameter.Length - 1; i++)
                {
                    db.AddInParameter(dbCommand, pinParameter[i].ParameterName, pinParameter[i].DbType, pinParameter[i].Value);
                }
                try
                {
                    retval = db.ExecuteNonQuery(dbCommand);
                    Arr.Add(retval);

                }
                catch (SqlException sqlex)
                {
                    Arr.Add(retval);
                    Arr.Add(sqlex.Errors[1].Message.ToString());

                    return Arr;
                }
            }

            return Arr;
        }
        /// <summary>
        /// Execute SQL using ExecuteScalar method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <returns></returns>
        public object ExecuteScalar(string pinQuery)
        {
            object retval = null;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;
                retval = db.ExecuteScalar(dbCommand);

            }

            return retval;
        }
        /// <summary>
        /// Execute SQL using ExecuteScalar method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <param name="pinParameter"></param>
        /// <returns></returns>
        public object ExecuteScalar(string pinQuery, params SqlParameter[] pinParameter)
        {

            try
            {
                object retval = null;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                
                Database db = factory.Create(dbConnectionKey);
              

                using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
                {
                    dbCommand.CommandTimeout = 600;


                    for (i = 0; i <= pinParameter.Length - 1; i++)
                    {
                        db.AddInParameter(dbCommand, pinParameter[i].ParameterName, pinParameter[i].DbType, pinParameter[i].Value);
                    }
                    retval = db.ExecuteScalar(dbCommand);

                }

                return retval;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Execute SQL using ExecuteReader method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string pinQuery )
        {

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            IDataReader reader;
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;
                reader = db.ExecuteReader(dbCommand);
            }

            return reader;
        }

        /// <summary>
        /// Execute SQL using ExecuteReader method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <param name="pinParameter"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string pinQuery, params SqlParameter[] pinParameter)
        {

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            IDataReader reader;
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;

                for (i = 0; i <= pinParameter.Length - 1; i++)
                {
                    db.AddInParameter(dbCommand, pinParameter[i].ParameterName, pinParameter[i].DbType, pinParameter[i].Value);
                }
                reader = db.ExecuteReader(dbCommand);
            }

            return reader;
        }
        /// <summary>
        /// Execute SQL using ExecuteDataSet method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string pinQuery)
        {

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(dbConnectionKey);
            using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
            {
                dbCommand.CommandTimeout = 600;

                return (db.ExecuteDataSet(dbCommand));

            }
        }
        /// <summary>
        /// Execute SQL using ExecuteDataSet method
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <param name="pinparameter"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string pinQuery, params SqlParameter[] pinparameter)
        {


            try
            {
                Database db = null;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                
                
                db = factory.Create(dbConnectionKey);


                using (System.Data.Common.DbCommand dbCommand = (pinQuery.StartsWith("SELECT") | pinQuery.StartsWith("select")) ? db.GetSqlStringCommand(pinQuery) : db.GetStoredProcCommand(pinQuery))
                {
                    dbCommand.CommandTimeout = 600;
                    for (i = 0; i <= pinparameter.Length - 1; i++)
                    {
                        db.AddInParameter(dbCommand, pinparameter[i].ParameterName, pinparameter[i].DbType, pinparameter[i].Value);
                    }
                    return db.ExecuteDataSet(dbCommand);

                }


            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }


        /// <summary>
        /// Execute SQL Without enterprise library
        /// </summary>
        /// <param name="pinQuery"></param>
        /// <param name="pinParameter"></param>
        /// <returns></returns>
        public int ExecuteNonQueryWithoutEL(string pinQuery, params SqlParameter[] pinParameter)
        {
            SqlConnection con = new SqlConnection("DocConnectionString");
            SqlCommand cmd = new SqlCommand(pinQuery, con)
            {
                CommandTimeout = 600
            };
            if (pinQuery.StartsWith("insert") | pinQuery.StartsWith("INSERT") | pinQuery.StartsWith("update") | pinQuery.StartsWith("UPDATE") | pinQuery.StartsWith("delete") | pinQuery.StartsWith("DELETE"))
            {

                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.Text;

            }
            for (i = 0; i <= pinParameter.Length - 1; i++)
            {
                cmd.Parameters.Add(pinParameter[i]);
            }
            try
            {
                con.Open();
                int retval = cmd.ExecuteNonQuery();
                return retval;

            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
 
        }


    }
}
