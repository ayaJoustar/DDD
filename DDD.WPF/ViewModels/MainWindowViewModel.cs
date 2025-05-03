using System;
using DDD.Domain;
using DDD.WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DDD.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            WeatherLatestButton = new DelegateCommand(WeatherLatestButtonExecute);
            WeatherListButton = new DelegateCommand(WeatherListButtonExecute);
            WeatherSaveButton = new DelegateCommand(WeatherSaveButtonExecute);

            Title = Shared.FakePath;
        }

        private string _title = "DDD";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _statusLabel = "--";
        public string StatusLabel
        {
            get { return _statusLabel; }
            set { SetProperty(ref _statusLabel, value); }
        }

        public DelegateCommand WeatherLatestButton { get; }

        private void WeatherLatestButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(WeatherLatestView));
        }

        public DelegateCommand WeatherListButton { get; }

        private void WeatherListButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(WeatherListView));
        }

        public DelegateCommand WeatherSaveButton { get; }

        private void WeatherSaveButtonExecute()
        {
            _dialogService.ShowDialog(nameof(WeatherSaveView), null, null);
        }
    }
}
