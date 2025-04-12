using System.Windows;
using DDD.Domain.Exceptions;
using DDD.WPF.Views;
using Prism.Ioc;

namespace DDD.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBoxImage icon = MessageBoxImage.Error;
            string caption = "エラー";

            if (e.Exception is ExceptionBase exceptionBase)
            {
                if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Info)
                {
                    icon = MessageBoxImage.Information;
                    caption = "情報";
                }
                else if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Warning)
                {
                    icon = MessageBoxImage.Warning;
                    caption = "警告";
                }
            }

            MessageBox.Show(e.Exception.Message, caption, MessageBoxButton.OK, icon);
            e.Handled = true;
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WeatherLatestView>();
        }
    }
}
