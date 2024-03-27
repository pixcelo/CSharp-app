using System;
using System.Windows.Forms;

namespace SampleLog
{
    public partial class Form1 : Form
    {
        private static log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
            logger.Fatal("log1");
            logger.Error("log2");
            logger.Warn("log3");
            logger.Info("log4");
            logger.Debug("log5");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Debug("clicked");
        }
    }
}
