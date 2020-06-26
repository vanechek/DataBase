using DataBase.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataBase.UserControls
{
    public class SlideControlModel : BaseViewModel
    {
        private double _WidthPanel = 30;
        public double WidthPanel
        {
            get { return _WidthPanel; }
            set { _WidthPanel = value; OnPropertyChanged(); }
        }
        private double _MinWidthSlideControl = 30;
        public double MinWidthSlideControl
        {
            get { return _MinWidthSlideControl; }
            set { _MinWidthSlideControl = value; OnPropertyChanged(); }
        }
        private double _MaxWidthSlideControl = 200;
        public double MaxWidthSlideControl
        {
            get { return _MaxWidthSlideControl; }
            set { _MaxWidthSlideControl = value; OnPropertyChanged(); }
        }
        private Visibility _SlideRightVisibility = Visibility.Collapsed;
        public Visibility SlideRightVisibility
        {
            get { return _SlideRightVisibility; }
            set { _SlideRightVisibility = value; OnPropertyChanged(); }
        }
        private Visibility _SlideLeftVisibility = Visibility.Visible;
        public Visibility SlideLeftVisibility
        {
            get { return _SlideLeftVisibility; }
            set { _SlideLeftVisibility = value; OnPropertyChanged(); }
        }
        public static SlideControlModel Instance => new SlideControlModel();
        public ICommand ClickToOpenCreateNewAppliaction { get; }
        public ICommand ClickToView { get; }
        public ICommand ClickToOpenCreateNewConsignment { get; }
        public ICommand ClickToSlideRight => new DelegateCommand(async (obj) =>
        {
            await Task.Run(() =>
            {
                SlideRightVisibility = Visibility.Collapsed;
                while (WidthPanel >= MinWidthSlideControl)
                {
                    WidthPanel -= 10;
                    Thread.Sleep(35);
                }
                SlideLeftVisibility = Visibility.Visible;
            });
        });

        public ICommand ClickToSlideLeft => new DelegateCommand(async (obj) =>
        {
            await Task.Run(() =>
            {
                SlideLeftVisibility = Visibility.Collapsed;
                while (WidthPanel <= MaxWidthSlideControl)
                {
                    WidthPanel += 10;
                    Thread.Sleep(35);
                }
                SlideRightVisibility = Visibility.Visible;
            });
        });
    }
}
