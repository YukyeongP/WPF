using WPF3.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WPF3.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserInfo> UserList { get; } = new ObservableCollection<UserInfo>();
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}