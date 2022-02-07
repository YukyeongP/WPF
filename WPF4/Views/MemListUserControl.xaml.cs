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

        public void TreeViewSelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
        {
            var vm = DataContext as MemListViewModel;
            if (e.NewValue is UserInfo userInfo)
            {
                vm.SelectedUser = userInfo;
            }
            else
            {
                vm.SelectedUser = null;
            }
        }
    }
}
