using BL.Settings;
using BL.Shipment;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{

    public partial class PackageEntry : ClsPageBase, INweEntryWeb
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
                ClsFillCombo.FillCategory(ddlPackingKey, enCategory.Packaging);
                ClsFillCombo.FillCategory(ddlUOM, enCategory.UOM);
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
                ClsAirWayMain2Packing objSave = new ClsAirWayMain2Packing();
         
                objSave.A2PKey = PagePrimaryKey;
                objSave.AirwayBillKey = iAirWayKey;
                objSave.PackingKey = FNC.Conv(ddlPackingKey.SelectedValue, enDataType.INT);
                objSave.Qty = FNC.Conv(txtQty.Text.Trim(), enDataType.INT);
                objSave.Weight = FNC.Conv(txtWeight.Text.Trim(), enDataType.DECIMAL);
                objSave.DL = FNC.Conv(txtDL.Text.Trim(), enDataType.DECIMAL);
                objSave.DW = FNC.Conv(txtDW.Text.Trim(), enDataType.DECIMAL);
                objSave.DH = FNC.Conv(txtDH.Text.Trim(), enDataType.DECIMAL);
                objSave.UOM = ddlUOM.SelectedValue;


                ddlPackingKey.Focus();
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
            ClsAirWayMain2Packing objLoad = new ClsAirWayMain2Packing();
            objLoad.A2PKey = PagePrimaryKey;
            try
            {
                /***********Codeing Start*********************/
 
                var LstLoad = objLoad.GetAirWayMain2Packing();

                foreach (var item in LstLoad)
                {


                    //    AirwayBillKey = AirwayBillKey;
                    ddlPackingKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlPackingKey, item.PackingKey.ToString());
                    txtQty.Text = item.Qty.ToString();
                    txtWeight.Text = item.Weight.ToString();
                    txtDL.Text = item.DL.ToString();
                    txtDW.Text = item.DW.ToString();
                    txtDH.Text = item.DH.ToString();
                    ddlUOM.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlUOM, item.UOM.ToString());
                    ddlPackingKey.Focus();
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
                ddlPackingKey.SelectedIndex = -1;
                txtQty.Text = String.Empty;
                txtWeight.Text = String.Empty;
                txtDL.Text = String.Empty;
                txtDW.Text = String.Empty;
                txtDH.Text = String.Empty;
                ddlUOM.SelectedIndex = -1;


                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion


    }
}