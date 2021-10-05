using OfficeOpenXml;
using System.Data;
using System.Linq;

namespace CourierNew
{
    public static class ExcelPackageExtensions
    {
        public static DataTable ToDataTable(this ExcelPackage package,int iFromRow,int iFromColumn,int iToRow,int iToColumn)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable table = new DataTable();
            //workSheet.Dimension.End.Column
            foreach (var firstRowCell in workSheet.Cells[iFromRow, iFromColumn, iToRow, iToColumn])
            {
                table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = iFromRow+1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, iFromColumn, rowNumber, iToColumn];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                table.Rows.Add(newRow);
            }
            return table;
        }
    }
}