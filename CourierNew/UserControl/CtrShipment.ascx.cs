using BL;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.UserControl
{
    public partial class CtrShipment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              //btnPrepareShipment.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.PrepareShipment, enRoleType.Add);
              //btnLocalShipment.Visible = ClsCacheData.IsAllowToAccess(enUserRoles.LocalShipment, enRoleType.Add);
        }
    }
}