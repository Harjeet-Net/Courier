using BL.Common;
using CommonEntity;
using DL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BL
{
	public class clsConfigurationMember : ClsBaseBL
	{
	 

		public string ConfigName { get; set; }

		public string ConfigValue { get; set; }
	}
	public class clsConfiguration : clsConfigurationMember
	{

		public int AddUpdateDelete(String sXML)
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@XML",                                 sXML) 
				};
				var result = objSave.ExecuteNonQuery("ConfigurationSave", objPrams);
				if (result > 0)
				{
					LoadSettings();
				}
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static String  SQLBackup()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@Path", clsVariables.sBACKUPPATH)
				};
				clsVariables.sLastBackup = objSave.ExecuteScalar("SQLBackup", objPrams).ToString();
				return clsVariables.sLastBackup;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsConfigurationMember> GetConfigurationMemberList()
		{
			try
			{
				List<clsConfigurationMember> objLst = new List<clsConfigurationMember>();
	
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);

				IDataReader dr = objSql.ExecuteReader("ConfigurationGet");
				while (dr.Read())
				{
					clsConfigurationMember objGet = new clsConfigurationMember();


					objGet.ConfigName = (dr["ConfigName"] ?? "").ToString();
					objGet.ConfigValue = (dr["ConfigValue"] ?? "").ToString();
					objLst.Add(objGet);
				}

				return objLst;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		public    void LoadSettings()
		{
			try
			{
				List<clsConfigurationMember> Lst = GetConfigurationMemberList();
				clsVariables.sA4PRINTER			= Lst.Find(x=>x.ConfigName.Equals("A4 PRINTER")).ConfigValue;
				clsVariables.sAUTOBACKUPTIME1 	= Lst.Find(x=>x.ConfigName.Equals("AUTO BACKUP TIME-1")).ConfigValue;
				clsVariables.sAUTOBACKUPTIME2 	= Lst.Find(x=>x.ConfigName.Equals("AUTO BACKUP TIME-2")).ConfigValue;
				clsVariables.sBACKUPPATH 		= Lst.Find(x=>x.ConfigName.Equals("BACKUP PATH")).ConfigValue;
				clsVariables.sDEFAULTPRINTER 	= Lst.Find(x=>x.ConfigName.Equals("DEFAULT PRINTER")).ConfigValue;
				clsVariables.sPOSPRINTER 		= Lst.Find(x=>x.ConfigName.Equals("POS PRINTER")).ConfigValue;
				clsVariables.sLastBackup		= Lst.Find(x => x.ConfigName.Equals("BACKUP")).ConfigValue;

			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
	}  // End Of Class



}
