using DDD.Domain.Repositoriers;
using DDD.Infrastracture.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        private IWeatherRepository weather;

        public WeatherListViewModel() : this(new WeatherSQLite())
        {      
        }

        public WeatherListViewModel(IWeatherRepository weather)
        {
            this.weather = weather;

            foreach (var entity in weather.GetData())
            {
                this.Weathers.Add(new WeatherListViewModelWeather(entity));
            }
        }

        public BindingList<WeatherListViewModelWeather> Weathers { get; set; }
            = new BindingList<WeatherListViewModelWeather>();
    }
}
