using System;
using System.IO;
using WPF5_UI.Models;
using Prism.Commands;
using System.Threading;
using System.Windows.Input;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPF5_UI.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int count = 0;
        private Thread thread;

        public static FileInfoClass FileInformation { get; } = SearchClass.GetTargetFileInfo();
        public static ConcurrentBag<FileInfoClass> FileInformationCollection { get; } = SearchClass.GetTargetFilesInfo();
        public ICommand PushButton { get; set; }

        public MainViewModel()
        {
            PushButton = new DelegateCommand<object>(ScanButtonClick);

            var allDrives = DriveInfo.GetDrives();
            thread = new Thread(new ParameterizedThreadStart(Working));
            if (count == 0)
            {
                thread.Start(allDrives[1]);
            }
        }

        public static void Working(object drive)
        {
            var drives = drive as DriveInfo;
            var rootDir = drives.RootDirectory.ToString();
            var searchClass = new SearchClass(rootDir);
            searchClass.StartSearch(rootDir, "*.dll|*.exe");
            MessageBox.Show("작업 종료");
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

        private bool _isRunning = true;
        public void ScanButtonClick(object obj)
        {
            _isRunning = !_isRunning;
            ButtonName = (ButtonName == "스캔 시작") ? "스캔 정지" : "스캔 시작";

            if (!_isRunning)
            {
                thread.Suspend();
            }
            else
            {
                try
                {
                    Thread.Sleep(30);
                    thread.Resume();
                }
                catch
                {
                }
            }
        }

        //public void ScanButtonClick2(object obj)
        //{
        //    count++;
        //    _isRunning = !_isRunning;
        //    _isRunning = true ? ButtonName == "스캔 정지" : ButtonName == "스캔 시작";

        //    if (count == 1)
        //    {
        //        var allDrives = DriveInfo.GetDrives();
        //        thread = new Thread(new ParameterizedThreadStart(Working));
        //        thread.Start(allDrives[0]);
        //    }

        //    if (!_isRunning)
        //    {
        //        thread.Suspend();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Thread.Sleep(30);
        //            thread.Resume();
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}

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

//