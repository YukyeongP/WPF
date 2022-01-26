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

        /* public string Name
         {
             get { return (string)GetValue(NameProperty); }
             set
             {
                 SetValue(NameProperty, value);
             }
         }

         private static DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(AddMemUserControl),
             new FrameworkPropertyMetadata(string.Empty,
                 FrameworkPropertyMetadataOptions.Inherits));*/
    }
}
