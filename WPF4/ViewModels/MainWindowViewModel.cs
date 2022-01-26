using WPF4.Views;
using Prism.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF4.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand RegisterMenu { get; set; }
        public ICommand UserListMenu { get; set; }

        public MainWindowViewModel()
        {
            RegisterMenu = new DelegateCommand(RegisterMenuBtnClick);
            UserListMenu = new DelegateCommand(UserListMenuBtnClick);
        }

        public void RegisterMenuBtnClick()
        {
            
        }

        public void UserListMenuBtnClick()
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
