using WPF4.Models;
using Prism.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WPF4.ViewModels
{
    public class MemListViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<UserInfo> Users { get; } = UserDataSource.GetUsers();
        public ICommand Delete { get; set; }

        public MemListViewModel()
        {
            Delete = new DelegateCommand<object>(DeleteButtonClick);
        }

        private UserInfo selectedUser;
        public UserInfo SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public void DeleteButtonClick(object obj)
        {
            if (SelectedUser == null)
            {
                return;
            }
            Users.Remove(SelectedUser);
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
