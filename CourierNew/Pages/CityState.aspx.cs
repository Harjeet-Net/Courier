using BL.EmployeeMaster;
using CommonEntity;
using System;
using System.Web.UI.WebControls;
namespace CourierNew.Pages
{
    public partial class CityState : ClsPageBase, INweEntryWeb
    {
        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitForm();
            }
            PageName = this.PageName;
            ltMsg.Text = "";
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
                ClsFillCombo.FillOtherCombo(ddlCOUNTRYID, enComboOther.CountryName);
                //ClsFillCombo.FillOtherCombo(ddlStateID, enComboOther.StateName);
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
        public bool SaveForm(string mode)
        {
            try
            {
                /***********Codeing Start*********************/
                clsCityStatesCounty objSave = new clsCityStatesCounty();
                {
                    objSave.CityID = PagePrimaryKey;
                    objSave.StateID = FNC.Conv(ddlStateID.Text.Trim(), enDataType.INT);
                    objSave.COUNTRYID = FNC.Conv(ddlCOUNTRYID.Text.Trim(), enDataType.INT);
                    objSave.CityEnglish = txtCityEnglish.Text.Trim();
                    objSave.CityArabic = txtCityArabic.Text.Trim();
                    objSave.CityOther = txtCityOther.Text.Trim();

                }


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
                    btnTop.PageKey = PagePrimaryKey;
                    btnTop.IsAddUpdateRecord = true;
                    btnTop.InitForm();
                    return true;
                }
            }

            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            return false;
        }
        public void LoadFormData()
        {
            clsCityStatesCounty objSearch = new clsCityStatesCounty();

            try
            {
                /***********Codeing Start*********************/
                objSearch.CityID = PagePrimaryKey;

                var lstCat = objSearch.GETCityStatesCountry();

                foreach (var item in lstCat)
                {
                    
                    ddlCOUNTRYID.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCOUNTRYID, item.COUNTRYID.ToString());
                    txtCityEnglish.Text = item.CityEnglish;
                    txtCityArabic.Text = item.CityArabic;
                    txtCityOther.Text = item.CityOther;
                    FillStateByCountry(item.COUNTRYID.ToString());
                    ddlStateID.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlStateID, item.StateID.ToString());

                };
                /***********Codeing End*********************/
                btnTop.PageKey = PagePrimaryKey;
                btnTop.IsAddUpdateRecord = false;
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
            //FIX CODE
            PagePrimaryKey = 0;
            /***********Codeing Start*********************/
            ddlStateID.SelectedIndex = -1;
            ddlCOUNTRYID.SelectedIndex = -1;
            txtCityEnglish.Text = String.Empty;
            txtCityArabic.Text = String.Empty;
            txtCityOther.Text = String.Empty;


            /***********Codeing End*********************/
        }
       

        private void FillStateByCountry(String sCountryKey)
        {
            try { ClsFillCombo.FillOtherCombo(ddlStateID, enComboOther.StateNameByCountry, sCountryKey); }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        protected void ddlCOUNTRYID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStateByCountry(ddlCOUNTRYID.SelectedValue);
        }
    }
}