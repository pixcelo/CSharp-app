using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;

namespace ExcelAddIn.Services
{
	public class ImageService
	{
		public bool SaveImagesFromWorkbook(string workbookPath)
		{
			Application excelApp = null;
			Workbook workbook = null;

			try
			{
				excelApp = new Application();
				workbook = excelApp.Workbooks.Open(workbookPath);

				string saveDirectory = Path.Combine(
					Path.GetDirectoryName(workbookPath),
					Path.GetFileNameWithoutExtension(workbookPath) + "_Images");

				if (!Directory.Exists(saveDirectory))
				{
					Directory.CreateDirectory(saveDirectory);
				}

				int imageIndex = 0;
				foreach (Worksheet ws in workbook.Sheets)
				{
					foreach (Shape shape in ws.Shapes)
					{
						if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoPicture)
						{
							string imagePath = Path.Combine(saveDirectory, $"Image_{++imageIndex}.jpg");
							shape.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);

							if (Clipboard.ContainsImage())
							{
								var image = Clipboard.GetImage();
								image.Save(imagePath, ImageFormat.Png);
							}
						}
					}
				}

				return imageIndex > 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
				return false;
			}
			finally
			{
				if (workbook != null)
				{
					workbook.Close(false);
					Marshal.ReleaseComObject(workbook);
				}
				if (excelApp != null)
				{
					excelApp.Quit();
					Marshal.ReleaseComObject(excelApp);
				}
			}
		}

	}
}