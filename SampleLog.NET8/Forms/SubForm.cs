using SampleLog.NET8.Classes;

namespace SampleLog.NET8.Forms
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            var keyValue = new KeyValue<string>();
            keyValue.Key = "Key";
            keyValue.Value = "1";
        }
    }
}
