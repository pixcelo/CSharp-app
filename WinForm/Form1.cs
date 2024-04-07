using System;
using System.Drawing;
using System.Web;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace SampleLog
{
    public partial class Form1 : Form
    {
        private static log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL = "https://qiita.com";
            var bitmap = GenerateQRcode(URL);

            pictureBoxQR.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxQR.Image = bitmap;
        }

        /// <summary>
        /// QRコード生成
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        private Bitmap GenerateQRcode(string URL)
        {
            var writer = new BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 1
                }
            };

            return writer.Write(URL);
        }
    }
}
