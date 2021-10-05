using BL;
using CommonEntity;
using System;

namespace CourierNew.UserControl
{
    public partial class CtrCustomerMaster : clsControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsFillCombo.FillOtherCombo(ddlCountry, enComboOther.CountryName);
            //    btnCatAdd.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.UserMaster, enRoleType.Add);
        }
    }
}