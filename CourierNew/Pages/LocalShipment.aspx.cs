using BL.Shipment;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class LocalShipment : ClsPageBase
    {

        public void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);
                    ClsFillCombo.FillCategory(ddlDepartmentKey, enCategory.Department);
                    ClsFillCombo.FillCategory(ddlReciverDepartmentKey, enCategory.Department);
                

                    if (PagePrimaryKey > 0)
                    {
                        txtAirWayKey.Text = PagePrimaryKey.ToString();
                        LoadFormData();
                    }
                    else
                    {
                        ResetFormControls();
                    }
                }
                PageName = this.Title;
                ltMsg.Text = "";


            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }

        public void LoadFormData()
        {
            clsAirWayMain objSearch = new clsAirWayMain();

            try
            {
                /***********Codeing Start*********************/
                objSearch.TranID = PagePrimaryKey;


                var lstCat = objSearch.GetAirWayMainMemberList();

                foreach (var item in lstCat)
                {

                    txtCustomerKey.Text = item.SenderName;
                    auCustomerKeyV.Text = item.CustomerKey.ToString();
                    txtCompanyName.Text = item.CompanyName;
                    ddlDepartmentKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlDepartmentKey, item.DepartmentKey.ToString());
                    ddlAddressKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlAddressKey, item.AddressKey.ToString());
                    txtemail.Text = item.Senderemail;
                    txtreferencenumber.Text = item.Senderreferencenumber;
                    txtsenderPACI.Text = item.SenderPACI;
                    ddlSenderCountry.Text = item.SenderCountry;
                    ddlSenderState.Text = item.SenderState;
                    ddlSenderCity.Text = item.SenderCity;
                    txtpostcode.Text = item.Senderpostcode;
                    txtsenderMobile.Text = item.senderMobile;
                    txtsenderAltCont.Text = item.senderAltCont;
                    btnAddAddress.OnClientClick = String.Format(@"return Op1(14,0,{0});", item.CustomerKey);
                    btnEditAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditAddress";
                    auReciverKeyV.Text = item.ReciverKey.ToString();
                    txtReciverKey.Text = item.ReceiverName;
                    txtReciverKeyCompanyName.Text = item.ReciverKeyCompanyName;
                    ddlReciverDepartmentKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlReciverDepartmentKey, item.ReciverDepartmentKey.ToString());
                    ddlReciverAddressKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlReciverAddressKey, item.ReciverAddressKey.ToString());

                    txtRemail.Text = item.Reciveremail;
                    txtRreferencenumber.Text = item.ReciverRreferencenumber;
                    txtRpaci.Text = item.ReciverRpaci;
                    ddlReceiverCountry.Text = item.ReceiverCountry;
                    ddlReceiverState.Text = item.ReceiverState;
                    ddlReceiverCity.Text = item.ReceiverCity;
                    txtRpostcode.Text = item.ReciverRpostcode;
                    txtRmobileno.Text = item.ReciverRmobileno;
                    txtRotherno.Text = item.ReciverRotherno;

                }  
                /***********Codeing End*********************/
                //btnTop.PageKey = PagePrimaryKey;
                //btnTop.IsAddUpdateRecord = true;
                //btnTop.VisibleDelRecord = true;
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                //btnTop.IsAddUpdateRecord = true;
                //btnTop.PageKey = PagePrimaryKey;
                //btnTop.InitForm();
            }

        }
        public void ResetFormControls()
        {
            try
            {
                //FIX CODE
                PagePrimaryKey = 0;
                /***********Codeing Start*********************/

             
                txtCustomerKey.Text = String.Empty;
                auCustomerKeyV.Text = String.Empty;
                txtCompanyName.Text = String.Empty;
                ddlDepartmentKey.SelectedIndex = -1;
                ddlAddressKey.SelectedIndex = -1;
                txtemail.Text = String.Empty;
                txtreferencenumber.Text = String.Empty;
                txtsenderPACI.Text = String.Empty;
                ddlSenderCountry.Text = String.Empty;
                ddlSenderState.Text = String.Empty;
                ddlSenderCity.Text = String.Empty;
                txtpostcode.Text = String.Empty;
                txtsenderMobile.Text = String.Empty;
                txtsenderAltCont.Text = String.Empty;

                auReciverKeyV.Text = String.Empty;
                txtReciverKey.Text = String.Empty;
                txtReciverKeyCompanyName.Text = String.Empty;
                ddlReciverDepartmentKey.SelectedIndex = -1;
                ddlReciverAddressKey.SelectedIndex = -1;
                txtRemail.Text = String.Empty;
                txtRreferencenumber.Text = String.Empty;
                txtRpaci.Text = String.Empty;
                ddlReceiverCountry.Text = String.Empty;
                ddlReceiverState.Text = String.Empty;
                ddlReceiverCity.Text = String.Empty;
                txtRpostcode.Text = String.Empty;
                txtRmobileno.Text = String.Empty;
                txtRotherno.Text = String.Empty;
                btnAddAddress.OnClientClick = "";
                btnEditAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditAddress";
             

                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
 
    }

}


