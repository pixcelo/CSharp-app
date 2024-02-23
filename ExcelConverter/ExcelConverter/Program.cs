using Excel = Microsoft.Office.Interop.Excel;

class Program
{
	static void Main(string[] args)
	{
		// コマンドライン引数からファイルパスを取得
		// ExcelConverter.exe "C:\path\to\your\inputFile.xls" "C:\path\to\your\outputFile.xlsx"
		if (args.Length < 2)
		{
			Console.WriteLine("Usage: ExcelConverter <input file> <output file>");
			return;
		}
		string inputFile = args[0];
		string outputFile = args[1];

		var excelApp = new Excel.Application();
		Excel.Workbook workbook = null;

		try
		{
			// .xlsファイルを開く
			workbook = excelApp.Workbooks.Open(inputFile);

			// .xlsx形式で保存
			workbook.SaveAs(outputFile, Excel.XlFileFormat.xlOpenXMLWorkbook);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			if (workbook != null)
			{
				workbook.Close(false);
				excelApp.Quit();
			}

			// COMオブジェクトの解放
			System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
		}
	}
}
