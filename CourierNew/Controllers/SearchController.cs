using BL.AuthenticationAndSession;
using BL.Cashier;
using BL.DriverMaster;
using BL.EmployeeMaster;
using BL.REFTABLE;
using BL.Settings;
using BL.Shipment;
using BL.TemplateMaster;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Controllers
{
    public class SearchController : ApiController
    {
        [Route("api/Search/Client_SearchUserMaster")]
        //SearchEmployee
        [HttpGet]
        [ActionName("Client_SearchUserMaster")]
        public List<ClsUserMasterMember> Client_SearchUserMaster()
        {
            ClsUserMaster objGet = new ClsUserMaster();
            try
            {
                //if (sfirstname == null) { sfirstname = ""; }
                //objGet.firstname = sfirstname;
                objGet.UserMasterKey = 0;
                var obj = objGet.SearchUserMaster();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchUserMaster"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchUserMaster"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchCategoryMaster
        [HttpGet]
        [ActionName("Client_SearchCategoryMaster")]
        public List<ClsCategoryMasterMember> Client_SearchCategoryMaster(string sCategoryName)
        {
            ClsCategoryMaster objGet = new ClsCategoryMaster();
            try
            {
                if (sCategoryName == null) { sCategoryName = ""; }
                objGet.CategoryName = sCategoryName;
                var obj = objGet.SearchCategoryMaster();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchCategoryMaster"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchCategoryMaster"
                };
                throw new HttpResponseException(resp);
            }

        }
        
        [Route("api/Search/Client_RoleGet")]
        //Userpermission
        [HttpGet]
        [ActionName("Client_RoleGet")]
        public List<ClsCategoryMasterMember> Client_RoleGet()
        {
            ClsCategoryMaster objGet = new ClsCategoryMaster();
            try
            {

                var obj = objGet.GetOnlyRole();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_RoleGet"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_RoleGet"
                };
                throw new HttpResponseException(resp);
            }

        }


        //SearchRefTable
        [HttpGet]
        [ActionName("Client_SearchREFTABLE")]
        public List<ClsRefTableMember> Client_SearchREFTABLE(string sREFTYPE, string sREFSUBTYPE)
        {
            ClsRefTable objGet = new ClsRefTable();
            try
            {
                if (sREFTYPE == null) { sREFTYPE = ""; }
                objGet.REFTYPE = sREFTYPE;
                if (sREFSUBTYPE == null) { sREFSUBTYPE = ""; }
                objGet.REFSUBTYPE = sREFSUBTYPE;

                var obj = objGet.SearchREFTABLE();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchREFTABLE"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchREFTABLE"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchTemplateMaster
        [HttpGet]
        [ActionName("Client_SearchTemplateMaster")]
        public List<ClsTemplateMasterMember> Client_SearchTemplateMaster(string sTemplateType)
        {
            ClsTemplateMaster objGet = new ClsTemplateMaster();
            try
            {
                if (sTemplateType == null) { sTemplateType = ""; }
                objGet.TemplateType = sTemplateType;
                var obj = objGet.SearchTemplateMaster();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchTemplateMaster"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchTemplateMaster"
                };
                throw new HttpResponseException(resp);
            }

        }


        //SearchEmployee
        [HttpGet]
        [ActionName("Client_SearchEmployee")]
        public List<clsEmployeeMember> Client_SearchEmployee(string sfirstname, int iMainHRRoleID)
        {
            clsEmployee objGet = new clsEmployee();
            try
            {
                if (sfirstname == null) { sfirstname = ""; }
                objGet.firstname = sfirstname;
                objGet.MainHRRoleID = iMainHRRoleID;
                var obj = objGet.SearchEmployee();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchEmployee"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchEmployee"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchCityStatesCounty
        [HttpGet]
        [ActionName("Client_SearchCityStatesCounty")]
        public List<clsCityStatesCountyMember> Client_SearchCityStatesCounty(int iCOUNTRYID, int iStateID)
        {
            clsCityStatesCounty objGet = new clsCityStatesCounty();
            try
            {
                objGet.StateID = iStateID;
                objGet.COUNTRYID = iCOUNTRYID;

                var obj = objGet.SearchCityStatesCounty();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchCityStatesCounty"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchCityStatesCounty"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchCashier
        [HttpGet]
        [ActionName("Client_SearchCashier")]
        public List<ClsCashierMember> Client_SearchCashier(string sExpenseType)
        {
            ClsCashier objGet = new ClsCashier();
            try
            {
                if (sExpenseType == null) { sExpenseType = ""; }
                objGet.ExpenseType = sExpenseType;
                var obj = objGet.SearchCashier();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchCashier"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchCashier"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchDriverMaster
        [HttpGet]
        [ActionName("Client_SearchDriver")]
        public List<ClsDriverMember> Client_SearchDriver(string sDriverName)
        {
            ClsDriver objGet = new ClsDriver();
            try
            {
                if (sDriverName == null) { sDriverName = ""; }
                objGet.DriverName = sDriverName;
                var obj = objGet.SearchDriver();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchDriver"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchDriver"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchCustomer
        [HttpGet]
        [ActionName("Client_SearchCustomer")]
        public List<clsCustomerMember> Client_SearchCustomer(int iID, string sMobileNumber,string sCountry)
        {
            clsCustomer objGet = new clsCustomer();
            try
            {
                
                objGet.Id = iID;
                if (sMobileNumber == null) { sMobileNumber = ""; }
                    objGet.MobileNumber = sMobileNumber;
                if(sCountry == null) { sCountry = ""; }
                objGet.Country = sCountry;

                var obj = objGet.SearchCustomer();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchCustomer"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchCustomer"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchCustomerAddress
        [HttpGet]
        [ActionName("Client_SearchCustomerAddress")]
        public List<clsCustomerAddressMember> Client_SearchCustomerAddress(int iCustomerKey)
        {
            clsCustomerAddress objGet = new clsCustomerAddress();
            try
            {

                objGet.CustomerKey = iCustomerKey;
               

                var obj = objGet.SearchCustomerAddress();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchCustomerAddress"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchCustomerAddress"
                };
                throw new HttpResponseException(resp);
            }

        }

        [Route("api/Search/Client_SearchAirWayMain2Packing")]
        //SearchPackageEntry
        [HttpGet]
        [ActionName("Client_SearchAirWayMain2Packing")]
        public List<ClsAirWayMain2PackingMember> Client_SearchAirWayMain2Packing(int iAirwayBillKey)
        {
            ClsAirWayMain2Packing objGet = new ClsAirWayMain2Packing();
            try
            {

                objGet.AirwayBillKey = iAirwayBillKey;
                var obj = objGet.SearchAirWayMain2Packing();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchAirWayMain2Packing"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchAirWayMain2Packing"
                };
                throw new HttpResponseException(resp);
            }

        }

        [Route("api/Search/GetAirWayBillImportList")]
        //GetAirWayBillImportList
        [HttpGet]
        [ActionName("GetAirWayBillImportList")]
        public List<ClsAirWayBillImportExcel> GetAirWayBillImportList()
        {
            ClsAirWayBillImportExcelMaster objEntity = new ClsAirWayBillImportExcelMaster();
            try
            {
                var obj = objEntity.GetAirWayBillImportList();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in GetAirWayBillImportList"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in GetAirWayBillImportList"
                };
                throw new HttpResponseException(resp);
            }

        }


        [Route("api/Search/Client_SearchInvoiceDetail")]
        //SearchInvoiceDetails
        [HttpGet]
        [ActionName("Client_SearchInvoiceDetail")]
        public List<ClsInvoiceDetailMember> Client_SearchInvoiceDetail(int iAirwayBillKey)
        {
            ClsInvoiceDetail objGet = new ClsInvoiceDetail();
            try
            {

                objGet.AirwayBillKey = iAirwayBillKey;


                var obj = objGet.SearchInvoiceDetail();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchInvoiceDetail"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchInvoiceDetail"
                };
                throw new HttpResponseException(resp);
            }

        }

        //SearchInvoiceDetails
        [HttpGet]
        [ActionName("Client_SearchAirWayMain")]
        public List<clsAirWayMainMember> Client_SearchAirWayMain(String sTranType)
        {
            clsAirWayMain objGet = new clsAirWayMain();
            try
            {

                objGet.TranType = sTranType;


                var obj = objGet.SearchAirWayMain();

                if (obj == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Unable to fetch content."),
                        ReasonPhrase = "Server Error in Client_SearchAirWayMain"
                    };
                    throw new HttpResponseException(resp);
                }
                return obj;
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Server Error in Client_SearchAirWayMain"
                };
                throw new HttpResponseException(resp);
            }

        }

    }
}