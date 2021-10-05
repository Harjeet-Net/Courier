
using BL.REFTABLE;
using CommonEntity;
using System;
using System.Web.UI.WebControls;


namespace CourierNew.Pages
{
    public partial class RefTable : ClsPageBase, INweEntryWeb
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
                ClsRefTable objSave = new ClsRefTable();


                objSave.REFID = PagePrimaryKey;
                objSave.REFTYPE = ddlREFTYPE.SelectedValue;
                objSave.REFSUBTYPE = ddlREFSUBTYPE.SelectedValue;
                objSave.SHORTNAME = txtSHORTNAME.Text.Trim();
                objSave.REFNAME1 = txtREFNAME1.Text.Trim();
                objSave.REFNAME2 = txtREFNAME2.Text.Trim();
                objSave.REFNAME3 = txtREFNAME3.Text.Trim();
                objSave.SWITCH1 = txtSWITCH1.Text.Trim();
                objSave.SWITCH2 = txtSWITCH2.Text.Trim();
                objSave.SWITCH3 = txtSWITCH3.Text.Trim();
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
            ClsRefTable objSearch = new ClsRefTable();

            try
            {
                /***********Codeing Start*********************/
                objSearch.REFID = PagePrimaryKey;

                var lstCat = objSearch.GetREFTABLE();

                foreach (var item in lstCat)
                {
                    ddlREFTYPE.SelectedValue = item.REFTYPE;
                    ddlREFSUBTYPE.Text = item.REFSUBTYPE;
                    txtSHORTNAME.Text = item.SHORTNAME;
                    txtREFNAME1.Text = item.REFNAME1;
                    txtREFNAME2.Text = item.REFNAME2;
                    txtREFNAME3.Text = item.REFNAME3;
                    txtSWITCH1.Text = item.SWITCH1;
                    txtSWITCH2.Text = item.SWITCH2;
                    txtSWITCH3.Text = item.SWITCH3;

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

            try
            {//FIX CODE
                PagePrimaryKey = 0;
                /***********Codeing Start*********************/
                ddlREFTYPE.SelectedIndex = -1;
                ddlREFSUBTYPE.SelectedIndex = -1;
                txtSHORTNAME.Text = string.Empty;
                txtREFNAME1.Text = string.Empty;
                txtREFNAME2.Text = string.Empty;
                txtREFNAME3.Text = string.Empty;
                txtSWITCH1.Text = string.Empty;
                txtSWITCH2.Text = string.Empty;
                txtSWITCH3.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }

        }


    }
}