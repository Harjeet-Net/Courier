using BL.AuthenticationAndSession;
using CommonEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class UserEntry : ClsPageBase, INweEntryWeb
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
                PageName = this.Page.Title;
                ltMsg.Text = "";

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
                ClsFillCombo.FillCategory(ddlUserRoleKey, enCategory.UserRole);
                ClsFillCombo.FillCategory(ddlPosition, enCategory.Position);
                
                //ClsFillCombo.FillOtherCombo(ddlVehicleKey, enComboOther.VehicleKeyName);
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
                ClsUserMaster objSave = new ClsUserMaster();
                string Message = string.Empty;

                objSave.UserMasterKey = PagePrimaryKey;
                objSave.UserCode = txtUserCode.Text.Trim();
                objSave.UserFullName = txtUserFullName.Text.Trim();
                objSave.PositionKey = FNC.Conv(ddlPosition.SelectedValue, enDataType.INT);
                objSave.AllowToAccessLogin = ddlAllowToAccessLogin.SelectedValue;
                objSave.UserName = txtUserName.Text.Trim();
                objSave.UserPassword = txtUserPassword.Text.Trim();
                objSave.UserActive = FNC.Conv(ddlStatus.SelectedValue, enDataType.BOOL);
                objSave.UserRoleKey = FNC.Conv(ddlUserRoleKey.SelectedValue, enDataType.INT);
             
                //objSave.VehicleKey = FNC.Conv(ddlVehicleKey.SelectedValue, enDataType.INT);

                objSave.UserImage = crpUserImage.FileName;
                objSave.UserImageByte = crpUserImage.ImageByte;
;
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
            ClsUserMaster objSearch = new ClsUserMaster();

            try
            {
                /***********Codeing Start*********************/
                objSearch.UserMasterKey = PagePrimaryKey;
                var lstLoad = objSearch.GetUserMaster();


                foreach (var item in lstLoad)
                {

                    

                    txtUserCode.Text = item.UserCode;
                    txtUserFullName.Text = item.UserFullName;
                    ddlPosition.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlPosition, item.PositionKey.ToString());
                    ddlAllowToAccessLogin.SelectedValue = ClsCommonUI.SetDropdowValue(ddlAllowToAccessLogin, item.AllowToAccessLogin).ToString();
                    txtUserName.Text = item.UserName;
                    txtUserPassword.Text =  item.UserPassword;
                    txtUserPassword.Attributes["value"] = txtUserPassword.Text;
                    ddlStatus.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlStatus, item.UserActive.ToString());
                    ddlUserRoleKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlUserRoleKey, item.UserRoleKey.ToString());

                   
                    //ddlVehicleKey.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlVehicleKey, item.VehicleKey.ToString());


                    var FileName = item.UserImageByte == null ? "" : "data:image/png;base64," + Convert.ToBase64String(item.UserImageByte, 0, item.UserImageByte.Length);
                    crpUserImage.FileName = FileName;// "data:image/png;base64," + Convert.ToBase64String(lstLoad.UserImageByte, 0, lstLoad.UserImageByte.Length);// lstLoad.UserImage;
                    crpUserImage.ImageByte = item.UserImageByte;
                   

                    txtUserFullName.Focus();
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
                txtUserCode.Text = string.Empty;
                ddlPosition.SelectedIndex = -1;
                txtUserFullName.Text = string.Empty;               
                ddlStatus.SelectedIndex = -1;
                txtUserName.Text = string.Empty;
                txtUserPassword.Text = string.Empty;
                crpUserImage.FileName = string.Empty;
                ddlAllowToAccessLogin.SelectedIndex = -1;
                ddlUserRoleKey.SelectedIndex = -1;
 
                //ddlVehicleKey.SelectedIndex = -1;
                txtUserFullName.Focus();
                /***********Codeing End*********************/

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
           
        }

      
    }
}