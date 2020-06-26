using DataBase.Helpers;
using DataBase.Model.Table;
using DataBase.Service;
using DataBase.Service.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataBase.ViewModel
{
    public class DataBaseViewModel : BaseViewModel
    {
        #region Binding
        private ObservableCollection<string> _CategoriyForFinded;
        public ObservableCollection<string> CategoriyForFinded
        {
            get { return _CategoriyForFinded; }
            set { _CategoriyForFinded = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Gu12> _ListOfApplications;
        public ObservableCollection<Gu12> ListOfApplications
        {
            get { return _ListOfApplications; }
            set { _ListOfApplications = value; OnPropertyChanged(); }
        }  
        private ObservableCollection<Product> _ListProduct;
        public ObservableCollection<Product> ListProduct
        {
            get { return _ListProduct; }
            set { _ListProduct = value; OnPropertyChanged(); }
        }
        private Visibility _VisibilityGu12Base = Visibility.Visible;
        public Visibility VisibilityGu12Base
        {
            get { return _VisibilityGu12Base; }
            set { _VisibilityGu12Base = value; OnPropertyChanged(); }
        }  
        private bool _IsEnabledGu12Base = true;
        public bool IsEnabledGu12Base
        {
            get { return _IsEnabledGu12Base; }
            set { _IsEnabledGu12Base = value; OnPropertyChanged(); }
        } 
        private Visibility _VisibilityCreateTheProductPanel = Visibility.Hidden;
        public Visibility VisibilityCreateTheProductPanel
        {
            get { return _VisibilityCreateTheProductPanel; }
            set { _VisibilityCreateTheProductPanel = value; OnPropertyChanged(); }
        }  
        private bool _IsEnabledProductPanel = false;
        public bool IsEnabledProductPanel
        {
            get { return _IsEnabledProductPanel; }
            set { _IsEnabledProductPanel = value; OnPropertyChanged(); }
        }
        private double _WidthPanel;
        public double WidthPanel
        {
            get { return _WidthPanel; }
            set { _WidthPanel = value; OnPropertyChanged(); }
        } 
        private double _MaxWidthPanel = 250;
        public double MaxWidthPanel
        {
            get { return _MaxWidthPanel; }
            set { _MaxWidthPanel = value; OnPropertyChanged(); }
        } 
        private bool _IsCreatedProduct;
        public bool IsCreatedProduct
        {
            get { return _IsCreatedProduct; }
            set { _IsCreatedProduct = value; OnPropertyChanged(); }
        } 
        private string _IsCreatedSend;
        public string IsCreatedSend
        {
            get { return _IsCreatedSend; }
            set { _IsCreatedSend = value; OnPropertyChanged(); }
        }
        private string _NameProduct;
        public string NameProduct
        {
            get { return _NameProduct; }
            set { _NameProduct = value; OnPropertyChanged(); }
        } 
        private string _WeightProduct;
        public string WeightProduct
        {
            get { return _WeightProduct; }
            set { _WeightProduct = value; OnPropertyChanged(); }
        } 
        private string _IsCreatedSupplySchedule;
        public string IsCreatedSupplySchedule
        {
            get { return _IsCreatedSupplySchedule; }
            set { _IsCreatedSupplySchedule = value; OnPropertyChanged(); }
        } 
        private ComboBoxItem _SelectedItem;
        public ComboBoxItem SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }
        
        #endregion
        #region Service
        private DataBaseService _dataBaseService;
        private readonly SqlService _sqlService;
        #endregion
        private bool IsPanelCreated = false;
        public DataBaseViewModel(DataBaseService dataBaseService, SqlService sqlService)
        {
            _dataBaseService = dataBaseService;
            _sqlService = sqlService;
            _dataBaseService = new DataBaseService(new Gu12ControlerRepository(_sqlService));
            ListProduct = new ObservableCollection<Product>();
            ListOfApplications = new ObservableCollection<Gu12>();
        }
        private void LoadBase()
        {
            _dataBaseService.GetItems(db =>
            {
                ListOfApplications = db.Gu12s.Local;
            });
        }

        public ICommand ClickToCreateApplication => new DelegateCommand((obj) =>
        {
            Task.Run(() =>
            {
                for (double i = 0; i < 250.0; i += 0)
                {
                    i += 10;
                    WidthPanel = i;
                    Thread.Sleep(10);
                }
            });
            IsPanelCreated = true;
            HideGu12Base();
            VisibilityCreateTheProductPanel = Visibility.Visible;
            IsEnabledProductPanel = true;
            _dataBaseService = new DataBaseService(new ProductControlerRepository(_sqlService));
            _dataBaseService.GetItems((db) =>
            {
                var products = db.Products.Where(items => items.Id >= 0).ToList();
                foreach (var item in products)
                {
                    ListProduct.Add(item);
                }
            });
        }, (panel) => IsApllicationCreated(IsPanelCreated));
        public ICommand ClickToCreateProduct => new DelegateCommand((obj) =>
        {
            Product product = new Product()
            {
                NameProduct = NameProduct,
                WeightProduct = WeightProduct.ConvertToDouble(),
                DangerProduct = SelectedItem.Content.ToString()
            };
            _dataBaseService.InsertItem(product);
            _dataBaseService.GetItems((db) => ListProduct = db.Products.Local);
            IsCreatedProduct = true;
        });
        private void HideGu12Base()
        {
            VisibilityGu12Base = Visibility.Hidden;
            IsEnabledGu12Base = false;
        }
        private void ShowGu12Base()
        {
            VisibilityGu12Base = Visibility.Visible;
            IsEnabledGu12Base = true;
        }
        private bool IsApllicationCreated(bool created)
        {
            if (created == true)
            {
                return false;
            }
            return true;
        }
        private void ClearPanel()
        {
            IsCreatedProduct = false;
            IsCreatedSend = "";
            IsCreatedSupplySchedule = "";
        }
        public ICommand CancelPanel => new DelegateCommand((obj) =>
        {
            Task.Run(() =>
            {
                for (double i = 250.0; i > 0.0 ; i -= 0)
                {
                    i -= 10;
                    WidthPanel = i;
                    Thread.Sleep(10);
                }
            });
            ClearPanel();
            IsPanelCreated = false;
            ShowGu12Base();
            VisibilityCreateTheProductPanel = Visibility.Hidden;
            IsEnabledProductPanel = false;
        });
    }
}
