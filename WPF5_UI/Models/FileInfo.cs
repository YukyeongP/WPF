using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace WPF5_UI.Model
{
    public class FileInfor : INotifyPropertyChanged
    {
        private List<string> _allfileNames = new List<string>();
        public List<string> AllFileNames
        {
            get => _allfileNames;
            set
            {
                _allfileNames = value;
                OnPropertyChanged(nameof(AllFileNames));
            }
        }

        //private string _fileName;
        //public string FileName
        //{
        //    get => _fileName;
        //    set
        //    {
        //        _fileName = value;
        //        _allFileCount++;
        //        OnPropertyChanged(nameof(FileName));
        //    }
        //}

        private int _allFileCount = 0;
        public int AllFileCount
        {
            get => _allFileCount;
            set
            {
                _allFileCount = value;
                OnPropertyChanged(nameof(AllFileCount));
            }
        }

        private double _allFileVolume;
        public double AllFileVolume
        {
            get => _allFileVolume;
            set
            {
                _allFileVolume = value;
                OnPropertyChanged(nameof(AllFileVolume));
            }
        }

        private List<string> _dllfileNames = new List<string>();
        public List<string> DllFileNames
        {
            get => _dllfileNames;
            set
            {
                _dllfileNames = value;
                OnPropertyChanged(nameof(DllFileNames));
            }
        }

        private string _dllfileName;
        public string DllFileName
        {
            get => _dllfileName;
            set
            {
                _dllfileName = value;
                OnPropertyChanged(nameof(DllFileName));
            }
        }

        private int _dllFileCount = 0;
        public int DllFileCount
        {
            get => _dllFileCount;
            set
            {
                _dllFileCount = value;
                OnPropertyChanged(nameof(DllFileCount));
            }
        }

        private double _dllFileVolume;
        public double DllFileVolume
        {
            get => _dllFileVolume;
            set
            {
                _dllFileVolume = value;
                OnPropertyChanged(nameof(DllFileVolume));
            }
        }

        private string _exefileName;
        public string ExeFileName
        {
            get => _exefileName;
            set
            {
                _exefileName = value;
                OnPropertyChanged(nameof(ExeFileName));
            }
        }

        private int _exeFileCount = 0;
        public int ExeFileCount
        {
            get => _exeFileCount;
            set
            {
                _exeFileCount = value;
                OnPropertyChanged(nameof(ExeFileCount));
            }
        }

        private double _exeFileVolume;
        public double ExeFileVolume
        {
            get => _exeFileVolume;
            set
            {
                _exeFileVolume = value;
                OnPropertyChanged(nameof(ExeFileVolume));
            }
        }
        public FileInfor()
        {
            //if(AllFileNameList == null)
            //{
            //    return;
            //}

            //foreach (var fileName in AllFileNameList)
            //{
            //    AllFileVolume += fileName.ToString().Length;
            //    _allFileCount++;

            //    if (fileName.EndsWith(".dll"))
            //    {
            //        DllFileList.ToList().Add(fileName);
            //        DllFileVolume += fileName.ToString().Length;
            //        DllFileCount++;
            //    }
            //    else if (fileName.EndsWith(".exe"))
            //    {
            //        ExeFileList.ToList().Add(fileName);
            //        ExeFileVolume += fileName.ToString().Length;
            //        ExeFileCount++;
            //    }
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
