using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPF4.Models
{
    public class UserDataSource : INotifyPropertyChanged
    {
        public static ObservableCollection<UserInfo> _users { get; } = new ObservableCollection<UserInfo>();

        public UserDataSource()
        {
        }
        public IEnumerable<UserInfo> UserList
        {
            get => _users;
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
            if (user.Name != null && user.Age != null && user.Sex != null) //
                _users.Add(user);
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
