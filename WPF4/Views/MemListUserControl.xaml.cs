using System;
using WPF4.Models;
using System.Windows;
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

        // 이 값을 MemListUserControl의 TbxName에 binding 
        public UserInfo TreeViewSelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
        {
            var selectedUser =new UserInfo();
            return selectedUser = (UserInfo)e.NewValue;

//            TbxName.Text = selectedUser.Name;
        }
    }
}
