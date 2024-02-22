using ExcelAddIn.Services;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Windows.Forms;

namespace ExcelAddIn
{
	public partial class RibbonImage
	{
		private void RibbonImage_Load(object sender, RibbonUIEventArgs e)
		{

		}

		private void buttonImage_Click(object sender, RibbonControlEventArgs e)
		{
			try
			{
				var excelApp = Globals.ThisAddIn.Application;
				var workbook = excelApp.ActiveWorkbook;
				if (workbook != null)
				{
					string workbookPath = workbook.FullName;
					var imageService = new ImageService();
					bool result = imageService.SaveImagesFromWorkbook(workbookPath);
					if (result)
					{
						MessageBox.Show(
							"画像が正常に保存されました。",
							"成功",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show(
							"保存する画像が見つかりませんでした。",
							"警告",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"エラー: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
