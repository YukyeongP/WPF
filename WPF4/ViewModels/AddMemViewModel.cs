using WPF4.Models;
using Prism.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF4.ViewModels
{
    public class AddMemViewModel:INotifyPropertyChanged
    {
        public ICommand Register { get; set; }
        public ICommand Cancel { get; set; }

        public AddMemViewModel()
        {
            NewUser = new UserInfo();

            Register = new DelegateCommand(RegisterBtnClick);
            Cancel = new DelegateCommand(CancelBtnClick);
        }

        private UserInfo _newUser;
        public UserInfo NewUser
        {
            get => _newUser;
            set
            {
                _newUser = value;
                OnPropertyChanged(nameof(NewUser));
            }
        }

        public void RegisterBtnClick()
        {
            UserDataSource.AddUser(new UserInfo(NewUser.Name, NewUser.Address, NewUser.Sex, NewUser.Birthday, NewUser.Age, NewUser.PhoneNo, NewUser.Note));
            NewUser = new UserInfo();
        }

        public void CancelBtnClick()
        {
            NewUser = new UserInfo();
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
