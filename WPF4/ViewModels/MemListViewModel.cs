using WPF4.Models;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using WPF4.Views;
using System;

namespace WPF4.ViewModels
{
    public class MemListViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<UserInfo> Users { get; } = UserDataSource.GetUsers();
        public ICommand Delete { get; set; }

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

        // SelctedUser를 MemListUserControl에 Binding 
        public MemListViewModel()
        {
            Delete = new DelegateCommand<object>(DeleteButtonClick);
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
