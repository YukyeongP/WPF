using WPF4.ViewModels;
using System.Windows.Controls;

namespace WPF4.Views
{
    /// <summary>
    /// Interaction logic for MemListUserControl.xaml
    /// </summary>
    public partial class MemListUserControl : UserControl
    {
        public MemListUserControl()
        {
            InitializeComponent();
            DataContext = new MemListViewModel();
        }
    }
}
