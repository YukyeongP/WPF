using System.Collections.ObjectModel;

namespace WPF4.Models
{
    public class UserDataSource
    {
        private static ObservableCollection<UserInfo> _users = new ObservableCollection<UserInfo>();
        public UserDataSource()
        {
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
            _users.Add(user);
        }
    }
}
