using DDD.Domain.Entities;
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
            DataBind();
        }

        /// <summary>
        /// データソースの連動
        /// </summary>
        private void DataBind()
        {
            this.AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            // コンボボックスのデータソースを設定
            this.AreasComboBox.DataBindings.Add(
                "SelectedValue", viewModel, nameof(viewModel.SelectedAreaId));
            this.AreasComboBox.DataBindings.Add(
                "DataSource", viewModel, nameof(viewModel.Areas));
            // コンボボックスの内部的な値はValueMemberで設定
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            // コンボボックスの表示はDisplayMemberで設定
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            this.DataDateLabel.DataBindings.Add(
                "Text", viewModel, nameof(viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add(
                "Text", viewModel, nameof(viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add(
                "Text", viewModel, nameof(viewModel.TemperatureText));
        }

        /// <summary>
        /// 直近値ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LatestButton_Click(object sender, EventArgs e)
        {
            viewModel.Search();
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
