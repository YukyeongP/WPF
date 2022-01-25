using WPF3.Model;
using System.Windows;

namespace WPF3
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
   
    public partial class UserWindow : Window
    {
        public UserInfo NewUser { get; set; }

        public UserWindow()
        {
            InitializeComponent();
            NewUser = new UserInfo();
            DataContext = NewUser;
        }

        private void ConfirmBtnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
