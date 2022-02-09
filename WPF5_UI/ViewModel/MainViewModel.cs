using System;
using System.IO;
using WPF5_UI.Models;
using Prism.Commands;
using System.Threading;
using System.Windows.Input;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace WPF5_UI.ViewModel
{
    class MainViewModel 
    {
        public static FileInfoClass FileInformation { get; } = SearchClass.GetTargetFileInfo();
        public static ConcurrentBag<FileInfoClass> FileInformationCollection { get; } = SearchClass.GetTargetFilesInfo();
        public ICommand PushButton { get; set; }
        public Thread thread;

        public MainViewModel()
        {
            var allDrives = DriveInfo.GetDrives();
            thread = new Thread(new ParameterizedThreadStart(Working));
            thread.Start(allDrives[0]);

            PushButton = new DelegateCommand<object>(ScanButtonClick);
        }

        public static void Working(object drive)
        {
            var drives = drive as DriveInfo;
            var rootDir = drives.RootDirectory.ToString();
            var searchClass = new SearchClass(rootDir);
            searchClass.StartSearch(rootDir, "*.dll|*.exe");
        }

        private string _buttonName = "스캔 시작";
        public string ButtonName
        {
            get => _buttonName;
            set
            {
                _buttonName = value;
                OnPropertyChanged(nameof(ButtonName));
            }
        }

        private bool _stop = false;
        public bool Stop
        {
            get => _stop;
            set
            {
                _stop = value;
                _stop = true ? ButtonName == "스캔 정지" : ButtonName == "스캔 시작";
                OnPropertyChanged(nameof(Stop));
            }
        }

        public int count = 0;
        public void ScanButtonClick(object obj)
        {
            count++;
            if (count % 2 == 1)
            {
                Stop = true;
                ButtonName = "스캔 정지";

               // Thread.Sleep(6000);
            }
            else
            {
                Stop = false;
                ButtonName = "스캔 시작";
            }
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
