using System.IO;
using WPF5_UI.Models;
using Prism.Commands;
using System.Threading;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WPF5_UI.Model;

namespace WPF5_UI.ViewModel
{
    class MainViewModel 
    {
        public static FileInfor FileInformation { get; } = SearchClass.GetInfo();

        public ICommand Pause { get; set; }
        public Thread thread;

        public MainViewModel()
        {
            var allDrives = DriveInfo.GetDrives();
            thread = new Thread(new ParameterizedThreadStart(Working));
            thread.Start(allDrives[0]);

            Pause = new DelegateCommand<object>(ScanButtonClick);
        }

        public static void Working(object drive)
        {
            var drives = drive as DriveInfo;
            var rootDir = drives.RootDirectory.ToString();

            var searchClass = new SearchClass(rootDir);
            searchClass.StartSearch(rootDir, "*.dll|*.exe");
        }

        public void ScanButtonClick(object obj)
        {
            thread.Interrupt();
        }
    }
}
