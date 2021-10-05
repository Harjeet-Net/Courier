using CommonEntity;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Charts
{
    public class ClsSalesPie
    {
        public String Branch { get; set; }
        public Decimal Percentage { get; set; }
    }
    public class ClsSales
    { 
        public String Branch { get; set; }
        public Decimal Percentage { get; set; }
        public List<decimal> Sales { get; set; }
    }
    public class ClsChartMember
    {
        public List<String> filteredDates { get; set; }
        public List<ClsSales>  LstSales { get; set; }
    }
    public class ClsChart
    {
        public List<ClsSalesPie> PieChartDat(String sBranches, String sFromDate, String sToDate )
        {

            ClsChartMember objGet = new ClsChartMember();
            ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
            SqlParameter[] objParam = new SqlParameter[]
            {
                      new SqlParameter("@Branches",  sBranches  ),
                      new SqlParameter("@FromDate",  sFromDate  ),
                      new SqlParameter("@ToDate",  sToDate  ),
 
            };
            var ds = objSql.ExecuteDataSet("ChartPieDataGet", objParam);
            List<ClsSalesPie> Lst = new List<ClsSalesPie>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ClsSalesPie objChart = new ClsSalesPie();
                objChart.Percentage =   FNC.Conv(dr["Percentage"].ToString(), enDataType.DECIMAL);
                objChart.Branch = dr["Branch"].ToString();
                Lst.Add(objChart);
            }
            return Lst;
        }



          public ClsChartMember  ChartDataGet(String sBranches , String sFromDate , String sToDate, String sFilter)
        {

            ClsChartMember objGet = new ClsChartMember();
            ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
            SqlParameter[] objParam = new SqlParameter[]
            {
                      new SqlParameter("@Branches",  sBranches  ),
                      new SqlParameter("@FromDate",  sFromDate  ),
                      new SqlParameter("@ToDate",  sToDate  ),
                      new SqlParameter("@Filter",  sFilter  ),
            };
            var ds = objSql.ExecuteDataSet("ChartDataGet", objParam);
            List<String> LstFilter = new List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LstFilter.Add(dr["Years"].ToString());
            }
            objGet.filteredDates = LstFilter;
            List<ClsSales> LstSalesDetail = new List<ClsSales>();
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                String BranchName = dr["Branche"].ToString();
                DataView dv = new DataView(ds.Tables[2]);
                dv.RowFilter = "BranchCode='" + BranchName + "'";

                ClsSales objSales = new ClsSales();

                objSales.Branch = BranchName;
                 List<decimal> LstSales = new List<decimal>();
                foreach (DataRow chr in dv.ToTable().Rows)
                {
                    objSales.Percentage = FNC.Conv(chr["Percentage"].ToString(), enDataType.DECIMAL);

                    LstSales.Add(FNC.Conv(chr["TotalSales"].ToString(), enDataType.DECIMAL));
                }
                objSales.Sales = LstSales;

                LstSalesDetail.Add(objSales);
            }
            objGet.LstSales = LstSalesDetail;
            return objGet; 
        }

        public DataSet ChartBarGet()
        {
            ClsChartMember objGet = new ClsChartMember();
            ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
            SqlParameter[] objParam = new SqlParameter[]
            {
                      new SqlParameter("@Branches",  ""  ),

            };
            var ds = objSql.ExecuteDataSet("Chart_Sales", objParam);

            return ds;

        }
        public static DataSet DashboardGet()
        {
            ClsChartMember objGet = new ClsChartMember();
            ClsSqlHelper objSql = new ClsSqlHelper(Helper.DBCONNTYPE.GetConnectionString);
 
            var ds = objSql.ExecuteDataSet("DashboardGet");

            return ds;

        }

        

    }
}
