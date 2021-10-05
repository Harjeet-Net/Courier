using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BL.TemplateMaster
{
	public class ClsTemplateMasterMember : ClsBaseBL
	{
		public int TemplateKey { get; set; }

		public string TemplateName { get; set; }

		public string Descriptions { get; set; }

		public string TemplateType { get; set; }

		public int CategoryKey { get; set; }

		public bool? Status { get; set; }

		public int? TenentID { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }
	}
	public class ClsTemplateMaster : ClsTemplateMasterMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@TemplateKey",                             TemplateKey),
						new SqlParameter("@TemplateName",                            TemplateName),
						new SqlParameter("@Descriptions",                            Descriptions),
						new SqlParameter("@TemplateType",                            TemplateType),
						new SqlParameter("@CategoryKey",                             CategoryKey),
						new SqlParameter("@Status",                                  Status),
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("TemplateMasterSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ClsTemplateMasterMember> GetTemplateMaster()
		{
			try
			{
				List<ClsTemplateMasterMember> objList = new List<ClsTemplateMasterMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@TemplateKey",  TemplateKey  )
					
				};
				IDataReader dr = objSql.ExecuteReader("TemplateMasterGet", objParam);
				while (dr.Read())
				{
					ClsTemplateMasterMember objGet = new ClsTemplateMasterMember();
					{
						objGet.TemplateKey = dr["TemplateKey"] is DBNull ? 0 : Convert.ToInt32(dr["TemplateKey"].ToString());
						objGet.TemplateName = (dr["TemplateName"] ?? "").ToString();
						objGet.Descriptions = (dr["Descriptions"] ?? "").ToString();
						objGet.TemplateType = (dr["TemplateType"] ?? "").ToString();
						objGet.CategoryKey = dr["CategoryKey"] is DBNull ? 0 : Convert.ToInt32(dr["CategoryKey"].ToString());
						objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
						objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
						objList.Add(objGet);
					}
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		public List<ClsTemplateMasterMember> SearchTemplateMaster()
		{
			try
			{
				List<ClsTemplateMasterMember> objList = new List<ClsTemplateMasterMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@TemplateType",  TemplateType  )

				};
				IDataReader dr = objSql.ExecuteReader("TemplateMasterSearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					ClsTemplateMasterMember objGet = new ClsTemplateMasterMember();
					
						objGet.TemplateKey = dr["TemplateKey"] is DBNull ? 0 : Convert.ToInt32(dr["TemplateKey"].ToString());
						objGet.TemplateName = (dr["TemplateName"] ?? "").ToString();
						objGet.Descriptions = (dr["Descriptions"] ?? "").ToString();
						objGet.TemplateType = (dr["TemplateType"] ?? "").ToString();
						objGet.CategoryKey = dr["CategoryKey"] is DBNull ? 0 : Convert.ToInt32(dr["CategoryKey"].ToString());
						objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
						objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
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
