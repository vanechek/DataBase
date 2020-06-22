using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBase.Helpers
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string nameproperty = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameproperty));
        }
    }
}
