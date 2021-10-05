using BL.Common;
using CommonEntity;
using DL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.EmployeeMaster
{
	public class clsEmployeeMember : ClsBaseBL
	{
		public int? TenentID { get; set; }

		public int employeeID { get; set; }

		public string userID { get; set; }

		public int? MainHRRoleID { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string name2 { get; set; }

		public string name3 { get; set; }

		public string Studen_LoginID { get; set; }

		public string PASSWORD { get; set; }
		public string emp_mobile { get; set; }
		public DateTime? joined_date { get; set; }
		public bool? Active { get; set; }

		public string EmployeeImage { get; set; }
		[JsonIgnore]
		public byte[] EmployeeImageByte { get; set; }
		[JsonIgnore]
		public String ByteToIMage { get; set; }
		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }

		public string MainHRRoleIDName { get; set; }
	}
	public class clsEmployee : clsEmployeeMember
	{


		public List<clsEmployeeMember> AuthenticateEmployee(string suserID, String sPASSWORD, string iTenentID)
		{
			try
			{
				List<clsEmployeeMember> objList = new List<clsEmployeeMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					 new SqlParameter("@userID"                    ,suserID  ),
					  new SqlParameter("@PASSWORD"                ,sPASSWORD  ),
					  new SqlParameter("@TenentID"                 ,iTenentID  )
				};
				IDataReader dr = objSql.ExecuteReader("EmployeeAutehnticate", objParam);

				
				while (dr.Read())
				{
					clsEmployeeMember objGet = new clsEmployeeMember
					{
						TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString()),
						employeeID = dr["employeeID"] is DBNull ? 0 : Convert.ToInt32(dr["employeeID"].ToString()),
						userID = (dr["userID"] ?? "").ToString(),
						MainHRRoleID = dr["MainHRRoleID"] is DBNull ? 0 : Convert.ToInt32(dr["MainHRRoleID"].ToString()),
						MainHRRoleIDName = (dr["MainHRRoleIDName"] ?? "").ToString(),
						lastname = (dr["lastname"] ?? "").ToString(),
						firstname = (dr["firstname"] ?? "").ToString(),
						name2 = (dr["name2"] ?? "").ToString(),
						name3 = (dr["name3"] ?? "").ToString(),
						Studen_LoginID = (dr["Studen_LoginID"] ?? "").ToString(),
						PASSWORD = (dr["PASSWORD"] ?? "").ToString(),
						emp_mobile = (dr["emp_mobile"] ?? "").ToString(),
						Active = dr["Active"] is DBNull ? false : Convert.ToBoolean(dr["Active"].ToString()),
						EmployeeImage = (dr["EmployeeImage"] ?? "").ToString(),
						EmployeeImageByte = String.IsNullOrEmpty(dr["EmployeeImageByte"].ToString()) ? null : (byte[])dr["EmployeeImageByte"],
					};

			
				objGet.ByteToIMage = String.IsNullOrEmpty(dr["EmployeeImageByte"].ToString()) ? "" : "data:image/png;base64," + Convert.ToBase64String(objGet.EmployeeImageByte, 0, objGet.EmployeeImageByte.Length);
				objList.Add(objGet);
				}
				return objList;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@employeeID",                              employeeID),
						new SqlParameter("@userID",                                  userID),
						new SqlParameter("@MainHRRoleID",                            MainHRRoleID),
						new SqlParameter("@lastname",                                lastname),
						new SqlParameter("@firstname",                               firstname),
						new SqlParameter("@name2",                                   name2),
						new SqlParameter("@name3",                                   name3),
						new SqlParameter("@Studen_LoginID",                          Studen_LoginID),
						new SqlParameter("@PASSWORD",                                PASSWORD),
						new SqlParameter("@emp_mobile",                              emp_mobile),
						new SqlParameter("@joined_date",                             joined_date),
						new SqlParameter("@Active",                                  Active),
						new SqlParameter("@EmployeeImage",                               EmployeeImage),
						new SqlParameter("@EmployeeImageByte",                           SqlDbType.VarBinary,-1),

						new SqlParameter("@Action",                                  Action.ToString())
				};
				objPrams[14].Value = EmployeeImageByte;
				var result = objSave.ExecuteNonQuery("EmployeeSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsEmployeeMember> GetEmployee()
		{
			try
			{
				List<clsEmployeeMember> objList = new List<clsEmployeeMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@employeeID",  employeeID  ),
				};
				IDataReader dr = objSql.ExecuteReader("EmployeeGet", objParam);
				clsEmployeeMember objGet = new clsEmployeeMember();
				while (dr.Read())
				{
					

					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.employeeID = dr["employeeID"] is DBNull ? 0 : Convert.ToInt32(dr["employeeID"].ToString());
					objGet.userID = (dr["userID"] ?? "").ToString();
					objGet.MainHRRoleID = dr["MainHRRoleID"] is DBNull ? 0 : Convert.ToInt32(dr["MainHRRoleID"].ToString());
					objGet.lastname = (dr["lastname"] ?? "").ToString();
					objGet.firstname = (dr["firstname"] ?? "").ToString();
					objGet.name2 = (dr["name2"] ?? "").ToString();
					objGet.name3 = (dr["name3"] ?? "").ToString();
					objGet.Studen_LoginID = (dr["Studen_LoginID"] ?? "").ToString();
					objGet.PASSWORD = (dr["PASSWORD"] ?? "").ToString();
					objGet.emp_mobile = (dr["emp_mobile"] ?? "").ToString();
					objGet.Active = dr["Active"] is DBNull ? false : Convert.ToBoolean(dr["Active"].ToString());
					objGet.EmployeeImage = (dr["EmployeeImage"] ?? "").ToString();
					objGet.EmployeeImageByte = String.IsNullOrEmpty(dr["EmployeeImageByte"].ToString()) ? null : (byte[])dr["EmployeeImageByte"];
					
				}
				
				objList.Add(objGet);
				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public List<clsEmployeeMember> SearchEmployee()
		{
			try
			{
				List<clsEmployeeMember> objList = new List<clsEmployeeMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@firstname",  firstname  ),
					  new SqlParameter("@MainHRRoleID",  MainHRRoleID  ),
				};
				IDataReader dr = objSql.ExecuteReader("EmployeeSearch", objParam);
				int Lc = 0;

				while (dr.Read())
				{
					clsEmployeeMember objGet = new clsEmployeeMember();

					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.employeeID = dr["employeeID"] is DBNull ? 0 : Convert.ToInt32(dr["employeeID"].ToString());
					objGet.userID = (dr["userID"] ?? "").ToString();
					objGet.MainHRRoleID = dr["MainHRRoleID"] is DBNull ? 0 : Convert.ToInt32(dr["MainHRRoleID"].ToString());
					objGet.lastname = (dr["lastname"] ?? "").ToString();
					objGet.firstname = (dr["firstname"] ?? "").ToString();
					objGet.name2 = (dr["name2"] ?? "").ToString();
					objGet.name3 = (dr["name3"] ?? "").ToString();
					objGet.Studen_LoginID = (dr["Studen_LoginID"] ?? "").ToString();
					objGet.PASSWORD = (dr["PASSWORD"] ?? "").ToString();
					objGet.emp_mobile = (dr["emp_mobile"] ?? "").ToString();
					objGet.Active = dr["Active"] is DBNull ? false : Convert.ToBoolean(dr["Active"].ToString());
					objGet.EmployeeImage = (dr["EmployeeImage"] ?? "").ToString();
					objGet.EmployeeImageByte = String.IsNullOrEmpty(dr["EmployeeImageByte"].ToString()) ? null : (byte[])dr["EmployeeImageByte"];
					objGet.Button = (dr["Button"] ?? "").ToString();
					objGet.RowIndex = Lc + 1;
					objList.Add(objGet);	
					Lc += 1;

				}
				//objGet.ByteToIMage = String.IsNullOrEmpty(dr["EmployeeImageByte"].ToString()) ? "" : "data:image/png;base64," + Convert.ToBase64String(objGet.EmployeeImageByte, 0, objGet.EmployeeImageByte.Length);
				
				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

	}  // End Of Class


}
