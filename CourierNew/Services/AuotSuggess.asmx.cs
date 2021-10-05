using BL;
using BL.Autosugess;
using BL.Shipment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CourierNew.Services
{
    /// <summary>
    /// Summary description for AuotSuggess
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AuotSuggess : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        public string[] GetAuto(string prefixText, int count, string contextKey)
        {
            System.Collections.Generic.List<string> items = new System.Collections.Generic.List<string>();
            try
            {
                DataTable dtAutoComp = new DataTable();
                clsAutoSgges objAuto = new clsAutoSgges();
                dtAutoComp = objAuto.GetAuto(prefixText, count, contextKey);

                if (dtAutoComp != null)
                {

                    List<string> list = new List<string>(dtAutoComp.Rows.Count);
                    foreach (DataRow dr in dtAutoComp.Rows)
                    {
                        list.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[1].ToString(), dr[0].ToString()));
                    }

                    return list.ToArray();
                }

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect(ex.Message.ToString(), true);
            }
            return items.ToArray();
        }
        [WebMethod(EnableSession = true)]
        public List<ClsCombo> FillOtherCombo(string ComboOther, string cri)
        {
            try
            {
                ClsCombo objFillCombo = new ClsCombo();
                var Lst = objFillCombo.ComboGet(ComboOther.ToString(), cri);
                return Lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod(EnableSession = true)]
        public clsCustomerMember CustomerDetailGet(int iId)
         {
            try
            {
                clsCustomer objDetail = new clsCustomer();
                objDetail.Id = iId;
                return objDetail.CustomerDetailGet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod(EnableSession = true)]
        public clsCustomerAddressMember AddressDetailGet(int iaddresskey, int tenentId)
      {
            try
            {
                clsCustomerAddress objDetail = new clsCustomerAddress();
                objDetail.AddressKey = iaddresskey;
                objDetail.TenentID = tenentId;
                return objDetail.CustomerAddressDetailGet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
