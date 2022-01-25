using WPF4.Model;
using System.Windows;
using WPF4.MainViewModel;
using System.Windows.Input;
using System.Windows.Controls;

namespace WPF4
{
    /// <summary>
    /// Interaction logic for AddMemUserControl.xaml
    /// </summary>
    public partial class AddMemUserControl : UserControl
    {
        private MainWindowViewModel _viewModel;

        public UserInfo NewUser { get; set; }
        public ICommand Register { get; set; }

        public AddMemUserControl()
        {
            InitializeComponent();
            NewUser = new UserInfo();
            DataContext = NewUser;
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CancelBtnClick()
        {

        }
    }
}
