using DataBase.Helpers;
using DataBase.Model.Table;
using DataBase.Service;
using DataBase.Service.Repository;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DataBase.ViewModel
{
    public class DataBaseViewModel : BaseViewModel
    {
        private ObservableCollection<string> _CategoriyForFinded;
        public ObservableCollection<string> CategoriyForFinded
        {
            get { return _CategoriyForFinded; }
            set { _CategoriyForFinded = value;OnPropertyChanged(); }
        }
        private DataBaseService _dataBaseService;
        private readonly SqlService _sqlService;
        public DataBaseViewModel(DataBaseService dataBaseService, SqlService sqlService)
        {
            _dataBaseService = dataBaseService;
            _sqlService = sqlService;
        }
        public ICommand ClickToCreateApplication => new DelegateCommand((obj) =>
        {
            _dataBaseService = new DataBaseService(new Gu12ControlerRepository(_sqlService));
        });
    }
}
