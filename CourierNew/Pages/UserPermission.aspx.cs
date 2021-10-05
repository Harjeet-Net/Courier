using BL;
using BL.Settings;
using CommonEntity;
using System;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class UserPermission : ClsPageBase, INweEntryWeb
    {
        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                InitForm();
                RemoveUserRoleCache();
                ResetFormControls();

            }
            btnTop.VisibleDelRecord = false;
            btnTop.VisibleAddnew = false;
            btnTop.IsAddUpdateRecord = true;
            btnTop.PageKey = 500;
            btnTop.InitForm();
        }
        public void InitForm()
        {
            ClsFillCombo.FillOtherCombo(ddlModule, enComboOther.SystemModules);
            ddlModule.SelectedIndex = -1;
            btnCatcheClear.Visible = false;
            PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);

        }
        public void Buttons_MasterEve(object sender, EventArgs e)
        {
            String ActionID = String.Empty;
            String ActionName = String.Empty;
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
                        Response.Redirect("~/Search/SearchCategory.aspx?CatName=" + ViewState["PageTitle"].ToString());
                    }
                    break;
                case "lnkSave":
                case "lnkDelRecord":
                case "btnDelete":

                    if (SaveForm(ActionName.Contains("Delete") ? "DELETE" : "SAVE") == true)
                    {
                        ResetFormControls();
                    }
                    break;
                case "lnkAddNew":

                    btnTop.IsAddUpdateRecord = true;
                    ResetFormControls();
                    break;
                case "lnkSearch":
                    Response.Redirect("~/Search/SearchCategory.aspx?CatName=UserRole");
                    break;
                case "lnkReset":

                    PagePrimaryKey = 0;
                    ResetFormControls();

                    break;
                case "btnLoadData":
                    SetControlJs();
                    LoadFormData();
                    break;
            }
        }
        public void ResetFormControls()
        {
            if (PagePrimaryKey.Equals(0))
            {
                lblModule.Visible = false;
                ddlModule.Visible = false;
                gv.Visible = false;
            }
            ddlModule.SelectedIndex = -1;
            gv.DataSource = null;
            gv.DataBind();
        }
        public void LoadFormData()
        {
            ClsRoles objLoad = new ClsRoles();
            try
            {


                var lstRoles = objLoad.GetRolesList(PagePrimaryKey, true);
                if (lstRoles != null)
                {

                    var rolefilterlist = lstRoles.FindAll(x => x.RoleId.Equals(PagePrimaryKey) && x.ModuleID.Equals(FNC.Conv(ddlModule.SelectedValue, enDataType.INT))).ToList();


                    if (rolefilterlist.Count > 0)
                    {

                        txtRoleName.Text = rolefilterlist.FirstOrDefault().RoleName;
                        lblRolePermissionFor.Text = String.Format("User Role Permission For {0}", txtRoleName.Text);
                    }
                    gv.DataSource = rolefilterlist;
                    gv.DataBind();
                    ddlModule.Visible = true;
                    lblModule.Visible = true;
                    lblModule.Text = lstRoles.FirstOrDefault().RoleName;
                    gv.Visible = true;

                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
                btnTop.PageKey = PagePrimaryKey;
                btnTop.InitForm();
            }
        }
        public bool SaveForm(string mode)
        {
            try
            {
                Cache.Remove(ClsCacheKeys.CacheRoleKey);
                RemoveUserRoleCache();
                ClsRoles objSave = new ClsRoles();
                string Message = string.Empty;
                objSave.RoleId = PagePrimaryKey;
                objSave.ModuleID = FNC.Conv(ddlModule.SelectedValue, enDataType.INT);
                String RoleXML = GenerateRolePermissionXML();
                if (objSave.AddUpdateDelete(RoleXML) > 0)
                {
                    RemoveUserRoleCache();
                    MessageJquery("User permission for " + txtRoleName.Text + " save ", enMessageBoxType.Success);

                    txtRoleName.Text = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
                btnTop.PageKey = PagePrimaryKey;
                btnTop.InitForm();
            }
            //AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "setTimeoutServer", "setTimeoutServer();", true);

            return false;
        }
        public string GenerateRolePermissionXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<RoleDS>");
            foreach (GridViewRow r in gv.Rows)
            {
                var PermissionKey = gv.DataKeys[r.RowIndex].Values["PermissionKey"].ToString();
                var MenuID = gv.DataKeys[r.RowIndex].Values["MenuID"].ToString();
                var Add = ((CheckBox)r.FindControl("chkAdd")).Checked;
                var Edit = ((CheckBox)r.FindControl("chkEdit")).Checked;
                var Delete = ((CheckBox)r.FindControl("chkDelete")).Checked;
                var View = ((CheckBox)r.FindControl("chkView")).Checked;
                var ViewLog = ((CheckBox)r.FindControl("chkViewLog")).Checked;
                var Print = ((CheckBox)r.FindControl("chkPrint")).Checked;
                sb.AppendFormat(@"<Role PermissionKey=""{0}""  Add=""{1}""   Edit=""{2}""  Delete=""{3}""  View=""{4}""  ViewLog=""{5}""  Print=""{6}"" MenuID=""{7}""  />",
                                       PermissionKey, Add, Edit, Delete, View, ViewLog, Print, MenuID
                    );
            }

            sb.Append("</RoleDS>");
            return sb.ToString();
        }
        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (PagePrimaryKey.Equals(0))
                {
                    ResetFormControls();
                    return;
                }

                LoadFormData();

            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
                btnTop.PageKey = PagePrimaryKey;
                btnTop.InitForm();
            }
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void btnDelete_Click(object sender, EventArgs e)
        {

        }
        public void SetControlJs()
        {

        }
        private static void RemoveUserRoleCache()
        {
            System.Web.HttpContext.Current.Cache.Remove(ClsCacheKeys.CacheRoleKey);
            System.Web.HttpContext.Current.Cache.Remove(ClsCacheKeys.CacheCategoryKey);
            System.Web.HttpContext.Current.Cache.Remove(ClsCacheKeys.CacheRoleTabKey);

        }
        protected void btnCatcheClear_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveUserRoleCache();
                LoadFormData();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "RemoveCache", "CacheAlertMessage();", true);

            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                btnTop.IsAddUpdateRecord = true;
                btnTop.PageKey = PagePrimaryKey;
                btnTop.InitForm();
            }
        }
    }
}