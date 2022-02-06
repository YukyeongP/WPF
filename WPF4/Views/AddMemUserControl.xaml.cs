using System.Windows.Controls;
using WPF4.ViewModels;
using System.Windows;
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
            // MemListUserControl로 전환
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            // MemListUserControl로 전환
            //this.Content = MemListUserControl.Instance.Content;
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
