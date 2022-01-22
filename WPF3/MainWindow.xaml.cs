using System.Windows;

namespace WPF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserWindow _userWindow = null;

        public MainWindow()
        {
            InitializeComponent();
            AddMemBtn.Click += new RoutedEventHandler(AddMemberBtnClick);
        }

        public void UserWindowOnUserWindowTextInputEvent(UserInfo Parameters)
        {
            UserlistBox.Items.Add(Parameters);
            if (_userWindow != null)
            {
                _userWindow.Close();
                _userWindow.OnUserWindowTextInputEvent -= new UserWindow.OnUserWindowTextInputHandler(UserWindowOnUserWindowTextInputEvent);
                _userWindow = null;
            }
        }

        private void AddMemberBtnClick(object sender, RoutedEventArgs e)
        {
            if (_userWindow == null)
            {
                _userWindow = new UserWindow();
                _userWindow.OnUserWindowTextInputEvent += new UserWindow.OnUserWindowTextInputHandler(UserWindowOnUserWindowTextInputEvent);

                _userWindow.Top = this.Top + (this.ActualHeight - _userWindow.Height) / 2;
                _userWindow.Left = this.Left + (this.ActualWidth - _userWindow.Width) / 2;
                _userWindow.ShowDialog();
            }
        }

        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            UserlistBox.Items.RemoveAt(UserlistBox.SelectedIndex);
            UserlistBox.Items.Refresh();
        }
    }
}
