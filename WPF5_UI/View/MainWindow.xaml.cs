using System.Windows;
using WPF5_UI.ViewModel;
using WPF5_UI.Models;
using System.Collections.ObjectModel;

namespace WPF5_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
