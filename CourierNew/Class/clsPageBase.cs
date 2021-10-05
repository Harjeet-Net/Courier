using BL.AuthenticationAndSession;
using CommonEntity;
using System;
using System.Configuration;
using System.Text;
using System.Web.UI;
namespace CourierNew
{
    public abstract class ClsPageBase : Page
    {
        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);


            //var SiteMap=  (HtmlGenericControl)  Page.FindControl("SiteMap");
            //if (SiteMap != null)
            //{ 
            //    SiteMap.InnerHtml = SiteMapeGet(this.Page.Title);
            //}
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
        public String UIUserRoleName
        {
            get
            {
                return ClsSessionData.GetLoginUserDataFromSession().UserRoleName.ToUpper();
            }
        }
        public int PageIndex
        {
            get
            {
                return Convert.ToInt32(ViewState["PageIndex"] ?? 0);
            }
        }
        public String UICompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyName"].ToString();
            }
        }
        public String SiteMapeGet(String page)
        {
            String MenuRUL = "";
            string SiteMate = "  <li class='breadcrumb - item'><a href='#'>Home</a></li>";

            if (page == "Category Entry" || page == "Note Entry")
            {
                MenuRUL = SiteMate + String.Format("  <li class='breadcrumb - item active'>{0}</li>", page);
            }
            return MenuRUL;
        }

        public int PagePrimaryKey
        {
            get
            {
                return Convert.ToInt32(ClsCommonUI.GetTextKey(this).Text);
            }
            set
            {
                ClsCommonUI.GetTextKey(this).Text = value.ToString();
            }
        }
        public String PageError(Exception ex, String pinMethodName)
        {
            String Error = String.Format("<h3>{0}:{1}</h3><li>{2}</li> ", this.Title, pinMethodName, ex.Message.ToString()); ;
            return SetPageMessageServerSide(Error, enMessageBoxType.Faliure);
        }
        public static String SetPageMessageServerSide(string message, enMessageBoxType messageType)
        {
            StringBuilder objstr = new StringBuilder();
            objstr.Append("<div class=\"box-danger\">");
            switch (messageType)
            {
                case enMessageBoxType.Success:
                    objstr.Append("<div id=\"divErrorServer\" class=\"alert alert-success alert-dismissable\" style='color: white;opacity: 2;z-index:9999' />");
                    //objstr.Append("<i class=\"fa fa-check\"></i>");
                    break;
                case enMessageBoxType.Faliure:
                    objstr.Append("<div id=\"divErrorServer\" class=\"alert alert-danger alert-dismissable\" style='color: white;opacity: 2;z-index:9999' />");
                    //objstr.Append("<i class=\"fa fa-ban\"></i>");
                    break;
            }


            objstr.Append("<h3><button type=\"button\" class=\"close\" onclick=\"HideError('divErrorServer');\"  style='color: white;opacity: 2;z-index:9999'>×</button></h3>");
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

    }
    public abstract class ClsPageBaseMaster : MasterPage
    {
        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);


            //var SiteMap=  (HtmlGenericControl)  Page.FindControl("SiteMap");
            //if (SiteMap != null)
            //    SiteMap.InnerHtml = SiteMapeGet(this.Page.Title);
            //}
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
        public String UICompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyName"].ToString();
            }
        }
        public String SiteMapeGet(String page)
        {
            String MenuRUL = "";
            string SiteMate = "  <li class='breadcrumb - item'><a href='#'>Home</a></li>";

            if (page == "Category Entry" || page == "Note Entry")
            {
                MenuRUL = SiteMate + String.Format("  <li class='breadcrumb - item active'>{0}</li>", page);
            }
            return MenuRUL;
        }
        public int PagePrimaryKey
        {
            get
            {
                return Convert.ToInt32(ClsCommonUI.GetTextKey(this.Master.Page).Text);
            }
            set
            {
                ClsCommonUI.GetTextKey(this.Master.Page).Text = value.ToString();
            }
        }
        public String PageError(Exception ex, String pinMethodName)
        {
            String Error = String.Format("<h3>{0}:{1}</h3><li>{2}</li> ", this.Master.Page.Title, pinMethodName, ex.Message.ToString()); ;
            return SetPageMessageServerSide(Error, enMessageBoxType.Faliure);
        }
        public static String SetPageMessageServerSide(string message, enMessageBoxType messageType)
        {
            StringBuilder objstr = new StringBuilder();
            objstr.Append("<div class=\"box-danger\">");
            switch (messageType)
            {
                case enMessageBoxType.Success:
                    objstr.Append("<div id=\"divErrorServer\" class=\"alert alert-success alert-dismissable\" style='color: white;opacity: 2;z-index:9999' />");
                    //objstr.Append("<i class=\"fa fa-check\"></i>");
                    break;
                case enMessageBoxType.Faliure:
                    objstr.Append("<div id=\"divErrorServer\" class=\"alert alert-danger alert-dismissable\" style='color: white;opacity: 2;z-index:9999' />");
                    //objstr.Append("<i class=\"fa fa-ban\"></i>");
                    break;
            }


            objstr.Append("<h3><button type=\"button\" class=\"close\" onclick=\"HideError('divErrorServer');\"  style='color: white;opacity: 2;z-index:9999'>×</button></h3>");
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

    }
}