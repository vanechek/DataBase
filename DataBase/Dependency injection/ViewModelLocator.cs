using DataBase.Service;
using DataBase.ViewModel;

namespace DataBase.Dependency_injection
{
    public class ViewModelLocator
    {
        public static MainViewModel MainViewModel => DiContainer.GetViewModel<MainViewModel>();
        public static SettingsDataBaseViewModel SettingsDataBaseViewModel => DiContainer.GetViewModel<SettingsDataBaseViewModel>();
        public static AuthenticationViewModel AuthenticationViewModel => DiContainer.GetViewModel<AuthenticationViewModel>();
        public static DataBaseViewModel DataBaseViewModel => DiContainer.GetViewModel<DataBaseViewModel>();
    }
}
