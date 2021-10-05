using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace CommonEntity
{
    public class clsMail
    {
        #region "Member"

        string _sLoginName;
        string _sUserName;
        string _sPassword;
        string _sBody;
        string _sHeader;
        string _sFromEmailId;
        string _sToEMailId;
        DataRow _drUser;
        string _sEmailServer;
        string _sCompanyName;
        string _sDesignation;
        string _sDepartment;
        string _sBranch;
        string _sRole;
        string _fromDate;
        string _toDate;
        string _TotalUsers;

        string _isCreated;
        #endregion

        #region "Property"

        public string isCreated
        {
            get { return _isCreated; }
            set { _isCreated = value; }
        }

        public string fromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        public string toDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }

        public string TotalUsers
        {
            get { return _TotalUsers; }
            set { _TotalUsers = value; }
        }


        public string LoginName
        {
            get { return _sLoginName; }
            set { _sLoginName = value; }
        }

        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }

        public string ToEMailId
        {
            get { return _sToEMailId; }
            set { _sToEMailId = value; }
        }

        public string EmailServer
        {
            get { return _sEmailServer; }
            set { _sEmailServer = value; }
        }

        public string SenderEmailId
        {
            get { return _sFromEmailId; }
            set { _sFromEmailId = value; }
        }

        public string Body
        {
            get { return _sBody; }
            set { _sBody = value; }
        }

        public string Header
        {
            get { return _sHeader; }
            set { _sHeader = value; }
        }

        public string Password
        {
            get { return _sPassword; }
            set { _sPassword = value; }
        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }
        }

        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }
        }

        public string Department
        {
            get { return _sDepartment; }
            set { _sDepartment = value; }
        }

        public string Branch
        {
            get { return _sBranch; }
            set { _sBranch = value; }
        }

        public string Role
        {
            get { return _sRole; }
            set { _sRole = value; }
        }

        public DataRow drUser
        {
            get { return _drUser; }
            set { _drUser = value; }
        }

        #endregion

        #region "Methods"



        private string GetMailBody()
        {

            System.Text.StringBuilder strMsgBody = new System.Text.StringBuilder();

            strMsgBody.Append("This is Test From Asian Tube Mills Private Limited");

            return Convert.ToString(strMsgBody);
        }

        //public bool SentTransactonErrorMail()
        //{
        //    try
        //    {

        //        string strBody = GetMailBody();

        //        if (strBody.Trim().Length == 0)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            List<string> lstMailTo = new List<string>();
        //            //     lstMailTo.Add("imran.crystal@gmail.com");
        //            lstMailTo.Add(clsSMTPSe;
        //            string strMailHeader = "Hi " + LoginName + ", Inward Authorization Reuest of " + objTran.StockTransferNo;
        //            AppConfig.AdminMail = "admin@faizanzw.com";// SenderEmailId;
        //            AppConfig.SMTPassword = "1qaz2wsx@";// Password;
        //            AppConfig.SMTPServerName = "webmail.faizanzw.com";// EmailServer;
        //            AppConfig.SMTPUserName = "admin@faizanzw.com";// UserName;

        //            //  return SendMail(lstMailTo, AppConfig.AdminMail, strMailHeader, System.Web.HttpUtility.HtmlEncode(strBody));
        //            return SendMail(lstMailTo, clsVariables.sUserEmail, strMailHeader, strBody);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }


        //}

        public static bool SendMail(String fileName, List<string> lstMailTo, string mailUserName, string strMailSubject, string strMailBody, List<string> lstMailCC = null, string mailServerName = "smtp.asianpipe.com", string mailPassword = "qT)jtuM6", String mailAttchmentPath = "")
        {

            try
            {
                if (lstMailTo.Count == 0)
                    return false;

                System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
                String MailFrom = mailUserName;// "mufaddal@rajfilters.com";// "sales @rajfilters.com";
                objMailMessage.From = new System.Net.Mail.MailAddress(MailFrom);

                foreach (string MailTo in lstMailTo)
                {
                    objMailMessage.To.Add(MailTo);
                }

                if ((lstMailCC != null))
                {
                    foreach (string MailCC in lstMailCC)
                    {
                        objMailMessage.CC.Add(MailCC);
                    }
                }
                //    String PDFPath = String.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory + "/PDF/", fileName + "_Invoice.pdf");
                objMailMessage.Attachments.Add(new Attachment(mailAttchmentPath));
                objMailMessage.Subject = strMailSubject;
                objMailMessage.Body = strMailBody;

                objMailMessage.Priority = System.Net.Mail.MailPriority.High;
                objMailMessage.IsBodyHtml = true;


                System.Net.Mail.SmtpClient MyMailServer = new System.Net.Mail.SmtpClient(mailServerName);
                MyMailServer.Credentials = new NetworkCredential(mailUserName, mailPassword);
                MyMailServer.Port = 587;
                if (mailServerName.Contains("gmail"))
                {
                    MyMailServer.EnableSsl = true;
                }
                else
                {
                    MyMailServer.EnableSsl = false;
                }
                MyMailServer.Send(objMailMessage);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        //method to send email to HOTMAIL
        public static void sendEMailThroughHotMail()
        {
            try
            {
                //Mail Message
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress("no-reply@asianpipe.com");
                //receiver email id
                mM.To.Add("imran.crystal@gmail.com");
                //subject of the email
                mM.Subject = "your subject line will go here";
                //deciding for the attachment
                mM.Attachments.Add(new Attachment(@"E:\\Company\AsianTubesInvcMail\AsianTubesInvcMail\bin\Debug\output.pdf"));
                //add the body of the email
                mM.Body = "Body of the email";
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient("webmail.asianpipe.com");
                //port number for Hot mail
                sC.Port = 587;
                //credentials to login in to hotmail account
                sC.Credentials = new NetworkCredential("no-reply@asianpipe.com", "qT)jtuM6");
                //enabled SSL
                sC.EnableSsl = false;
                //Send an email
                sC.Send(mM);
            }//end of try block
            catch (Exception ex)
            {
                throw ex;
            }//end of catch
        }//end of Email Method HotMail

        #endregion
    }

    public class AppConfig
    {
        public static string AdminMail { get; set; }
        public static string AppPath { get; set; }
        public static string SMTPassword { get; set; }
        public static string SMTPServerName { get; set; }
        public static string SMTPUserName { get; set; }
    }
}
