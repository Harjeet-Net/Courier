using BL.Shipment;
using CommonEntity;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.Pages
{
    public partial class RowDataImport : ClsPageBase
    {
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //ClsFillCombo.FillOtherCombo(ddlAssignTo, enComboOther.EmployeeByType, "Data Entry");
                    //ListItem item = new ListItem("Select All", "-1");
                    //ddlAssignTo.Items.Add(item);
                    

                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName) == ".xlsx" || Path.GetExtension(FileUpload1.FileName) == ".xls")
                    {
                        ViewState["dt"] = null;
                        ExcelPackage package = new ExcelPackage(FileUpload1.FileContent);
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt = package.ToDataTable(1, 1, 1, 60);
                        StringBuilder objStr = new StringBuilder();
                        objStr.Append("<cor>");
                        foreach (DataRow row in dt.Rows)
                        {
                            objStr.AppendFormat(@"<det  HAWB=""{0}""
                                                        ShipmentType=""{1}""
                                                        ShipperName=""{2}""
                                                        ShipperCompany=""{3}""
                                                        ShipperContact_Department=""{4}""
                                                        ShipperAddressType=""{5}""
                                                        ShipperCountry=""{6}""
                                                        ShipperArea=""{7}""
                                                        ShipperCity=""{8}""
                                                        ShipperBlock=""{9}""
                                                        ShipperStreet=""{10}""
                                                        ShipperAvenue=""{11}""
                                                        ShipperHouse_No =""{12}""
                                                        Shipper_EMail=""{13}""
                                                        ShipperPostCode=""{14}""
                                                        ShipperPACINumber=""{15}""
                                                        ShipperMobileNumber1=""{16}""
                                                        ShipperMobileNumber2=""{17}""
                                                        ReceiverName=""{18}""
                                                        ReceiverCompany=""{19}""
                                                        ReceiverContact_Department=""{20}""
                                                        ReceiverAddressType=""{21}""
                                                        ReceiverCountry=""{22}""
                                                        ReceiverArea=""{23}""
                                                        ReceiverCity=""{24}""
                                                        ReceiverBlock=""{25}""
                                                        ReceiverStreet=""{26}""
                                                        ReceiverAvenue=""{27}""
                                                        ReceiverHouse_No =""{28}""
                                                        Receiver_EMail=""{29}""
                                                        ReceiverPostCode=""{30}""
                                                        ReceiverPACINumber=""{31}""
                                                        ReceiverMobileNumber1=""{32}""
                                                        ReceiverMobileNumber2=""{33}""
                                                        ShipmentContent=""{34}""
                                                        PackagingType=""{35}""
                                                        Packaging=""{36}""
                                                        Quantity=""{37}""
                                                        Weights=""{38}""
                                                        Length=""{39}""
                                                        Width=""{40}""
                                                        Height=""{41}""
                                                        Packaging2=""{42}""
                                                        Quantity2=""{43}""
                                                        Length2=""{44}""
                                                        Weight2=""{45}""
                                                        Height2=""{46}""
                                                        Packaging3=""{47}""
                                                        Quantity3=""{48}""
                                                        Length3=""{49}""
                                                        Weight3=""{50}""
                                                        Height3=""{51}""
                                                        Invoice=""{52}""
                                                        Value=""{53}""
                                                        COD_Amount=""{54}""
                                                        Other_Charges=""{55}""
                                                        Total_Charges=""{56}""
                                                        Prefered_Schedule_Type=""{57}""
                                                        Preferred_Pickup_Window=""{58}""
                                                        Preferred_Delivery_Window=""{59}""

                                                       />"

                                                        , row["HAWB"]
                                                        , row["ShipmentType"]
                                                        , row["ShipperName"]
                                                        , row["ShipperCompany"]
                                                        , row["ShipperContact_Department"]
                                                        , row["ShipperAddressType"]
                                                        , row["ShipperCountry"]
                                                        , row["ShipperArea"]
                                                        , row["ShipperCity"]
                                                        , row["ShipperBlock"]
                                                        , row["ShipperStreet"]
                                                        , row["ShipperAvenue"]
                                                        , row["ShipperHouse_No "]
                                                        , row["Shipper_EMail"]
                                                        , row["ShipperPostCode"]
                                                        , row["ShipperPACINumber"]
                                                        , row["ShipperMobileNumber1"]
                                                        , row["ShipperMobileNumber2"]
                                                        , row["ReceiverName"]
                                                        , row["ReceiverCompany"]
                                                        , row["ReceiverContact_Department"]
                                                        , row["ReceiverAddressType"]
                                                        , row["ReceiverCountry"]
                                                        , row["ReceiverArea"]
                                                        , row["ReceiverCity"]
                                                        , row["ReceiverBlock"]
                                                        , row["ReceiverStreet"]
                                                        , row["ReceiverAvenue"]
                                                        , row["ReceiverHouse_No "]
                                                        , row["Receiver_EMail"]
                                                        , row["ReceiverPostCode"]
                                                        , row["ReceiverPACINumber"]
                                                        , row["ReceiverMobileNumber1"]
                                                        , row["ReceiverMobileNumber2"]
                                                        , row["ShipmentContent"]
                                                        , row["PackagingType"]
                                                        , row["Packaging"]
                                                        , row["Quantity"]
                                                        , row["Weights"]
                                                        , row["Length"]
                                                        , row["Width"]
                                                        , row["Height"]
                                                        , row["Packaging2"]
                                                        , row["Quantity2"]
                                                        , row["Length2"]
                                                        , row["Weight2"]
                                                        , row["Height2"]
                                                        , row["Packaging3"]
                                                        , row["Quantity3"]
                                                        , row["Length3"]
                                                        , row["Weight3"]
                                                        , row["Height3"]
                                                        , row["Invoice"]
                                                        , row["Value"]
                                                        , row["COD_Amount"]
                                                        , row["Other_Charges"]
                                                        , row["Total_Charges"]
                                                        , row["Prefered_Schedule_Type"]
                                                        , row["Preferred_Pickup_Window"]
                                                        , row["Preferred_Delivery_Window"]
                                                   );
                        }
                        objStr.Append("</cor>");
                        int result = 0;
                        clsAirWayMain objSave = new clsAirWayMain();
                        result = objSave.CourierImportSave(objStr.ToString(), FileUpload1.FileName);
                        if (result > 0)
                        {
                            //PageName = this.Page.Title;
                            //MessageJquery(PageName + " Save ", enMessageBoxType.Success);
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "SaveMessage", "SuccessFully", true);
                        }

                    }
                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        


    }
}