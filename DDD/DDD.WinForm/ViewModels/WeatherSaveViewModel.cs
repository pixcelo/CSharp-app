using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositoriers;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    /// <summary>
    /// 天気情報の登録画面のViewModel
    /// </summary>
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IWeatherRepository weather;
        private IAreasRepository areas;

        public WeatherSaveViewModel(
            IWeatherRepository weather,
            IAreasRepository areas)
        {
            this.weather = weather;
            this.areas = areas;
            this.DataDateValue = this.GetDataTime();
            this.SelectedCondition = Condition.Sunny.Value;
            this.TemperatureValue = string.Empty;

            foreach (var area in this.areas.GetData())
            {
                this.Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureValue { get; set; }
        public BindingList<AreaEntity> Areas { get; set; } = new BindingList<AreaEntity>();
        public BindingList<Condition> Conditions { get; set; } = new BindingList<Condition>(Condition.ToList());

        public void Save()
        {
            //if (this.SelectedAreaId == null)
            //{
            //    throw new InputException("エリアを選択してください");
            //}

            Guard.IsNull(this.SelectedAreaId, "エリアを選択してください");

            //float temperature;
            //if(!float.TryParse(this.TemperatureValue, out temperature))
            //{
            //    throw new InputException("温度の入力に誤りがあります");
            //}

            var temperature = Guard.IsFloat(this.TemperatureValue, "温度の入力に誤りがあります");

            var entity = new WeatherEntity(
                Convert.ToInt32(this.SelectedAreaId),
                this.DataDateValue,
                Convert.ToInt32(this.SelectedCondition),
                temperature);

            // 保存
            this.weather.Save(entity);
        }
    }
}
