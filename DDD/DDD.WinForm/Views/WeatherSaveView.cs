using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using DDD.WinForm.ViewModels;
using System;
using System.Windows.Forms;

namespace DDD.WinForm.Views
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel viewModel = new WeatherSaveViewModel();

        public WeatherSaveView()
        {
            InitializeComponent();

            this.DataBind();
        }

        private void DataBind()
        {
            // AreaIdComboBox
            this.AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaIdComboBox.DataBindings.Add(
                "SelectedValue", viewModel, nameof(viewModel.SelectedAreaId));
            this.AreaIdComboBox.DataBindings.Add(
                "DataSource", viewModel, nameof(viewModel.Areas));
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            // DataTimePickerの値をバインド
            this.DateTimeTextBox.DataBindings.Add(
                "Value", viewModel, nameof(viewModel.DataDateValue));

            // ConditionComboBox
            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ConditionComboBox.DataBindings.Add(
                "SelectedValue", viewModel, nameof(viewModel.SelectedCondition));
            this.ConditionComboBox.DataBindings.Add(
                "DataSource", viewModel, nameof(viewModel.Conditions));
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);

            this.TemperatureTextBox.DataBindings.Add(
                "Text", viewModel, nameof(viewModel.TemperatureValue));

            this.UnitLabel.DataBindings.Add(
                "Text", viewModel, nameof(viewModel.TemperatureUnitName));

            this.SaveButton.Click += (_, __) =>
            {
                try
                {
                    viewModel.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }
    }
}
