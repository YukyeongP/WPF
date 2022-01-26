using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WPF4.Models;

namespace WPF4.ViewModels
{
    public class MemListViewModel
    {
        public ObservableCollection<UserInfo> Users { get; } = UserDataSource.GetUsers();
        public UserInfo selectedUser; 
        public Visibility IsVisible { get; set; }

        public MemListViewModel()
        {
        }

        private Visibility _visibilty;
        public Visibility Visibility
        {
            get
            {
                return _visibilty;
            }
            set
            {
                _visibilty = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }

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
