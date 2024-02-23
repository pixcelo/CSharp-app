using OfficeOpenXml;
using System.Text;

namespace ExifExtracter
{
    public class ExcelService
    {
        public void OutputAsExcelFile(List<ExifData> list, string selectedDirName)
        {
            if (list.Count == 0)
            {
                return;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("exif");
                int row = 1;
                
                sheet.Cells[row, 1].Value = "Lat";
                sheet.Cells[row, 2].Value = "Lng";
                sheet.Cells[row, 3].Value = "Full paths";

                row = 2;

                foreach (var item in list)
                {
                    sheet.Cells[row, 1].Value = item.Lat;
                    sheet.Cells[row, 2].Value = item.Lng;
                    sheet.Cells[row, 3].Hyperlink = new Uri(item.Path);

                    // パスを分解して出力
                    int index = item.Path.IndexOf(selectedDirName);
                    string path = item.Path.Substring(index);
                    string[] dirs = path.Split(@"\");
                    int col = 4;

                    foreach (string dir in dirs)
                    {
                        sheet.Cells[row, col].Value = dir;
                        col++;
                    }

                    row++;
                }

                sheet.Cells.AutoFitColumns();

                var excelBytes = package.GetAsByteArray();                
                var downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
                var distPath = Path.Combine(downloadPath, "Exif.xlsx");
                File.WriteAllBytes(distPath, excelBytes);

                MessageBox.Show(distPath + Environment.NewLine + "ファイルを出力しました。");
            }
        }
    }
}
