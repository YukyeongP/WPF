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

        private Visibility _visibilty = Visibility.Visible;
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

        public void SetVisibility(bool visible)
        {
            if (visible)
                Visibility = Visibility.Visible;
            else
                Visibility = Visibility.Collapsed;
        }

        public void RegisterBtnClick()
        {
            UserDataSource.AddUser(NewUser);

            // MemListUserControl 보여주기
            this._visibilty = Visibility.Hidden;
        }

        private void CancelBtnClick()
        {
            // textbox reset
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
