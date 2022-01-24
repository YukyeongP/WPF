using WPF3.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF3.Commands;
using Prism.Commands;

namespace WPF3.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserInfo> UserList { get; } = new ObservableCollection<UserInfo>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand DeleteBtn { get; set; }
        public int SelectedIndex { get; set; } //userlistbox

        public MainWindowViewModel()
        {
            DeleteBtn = new DelegateCommand(DeleteBtnClick);
        }

        private void DeleteBtnClick()
        {
            if (UserList.Count > 0)
            {
                UserList.RemoveAt(SelectedIndex);
            }
        }

    }
}
