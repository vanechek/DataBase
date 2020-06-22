using DataBase.Dependency_injection;
using DataBase.Helpers;
using DataBase.Model;
using DataBase.Model.Table;
using DataBase.Service;
using DataBase.View;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataBase.ViewModel
{
    public class AuthenticationViewModel : BaseViewModel
    {
        #region Bindings
        private string _LoginText;
        public string LoginText
        {
            get { return _LoginText; }
            set { _LoginText = value; OnPropertyChanged(); }
        }
        private string _PasswordText;
        public string PasswordText
        {
            get { return _PasswordText; }
            set { _PasswordText = value; OnPropertyChanged(); }
        }
        #endregion
        #region Command
        public ICommand ClickToOpenSettingsDataBase { get; }
        public ICommand ClickToAuthorization { get; }
        #endregion
        #region Serivce
        private readonly PageService pageService;
        private readonly SqlService sqlService;
        #endregion
        private MyDbContext myDbContext;
        public SecureString SecureString { private get; set; }
        public Thread Thread { get; set; }
        public AuthenticationViewModel(PageService pageService, SqlService sqlService)
        {
            this.sqlService = sqlService;
            this.pageService = pageService;
            ClickToOpenSettingsDataBase = new DelegateCommand((obj) => OpenSettingsDataBase());
            ClickToAuthorization = new DelegateCommand((obj) => Authorization(), (panel) => !string.IsNullOrEmpty(LoginText) && !string.IsNullOrEmpty(SecureString.ConvertSecureString()));
        }
        public void OpenSettingsDataBase()
        {
            this.pageService.OnPageChanged(new SettingDataBaseView());
        }
        public Task Authorization()
        {
            Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(sqlService.GetConnectionString()))
                {
                    using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
                    {
                        var password = SecureString.ConvertSecureString();

                        Users users = new Users()
                        {
                            Login = LoginText,
                            Password = PasswordText
                        };
                        var currentUser = myDbContext.Users.FirstOrDefault(account => account.Login == LoginText && account.Password == password);
                        if (currentUser != null)
                        {
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                pageService.OnPageChanged(new DataBaseView());
                                ViewModelLocator.MainViewModel.EnableSlideControl();
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы не подключились к базе данных", "Ошибка подключения к базе данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            return Task.Delay(100);
        }
    }
}
