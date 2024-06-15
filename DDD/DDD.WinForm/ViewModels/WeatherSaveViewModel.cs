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
        private IAreasRepository areas;

        public WeatherSaveViewModel(IAreasRepository areas)
        {
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
        }
    }
}
