using WPF4.Models;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

namespace WPF4.ViewModels
{
    class AddMemViewModel
    {
        public UserInfo NewUser { get; } = new UserInfo();
        public ICommand Register { get; set; }
        //public UserInfo selectedUser;

        public Visibility IsVisible { get; set; }

        public AddMemViewModel()
        {
            Register = new DelegateCommand(RegisterBtnClick);
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

        public void RegisterBtnClick()
        {
            UserDataSource.AddUser(NewUser);           
        }

        private void CancelBtnClick()
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
