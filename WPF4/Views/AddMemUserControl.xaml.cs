using System.Windows.Controls;
using WPF4.ViewModels;

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
    }
}
