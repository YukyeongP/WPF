using System;
using System.Collections.Generic;
using WPF4.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF4.MainViewModel
{
    class MainWindowViewModel
    {
        public ObservableCollection<UserInfo> UserInfo = new ObservableCollection<UserInfo>();

        public MainWindowViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
