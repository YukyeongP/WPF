using WPF4.Models;
using Prism.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF4.ViewModels
{
    public class AddMemViewModel:INotifyPropertyChanged
    {
        //public ICommand SwitchViewCommand { get; }
        public ICommand Register { get; set; }
        public ICommand Cancel { get; set; }

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

        public AddMemViewModel()
        {
            NewUser = new UserInfo();

            Register = new DelegateCommand(RegisterBtnClick);
            Cancel = new DelegateCommand(CancelBtnClick);
            //SwitchViewCommand = new DelegateCommand<object>(p => OnSwitchView(p));
        }

        public void RegisterBtnClick()
        {
            UserDataSource.AddUser(new UserInfo(NewUser.Name, NewUser.Address, NewUser.Sex, NewUser.Birthday, NewUser.Age, NewUser.PhoneNo, NewUser.Note));
            NewUser = new UserInfo();

            //usercontrol 전환
        }

        public void CancelBtnClick()
        {
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
