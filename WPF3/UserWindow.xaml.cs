using System.Windows;

namespace WPF3
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            ConfirmBtn.Click += new RoutedEventHandler(ConfirmBtnClick);
        }

        public delegate void OnUserWindowTextInputHandler(UserInfo Parameters);
        public event OnUserWindowTextInputHandler OnUserWindowTextInputEvent;

        private UserInfo GetUserInfo()
        {
            var _userInfo = new UserInfo(TbxName.Text, TbxAge.Text, TbxAddress.Text, TbxPhoneNo.Text);
            return _userInfo;
        }

        private void ConfirmBtnClick(object sender, RoutedEventArgs e)
        {
            if (OnUserWindowTextInputEvent != null)
            {
                OnUserWindowTextInputEvent(GetUserInfo());
            }
            TbxName.Text = "";
            TbxAge.Text = "";
            TbxAddress.Text = "";
            TbxPhoneNo.Text = "";
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            UserWindow.GetWindow(this).Close();
        }

        private bool IsAllInfor()
        {
            return TbxName.Text.Length > 0 && TbxAge.Text.Length > 0 && TbxAddress.Text.Length > 0 && TbxPhoneNo.Text.Length > 0;
        }
    }
}
