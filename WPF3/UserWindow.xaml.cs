using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF3
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        UserInfo userInfo1 = new UserInfo();
        List<UserInfo> userInfoList = new List<UserInfo>();

        public UserWindow()
        {
            InitializeComponent();
            ConfirmBtn.Click += new RoutedEventHandler(ConfirmBtnClick);//
        }

        public delegate void OnUserWindowTextInputHandler(List<UserInfo> Parameters);
        public event OnUserWindowTextInputHandler OnUserWindowTextInputEvent;

        private List<UserInfo> GetUserInfo()
        {
            userInfoList.Add(new UserInfo() { Name = TbxName.Text, Age = TbxAge.Text, Address = TbxAddress.Text, PhoneNo = TbxPhoneNo.Text });
            return userInfoList;
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
