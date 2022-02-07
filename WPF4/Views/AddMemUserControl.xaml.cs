using System.Windows;
using DevExpress.Mvvm;
using WPF4.ViewModels;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace WPF4.Views
{
    /// <summary>
    /// Interaction logic for AddMemUserControl.xaml
    /// </summary>
    public partial class AddMemUserControl : UserControl
    {
        public AddMemUserControl()
        {
            InitializeComponent();
            DataContext = new AddMemViewModel();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            // For switching usercontrol
            Messenger.Default.Send("ToMemListControl");
            Messenger.Default.Send("ColorMemListButton");
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("ToMemListControl");
            Messenger.Default.Send("ColorMemListButton");
        }
    }
    class SexSelection : ObservableCollection<string>
    {
        public SexSelection()
        {
            Add("남");
            Add("여");
        }
    }
}
