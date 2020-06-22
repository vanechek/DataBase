using DataBase.Service;
using System.Windows;

namespace DataBase
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DiContainer.Unit();
            base.OnStartup(e);
        }
    }
}
