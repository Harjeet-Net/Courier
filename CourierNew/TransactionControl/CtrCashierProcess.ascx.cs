using BL.Cashier;
using CommonEntity;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.TransactionControl
{
    public partial class CtrCashierProcess : clsUserControlBase
    {
        public EnCashierPage PageType
        {
            get; set;
        }
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
           //     ClsFillCombo.FillNameOfCategory(ddlCategoryKey);

                /***********Codeing End*********************/

                PagePrimaryKey = FNC.Conv(ClsCommonUI.HandlNullString(Request.QueryString["PK"]), enDataType.INT);
                btnTop.PageKey = PagePrimaryKey;


                if (PageType.Equals(EnCashierPage.DayBegin))
                {
                    this.Page.Title = "Day Begin";
                }
                else
                {
                    this.Page.Title = "Day Close";
                }
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
                ClsCashier objSave = new ClsCashier();

                objSave.CashierId       = PagePrimaryKey;
                objSave.ExpenseType     = ddlExpenseType.SelectedValue.ToString();
                objSave.ShiftType       = ddlShiftType.SelectedValue.ToString();
                objSave.EmployeeName    = txtEmployeeName.Text.Trim();
                objSave.CashAmount      = FNC.Conv(txtCashAmount.Text.Trim(), enDataType.DECIMAL);
                objSave.ChequeAmount    = FNC.Conv(txtChequeAmount.Text.Trim(), enDataType.DECIMAL);
                objSave.CashReceive     = FNC.Conv(txtCashReceive.Text.Trim(), enDataType.DECIMAL);
                //if(txtDateandTime.Text.Length >7)
                //{
                    //objSave.DateandTime = Convert.ToDateTime(txtDateandTime.Text);
                    objSave.DateandTime = DateTime.Now;
                //}
                objSave.PageType        = PageType.ToString();
 
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
            ClsCashier objSearch = new ClsCashier();

            try
            {
                /***********Codeing Start*********************/
                objSearch.CashierId = PagePrimaryKey;
                

                var lstCat = objSearch.GetCashier();

                foreach (var item in lstCat)
                {
                    ddlExpenseType.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlExpenseType, item.ExpenseType);
                    ddlShiftType.SelectedIndex = ClsCommonUI.SetDropdowValue(ddlShiftType, item.ShiftType);
                    txtEmployeeName.Text    = item.EmployeeName;
                    txtCashAmount.Text      = item.CashAmount.ToString();
                    txtChequeAmount.Text    = item.ChequeAmount.ToString();
                    txtCashReceive.Text     = item.CashReceive.ToString();
                    if(item.DateandTime!=null)
                    {
                        txtDateandTime.Text = item.DateandTime.ToString("dd/MM/yyyy");
                    }
                    //    txtPageType.Text        = item.PageType;
                    ddlExpenseType.Focus();
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
                ddlExpenseType.SelectedIndex =  -1; 
                ddlShiftType  .SelectedIndex =  -1;
                txtEmployeeName .Text = String.Empty;
                txtCashAmount   .Text = String.Empty;
                txtChequeAmount .Text = String.Empty;
                txtCashReceive  .Text = String.Empty;
                txtDateandTime  .Text = String.Empty;
                //   txtPageType     .Text = String.Empty;
                ddlExpenseType.Focus();
                /***********Codeing End*********************/
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }
        #endregion

    }
}
