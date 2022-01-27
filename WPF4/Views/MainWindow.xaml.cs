using System.Windows;
using System.Windows.Media;
using WPF4.ViewModels;

namespace WPF4.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void AddMemBtnClick(object sender, RoutedEventArgs e)
        {
            MemListControl.Visibility = Visibility.Hidden;
            AddUserControl.Visibility = Visibility.Visible;
        }

        private void MemListBtnClick(object sender, RoutedEventArgs e)
        {
            AddUserControl.Visibility = Visibility.Hidden;
            MemListControl.Visibility = Visibility.Visible;
        }
    }
}
