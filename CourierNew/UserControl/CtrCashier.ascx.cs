using BL;
using BL.Cashier;
using CommonEntity;
using System;

namespace CourierNew.UserControl
{
   
    public partial class CtrCashier : clsControlBase
    {
        public EnCashierPage PageType
        {
            get; set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageType.Equals(EnCashierPage.DayBegin))
            {
     
                btnDayBegin.OnClientClick = "return Op(8,0); ";
            //    btnDayBegin.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.DayBegin, enRoleType.Add);
            }
            if (PageType.Equals(EnCashierPage.DayClose))
            {
                //btnCatAdd.Text = "Return Debit";
                btnDayClose.OnClientClick = "return Op(9,0); ";
            //    btnDayClose.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.DayClose, enRoleType.Add);
            }
        }
    }
}