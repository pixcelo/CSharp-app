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
        private readonly string ConnectionString = @"Data Source=C:\Users\bodom\Documents\csharp\DDD\DDD.db;Version=3;";

        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"
                SELECT DataDate, Condition, Temperature
                FROM Weather
                WHERE AreaId = @AreaId
                ORDER BY DataDate DESC
                LIMIT 1
                ";

            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(this.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", this.AreaIdTextBox.Text);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count == 0)
                {
                    this.DataDateLabel.Text = "データなし";
                    this.ConditionLabel.Text = string.Empty;
                    this.TemperatureLabel.Text = string.Empty;
                    return;
                }

                this.DataDateLabel.Text = dataTable.Rows[0]["DataDate"].ToString();
                this.ConditionLabel.Text = dataTable.Rows[0]["Condition"].ToString();
                // 小数点以下2桁で表示する
                this.TemperatureLabel.Text = 
                    Math.Round(Convert.ToSingle(dataTable.Rows[0]["Temperature"]), 2) + "℃";
            }
        }
    }
}
