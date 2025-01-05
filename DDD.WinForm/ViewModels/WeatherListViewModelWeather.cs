using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Entities;

namespace DDD.WinForm.ViewModels
{
    /// <summary>
    /// WeatherEntityで設定された値を、dgvに表示するにあたりどのような形で出すのかを決定するクラス
    /// </summary>
    public sealed class WeatherListViewModelWeather
    {
        private WeatherEntity _entity;
        public WeatherListViewModelWeather(WeatherEntity eintiry)
        {
            _entity = eintiry;
        }

        public string AreaId => _entity.AreaId.DsiplayValue;
        public string AreaName => _entity.AreaName;
        public string DataDate => _entity.DataDate.ToString();
        public string Condition => _entity.Condition.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }
}
