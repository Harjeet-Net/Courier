using CommonEntity;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CourierNew
{
    public class clsControlBase : System.Web.UI.UserControl
    {
        public String PageName
        {
            get
            {
                return this.Parent.Page.Title;
            }

        }

        public void Message(String message, enMessageBoxType messageType)
        {
            String Message = String.Format("Message('{0}','{1} sucess fully.' );", messageType.ToString(), message);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Save Data", Message, true);

        }
        protected override void OnLoad(EventArgs e)
        {
            Disposed += OnDispose;
            base.OnLoad(e);
            //Set page tile
            var HeadTitle = (HtmlGenericControl)this.FindControl("HeadTitle");


            if (HeadTitle != null)
            {
                HeadTitle.InnerHtml = this.Page.Title;
            }
        }
        //           
        private void OnDispose(object sender, EventArgs e)
        {
            // do stuff on dispose
        }
    }
}