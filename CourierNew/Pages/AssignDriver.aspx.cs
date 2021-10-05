using BL.Settings;
using BL.Shipment;
using BL.Vendor;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class AssignDriver : ClsPageBase, INweEntryWeb
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
               ClsFillCombo.FillOtherCombo(ddlDriverName, enComboOther.DriverName);
               ClsFillCombo.FillCategory(ddlVehicleKey,enCategory.Vehicle);

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
                clsAirWayMain objSave = new clsAirWayMain();

                objSave.TranID = iAirWayKey;
                objSave.DriverKey = FNC.Conv(ddlDriverName.SelectedValue, enDataType.INT);
                objSave.VehicleKey = FNC.Conv(ddlDriverName.SelectedValue, enDataType.INT);
                ddlDriverName.Focus();
                /***********Codeing Start*********************/

                if (mode == enAction.DELETE.ToString())
                {
                    objSave.Action = enAction.DELETE;
                }
                else
                {
                    objSave.Action = PagePrimaryKey == 0 ? enAction.ADD : enAction.UPDATE;
                }

                int result = objSave.AirWayMainDriverUpdate();
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
            ClsVendor objSearch = new ClsVendor();

            try
            {
                /***********Codeing Start*********************/
         //       objSearch.ID = PagePrimaryKey;
         //       objSearch.CategoryName = "";
                objSearch.Action = enAction.SELECTONE;
               var lstCat = objSearch.GetVendor();

                foreach (var item in lstCat)
                {

                    ddlDriverName.Text = item.VendorName;    
                   
            //        ddlStatus.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlStatus, item.Status.ToString());
                    ddlDriverName.Focus();
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
                ddlDriverName.SelectedIndex = -1;
                ddlVehicleKey.SelectedIndex = -1;
       
                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

          
        }
        #endregion

      

        
    }
}