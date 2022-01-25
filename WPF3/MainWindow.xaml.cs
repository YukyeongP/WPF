using WPF3.ViewModel;
using System.Windows;

namespace WPF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
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
    }
}
