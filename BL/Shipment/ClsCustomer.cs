using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL.Shipment
{
    public class clsCustomerMember : ClsBaseBL
	{
		public int Id { get; set; }

		public int TenentID { get; set; }

		public string CustomerName { get; set; }

		public string MobileNumber { get; set; }

		public string AlternateNumber { get; set; }

		public string EmailId { get; set; }

		public string ReferenceNumber { get; set; }

		public string PaciNumber { get; set; }

		public string Nationality { get; set; }

		public string Address { get; set; }

		public string ZipCode { get; set; }

		public string City { get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public bool? Status { get; set; }


		public int DefaultAddress { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }


		public List<clsCombo> LstAddress { get; set; }

		public DataTable dtAddress { get; set; }
	}
	public class clsCustomer : clsCustomerMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@Id",                                      Id),
						new SqlParameter("@TenentID",                                14),
						new SqlParameter("@CustomerName",                            CustomerName),
						new SqlParameter("@MobileNumber",                            MobileNumber),
						new SqlParameter("@AlternateNumber",                         AlternateNumber),
						new SqlParameter("@EmailId",                                 EmailId),
						new SqlParameter("@ReferenceNumber",                         ReferenceNumber),
						new SqlParameter("@PaciNumber",                              PaciNumber),
						new SqlParameter("@Nationality",                             Nationality),
						new SqlParameter("@Address",                                 Address),
						new SqlParameter("@ZipCode",                                 ZipCode),
						new SqlParameter("@City",                                    City),
						new SqlParameter("@Country",                                 Country),
						new SqlParameter("@State",                                   State),
						new SqlParameter("@Status",                                  Status),
						new SqlParameter("@DefaultAddress",                          DefaultAddress),

						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteScalar("CustomerSave", objPrams);
				return Convert.ToInt32(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public clsCustomerMember  GetCustomer()
		{
			try
			{
				clsCustomerMember objGet = new clsCustomerMember();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@Id",  Id  ),
				};
				DataSet ds = objSql.ExecuteDataSet("CustomerGet", objParam);
				if (ds.Tables.Count>0)
				{
					foreach(DataRow dr in ds.Tables[0].Rows)
                    {
						objGet.Id = dr["Id"] is DBNull ? 0 : Convert.ToInt32(dr["Id"].ToString());
						objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
						objGet.CustomerName = (dr["CustomerName"] ?? "").ToString();
						objGet.MobileNumber = (dr["MobileNumber"] ?? "").ToString();
						objGet.AlternateNumber = (dr["AlternateNumber"] ?? "").ToString();
						objGet.EmailId = (dr["EmailId"] ?? "").ToString();
						objGet.ReferenceNumber = (dr["ReferenceNumber"] ?? "").ToString();
						objGet.PaciNumber = (dr["PaciNumber"] ?? "").ToString();
						objGet.Nationality = (dr["Nationality"] ?? "").ToString();
						objGet.Address = (dr["Address"] ?? "").ToString();
						objGet.ZipCode = (dr["ZipCode"] ?? "").ToString();
						objGet.City = (dr["City"] ?? "").ToString();
						objGet.Country = (dr["Country"] ?? "").ToString();
						objGet.State = (dr["State"] ?? "").ToString();
						objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
						objGet.DefaultAddress = dr["DefaultAddress"] is DBNull ? 0 : Convert.ToInt32(dr["DefaultAddress"].ToString());
					}
					if(ds.Tables.Count>1)
                    {
						foreach(DataRow r2 in ds.Tables[1].Rows)
                        {
							objGet.dtAddress = ds.Tables[1];
                        }
                    }

				}

				return objGet;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}

		public clsCustomerMember CustomerDetailGet()
		{
			try
			{
				clsCustomerMember objitem = new clsCustomerMember();
				ClsSqlHelper objGet = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
					 	new SqlParameter("@Id",  Id  ),
				};
				DataSet ds = objGet.ExecuteDataSet("CustomerDetailGet", objPrams);
				if (ds != null)
				{
					if (ds.Tables.Count > 0)
					{
						foreach (DataRow dr in ds.Tables[0].Rows)
						{
							objitem.Id = dr["Id"] is DBNull ? 0 : Convert.ToInt32(dr["Id"].ToString());
							objitem.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
							objitem.CustomerName = (dr["CustomerName"] ?? "").ToString();
							objitem.MobileNumber = (dr["MobileNumber"] ?? "").ToString();
							objitem.AlternateNumber = (dr["AlternateNumber"] ?? "").ToString();
							objitem.EmailId = (dr["EmailId"] ?? "").ToString();
							objitem.ReferenceNumber = (dr["ReferenceNumber"] ?? "").ToString();
							objitem.PaciNumber = (dr["PaciNumber"] ?? "").ToString();
							objitem.Nationality = (dr["Nationality"] ?? "").ToString();
							objitem.Address = (dr["Address"] ?? "").ToString();
							objitem.ZipCode = (dr["ZipCode"] ?? "").ToString();
							objitem.City = (dr["City"] ?? "").ToString();
							objitem.Country = (dr["Country"] ?? "").ToString();
							objitem.State = (dr["State"] ?? "").ToString();
							objitem.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
							objitem.DefaultAddress = dr["DefaultAddress"] is DBNull ? 0 : Convert.ToInt32(dr["DefaultAddress"].ToString());
						}
					}
                    List<clsCombo> LstAdr = new List<clsCombo>();
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow r2 in ds.Tables[1].Rows)
                        {
                            LstAdr.Add(new clsCombo
                            {
                                ComboID = (r2["AddressKey"] ?? "").ToString(),
                                ComboValue = (r2["CustomerAddress"] ?? "").ToString()

                            });

                            objitem.LstAddress = LstAdr;
                        }

                    }

                }
				return objitem;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsCustomerMember> SearchCustomer()
		{
			try
			{
				List<clsCustomerMember> objList = new List<clsCustomerMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@Id",  Id  ),
					  new SqlParameter("@MobileNumber",  MobileNumber  ),
					  new SqlParameter("@Country",  Country  ),
				};
				IDataReader dr = objSql.ExecuteReader("CustomerSearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					clsCustomerMember objGet = new clsCustomerMember();

					objGet.Id = dr["Id"] is DBNull ? 0 : Convert.ToInt32(dr["Id"].ToString());
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.CustomerName = (dr["CustomerName"] ?? "").ToString();
					objGet.MobileNumber = (dr["MobileNumber"] ?? "").ToString();
					objGet.AlternateNumber = (dr["AlternateNumber"] ?? "").ToString();
					objGet.EmailId = (dr["EmailId"] ?? "").ToString();
					objGet.ReferenceNumber = (dr["ReferenceNumber"] ?? "").ToString();
					objGet.PaciNumber = (dr["PaciNumber"] ?? "").ToString();
					objGet.Nationality = (dr["Nationality"] ?? "").ToString();
					objGet.Address = (dr["Address"] ?? "").ToString();
					objGet.ZipCode = (dr["ZipCode"] ?? "").ToString();
					objGet.City = (dr["City"] ?? "").ToString();
					objGet.Country = (dr["Country"] ?? "").ToString();
					objGet.State = (dr["State"] ?? "").ToString();
					objGet.Status = dr["Status"] is DBNull ? false : Convert.ToBoolean(dr["Status"].ToString());
					objGet.DefaultAddress = dr["DefaultAddress"] is DBNull ? 0 : Convert.ToInt32(dr["DefaultAddress"].ToString());
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
