namespace ExifExtracter
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();            
        }
 
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {                    
                    textBoxPath.Text = Path.GetFullPath(ofd.SelectedPath);
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {            
            Run();
        }

        private void Run()
        {
            try
            {
                buttonRun.Enabled = false;

                if (!Directory.Exists(textBoxPath.Text))
                {
                    MessageBox.Show("フォルダが見つかりませんでした。");
                    return;
                }

                var er = new ExifReader();
                var list = er.GetExifDataList(textBoxPath.Text);

                var es = new ExcelService();
                string selectedDirName = Path.GetFileName(textBoxPath.Text);
                es.OutputAsExcelFile(list, selectedDirName);

            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Error);
            }
            finally
            {
                buttonRun.Enabled = true;
            }
        }

    }
}