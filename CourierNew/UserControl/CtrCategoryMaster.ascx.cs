using BL;
using CommonEntity;
using System;

namespace CourierNew.UserControl
{
    public partial class CtrCategoryMaster : clsControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsFillCombo.FillNameOfCategory(ddlCategoryName);
          //  btnCatAdd.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.CategoryMaster, enRoleType.Add);
        }
    }
}