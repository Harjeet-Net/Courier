using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.EmployeeMaster
{
    public class clsCityStatesCountyMember : ClsBaseBL
	{
		public int CityID { get; set; }

		public int StateID { get; set; }

		public int COUNTRYID { get; set; }

		public string CityEnglish { get; set; }

		public string CityArabic { get; set; }

		public string CityOther { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }

		public String StateName { get; set; }
		public String CountryName { get; set; }

	}
	public class clsCityStatesCounty : clsCityStatesCountyMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@CityID",                                   CityID),
						new SqlParameter("@StateID",                                  StateID),
						new SqlParameter("@COUNTRYID",                                COUNTRYID),
						new SqlParameter("@CityEnglish",                              CityEnglish),
						new SqlParameter("@CityArabic",                               CityArabic),
						new SqlParameter("@CityOther",                                CityOther),
						new SqlParameter("@Action",                                   Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("CityStatesCountySave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsCityStatesCountyMember> GETCityStatesCountry()
		{
			try
			{
				List<clsCityStatesCountyMember> objList = new List<clsCityStatesCountyMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@CityID",  CityID  ),
					

				};
				IDataReader dr = objSql.ExecuteReader("CityStatesCountyGET", objParam);
			
				while (dr.Read())
				{
					clsCityStatesCountyMember objGet = new clsCityStatesCountyMember();

					objGet.CityID = dr["CityID"] is DBNull ? 0 : Convert.ToInt32(dr["CityID"].ToString());
					objGet.StateID = dr["StateID"] is DBNull ? 0 : Convert.ToInt32(dr["StateID"].ToString());
					objGet.COUNTRYID = dr["COUNTRYID"] is DBNull ? 0 : Convert.ToInt32(dr["COUNTRYID"].ToString());
					objGet.CityEnglish = (dr["CityEnglish"] ?? "").ToString();
					objGet.CityArabic = (dr["CityArabic"] ?? "").ToString();
					objGet.CityOther = (dr["CityOther"] ?? "").ToString();
					

					objList.Add(objGet);
					
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		public List<clsCityStatesCountyMember> SearchCityStatesCounty()
		{
			try
			{
				List<clsCityStatesCountyMember> objList = new List<clsCityStatesCountyMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@StateID",  StateID  ),
					  new SqlParameter("@COUNTRYID",  COUNTRYID  ),

				};
				IDataReader dr = objSql.ExecuteReader("CityStatesCountySEARCH", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					clsCityStatesCountyMember objGet = new clsCityStatesCountyMember();

					objGet.CityID = dr["CityID"] is DBNull ? 0 : Convert.ToInt32(dr["CityID"].ToString());
					objGet.StateID = dr["StateID"] is DBNull ? 0 : Convert.ToInt32(dr["StateID"].ToString());
					objGet.COUNTRYID = dr["COUNTRYID"] is DBNull ? 0 : Convert.ToInt32(dr["COUNTRYID"].ToString());
					objGet.CityEnglish = (dr["CityEnglish"] ?? "").ToString();
					objGet.StateName = (dr["StateName"] ?? "").ToString();
					objGet.CountryName = (dr["CountryName"] ?? "").ToString();
					objGet.CityArabic = (dr["CityArabic"] ?? "").ToString();
					objGet.CityOther = (dr["CityOther"] ?? "").ToString();
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
