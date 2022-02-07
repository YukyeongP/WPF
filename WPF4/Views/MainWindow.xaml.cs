using System.Windows;
using WPF4.ViewModels;
using DevExpress.Mvvm;
using System.Windows.Media;

namespace WPF4.Views
{
    public enum MainViewType
    {
        AddMemberView,
        MemberListView
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResetViewModel(MainViewType.AddMemberView);

            Messenger.Default.Register<string>(this, MessageReceived);
        }

        private void AddMemBtnClick(object sender, RoutedEventArgs e)
        {
            ResetViewModel(MainViewType.AddMemberView);

            Messenger.Default.Send("ColorAddMemButton"); //NavigateToAddMem
        }

        private void ResetViewModel(MainViewType viewType)
        {
            if (viewType == MainViewType.AddMemberView)
            {
                DataContext = new AddMemViewModel();
            }
            else
            {
                DataContext = new MemListViewModel();
            }
        }

        private void MemListBtnClick(object sender, RoutedEventArgs e)
        {
            ResetViewModel(MainViewType.MemberListView);

            Messenger.Default.Send("ColorMemListButton");
        }

        private void MessageReceived(string message)
        {
            if (message == "ToMemListControl")
            {
                ResetViewModel(MainViewType.MemberListView);
            }
            if (message == "ColorAddMemButton")
            {
                AddMemButton.Background = Brushes.Lavender;
                MemListButton.Background = Brushes.Transparent;
            }
            if (message == "ColorMemListButton")
            {
                MemListButton.Background = Brushes.Lavender;
                AddMemButton.Background = Brushes.Transparent;
            }
        }
    }
}
