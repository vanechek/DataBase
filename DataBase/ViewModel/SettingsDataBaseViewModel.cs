using DataBase.Dependency_injection;
using DataBase.Helpers;
using DataBase.Model;
using DataBase.Service;
using DataBase.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace DataBase.ViewModel
{
    public class SettingsDataBaseViewModel : BaseViewModel
    {
        #region Binding
        private string _NameServerText = @"(localdb)\MSSQLLocalDB";
        public string NameServerText
        {
            get { return _NameServerText; }
            set { _NameServerText = value; OnPropertyChanged(); }
        }
        private string _NameDataBaseText = "Gu12";
        public string NameDataBaseText
        {
            get { return _NameDataBaseText; }
            set { _NameDataBaseText = value; OnPropertyChanged(); }
        }
        private string _UserNameText = "admin";
        public string UserNameText
        {
            get { return _UserNameText; }
            set { _UserNameText = value; OnPropertyChanged(); }
        }
        private string _UserPasswordText = "1234";
        public string UserPasswordText
        {
            get { return _UserPasswordText; }
            set { _UserPasswordText = value; OnPropertyChanged(); }
        }
        #endregion
        private readonly SqlService sqlService;
        private readonly PageService pageService;
        private MyDbContext myDbContext;
        public SettingsDataBaseViewModel(SqlService sqlService, PageService pageService)
        {
            this.sqlService = sqlService;
            this.pageService = pageService;
        }

        public ICommand ClickToConnect => new DelegateCommand((obj) =>
        {
            try
            {
                sqlService.CreateConnectionString(NameServerText, NameDataBaseText, UserNameText, UserPasswordText);
                myDbContext = new MyDbContext(sqlService.GetConnectionString());
                this.pageService.OnPageChanged(new AuthenticationPage());
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные от сервера", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
       
    }
}
