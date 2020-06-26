using System.Windows;
using System.Windows.Shell;

namespace DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClickThenToCloseWindow.Click += (sender, e) => this.Close();
            ClickThenToHideWindow.Click += (sender, e) =>
            {
                if (this.IsActive == true && this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Minimized;

                }
            };
            ClickThenToMaximizedWindow.Click += (sender, e) =>
            {
                if (this.IsActive == true && this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };
        }
    }
}
