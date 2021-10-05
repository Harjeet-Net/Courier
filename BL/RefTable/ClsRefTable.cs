using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BL.REFTABLE
{
	public class ClsRefTableMember : ClsBaseBL
	{
		public int TenentID { get; set; }

		public int REFID { get; set; }

		public string REFTYPE { get; set; }

		public string REFSUBTYPE { get; set; }

		public string SHORTNAME { get; set; }

		public string REFNAME1 { get; set; }

		public string REFNAME2 { get; set; }

		public string REFNAME3 { get; set; }

		public string SWITCH1 { get; set; }

		public string SWITCH2 { get; set; }

		public string SWITCH3 { get; set; }

		//public int? SWITCH4 { get; set; }

		//public string Remarks { get; set; }
		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }
	}
	public class ClsRefTable : ClsRefTableMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@REFID",                                   REFID),
						new SqlParameter("@REFTYPE",                                 REFTYPE),
						new SqlParameter("@REFSUBTYPE",                              REFSUBTYPE),
						new SqlParameter("@SHORTNAME",                               SHORTNAME),
						new SqlParameter("@REFNAME1",                                REFNAME1),
						new SqlParameter("@REFNAME2",                                REFNAME2),
						new SqlParameter("@REFNAME3",                                REFNAME3),
						new SqlParameter("@SWITCH1",                                 SWITCH1),
						new SqlParameter("@SWITCH2",                                 SWITCH2),
						new SqlParameter("@SWITCH3",                                 SWITCH3),
						//new SqlParameter("@SWITCH4",                                 SWITCH4),
						//new SqlParameter("@Remarks",                                 Remarks),
						new SqlParameter("@Action",                                   Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("REFTABLESave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsRefTableMember> GetREFTABLE()
		{
			try
			{
				List<ClsRefTableMember> objList = new List<ClsRefTableMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@REFID",  REFID),
				};
				IDataReader dr = objSql.ExecuteReader("REFTABLEGet", objParam);
				while (dr.Read())
				{
					ClsRefTableMember objGet = new ClsRefTableMember();

					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.REFID = dr["REFID"] is DBNull ? 0 : Convert.ToInt32(dr["REFID"].ToString());
					objGet.REFTYPE = (dr["REFTYPE"] ?? "").ToString();
					objGet.REFSUBTYPE = (dr["REFSUBTYPE"] ?? "").ToString();
					objGet.SHORTNAME = (dr["SHORTNAME"] ?? "").ToString();
					objGet.REFNAME1 = (dr["REFNAME1"] ?? "").ToString();
					objGet.REFNAME2 = (dr["REFNAME2"] ?? "").ToString();
					objGet.REFNAME3 = (dr["REFNAME3"] ?? "").ToString();
					objGet.SWITCH1 = (dr["SWITCH1"] ?? "").ToString();
					objGet.SWITCH2 = (dr["SWITCH2"] ?? "").ToString();
					objGet.SWITCH3 = (dr["SWITCH3"] ?? "").ToString();
					//objGet.SWITCH4 = dr["SWITCH4"] is DBNull ? 0 : Convert.ToInt32(dr["SWITCH4"].ToString());
					//objGet.Remarks = (dr["Remarks"] ?? "").ToString();					

					objList.Add(objGet);					
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		public List<ClsRefTableMember> SearchREFTABLE()
		{
			try
			{
				List<ClsRefTableMember> objList = new List<ClsRefTableMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@REFTYPE",  REFTYPE),
					  new SqlParameter("@REFSUBTYPE", REFSUBTYPE),
					
				};
				IDataReader dr = objSql.ExecuteReader("REFTABLESearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					ClsRefTableMember objGet = new ClsRefTableMember();

					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.REFID = dr["REFID"] is DBNull ? 0 : Convert.ToInt32(dr["REFID"].ToString());
					objGet.REFTYPE = (dr["REFTYPE"] ?? "").ToString();
					objGet.REFSUBTYPE = (dr["REFSUBTYPE"] ?? "").ToString();
					objGet.SHORTNAME = (dr["SHORTNAME"] ?? "").ToString();
					objGet.REFNAME1 = (dr["REFNAME1"] ?? "").ToString();
					objGet.REFNAME2 = (dr["REFNAME2"] ?? "").ToString();
					objGet.REFNAME3 = (dr["REFNAME3"] ?? "").ToString();
					objGet.SWITCH1 = (dr["SWITCH1"] ?? "").ToString();
					objGet.SWITCH2 = (dr["SWITCH2"] ?? "").ToString();
					objGet.SWITCH3 = (dr["SWITCH3"] ?? "").ToString();
					//objGet.SWITCH4 = dr["SWITCH4"] is DBNull ? 0 : Convert.ToInt32(dr["SWITCH4"].ToString());
					//objGet.Remarks = (dr["Remarks"] ?? "").ToString();
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

	}  // End Of Class

	

}
