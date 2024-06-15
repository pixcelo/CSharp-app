using DDD.Domain.ValueObjects;
using System;

namespace DDD.WinForm.ViewModels
{
    /// <summary>
    /// 天気情報の登録画面のViewModel
    /// </summary>
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            this.DataDateValue = this.GetDataTime();
            this.SelectedCondition = Condition.Sunny.Value;
            this.TemperatureValue = string.Empty;
        }

        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureValue { get; set; }
    }
}
