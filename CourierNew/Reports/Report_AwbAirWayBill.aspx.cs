using BL.Shipment;
using CommonEntity;
using CourierNew;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CourierNew.Reports
{

    public partial class Report_AwbAirWayBill : ClsPageBase
    {
        //https://www.nuget.org/packages/Microsoft.ReportingServices.ReportViewerControl.WebForms/140.340.80/
        //Install-Package Microsoft.ReportingServices.ReportViewerControl.WebForms -Version 150.1404.0
        /// <summary>
        /// In VS2019 Report version 12 in not supporitng. There is no need to take choose item for report viewer.
        /// We take from SW
        /// </summary>

        #region Variables
        String ReportFile = String.Format("Reports\\{0}.rdlc", "Report_AwbAirWayBill");



        #endregion
        
        public int iAirWayKey
        {
            get
            {
                return FNC.Conv(Request.QueryString["airwayKey"].ToString(), enDataType.INT);
            }
        }

        #region Functions
        public DataSet BindReportDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                clsAirWayMain objSearch = new clsAirWayMain();
          
                ds = objSearch.Report_AwbAirWayBill(iAirWayKey);
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return ds;
        }
        private void LoadReport()
        {
            try
            {

                rptViewer.Visible = true;
                DataTable dt = new DataTable();
                var Ds = BindReportDataSet();


                if (Ds.Tables.Count > 0)
                {
                    dt = Ds.Tables[0];
                }

                if (dt != null)
                {
                    /*rptViewer.Reset();*/
                    rptViewer.LocalReport.ReportPath = ReportFile;

                  
                    ReportDataSource rds = new ReportDataSource("dsPrint", dt);
                    rptViewer.LocalReport.DataSources.Clear();
                    rptViewer.LocalReport.DataSources.Add(rds);
                    rptViewer.DataBind();
                    rptViewer.LocalReport.Refresh();
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetReport();

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }
        private void ResetReport()
        {
            try
            {

                LoadReport();

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        #endregion


        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            ltMsg.Text = String.Empty;
            if (!IsPostBack)
            {
                try
                {
                   
                    ResetReport();
                }
                catch (Exception ex)
                {

                    ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }

            }
            ltMsg.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                LoadReport();
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

     
        #endregion

        
    }
}