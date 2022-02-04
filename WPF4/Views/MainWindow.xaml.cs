using System.Windows;
using System.Windows.Controls;
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
            AddUserControl.Visibility = Visibility.Visible;
            MemListControl.Visibility = Visibility.Hidden;

            AddMemButton.Background = Brushes.LightSkyBlue;
            MemListButton.Background = Brushes.Transparent;
        }

        private void MemListBtnClick(object sender, RoutedEventArgs e)
        {
            MemListControl.Visibility = Visibility.Visible;
            AddUserControl.Visibility = Visibility.Hidden;

            MemListButton.Background = Brushes.LightSkyBlue;
            AddMemButton.Background = Brushes.Transparent;
        }
    }
}
