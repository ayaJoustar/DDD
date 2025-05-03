using System.Windows;

namespace DDD.WPF.Services
{
    public interface IMessageService
    {
        void ShowDialog(string message);

        MessageBoxResult Question(string message);
    }
}
