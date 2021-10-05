using BL.Shipment;
using CommonEntity;
using System;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{

    public partial class InvoiceDetail : ClsPageBase, INweEntryWeb
    {
        public int iAirWayKey
        {
            get { return FNC.Conv(Request.QueryString["parentkey"], enDataType.INT); }

        }


        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    InitForm();
                    txtAirWayKey.Text = iAirWayKey.ToString();
                }
                PageName = this.Title;
                ltMsg.Text = "";


            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        public void Buttons_MasterEve(object sender, EventArgs e)
        {
            try
            {

                string ActionName;
                string ActionID;
                if (sender is LinkButton)
                {
                    ActionID = ((LinkButton)sender).ID;
                    ActionName = ((LinkButton)sender).Text;
                }
                else
                {
                    ActionID = ((Button)sender).ID;
                    ActionName = ((Button)sender).Text;
                }
                switch (ActionID)
                {
                    case "btnSaveAndClose":
                        if (SaveForm("Save") == true)
                        {

                        }
                        break;
                    case "lnkSave":
                    case "lnkDelRecord":
                    case "btnDelete":

                        if (SaveForm(ActionName.Contains("Delete") ? "DELETE" : "SAVE") == true)
                        {
                            MessageJquery(PageName + " save ", enMessageBoxType.Success);
                            ResetFormControls();
                        }
                        break;
                    case "lnkAddNew":
                        btnTop.PageKey = 0;
                        ResetFormControls();
                        break;
                    case "lnkSearch":
                        break;
                    case "lnkReset":
                        ResetFormControls();
                        break;
                    case "btnLoadData":
                        LoadFormData();
                        break;
                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        public void InitForm()
        {
            try
            {
                /***********Codeing Start*********************/
                ClsFillCombo.FillCategory(ddlNetWeightUnit, enCategory.UOM);
                ClsFillCombo.FillCategory(ddlGrossWeightUnit, enCategory.UOM);
                ClsFillCombo.FillCategory(ddlQunatityUnit, enCategory.UOM);
                ClsFillCombo.FillOtherCombo(ddlManufactureFrom, enComboOther.CountryName);
                /***********Codeing End*********************/

                PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);
                btnTop.PageKey = PagePrimaryKey;
                if (PagePrimaryKey > 0)
                {
                    LoadFormData();
                }
                else
                {

                    ResetFormControls();
                }

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion

        #region CRUD
        public bool SaveForm(string mode)
        {
            try
            {
                /***********Codeing Start*********************/
                ClsInvoiceDetail objSave = new ClsInvoiceDetail();

                objSave.InvoiceDetailKey = PagePrimaryKey;
                objSave.AirwayBillKey = iAirWayKey;
                objSave.ItemDescription = txtItemDescription.Text.Trim();
                objSave.ManufactureFrom = FNC.Conv(ddlManufactureFrom.SelectedValue, enDataType.INT);
                objSave.CommodityCode = txtCommodityCode.Text.Trim();
                objSave.Quantity = FNC.Conv(txtQuantity.Text.Trim(), enDataType.INT);
                objSave.QunatityUnit = ddlQunatityUnit.SelectedValue;
                objSave.ItemValue = FNC.Conv(txtItemValue.Text.Trim(), enDataType.INT);
                objSave.Currencey = ddlCurrencey.SelectedValue;
                objSave.NetWeight = FNC.Conv(txtNetWeight.Text.Trim(), enDataType.INT);
                objSave.NetWeightUnit = ddlNetWeightUnit.SelectedValue;
                objSave.GrossWeight = FNC.Conv(txtGrossWeight.Text.Trim(), enDataType.INT);
                objSave.GrossWeightUnit = ddlGrossWeightUnit.SelectedValue;
                //objSave.InvoiceKey = iAirWayKey;
                /***********Codeing Start*********************/

                if (mode == enAction.DELETE.ToString())
                {
                    objSave.Action = enAction.DELETE;
                }
                else
                {
                    objSave.Action = PagePrimaryKey == 0 ? enAction.ADD : enAction.UPDATE;
                }

                int result = objSave.AddUpdateDelete();
                if (result > 0)
                {

                    btnTop.PageKey = 0;
                    return true;
                }
            }

            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            return false;
        }
        public void LoadFormData()
        {
            ClsInvoiceDetail objLoad = new ClsInvoiceDetail();
            objLoad.InvoiceDetailKey = PagePrimaryKey;
            try
            {
                /***********Codeing Start*********************/

                var LstLoad = objLoad.GetInvoiceDetail();

                foreach (var item in LstLoad)
                {

                     
                    txtItemDescription.Text = item.ItemDescription;
                    ddlManufactureFrom.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlManufactureFrom, item.ManufactureFrom.ToString());
                    txtCommodityCode.Text = item.CommodityCode;
                    txtQuantity.Text = item.Quantity.ToString();
                    ddlQunatityUnit.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlQunatityUnit, item.QunatityUnit.ToString());
                    txtItemValue.Text = item.ItemValue.ToString();
                    ddlCurrencey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCurrencey, item.Currencey.ToString());
                    txtNetWeight.Text = item.NetWeight.ToString();
                    ddlNetWeightUnit.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlNetWeightUnit, item.NetWeightUnit.ToString());
                    txtGrossWeight.Text = item.GrossWeight.ToString();
                    ddlGrossWeightUnit.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlGrossWeightUnit, item.GrossWeightUnit.ToString());


                };
                /***********Codeing End*********************/
                btnTop.PageKey = PagePrimaryKey;
                btnTop.IsAddUpdateRecord = true;
                btnTop.VisibleDelRecord = true;
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
                btnTop.PageKey = PagePrimaryKey;
                btnTop.InitForm();
            }

        }
        public void ResetFormControls()
        {
            try
            {
                //FIX CODE
                PagePrimaryKey = 0;
                /***********Codeing Start*********************/
                txtItemDescription.Text = String.Empty;
                ddlManufactureFrom.SelectedIndex = -1;
                txtCommodityCode.Text = String.Empty;
                txtQuantity.Text = string.Empty;
                ddlQunatityUnit.SelectedIndex = -1;
                txtItemValue.Text = String.Empty;
                ddlCurrencey.SelectedIndex = -1;
                txtNetWeight.Text = String.Empty;
                ddlNetWeightUnit.SelectedIndex = -1;
                txtGrossWeight.Text = String.Empty;
                ddlGrossWeightUnit.SelectedIndex = -1;


                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion


    }
}