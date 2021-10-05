using System;
using System.Configuration;
namespace CommonEntity
{
    public static class clsVariables
    {


        public static String API
        {
            get
            {
                return FNC.DecryptData( ConfigurationManager.AppSettings["API"].ToString());
            }
        }

        public static int BranchID
        {
            get
            {
                return FNC.Conv(ConfigurationManager.AppSettings["BranchID"].ToString(), enDataType.INT);
            }
        }

        public static String ErrorDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorDirectory"].ToString();
            }
        }
        public static String BackupPath
        {
            get
            {
                return ConfigurationManager.AppSettings["BackupPath"].ToString();
            }
        }
        public static String ProductName
        {
            get
            {
                return ConfigurationManager.AppSettings["ProductName"].ToString();
            }
        }

        public static String CompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyName"].ToString();
            }
        }
        public static String SubDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["SubDomain"].ToString();
            }
        }
        public static string sMessageBox = "[ ROMS ver. 1.0 ]";

        public enum enTextType : byte
        {
            enInt = 1,
            enFloat,
            enDouble,
            enDecimal
        }

        //BOOLEAN VARIABLES
        public static bool nonNumberEntered = false;
        public static string sBranchName;
        public static string sBranchAddress;
        public static byte[] bBranchLogoByte;
        public static string sPhones;
        public static string sEnail;
        public static bool boolConnected = false;
        public static string sUserLogin;
        public static int iSeconds = 10;
        public static int iTimerCount = 0;


        public static int iBranchUserKey;
        public static string sUserName;
        public static string sUserPassword;
        public static string sEmployeeCode;
        public static string sDescription;
        public static string sTRN;
        /****************Branch Rights*******************/
        public static bool bTrainingAccess_Branch;
        public static bool bTradingAccess_Branch;
        public static bool bSpaceAccess_Branch;
        public static bool bInstallmentAccess_Branch;
        public static bool bPosInvoiceAccess_Branch;
        public static bool bRentingAccess_Branch;
        public static bool bEnrolmentAccess_Branch;
        public static bool bDiscountAllowed_Branch;
        public static bool bStockEntryAccess_Branch;
        /******************* User Rights*****************/

        public static bool bReportsAccess;
        public static bool bInvoiceAccess;
        public static bool bInvoiceCancel;
        public static bool bEnrolmentAccess;
        public static bool bCandidateAccess;
        public static bool bCandidateOnlineSearch;
        public static bool bEIDReaderAccess;
        public static bool bUpdateToolAccess;
        public static bool bDownloadDataAccess;
        public static bool bAdminAccess;
        /**********************End Of User Rights************************/

        public static bool bStatus;
        public static string sA4PRINTER;
        public static string sAUTOBACKUPTIME1;
        public static string sAUTOBACKUPTIME2;
        public static string sBACKUPPATH;
        public static string sDEFAULTPRINTER;
        public static string sPOSPRINTER;
        public static string sLastBackup;


    }
}































