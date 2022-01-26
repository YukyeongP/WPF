using System.Windows;
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

        // command, command parameter
        /*     private void selectViewModel(string name)
             {
                 if (name == "AddMemBtn")
                 {
                     DataContext = new AddMemViewModel();
                 }
                 if (name == "MemListBtn")
                 {
                     DataContext = new MemListViewModel();
                 }
             }
     */
        private void AddMemBtnClick(object sender, RoutedEventArgs e)
        {
            MemListUC.Visibility = Visibility.Hidden;
            AddUserUC.Visibility = Visibility.Visible;
        }

        private void MemListBtnClick(object sender, RoutedEventArgs e)
        {
            AddUserUC.Visibility = Visibility.Hidden;
            MemListUC.Visibility = Visibility.Visible;
        }
    }
}
