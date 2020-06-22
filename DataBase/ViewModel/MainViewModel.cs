using DataBase.Helpers;
using DataBase.Service;
using DataBase.View;
using System.Windows;
using System.Windows.Controls;

namespace DataBase.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region привязка
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; OnPropertyChanged(); }
        }
        private Visibility _VisibilitySlideControl = Visibility.Hidden;
        public Visibility VisibilitySlideControl
        {
            get { return _VisibilitySlideControl; }
            set { _VisibilitySlideControl = value; OnPropertyChanged(); }
        }
        private bool _IsEnabledSlideControl = false;
        public bool IsEnabledSlideControl
        {
            get { return _IsEnabledSlideControl; }
            set { _IsEnabledSlideControl = value; OnPropertyChanged(); }
        }
        public double MinHeightCustomWindow { get; set; } = 300;
        public double MinWidthCustomWindow { get; set; } = 500;
        private double cornerRadius = 10;
        public double CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = value; }
        }
        public CornerRadius CornerRadiusCustomWindow { get { return new CornerRadius(CornerRadius); } }
        public double TitleHeight = 60;
        public GridLength TitleCustomWindow { get { return new GridLength(TitleHeight); } }
        private double ResizeBorderThickness { get; set; } = 6;
        public Thickness ResizeBorderThicknessCustomWindow { get { return new Thickness(ResizeBorderThickness); } }
        public double CaptionHeightCustomWindow { get; set; } = 60;
        #endregion
        #region комманды
        #endregion
        private PageService pageService;
        public void EnableSlideControl()
        {
            VisibilitySlideControl = Visibility.Visible;
            IsEnabledSlideControl = true;
        }
        public MainViewModel(PageService pageService)
        {
            this.pageService = pageService;
            this.pageService.PageChanged += (page) =>
            {
                CurrentPage = page;
            };
            this.pageService.OnPageChanged(new AuthenticationPage());
        }
    }
}
