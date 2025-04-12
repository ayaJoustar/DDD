using System;
using System.Collections.ObjectModel;
using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using Prism.Commands;
using Prism.Mvvm;

namespace DDD.WPF.ViewModels
{
    public class WeatherLatestViewModel : BindableBase
    {

        private IWeatherRepository _weather;
        IAreasRepository _areasRepository;

        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weather = weather;
            _areasRepository = areas;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

            LatestButton = new DelegateCommand(LatestButtonExecute);
        }

        private ObservableCollection<AreaEntity> _areas = new ObservableCollection<AreaEntity>();
        public ObservableCollection<AreaEntity> Areas
        {
            get { return _areas; }
            set
            {
                SetProperty(ref _areas, value);
            }
        }

        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                SetProperty(ref _selectedArea, value);
            }
        }
        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                SetProperty(ref _dataDateText, value);
            }
        }
        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                SetProperty(ref _conditionText, value);
            }
        }
        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

        public DelegateCommand LatestButton { get; }

        private void LatestButtonExecute()
        {
            if(SelectedArea == null)
            {
                throw new InputException("地域を選択してください。");
            }

            var entity = _weather.GetLatest(SelectedArea.AreaId);
            if (entity == null)
            {
                DataDateText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }

            //空文字にしたら全てのプロパティに適用される
            //OnPropertyChanged("");
        }
    }
}
