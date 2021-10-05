using BL.Settings;
using BL.Shipment;
using BL.TemplateMaster;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class PrepareShipment : ClsPageBase
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
                    ClsFillCombo.FillCategory(ddlPackingTypeKey, enCategory.PackingType);

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
                    ddlTranType.SelectedValue = item.TranType;

                    txtCustomerKey.Text = item.SenderName;
                    auCustomerKeyV.Text = item.CustomerKey.ToString();
                    ClsFillCombo.FillOtherCombo(ddlAddressKey, enComboOther.CustomerAddress, auCustomerKeyV.Text);
                    ddlAddressKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlAddressKey, item.AddressKey.ToString());
                    if (ddlAddressKey.SelectedIndex > 0)
                    {
                        btnAddSenderAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2  btnAddSenderAddress";
                        btnEditSenderAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2  btnEditSenderAddress";
                    }
                    btnAddSenderAddress.OnClientClick = String.Format(@"return Op1(14,0,{0});", item.CustomerKey);
                    btnEditSenderAddress.OnClientClick = String.Format(@"return Op(14,{0});", item.AddressKey);
                    txtCompanyName.Text = item.CompanyName;
                    ddlDepartmentKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlDepartmentKey, item.DepartmentKey.ToString());                 
                    txtemail.Text = item.Senderemail;
                    txtreferencenumber.Text = item.Senderreferencenumber;
                    txtsenderPACI.Text = item.SenderPACI;
                    ddlSenderCountry.Text = item.SenderCountry;
                    ddlSenderState.Text = item.SenderState;
                    ddlSenderCity.Text = item.SenderCity;
                    txtpostcode.Text = item.Senderpostcode;
                    txtsenderMobile.Text = item.senderMobile;
                    txtsenderAltCont.Text = item.senderAltCont;
                    
                    auReciverKeyV.Text = item.ReciverKey.ToString();
                    txtReciverKey.Text = item.ReceiverName;
                    ClsFillCombo.FillOtherCombo(ddlReciverAddressKey, enComboOther.CustomerAddress, auReciverKeyV.Text);
                    ddlReciverAddressKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlReciverAddressKey, item.ReciverAddressKey.ToString());
                    if (ddlReciverAddressKey.SelectedIndex > 0)
                    {
                        btnAddReceiverAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2  btnAddReceiverAddress";
                        btnEditSenderAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2  btnEditSenderAddress";
                    }
                    btnAddReceiverAddress.OnClientClick = String.Format(@"return Op1(14,0,{0});", item.ReciverKey);
                    btnEditReceiverAddress.OnClientClick = String.Format(@"return Op(14,{0});", item.ReciverAddressKey);
                    txtReciverKeyCompanyName.Text = item.ReciverKeyCompanyName;
                    ddlReciverDepartmentKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlReciverDepartmentKey, item.ReciverDepartmentKey.ToString());
                    txtRemail.Text = item.Reciveremail;
                    txtRreferencenumber.Text = item.ReciverRreferencenumber;
                    txtRpaci.Text = item.ReciverRpaci;
                    ddlReceiverCountry.Text = item.ReceiverCountry;
                    ddlReceiverState.Text = item.ReceiverState;
                    ddlReceiverCity.Text = item.ReceiverCity;
                    txtRpostcode.Text = item.ReciverRpostcode;
                    txtRmobileno.Text = item.ReciverRmobileno;
                    txtRotherno.Text = item.ReciverRotherno;

                    ddlPackingTypeKey.SelectedIndex =ClsCommonUI.SetDropdowValue(ddlPackingTypeKey, item.PackingTypeKey.ToString());

                    if (item.InvoiceType == "UploadedInvoice")
                    {
                        chkCreateInvoice.Checked = false;
                        chkUploadedInvoice.Checked = true;
                    }
                    else
                    {
                        chkCreateInvoice.Checked = true;
                        chkUploadedInvoice.Checked = false;
                    }

                    txtAttachPath1.Text=item.Attachment1;
                    txtAttachPath2.Text = item.Attachment2;
                    txtShipmentDescription.Text = item.ShipmentDescription;
                    ddlShipmentPurpose.SelectedValue = item.ShipmentPurpose;
                    txtShipmentRefrence.Text = item.ShipmentRefrence;
                    ddlExportType.SelectedValue = item.ExportType;
                    ddlCustomerOfTrade.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCustomerOfTrade, item.CustomerOfTrade.ToString());
                    ddlReasonForExport.SelectedValue = item.ReasonForExport;
                    txtPaymentTerms.Text = item.PaymentTerms;
                    txtPlaceOfDestination.Text = item.PlaceOfDestination;
                    ddlPickupType.SelectedValue = item.PickupType;
                    ddlPickupWindow.SelectedValue = item.PickupWindow;
                    ddlDeliverytype.SelectedValue = item.Deliverytype;
                    ddlDeliveryWindow.SelectedValue = item.DeliveryWindow;

                    //PaymentType
                    //FreightCharges
                    //Chargable Weight
                    //    txtConsignmentValue
                    //    Insurance Amount
                    //    Other Charges
                    //    Delivery Charges
                    
                };
                /***********Codeing End*********************/
               
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
               
            }

        }
        public void ResetFormControls()
        {
            try
            {
                //FIX CODE
                PagePrimaryKey = 0;
                /***********Codeing Start*********************/

                ddlTranType.SelectedIndex = -1;
                txtCustomerKey.Text = String.Empty;
                auCustomerKeyV.Text = String.Empty;
                txtCompanyName.Text = String.Empty;
                ddlDepartmentKey.SelectedIndex = -1;
                //ddlAddressKey.SelectedIndex = -1;
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
                //ddlReciverAddressKey.SelectedIndex = -1;
                txtRemail.Text = String.Empty;
                txtRreferencenumber.Text = String.Empty;
                txtRpaci.Text = String.Empty;
                ddlReceiverCountry.Text = String.Empty;
                ddlReceiverState.Text = String.Empty;
                ddlReceiverCity.Text = String.Empty;
                txtRpostcode.Text = String.Empty;
                txtRmobileno.Text = String.Empty;
                txtRotherno.Text = String.Empty;
                btnAddSenderAddress.OnClientClick = "";
                //btnEditSenderAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditSenderAddress";
                chkCreateInvoice.Checked = false;
                chkUploadedInvoice.Checked = false;
                btnAddSenderAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnAddSenderAddress";
                btnEditSenderAddress.CssClass = "btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2 hidden btnEditSenderAddress";
                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }

    }

}


