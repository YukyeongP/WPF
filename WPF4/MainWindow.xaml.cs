using WPF4.Model;
using System.Windows;
using WPF4.MainWindowViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
