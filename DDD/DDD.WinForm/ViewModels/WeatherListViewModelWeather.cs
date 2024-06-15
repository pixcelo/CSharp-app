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
    }
}
