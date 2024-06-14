using DDD.WinForm.Common;
using DDD.WinForm.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel viewModel = new WeatherLatestViewModel();

        public WeatherLatestView()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(this.AreaIdTextBox.Text)) return;

        //    var dataTable = WeatherSQLite.GetLatest(Convert.ToInt32(this.AreaIdTextBox.Text));

        //    if (dataTable.Rows.Count == 0)
        //    {
        //        this.DataDateLabel.Text = "データなし";
        //        this.ConditionLabel.Text = string.Empty;
        //        this.TemperatureLabel.Text = string.Empty;
        //        return;
        //    }

        //    this.DataDateLabel.Text = dataTable.Rows[0]["DataDate"].ToString();
        //    this.ConditionLabel.Text = dataTable.Rows[0]["Condition"].ToString();
        //    this.TemperatureLabel.Text =
        //        CommonFunc.RoundString(Convert.ToSingle(dataTable.Rows[0]["Temperature"]),
        //        CommonConst.TemperatureDigit)
        //        + CommonConst.TemperatureUnitName;            
        //}        
    }
}
