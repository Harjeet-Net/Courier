
using BL.EmployeeMaster;
using CommonEntity;
using System;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class EmployeeMaster :ClsPageBase,INweEntryWeb
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
                PageName = this.PageName;
                ltMsg.Text = "";
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
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
                ClsFillCombo.FillCategory(ddlMainHRRoleID, enCategory.UserRole);
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
                clsEmployee objSave = new clsEmployee();
                objSave.TenentID = 14;
                objSave.employeeID = PagePrimaryKey;
                objSave.userID = txtuserID.Text.Trim();
                objSave.MainHRRoleID = FNC.Conv(ddlMainHRRoleID.SelectedValue, enDataType.INT);
                objSave.lastname = txtlastname.Text.Trim();
                objSave.firstname = txtfirstname.Text.Trim();
                objSave.name2 = txtname2.Text.Trim();
                objSave.name3 = txtname3.Text.Trim();
                objSave.Studen_LoginID = txtStuden_LoginID.Text.Trim();
                objSave.PASSWORD = txtPASSWORD.Text.Trim();
                objSave.EmployeeImage = crpUserImage.FileName;
                objSave.EmployeeImageByte = crpUserImage.ImageByte;
                if (txtjoined_date.Text.Length > 7)
                    objSave.joined_date = Convert.ToDateTime(txtjoined_date.Text);
                objSave.Active = FNC.Conv(ddlActive.SelectedValue, enDataType.BOOL);
                objSave.emp_mobile = txtemp_mobile.Text.Trim();
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
            clsEmployee objSearch = new clsEmployee();

            try
            {
                ///***********Codeing Start*********************/
                objSearch.employeeID = PagePrimaryKey;

                var lstCat = objSearch.GetEmployee();

                foreach (var item in lstCat)
                {
                    txtuserID.Text = item.userID;
                    ddlMainHRRoleID.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlMainHRRoleID, item.MainHRRoleID.ToString());
                    txtlastname.Text = item.lastname;
                    txtfirstname.Text = item.firstname;
                    txtname2.Text = item.name2;
                    txtname3.Text = item.name3;
                    txtStuden_LoginID.Text = item.Studen_LoginID;
                    txtPASSWORD.Text = item.PASSWORD;
                    if (item.joined_date !=null)
                        txtjoined_date.Text = Convert.ToDateTime(item.joined_date).ToString("dd/MM/yyyy");
                    ddlActive.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlActive, item.Active.ToString());
                    txtemp_mobile.Text = item.emp_mobile;
                    var FileName = item.EmployeeImageByte == null ? "" : "data:image/png;base64," + Convert.ToBase64String(item.EmployeeImageByte, 0, item.EmployeeImageByte.Length);
                    crpUserImage.FileName = FileName;// "data:image/png;base64," + Convert.ToBase64String(lstLoad.UserImageByte, 0, lstLoad.UserImageByte.Length);// lstLoad.UserImage;
                    crpUserImage.ImageByte = item.EmployeeImageByte;

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
            {
                //FIX CODE
                PagePrimaryKey = 0;
                /***********Codeing Start*********************/

                txtuserID.Text = string.Empty;
                ddlMainHRRoleID.SelectedIndex = -1;
                txtlastname.Text = string.Empty;
                txtfirstname.Text = string.Empty;
                txtname2.Text = string.Empty;
                txtname3.Text = string.Empty;
                txtStuden_LoginID.Text = string.Empty;
                txtPASSWORD.Text = string.Empty;
                txtjoined_date.Text = string.Empty;
                ddlActive.SelectedIndex = -1;
                txtemp_mobile.Text = string.Empty;
                crpUserImage.FileName = string.Empty;

                /***********Codeing End*********************/
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            
        }

        #endregion

    }
}

