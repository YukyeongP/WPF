using System.ComponentModel;

namespace WPF5_UI.Models
{
    public class FileInfoClass: INotifyPropertyChanged
    {
        public FileInfoClass()
        {
        }
        
        private string _extension;
        public string Extension
        {
            get => _extension;
            set
            {

            }
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                if (_fileName.EndsWith(".dll"))
                {
                    DllFileName = _fileName;
                    DllFileSize = _fileSize;
                }
                else if (_fileName.EndsWith(".exe"))
                {
                    ExeFileName = _fileName;
                    ExeFileSize = _fileSize;
                }

                OnPropertyChanged(nameof(FileName));
            }
        }

        private long _fileCount = 0;
        public long FileCount
        {
            get => _fileCount;
            set
            {
                _fileCount = value;
                OnPropertyChanged(nameof(FileCount));
            }
        }


        private long _fileSize;
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
