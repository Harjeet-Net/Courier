using BL.Settings;
using BL.TemplateMaster;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class TemplateMaster : ClsPageBase, INweEntryWeb
    {
        #region "Fix Code"
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    InitForm();
                   
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
                ClsFillCombo.FillNameOfCategory(ddlCategoryKey);

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
                ClsTemplateMaster objSave = new ClsTemplateMaster();

                objSave.TemplateKey      = PagePrimaryKey;
                objSave.TemplateName     = txtTemplateName.Text.Trim();
                objSave.Descriptions     = txtDescriptions.Text.Trim();
                objSave.TemplateType     = ddlTemplateType.SelectedValue;
                objSave.CategoryKey      = FNC.Conv(ddlCategoryKey.SelectedValue, enDataType.INT);
                objSave.Status           = FNC.Conv(ddlStatus.SelectedValue, enDataType.BOOL);

                //objSave.TemplateKey = PagePrimaryKey,      
                //objSave.TemplateName = txtTemplateName.Text.Trim();
                //objSave.TemplateType = ddlTemplateType.SelectedValue.ToString();
                //objSave.Descriptions = txtDescriptions.Text.Trim();
                //objSave.Status = FNC.Conv(ddlStatus.SelectedValue, enDataType.BOOL);


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
            ClsTemplateMaster objSearch = new ClsTemplateMaster();

            try
            {
                /***********Codeing Start*********************/
                objSearch.TemplateKey = PagePrimaryKey;
                

                var lstCat = objSearch.GetTemplateMaster();

                foreach (var item in lstCat)
                {
                    txtTemplateName.Text = item.TemplateName;
                    txtDescriptions.Text = item.Descriptions;
                    ddlTemplateType.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlTemplateType, item.TemplateType);
                    ddlCategoryKey.SelectedIndex  = ClsCommonUI.SetDropdowValue(ddlCategoryKey, item.CategoryKey.ToString());
                    ddlStatus.SelectedIndex       = ClsCommonUI.SetDropdowValue(ddlStatus, item.Status.ToString());
                    txtTemplateName.Focus();

                    
                    
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
                txtTemplateName.Text                = String.Empty;
                txtDescriptions.Text                = String.Empty;
                ddlTemplateType.SelectedIndex       = -1;
                ddlCategoryKey.SelectedIndex        = -1;
                ddlStatus.SelectedIndex             = -1;
                txtTemplateName.Focus();



                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion




    }
}