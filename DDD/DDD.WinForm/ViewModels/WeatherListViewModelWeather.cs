using DDD.Domain.Entities;

namespace DDD.WinForm.ViewModels
{
    public class WeatherListViewModelWeather
    {
        private WeatherEntity entity;

        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            this.entity = entity;
        }

        public string AreaId => entity.AreaId.ToString();
        public string AreaName => entity.AreaName;
        public string DataDate => entity.DataDate.ToString();
        public string Condition => entity.Condition.DisplayValue;
        public string Temperature => entity.Temperature.DisplayValueWithUnitSpace;
    }
}
