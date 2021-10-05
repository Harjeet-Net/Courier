using BL.Shipment;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CourierNew.UserControl
{
    public partial class CtrShipmentImportExcel : clsControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName) == ".xlsx" || Path.GetExtension(FileUpload1.FileName) == ".xls")
                    {
                        ExcelPackage package = new ExcelPackage(FileUpload1.FileContent);
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt = package.ToDataTable(1, 1, 1, 60);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                SetAttributeShipmentImportExcel(dr);
                            }

                            RadGridDetail.Rebind();
                        }
                    }
                }
            }
            catch (Exception ex) { string msg = ex.Message; }

        }

        private void SetAttributeShipmentImportExcel(DataRow dr)
        {
            try
            {
                /***********Codeing Start*********************/
                ClsAirWayBillImportExcelMaster objEntity = new ClsAirWayBillImportExcelMaster
                {
                    AWBDate = DateTime.ParseExact(dr[0].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),//Convert.ToDateTime(DateTime.ParseExact(dr[1].ToString(), "dd/MM/yyyy", null)),
                    AirwayBillNo = dr[1].ToString(),
                    AWBType = dr[2].ToString(),
                    DriverName = dr[3].ToString(),
                    ShipperName = dr[4].ToString(),
                    ConsigneeName = dr[5].ToString(),
                    ConsigneeAdd1 = dr[6].ToString(),
                    ConsigneeAdd2 = dr[7].ToString(),
                    ConsigneeAdd3 = dr[8].ToString(),
                    ConsigneeCityId = dr[9].ToString(),
                    ConsigneeTelephone = dr[10].ToString(),
                    ConsigneePCS = dr[11].ToString(),
                    ConsigneeWeight = float.Parse(dr[12].ToString()),
                    ConsigneeNetAmount = float.Parse(dr[13].ToString())
                };

                int result = objEntity.InsertUpdate_AirWayBill_Temp_Import_Excel();
                if (result > 0)
                {

                }
            }

            catch (Exception ex) { string msg = ex.Message; }
        }

        protected void RadGridDetail_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                RadGridDetail.DataSource = new string[0];
                ClsAirWayBillImportExcelMaster objEntity = new ClsAirWayBillImportExcelMaster();
                DataTable dt = objEntity.GetAirWayBillTempByUserID();
                if (dt.Rows.Count > 0)
                {
                    RadGridDetail.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        protected void RadGridDetail_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem item in RadGridDetail.Items)
            {
                if (ShipmentTempID.Contains("," + Convert.ToInt32(item.GetDataKeyValue("TempID")).ToString() + ","))
                {
                    ((CheckBox)item.FindControl("ckboxShipmentTemp")).Checked = true;
                }
            }
        }

        protected void ckboxShipmentTempSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckboxSelectAll = (CheckBox)sender;

            if (ckboxSelectAll.Checked == true)
            {
                foreach (GridDataItem gvr in RadGridDetail.Items)
                {
                    CheckBox ckboxShipmentTemp = (CheckBox)gvr.FindControl("ckboxShipmentTemp");
                    HiddenField hfTempID = (HiddenField)gvr.FindControl("hfTempID");

                    if (ckboxShipmentTemp != null)
                    {
                        ckboxShipmentTemp.Checked = true;
                        ShipmentTempID += hfTempID.Value + ",";
                    }
                }
            }
            else
            {
                foreach (GridDataItem gvr in RadGridDetail.Items)
                {
                    CheckBox ckboxShipmentTemp = (CheckBox)gvr.FindControl("ckboxShipmentTemp");
                    if (ckboxShipmentTemp != null)
                    {
                        ckboxShipmentTemp.Checked = false;
                    }
                }
                string str = Convert.ToString(ViewState["ShipmentTempID"]);
                ViewState.Remove("ShipmentTempID");
            }

        }

        protected void ckboxShipmentTemp_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckboxShipmentTemp = (CheckBox)sender;
            GridDataItem item = (GridDataItem)ckboxShipmentTemp.NamingContainer;
            int ID = Convert.ToInt32(item.GetDataKeyValue("TempID"));
            if (ckboxShipmentTemp.Checked)
            {
                ShipmentTempID += ID.ToString() + ",";
            }
            else
            {
                ShipmentTempID = ShipmentTempID.Replace(ID.ToString() + ",", "");
            }
        }

        public string ShipmentTempID
        {
            set
            {
                ViewState["ShipmentTempID"] = value;
            }
            get
            {
                if (ViewState["ShipmentTempID"] != null)
                {
                    return Convert.ToString(ViewState["ShipmentTempID"]);
                }
                else
                {
                    return ",0,";
                }
            }
        }
    }
}