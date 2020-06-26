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
        private string _IsConnecting;
        public string IsConnecting
        {
            get { return _IsConnecting; }
            set { _IsConnecting = value; OnPropertyChanged(); }
        }
        #endregion
        #region Serivce
        private readonly PageService pageService;
        private readonly SqlService sqlService;
        #endregion
        private MyDbContext myDbContext;
        public SecureString SecureString { private get; set; }
        public AuthenticationViewModel(PageService pageService, SqlService sqlService)
        {
            this.sqlService = sqlService;
            this.pageService = pageService;
        }
        #region Command
        public ICommand ClickToOpenSettingsDataBase => new DelegateCommand((obj) =>
        {
            this.pageService.OnPageChanged(new SettingDataBaseView());
        });
        public ICommand ClickToAuthorization => new DelegateCommand((obj) =>
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
                            MainViewModel.ControlUi(() =>
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
            }).Wait(100);
        }, (panel) => !string.IsNullOrEmpty(LoginText) && !string.IsNullOrEmpty(SecureString.ConvertSecureString()));
        #endregion
    }
}
