
using CourierNew.UserControl;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CourierNew
{
    public class ClsCommonUI
    {
        public static dynamic AddControlToPage(Page pinPage, string pinRequestForContrl, string pinOtherCriteria = "")
        {
            if (pinOtherCriteria is null)
            {
                throw new ArgumentNullException(nameof(pinOtherCriteria));
            }

            dynamic Ctr;
            String DefaultPath = "~/UserControl/{0}.ascx";
            //String Reportpath = "~/UserControl/SearchReport/{0}.ascx";
            if (pinRequestForContrl.Equals("CategoryMaster"))
            {
                Ctr = (CtrCategoryMaster)pinPage.LoadControl(string.Format(DefaultPath, "CtrCategoryMaster"));
            }
            else if (pinRequestForContrl.Equals("UserEntry"))
            {
                Ctr = (CtrUserMaster)pinPage.LoadControl(string.Format(DefaultPath, "CtrUserMaster"));
            }
            else if (pinRequestForContrl.Equals("UserPermission"))
            {
                Ctr = (CtrUserPermission)pinPage.LoadControl(string.Format(DefaultPath, "CtrUserPermission"));
            }

            else if (pinRequestForContrl.Equals("RefTable"))
            {
                Ctr = (CtrRefTable)pinPage.LoadControl(string.Format(DefaultPath, "CtrRefTable"));
            }
            else if (pinRequestForContrl.Equals("EmployeeMaster"))
            {
                Ctr = (CtrEmployeeMaster)pinPage.LoadControl(string.Format(DefaultPath, "CtrEmployeeMaster"));
            }
            else if (pinRequestForContrl.Equals("CityState"))
            {
                Ctr = (CtrCityState)pinPage.LoadControl(string.Format(DefaultPath, "CtrCityState"));
            }
            else if (pinRequestForContrl.Equals("TemplateMaster"))
            {
                Ctr = (CtrTemplateMaster)pinPage.LoadControl(string.Format(DefaultPath, "CtrTemplateMaster"));
            }
            else if (pinRequestForContrl.Equals("CustomerMaster"))
            {
                Ctr = (CtrCustomerMaster)pinPage.LoadControl(string.Format(DefaultPath, "CtrCustomerMaster"));
            }
            else if (pinRequestForContrl.Equals("CustomerAddress"))
            {
                Ctr = (CtrCustomerAddress)pinPage.LoadControl(string.Format(DefaultPath, "CtrCustomerAddress"));
            }
            else if (pinRequestForContrl.Equals("Shipment"))
            {
                Ctr = (CtrShipment)pinPage.LoadControl(string.Format(DefaultPath, "CtrShipment"));
            }
            else if (pinRequestForContrl.Equals("ShipmentImportExcel"))
            {
                Ctr = (CtrShipmentImportExcel)pinPage.LoadControl(string.Format(DefaultPath, "CtrShipmentImportExcel"));
            }
            else if (pinRequestForContrl.Equals("CashierProcess"))
            {
                Ctr = (CtrCashier)pinPage.LoadControl(string.Format(DefaultPath, "CtrCashier"));
            }
            else if (pinRequestForContrl.Equals("DriverMaster"))
            {
                Ctr = (CtrDriverMaster)pinPage.LoadControl(string.Format(DefaultPath, "CtrDriverMaster"));
            }

            else
            {
                Ctr = null;
            }

            return Ctr;
        }
        public static void LogOut(Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "cle", "windows.history.clear();", true);

            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Remove("SessionData");
            HttpContext.Current.Session.Remove("RolesList");
            HttpContext.Current.Session.Remove("KeepSessionAlive");
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.CacheControl = "no-cache";
            string nextpage = "../Login";
            HttpContext.Current.Response.Write("<script language=\"javascript\">");
            HttpContext.Current.Response.Write("{");
            HttpContext.Current.Response.Write(" var Backlen=history.length;");
            HttpContext.Current.Response.Write(" history.go(-Backlen);");
            HttpContext.Current.Response.Write(" window.location.href='" + nextpage + "'; ");
            HttpContext.Current.Response.Write("}");
            HttpContext.Current.Response.Write("</script>");


        }
        public static TextBox GetTextKey(Page page)
        {
            return ((TextBox)page.Master.FindControl("txtKey"));
        }
        public static string HandlNullString(Object val)
        {
            return (val ?? "").ToString();
        }
        public static int SetDropdowValue(DropDownList ddl, string sValue)
        {
            return ddl.Items.IndexOf(ddl.Items.FindByValue(sValue));
        }
        public static int SetDropdowValueBytext(DropDownList ddl, string sValue)
        {
            return ddl.Items.IndexOf(ddl.Items.FindByText(sValue));
        }
        public static System.Drawing.Image Base64ToImage(string base64String)
        {

            byte[] newBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(newBytes);
            return System.Drawing.Image.FromStream(ms);
            //System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(base64String));
            //return x;
        }
        public static byte[] ImageBytesGet(String FilePath)
        {
            if (File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] Image = new byte[fs.Length];
                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return Image;
            }
            return null;
        }


        public static void SendSMS(string PinPhoneNumber, string pinSenderId, string PinValue1, string Pinvalue2 = "", string PinValue3 = "")
        {
            if (PinPhoneNumber.ToString().Length <= 10)
            {
                // use the API URL here  
                //   string strUrl = "http://bhashsms.com/api/sendmsg.php?user=shafalya&pass=123456&sender=SHAFLY&phone=9904042257,9157158201&text=Happy%20Diwali&priority=ndnd&stype=normal";
                string strUrl = "http://msg.hginfosys.co.in/submitsms.jsp?user=CCAhmd&key=d35ea263eaXX&mobile=" + PinPhoneNumber + "&message=" + PinValue1 + "&senderid=" + pinSenderId + "&accusage=1";
                //// Create a request object  
                WebRequest request = HttpWebRequest.Create(strUrl);
                // Get the response back  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                _ = readStream.ReadToEnd();
                response.Close();
                s.Close();
                readStream.Close();
            }

            if (Pinvalue2 is null)
            {
                throw new ArgumentNullException(nameof(Pinvalue2));
            }

            if (PinValue3 is null)
            {
                throw new ArgumentNullException(nameof(PinValue3));
            }
        }
        public static String GetDateInMMDDYYY(string date)
        {
            //	return date.Length < 9 ? "" : DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy",CultureInfo.InvariantCulture);
            return date.Length < 8 ? "" : DateTime.ParseExact(date.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
        public static void SortGrid(ref GridView grid, DataTable dataTable, string sortExpression, int newPageIndex)
        {
            try
            {
                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable)
                    {
                        Sort = sortExpression
                    };
                    grid.PageIndex = newPageIndex;
                    if (dataTable.Rows.Count / grid.PageSize > 1)
                    {
                        grid.AllowPaging = true;
                    }
                    else
                    {
                        grid.AllowPaging = false;
                    }

                    grid.DataSource = dataView;
                    grid.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}