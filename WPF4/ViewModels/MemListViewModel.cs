using WPF4.Models;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;

namespace WPF4.ViewModels
{
    public class MemListViewModel
    {
        public ObservableCollection<UserInfo> Users { get; } = UserDataSource.GetUsers();
        public UserInfo SelectedUser;
        public ICommand Delete { get; set; }
        public Visibility IsVisible { get; set; }

        public MemListViewModel()
        {
            Delete = new DelegateCommand<object>(DeleteBtnClick);
        }

        public void DeleteBtnClick(object obj)
        {
            if (SelectedUser == null)
            {
                return;
            }

            Users.Remove(SelectedUser);
        }

        private Visibility _visibilty = Visibility.Hidden;
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
