using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPF4.Models
{
    public class UserDataSource : INotifyPropertyChanged
    {
        private static ObservableCollection<UserInfo> _users { get; } = new ObservableCollection<UserInfo>();
        public event PropertyChangedEventHandler PropertyChanged;

        public UserDataSource()
        {
        }
        public IEnumerable<UserInfo> UserList
        {
            get { return _users; }
        }

        public static ObservableCollection<UserInfo> GetUsers()
        {
            return _users;
        }

        public static void RemoveUser(UserInfo user)
        {
            _users.Remove(user);    
        }

        public static void AddUser(UserInfo user)
        {
            if (user != null)
                _users.Add(user);
        }       
    }
}
