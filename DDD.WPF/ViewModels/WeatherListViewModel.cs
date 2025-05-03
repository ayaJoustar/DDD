using System.Collections.ObjectModel;
using System.Reflection;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using Prism.Commands;
using Prism.Mvvm;

namespace DDD.WPF.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        private readonly IWeatherRepository _weather;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public WeatherListViewModel(MainWindowViewModel mainWindowViewModel) : this(new WeatherSQLite(), mainWindowViewModel)
        {
            UpdateButton = new DelegateCommand(UpdateButtonExecute);
            DataGridSelectionChanged = new DelegateCommand(DataGridSelectionChangedExecute);
            DataGridMouseDoubleClick = new DelegateCommand(DataGridMouseDoubleClickExecute);
            _mainWindowViewModel = mainWindowViewModel;
        }

        public WeatherListViewModel(IWeatherRepository weather, MainWindowViewModel mainWindowViewModel)
        {
            _weather = weather;
            _mainWindowViewModel= mainWindowViewModel;

            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }
        }

        private ObservableCollection<WeatherListViewModelWeather> _weathers = new();
        public ObservableCollection<WeatherListViewModelWeather> Weathers
        {
            get { return _weathers; }
            set
            {
                SetProperty(ref _weathers, value);
            }
        }

        private WeatherListViewModelWeather _selectedWeather;

        public WeatherListViewModelWeather SelectedWeather
        {
            get { return _selectedWeather; }
            set
            {
                SetProperty(ref _selectedWeather, value);
            }
        }

        public DelegateCommand UpdateButton { get; }

        private void UpdateButtonExecute()
        {
            _mainWindowViewModel.StatusLabel = "検索しました。";
        }

        public DelegateCommand DataGridSelectionChanged { get; }

        private void DataGridSelectionChangedExecute()
        {

        }

        public DelegateCommand DataGridMouseDoubleClick { get; }

        private void DataGridMouseDoubleClickExecute()
        {

        }
    }
}
