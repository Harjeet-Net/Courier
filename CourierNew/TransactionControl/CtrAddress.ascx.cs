using BL.DriverMaster;
using BL.Shipment;
using CommonEntity;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace CourierNew.TransactionControl
{
    public partial class CtrAddress : clsUserControlBase
    {
        public int iCustomerKey
        {
            get
            {
                return PagePrimaryKey == 0 ? FNC.Conv(Request.QueryString["parentkey"].ToString(), enDataType.INT) : 0;
            }
        }

        public int CustomerKey
        {
            get;set;
        }
        public EnPageType PageType
        {
            get; set;
        }


        //public int iLoadCustKey
        //{
        //    get
        //    {
        //        return FNC.Conv(Request.QueryString["parentkey"].ToString(), enDataType.INT);
        //    }

        //}
        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ClsFillCombo.FillOtherCombo(ddlCountry, enComboOther.CountryName);
                    if (PageType==EnPageType.Parent)
                    InitForm();
                }

                if (PageType == EnPageType.Parent)
                {
                    PageName = this.Page.Title;
                    ltMsg.Text = "";

                }
                else
                {
                    btnTop.Visible = false;
                }

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }
        public void Buttons_MasterEve(object sender, EventArgs e)
        {
            try
            {

                string ActionID;
                string ActionName;
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
                        LoadFormData(CustomerKey);
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

                
                //ClsFillCombo.FillOtherCombo(ddlState, enComboOther.StateName);
                //ClsFillCombo.FillOtherCombo(ddlCity, enComboOther.CityName);
                /***********Codeing End*********************/
                //if (iLoadCustKey > 0)
                //{
                //    clsCustomer objLoad = new clsCustomer();
                //    objLoad.Id = iLoadCustKey;
                //    var objData = objLoad.GetCustomer();
                //    txtCustomerKey.Text = objData.CustomerName;
                //    auCustomerKeyV.Text = objData.Id.ToString();
                //}
                PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);
                btnTop.PageKey = PagePrimaryKey;
                if (PagePrimaryKey > 0)
                {

                    LoadFormData(CustomerKey);
                }
                else
                {

                    ResetFormControls();
                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion

        public bool SaveForm(string mode)
        {
            try
            {
                /***********Codeing Start*********************/
                clsCustomerAddress objSave = new clsCustomerAddress();
                string Message = string.Empty;

                objSave.AddressKey = PagePrimaryKey;
                //if (iCustomerKey > 0)
                //{
                if (PageType == EnPageType.Child)
                {
                    objSave.CustomerKey = this.CustomerKey;
                }
                else {
                    objSave.CustomerKey = iCustomerKey;
                }
              
                //}
                ////else
                ////{
                //    objSave.CustomerKey = FNC.Conv(auCustomerKeyV.Text, enDataType.INT);
                ////}

                objSave.AddressName = txtAddressName.Text.Trim();
                objSave.FlatNo = txtFlatNo.Text.Trim();
                objSave.FloorNo = txtFloorNo.Text.Trim();
                objSave.BlockNo = txtBlockNo.Text.Trim();
                objSave.Country = ddlCountry.SelectedValue;
                objSave.City = ddlCity.SelectedValue;
                objSave.State = ddlState.SelectedValue;
                objSave.Address1 = txtAddress1.Text.Trim();
                objSave.Address2 = txtAddress2.Text.Trim();
                objSave.Address3 = txtAddress3.Text.Trim();
                objSave.PostCode = txtPostCode.Text.Trim();

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
        public void LoadFormData(int iAddressKey)
        {
            clsCustomerAddress objSearch = new clsCustomerAddress();

            try
            {
                PagePrimaryKey = iAddressKey;
                /***********Codeing Start*********************/
                objSearch.AddressKey = iAddressKey;

                var lstLoad = objSearch.GetCustomerAddress();

                foreach (var item in lstLoad)
                {
                    txtCustomerKey.Text = item.CustomerName;
                    auCustomerKeyV.Text = item.CustomerKey.ToString();
                    txtAddressName.Text = item.AddressName;
                    txtFlatNo.Text = item.FlatNo;
                    txtFloorNo.Text = item.FloorNo;
                    txtBlockNo.Text = item.BlockNo;
                    ddlCountry.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCountry, item.Country);
                    FillStateByCountry(ddlCountry.SelectedValue);
                    ddlState.SelectedValue = item.State;
                    FillCityByState(ddlState.SelectedValue);
                    ddlCity.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCity, item.City);
                    txtAddress1.Text = item.Address1;
                    txtAddress2.Text = item.Address2;
                    txtAddress3.Text = item.Address3;
                    txtPostCode.Text = item.PostCode;

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
                txtAddressName.Text = String.Empty;
                txtFlatNo.Text = String.Empty;
                txtFloorNo.Text = String.Empty;
                txtBlockNo.Text = String.Empty;
                ddlCountry.SelectedIndex = -1;
                ddlCity.SelectedIndex = -1;
                ddlState.SelectedIndex = -1;
                txtAddress1.Text = String.Empty;
                txtAddress2.Text = String.Empty;
                txtAddress3.Text = String.Empty;
                txtCustomerKey.Text = string.Empty;
                auCustomerKeyV.Text = "0";
                txtPostCode.Text = string.Empty;

                /***********Codeing End*********************/

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        private void FillStateByCountry(String sCountryKey)
        {
            try { ClsFillCombo.FillOtherCombo(ddlState, enComboOther.StateNameByCountry, sCountryKey); }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        protected void ddlSenderCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStateByCountry(ddlCountry.SelectedValue);
        }

        private void FillCityByState(String sStateKey)
        {
            try { ClsFillCombo.FillOtherCombo(ddlCity, enComboOther.CityNameByState, sStateKey); }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        protected void ddlSenderState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCityByState(ddlState.SelectedValue);
        }

    }


}