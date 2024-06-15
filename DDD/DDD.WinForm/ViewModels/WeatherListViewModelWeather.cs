using DDD.Domain.Entities;

namespace DDD.WinForm.ViewModels
{
    /// <summary>
    /// 画面に表示する天気情報（各行はGridに文字列で表示する）
    /// </summary>
    public class WeatherListViewModelWeather
    {
        private WeatherEntity entity;

        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            this.entity = entity;
        }

        public string AreaId => entity.AreaId.DisplayValue;
        public string AreaName => entity.AreaName;
        public string DataDate => entity.DataDate.ToString();
        public string Condition => entity.Condition.DisplayValue;
        public string Temperature => entity.Temperature.DisplayValueWithUnitSpace;
    }
}
