using CommonEntity;
using System;
using System.Text;
using System.Web.UI;
namespace CourierNew
{
    public class clsUserControlBase : System.Web.UI.UserControl
    {
        public String PageError(Exception ex, String pinMethodName)
        {
            String Error = String.Format("<h3>{0}:{1}</h3><li>{2}</li> ", this.Page.Title, pinMethodName, ex.Message.ToString()); ;
            return SetPageMessageServerSide(Error, enMessageBoxType.Faliure);
        }
        public static String SetPageMessageServerSide(string message, enMessageBoxType messageType)
        {
            StringBuilder objstr = new StringBuilder();
            objstr.Append("<div class=\"box-danger\">");
            switch (messageType)
            {
                case enMessageBoxType.Success:
                    objstr.Append("<div id=\"divErrorServer\" class=\"alert alert-success alert-dismissable\" style='color: white;opacity: 2;' />");
                    //objstr.Append("<i class=\"fa fa-check\"></i>");
                    break;
                case enMessageBoxType.Faliure:
                    objstr.Append("<div id=\"divErrorServer\" class=\"alert alert-danger alert-dismissable\" style='color: white;opacity: 2;' />");
                    //objstr.Append("<i class=\"fa fa-ban\"></i>");
                    break;
            }


            objstr.Append("<h3><button type=\"button\" class=\"close\" onclick=\"HideError('divErrorServer');\"  style='color: white;opacity: 2;'>×</button></h3>");
            objstr.Append("<b>Alert!</b><ul>");
            objstr.Append("" + message + "");
            objstr.Append("</ul>");
            objstr.Append("</div>");
            objstr.Append("<script> $('html, body').animate({ scrollTop: 0 }, 'slow');</script>");
            return objstr.ToString();
        }
        public void MessageJquery(String message, enMessageBoxType messageType)
        {
            String Message = String.Format("Message('{0}','{1} sucess fully.' );", messageType.ToString(), message);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Save Data", Message, true);

        }
        
        public String PageName
        {
            get
            {
                return this.Page.Title;
            }
            set
            {
                this.Page.Title = value;
            }

        }
        public int PagePrimaryKey
        {
            get
            {
                return Convert.ToInt32(ClsCommonUI.GetTextKey(this.Page).Text);
            }
            set
            {
                ClsCommonUI.GetTextKey(this.Page).Text = value.ToString();
            }
        }
        public int PageIndex
        {
            get
            {
                return Convert.ToInt32(ViewState["PageIndex"] ?? 0);
            }
        }
    }
}