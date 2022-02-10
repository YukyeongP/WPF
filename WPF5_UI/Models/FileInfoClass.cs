using System.ComponentModel;

namespace WPF5_UI.Models
{
    public class FileInfoClass: INotifyPropertyChanged
    {
        public FileInfoClass()
        {
        }

        public FileInfoClass(string name)
        {
            FileName = name;
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                FileCount++;
                //if (_fileName.EndsWith(".dll"))
                //{
                //    DllFileName = _fileName;
                //    DllFileSize = _fileSize;
                //    DllFileCount++;
                //}
                //else if (_fileName.EndsWith(".exe"))
                //{
                //    ExeFileName = _fileName;
                //    ExeFileSize = _fileSize;
                //    ExeFileCount++;
                //}

                OnPropertyChanged(nameof(FileName));
            }
        }

        private int _filecount = 0;
        public int FileCount
        {
            get => _filecount;
            set
            {
                _filecount += value;
                OnPropertyChanged(nameof(FileCount));
            }
        }

        private long _fileSize = 0;
        public long FileSize
        {
            get => _fileSize;
            set
            {
                _fileSize += value;
                OnPropertyChanged(nameof(FileSize));
            }
        }

        private string _dllFileName;
        public string DllFileName
        {
            get => _dllFileName;
            set
            {
                _dllFileName = value;
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

        private long _dllfileSize = 0;
        public long DllFileSize
        {
            get => _dllfileSize;
            set
            {
                _dllfileSize += value;
                OnPropertyChanged(nameof(DllFileSize));
            }
        }

        private string _exeFileName;
        public string ExeFileName
        {
            get => _exeFileName;
            set
            {
                _exeFileName = value;
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

        private long _exefileSize = 0;
        public long ExeFileSize
        {
            get => _exefileSize;
            set
            {
                _exefileSize += value;
                OnPropertyChanged(nameof(ExeFileSize));
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

        //public override string ToString()
        //{
        //    return $"Filename: {FileName} DllFile: {DllFileName} ExeFile: {ExeFileName}";
        //}
    }
}
