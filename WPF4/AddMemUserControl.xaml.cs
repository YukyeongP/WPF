using WPF4.Model;
using System.Windows.Controls;

namespace WPF4
{
    /// <summary>
    /// Interaction logic for AddMemUserControl.xaml
    /// </summary>
    public partial class AddMemUserControl : UserControl
    {
        public UserInfo NewUser { get; set; }

        public AddMemUserControl()
        {
            InitializeComponent();
            NewUser = new UserInfo();
            DataContext = NewUser;
        }
    }
}
