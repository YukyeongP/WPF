using System.Windows;
using Prism.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF4.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {         
        //public ICommand SwitchViewCommand { get; }
        public ICommand RegisterMenu { get; set; }
        public ICommand UserListMenu { get; set; }

        public MainWindowViewModel()
        {
            RegisterMenu = new DelegateCommand(RegisterMenuBtnClick);
            UserListMenu = new DelegateCommand(UserListMenuBtnClick);

            AddMemUCIsVisible = Visibility.Visible;
            //MemListUCIsVisible = Visibility.Collapsed;
        }

        private Visibility _addMemUCIsVisible;
        public Visibility AddMemUCIsVisible
        {
            get
            {
                return _addMemUCIsVisible;
            }
            set
            {
                _addMemUCIsVisible = value;
                MemListUCIsVisible = (_addMemUCIsVisible == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;

                OnPropertyChanged(nameof(AddMemUCIsVisible));
            }
        }

        private Visibility _memListUCIsVisible;
        public Visibility MemListUCIsVisible
        {
            get
            {
                return _memListUCIsVisible;
            }
            set
            {
                _memListUCIsVisible = value;
                OnPropertyChanged(nameof(MemListUCIsVisible));
            }
        }

        public void RegisterMenuBtnClick()
        {
            AddMemUCIsVisible = Visibility.Visible;
        }

        public void UserListMenuBtnClick()
        {
            MemListUCIsVisible = Visibility.Visible;
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

        //private int switchView;
        //public int SwitchView
        //{
        //    get => switchView;
        //    set
        //    {
        //        switchView = value;
        //        OnPropertyChanged(nameof(SwitchView));
        //    }
        //}

        //private void OnSwitchView(object index)
        //{
        //    SwitchView = int.Parse(index.ToString());
        //}
    }
}
