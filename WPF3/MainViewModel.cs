using WPF3.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using Prism.Commands;
using System;
using System.Collections.Generic;

namespace WPF3.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserInfo> UserList { get; } = new ObservableCollection<UserInfo>();
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Delete { get; set; }
        public UserInfo SelectedUser { get; set; }

        public MainViewModel()
        {
            Delete = new DelegateCommand<object>(DeleteBtnClick);
        }

        public void DeleteBtnClick(object obj)
        {
            if (SelectedUser == null)
            {
                return;
            }

            UserList.Remove(SelectedUser);
        }

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