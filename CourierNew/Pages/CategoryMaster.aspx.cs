using BL.Settings;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class CategoryMaster : ClsPageBase, INweEntryWeb
    {
        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    InitForm();
                    if (Request.QueryString["parentkey"] != null)
                    {
                        ddlCategoryName.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCategoryName, Request.QueryString["parentkey"].ToString());
                    }
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
                ClsFillCombo.FillNameOfCategory(ddlCategoryName);
                
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
                ClsCategoryMaster objSave = new ClsCategoryMaster
                {
                    CategoryKey = PagePrimaryKey,
                    CategoryName = ddlCategoryName.SelectedValue.ToString(),
                    CatVal = txtCatVal.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Status = FNC.Conv(ddlStatus.SelectedValue, enDataType.BOOL),
                };

                ddlCategoryName.Focus();
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
            ClsCategoryMaster objSearch = new ClsCategoryMaster();

            try
            {
                /***********Codeing Start*********************/
                objSearch.CategoryKey = PagePrimaryKey;
                objSearch.CategoryName = "";
                objSearch.Action = enAction.SELECTONE;
                var lstCat = objSearch.GetCategoryMasterMemberList();

                foreach (var item in lstCat)
                {

                    ddlCategoryName.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlCategoryName, item.CategoryName);
                    txtCatVal.Text = item.CatVal;
                    txtDescription.Text = item.Description;
                    ddlStatus.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlStatus, item.Status.ToString());
                    ddlCategoryName.Focus();
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
                txtCatVal.Text = String.Empty;
                txtDescription.Text = String.Empty;
                ddlStatus.SelectedIndex = -1;
                ddlCategoryName.Focus();
                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

          
        }
        #endregion

      

        
    }
}