using BL.DriverMaster;
using BL.Shipment;
using CommonEntity;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class CustomerMaster : ClsPageBase, INweEntryWeb
    {
        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //dynamic ctrAdr = CtrAddress.FindControl("btnTop");
                //if (ctrAdr != null)
                //{
                //    ctrAdr.IsCustomJs = true;
                //    ctrAdr.SetControlJs();
                //}
                if (!IsPostBack)
                {
                    InitForm();
                }
                PageName = this.Page.Title;
                ltMsg.Text = "";

                //IsCustomJs="false" 

             
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
                            CtrAddress.ResetFormControls();
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
                ClsFillCombo.FillCategory(ddlNationality, enCategory.Nationality);
                ClsFillCombo.FillOtherCombo(ddlCountry, enComboOther.CountryName);
                
                /***********Codeing End*********************/

                PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);
                ClsFillCombo.FillOtherCombo(ddlDefaultAddress, enComboOther.CustomerAddress, PagePrimaryKey.ToString());
                btnTop.PageKey = PagePrimaryKey;
                if (PagePrimaryKey > 0)
                {
    
                    LoadFormData();
                    
                }
                else
                {
                   
                    ResetFormControls();
                    
                }
                CtrAddress.Visible = PagePrimaryKey == 0 ? true : false;;
                divAdd.Visible = CtrAddress.Visible;
                
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion

        public bool SaveForm(string mode)
        {
            try
            {
                /***********Codeing Start*********************/
                clsCustomer objSave = new clsCustomer();
                string Message = string.Empty;

                objSave.Id= PagePrimaryKey;
                objSave.CustomerName  = txtCustomerName  .Text.Trim();
                objSave.MobileNumber= txtMobileNumber.Text.Trim();
                objSave.AlternateNumber = txtAlternateNumber.Text.Trim();
                objSave.EmailId = txtEmailId.Text.Trim();
                objSave.ReferenceNumber = txtReferenceNumber.Text.Trim();
                objSave.PaciNumber = txtPaciNumber.Text.Trim();
                objSave.Nationality = ddlNationality.SelectedValue;
                objSave.Address = txtAddress.Text.Trim();
                objSave.Country = ddlCountry.SelectedValue;
                objSave.City = ddlCity.SelectedValue;
                objSave.State = ddlState.SelectedValue;
                objSave.ZipCode = txtZipCode.Text.Trim();
                objSave.Status = FNC.Conv(ddlStatus.SelectedValue,enDataType.BOOL);
                objSave.DefaultAddress = FNC.Conv(ddlDefaultAddress.SelectedValue, enDataType.INT);
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
                    if (CtrAddress.Visible)
                    {
                        CtrAddress.CustomerKey = result;
                        CtrAddress.SaveForm(enAction.ADD.ToString());
                    }
                    btnTop.PageKey = 0;
                    return true;
                }
            }

            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            return false;
        }
        public void LoadFormData()
        {
            clsCustomer objSearch = new clsCustomer();

            try
            {
                /***********Codeing Start*********************/
                objSearch.Id = PagePrimaryKey;
                btnAddAddress.Visible = true;
                var item = objSearch.GetCustomer();
                btnAddAddress.OnClientClick = String.Format("return Op1(14,0,{0})", PagePrimaryKey);

                if (PagePrimaryKey>0)
                {
                    txtCustomerName.Text = item.CustomerName;
                    txtMobileNumber.Text = item.MobileNumber;
                    txtAlternateNumber.Text = item.AlternateNumber;
                    txtEmailId.Text = item.EmailId;
                    txtReferenceNumber.Text = item.ReferenceNumber;
                    txtPaciNumber.Text = item.PaciNumber;
                    ddlNationality.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlNationality, item.Nationality);
                    txtAddress.Text = item.Address;
                    ddlCountry.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCountry, item.Country);
                    FillStateByCountry(ddlCountry.SelectedValue);
                    ddlState.SelectedValue =  item.State;
                    
                    FillCityByState(ddlState.SelectedValue);
                    ddlCity.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCity, item.City);
                    txtZipCode.Text = item.ZipCode;
                    ddlStatus.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlStatus, item.Status.ToString());
                    ddlDefaultAddress.CssClass = "ddlDefaultAddress form-control form-control-lg form-control-solid";
                    ddlDefaultAddress.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlDefaultAddress, item.DefaultAddress.ToString());
                };
                gv.DataSource = item.dtAddress;
                gv.DataBind();
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
                txtCustomerName.Text = String.Empty;
                txtMobileNumber.Text = String.Empty;
                txtAlternateNumber.Text = String.Empty;
                txtEmailId.Text = String.Empty;
                txtReferenceNumber.Text = String.Empty;
                txtPaciNumber.Text = String.Empty;
                ddlNationality.SelectedIndex = -1;
                txtAddress.Text = String.Empty;

                ddlCountry.SelectedIndex = -1;
                ddlCity.SelectedIndex = -1;
                ddlState.SelectedIndex = -1;
                txtZipCode.Text = String.Empty;
                ddlStatus.Text = String.Empty;
                
                ddlDefaultAddress.SelectedIndex = -1;
                dvAdressgrid.Visible = false;
                //gv.DataSource = null;
                //gv.DataBind();
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

        protected void gv_RowDataCommand(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   // int iAddressKey = FNC.Conv(gv.DataKeys[e.Row.RowIndex]["AddressKey"].ToString(), enDataType.INT);

                    //Button Edit = (Button)e.Row.FindControl("btnEdit");

                    //Edit.OnClientClick = String.Format("return Op(14,{0})", iAddressKey); ;


                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
            }
            
        }

       
    }


}