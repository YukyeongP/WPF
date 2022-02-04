using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF4.Models;
using WPF4.ViewModels;

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
