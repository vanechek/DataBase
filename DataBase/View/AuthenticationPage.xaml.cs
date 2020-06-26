using DataBase.ViewModel;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace DataBase.View
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationPage.xaml
    /// </summary>
    public partial class AuthenticationPage : Page
    {
        public AuthenticationPage()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((AuthenticationViewModel)this.DataContext).SecureString = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
