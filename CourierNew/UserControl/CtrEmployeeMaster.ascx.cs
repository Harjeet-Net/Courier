using BL;
using CommonEntity;
using CourierNew;
using System;


namespace CourierNew.UserControl
{
    public partial class CtrEmployeeMaster : clsControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsFillCombo.FillCategory(ddlMainHRRoleID, enCategory.UserRole);
       //    btnCatAdd.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.EmployeeMaster, enRoleType.Add);
        }
    }
}