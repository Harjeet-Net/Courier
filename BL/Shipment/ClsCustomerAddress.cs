using BL.AuthenticationAndSession;
using BL.Common;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BL.Shipment
{
	public class clsCustomerAddressMember : ClsBaseBL
	{
		public int AddressKey { get; set; }

		public int TenentID { get; set; }

		public int CustomerKey { get; set; }

		public string AddressName { get; set; }

		public string FlatNo { get; set; }

		public string FloorNo { get; set; }

		public string BlockNo { get; set; }

		public string City { get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string Address1 { get; set; }

		public string Address2 { get; set; }

		public string Address3 { get; set; }
		public string PostCode { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public int? UpdatedBy { get; set; }

		/****************EXtended property ****************************/

		public String Button { get; set; }

		public int RowIndex { get; set; }

		public string CustomerName { get; set; }


		public string  CityName { get; set; }
		public string CountryName { get; set; }
		public string StateName { get; set; }
	}
	public class clsCustomerAddress : clsCustomerAddressMember
	{

		public int AddUpdateDelete()
		{
			try
			{
				ClsSqlHelper objSave = new ClsSqlHelper(Helper.DBCONNTYPE.SaveAndDeleteConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
						new SqlParameter("@AddressKey",                              AddressKey),
						new SqlParameter("@TenentID",                                TenentID),
						new SqlParameter("@CustomerKey",                             CustomerKey),
						new SqlParameter("@AddressName",                             AddressName),
						new SqlParameter("@FlatNo",                                  FlatNo),
						new SqlParameter("@FloorNo",                                 FloorNo),
						new SqlParameter("@BlockNo",                                 BlockNo),
						new SqlParameter("@PostCode",                                 PostCode),
						new SqlParameter("@City",                                    City),
						new SqlParameter("@Country",                                 Country),
						new SqlParameter("@State",                                   State),
						new SqlParameter("@Address1",                                Address1),
						new SqlParameter("@Address2",                                Address2),
						new SqlParameter("@Address3",                                Address3),
						new SqlParameter("@UpdatedDate",                             UpdatedDate),
						new SqlParameter("@UpdatedBy",                               UpdatedBy),						
						new SqlParameter("@UserID",                                  UserID),
						new SqlParameter("@Action",                                  Action.ToString())
				};
				var result = objSave.ExecuteNonQuery("CustomerAddressSave", objPrams);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<clsCustomerAddressMember> GetCustomerAddress()
		{
			try
			{
				List<clsCustomerAddressMember> objList = new List<clsCustomerAddressMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@AddressKey",  AddressKey  ),
			
				};
				IDataReader dr = objSql.ExecuteReader("CustomerAddressGet", objParam);
				while (dr.Read())
				{
					clsCustomerAddressMember objGet = new clsCustomerAddressMember();

					objGet.AddressKey = dr["AddressKey"] is DBNull ? 0 : Convert.ToInt32(dr["AddressKey"].ToString());
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.CustomerKey = dr["CustomerKey"] is DBNull ? 0 : Convert.ToInt32(dr["CustomerKey"].ToString());
					objGet.CustomerName= (dr["CustomerName"] ?? "").ToString();
					objGet.AddressName = (dr["AddressName"] ?? "").ToString();
					objGet.FlatNo = (dr["FlatNo"] ?? "").ToString();
					objGet.FloorNo = (dr["FloorNo"] ?? "").ToString();
					objGet.BlockNo = (dr["BlockNo"] ?? "").ToString();
					objGet.PostCode = (dr["PostCode"] ?? "").ToString();
					objGet.City = (dr["City"] ?? "").ToString();
					objGet.Country = (dr["Country"] ?? "").ToString();
					objGet.State = (dr["State"] ?? "").ToString();
					objGet.Address1 = (dr["Address1"] ?? "").ToString();
					objGet.Address2 = (dr["Address2"] ?? "").ToString();
					objGet.Address3 = (dr["Address3"] ?? "").ToString();
					if (dr["UpdatedDate"] != DBNull.Value)
						objGet.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
					objGet.UpdatedBy = dr["UpdatedBy"] is DBNull ? 0 : Convert.ToInt32(dr["UpdatedBy"].ToString());
					objList.Add(objGet);
				}

				return objList;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
		}
		public clsCustomerAddressMember CustomerAddressDetailGet()
		{
			try
			{
				clsCustomerAddressMember objitem = new clsCustomerAddressMember();
				ClsSqlHelper objGet = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objPrams = new SqlParameter[]
				{
					 					  new SqlParameter("@AddressKey",  AddressKey  ),
				};
				DataSet ds = objGet.ExecuteDataSet("CustomerAddressDetailGet", objPrams);
				if (ds != null)
				{
					if (ds.Tables.Count > 0)
					{
						foreach (DataRow dr in ds.Tables[0].Rows)
						{
							objitem.AddressKey = dr["AddressKey"] is DBNull ? 0 : Convert.ToInt32(dr["AddressKey"].ToString());
							
							objitem.AddressName = (dr["AddressName"] ?? "").ToString();
							objitem.FlatNo = (dr["FlatNo"] ?? "").ToString();
							objitem.FloorNo = (dr["FloorNo"] ?? "").ToString();
							objitem.BlockNo = (dr["BlockNo"] ?? "").ToString();
							objitem.PostCode = (dr["PostCode"] ?? "").ToString();
							objitem.City = (dr["City"] ?? "").ToString();
							objitem.CityName = (dr["CityName"] ?? "").ToString();
							objitem.Country = (dr["Country"] ?? "").ToString();
							objitem.CountryName = (dr["CountryName"] ?? "").ToString();
							objitem.State = (dr["State"] ?? "").ToString();
							objitem.StateName = (dr["StateName"] ?? "").ToString();
							objitem.Address1 = (dr["Address1"] ?? "").ToString();
							objitem.Address2 = (dr["Address2"] ?? "").ToString();
							objitem.Address3 = (dr["Address3"] ?? "").ToString();

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
		public List<clsCustomerAddressMember> SearchCustomerAddress()
		{
			try
			{
				List<clsCustomerAddressMember> objList = new List<clsCustomerAddressMember>();
				ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
				SqlParameter[] objParam = new SqlParameter[]
				{
					  new SqlParameter("@CustomerKey",  CustomerKey  ),

				};
				IDataReader dr = objSql.ExecuteReader("CustomerAddressSearch", objParam);
				int Lc = 0;
				while (dr.Read())
				{
					clsCustomerAddressMember objGet = new clsCustomerAddressMember();

					objGet.AddressKey = dr["AddressKey"] is DBNull ? 0 : Convert.ToInt32(dr["AddressKey"].ToString());
					objGet.TenentID = dr["TenentID"] is DBNull ? 0 : Convert.ToInt32(dr["TenentID"].ToString());
					objGet.CustomerKey = dr["CustomerKey"] is DBNull ? 0 : Convert.ToInt32(dr["CustomerKey"].ToString());
					objGet.AddressName = (dr["AddressName"] ?? "").ToString();
					objGet.CustomerName = (dr["CustomerName"] ?? "").ToString();
					objGet.FlatNo = (dr["FlatNo"] ?? "").ToString();
					objGet.FloorNo = (dr["FloorNo"] ?? "").ToString();
					objGet.BlockNo = (dr["BlockNo"] ?? "").ToString();
					objGet.PostCode = (dr["PostCode"] ?? "").ToString();
					objGet.City = (dr["City"] ?? "").ToString();
					objGet.Country = (dr["Country"] ?? "").ToString();
					objGet.State = (dr["State"] ?? "").ToString();
					objGet.Address1 = (dr["Address1"] ?? "").ToString();
					objGet.Address2 = (dr["Address2"] ?? "").ToString();
					objGet.Address3 = (dr["Address3"] ?? "").ToString();
					if (dr["UpdatedDate"] != DBNull.Value)
						objGet.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
					objGet.UpdatedBy = dr["UpdatedBy"] is DBNull ? 0 : Convert.ToInt32(dr["UpdatedBy"].ToString());
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
