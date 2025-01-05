using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;

namespace DDD.WinForm.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        IWeatherRepository _weather;

        public WeatherListViewModel() :this(new WeatherSQLite())
        {
            
        }

        public WeatherListViewModel(IWeatherRepository　weather)
        {
            _weather = weather;

            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }
        }
        public BindingList<WeatherListViewModelWeather> Weathers { get; set; } = new BindingList<WeatherListViewModelWeather>();
    }
}
