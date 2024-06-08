using DDD.WinForm.Common;
using DDD.WinForm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.AreaIdTextBox.Text)) return;

            var dataTable = WeatherSQLite.GetLatest(Convert.ToInt32(this.AreaIdTextBox.Text));

            if (dataTable.Rows.Count == 0)
            {
                this.DataDateLabel.Text = "データなし";
                this.ConditionLabel.Text = string.Empty;
                this.TemperatureLabel.Text = string.Empty;
                return;
            }

            this.DataDateLabel.Text = dataTable.Rows[0]["DataDate"].ToString();
            this.ConditionLabel.Text = dataTable.Rows[0]["Condition"].ToString();               
            this.TemperatureLabel.Text =
                CommonFunc.RoundString(Convert.ToSingle(dataTable.Rows[0]["Temperature"]),
                CommonConst.TemperatureDigit)
                + CommonConst.TemperatureUnitName;            
        }        
    }
}
