using WPF3.ViewModel;
using System.Windows;

namespace WPF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void AddMemberBtnClick(object sender, RoutedEventArgs e)
        {
            var wnd = new UserWindow();
            wnd.Owner = this;
            if (wnd.ShowDialog() != true)
            {
                return;
            }

            _viewModel.UserList.Add(wnd.NewUser);
        }
        
         private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.UserList.Count > 0)
            {
                _viewModel.UserList.RemoveAt(UserlistBox.SelectedIndex);                
            }
        }
    }
}
