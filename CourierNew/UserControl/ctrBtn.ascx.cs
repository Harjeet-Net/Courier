using BL;
using CommonEntity;
using System;
using System.Web.UI.WebControls;

namespace CourierNew.UserControl
{
    public partial class ctrBtn : System.Web.UI.UserControl
    {

        public enUserRoles enRole
        {
            get; set;
        }

        public bool IsCustomJs
        {
            get;set;
        }
        public delegate void MasterActionEvetnHandler(object sender, EventArgs e);
        public event MasterActionEvetnHandler MasterEve;
        public delegate void MasterActionLoadEvetnHandler(object sender, EventArgs e);
        public event MasterActionLoadEvetnHandler MasterLoadEve;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            String ActionID = String.Empty;
            String ActionName = String.Empty;
            if (sender is Button)
            {
                ActionID = ((Button)sender).ID;
                ActionName = ((Button)sender).Text;
            }
            else
            {
                ActionID = ((Button)sender).ID;
                ActionName = ((Button)sender).Text;
            }
            if (ActionID.Equals("lnkReset"))
            {
                PageKey = 0;
                IsAddUpdateRecord = true;
            }
            if (ActionID.Equals("lnkAddNew"))
            {
                PageKey = 0;
                IsAddUpdateRecord = true;
            }
            MasterEve(sender, e);
            InitForm();
            SetControlJs();
        }
        public void SetControlJs()
        {
            lnkDelRecord.Attributes.Add("onclick", "javascript:return Delete();");
            lnkSave.Attributes.Add("onclick", "return Validate();");
            if (lnkSearch.Text == "Add Purchase")
            {
                lnkSearch.Attributes.Add("onclick", "return AlerAddNewPurchase();");
            }

            if (IsCustomJs)
            {
                lnkSave.Attributes.Add("onclick", "return ValidateOther();");
            }
        }
        public void InitForm()
        {

            lnkDelRecord.Visible = VisibleDelRecord;
            lnkSave.Visible = VisibleSave;
            lnkReset.Visible = VisibleCancel;
            lnkSearch.Visible = VisibleSearch;
            lnkPrint.Visible = VisiblePrint;
            //lnkAddNew.Visible = false;

            if (PageKey.Equals(0) && VisibleSave)
            {
                lnkSave.Text = "Save As New";
                lnkSave.ToolTip = "Click Here To Add New Record";
                lnkReset.Text = "Clear";

            }
            if (PageKey > 0 && VisibleSave)
            {
                lnkSave.Text = "Save Change";
                lnkSave.ToolTip = "Click Here To Change Record";
                lnkReset.Text = "Cancel";
                if (VisibleDelRecord)
                {
                    lnkDelRecord.Visible = true;
                }
            }
            lnkReset.Attributes.Add("class", "margin-top-18");

            if (PageKey > 0 && VisiblePrint)
            {
                lnkPrint.Visible = VisiblePrint;
            }


        }
        int _PageKey = 0;
        public int PageKey
        {
            get
            {
                return _PageKey;
            }
            set
            {
                _PageKey = value;
                InitForm();
            }
        }
        public bool IsAddUpdateRecord
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InitForm();
                SetControlJs();

            }
            if (enRole != enUserRoles.None)
            {
                if (PageKey == 0)
                    lnkSave.Visible = ClsCacheData.IsAllowToAccess(enRole, enRoleType.Add);
                if (PageKey > 0)
                {
                    lnkSave.Visible = ClsCacheData.IsAllowToAccess(enRole, enRoleType.Edit);
                    if (VisibleDelRecord)
                        lnkDelRecord.Visible = ClsCacheData.IsAllowToAccess(enRole, enRoleType.Delete);
                    if (VisiblePrint)
                        lnkPrint.Visible = ClsCacheData.IsAllowToAccess(enRole, enRoleType.Print);
                }
                lnkViewLog.Visible = ClsCacheData.IsAllowToAccess(enRole, enRoleType.ViewLog);
            }
            lnkViewLog.OnClientClick = "return OpenModelViewLog('" + enRole.ToString() + "');";
        }
        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            MasterLoadEve(sender, e);
            InitForm();
            SetControlJs();
        }
        public bool VisibleAddnew
        {
            get;
            set;
        }
        public bool VisibleDelRecord
        {
            get;
            set;
        }
        public bool VisibleSearch
        {
            get;
            set;
        }
        public bool VisibleCancel
        {
            get;
            set;

        }
        public bool VisibleSave
        {
            get;
            set;
        }
        public bool VisiblePrint
        {
            get;
            set;
        }

        public string SetPrintPage
        {
            set
            {
                lnkPrint.OnClientClick = value;
            }
        }


        public String ButtonActionMode
        {
            get;
            set;
        }

        public string SetHideCaptionForCancel
        {
            get
            {
                return lnkReset.Text;
            }
            set
            {
                if (value != "")
                {
                    lnkSearch.Text = value;
                }
                else
                {

                    lnkSearch.Text = " Serch";

                }
            }
        }

        public string SHowHideAllButton
        {
            set
            {
                buttons.Style.Add("display", value);
            }
        }
    }
}