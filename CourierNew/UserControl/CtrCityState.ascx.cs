using BL;
using CommonEntity;
using CourierNew;
using System;


namespace CourierNew.UserControl
{
    public partial class CtrCityState : clsControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsFillCombo.FillOtherCombo(ddlCOUNTRYID, enComboOther.CountryName,"126");
            ClsFillCombo.FillOtherCombo(ddlStateID, enComboOther.StateName);
         //   btnCatAdd.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CityState, enRoleType.Add);
        }

    }



}