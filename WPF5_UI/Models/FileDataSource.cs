using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace WPF5_UI.Models
{
    public class FileDataSource : INotifyPropertyChanged
    {
        public static ObservableCollection<FileInfoClass> _files { get; } = new ObservableCollection<FileInfoClass>();
        public static ObservableCollection<FileInfoClass> _dllFiles { get; } = new ObservableCollection<FileInfoClass>();
        public static ObservableCollection<FileInfoClass> _exeFiles { get; } = new ObservableCollection<FileInfoClass>();

        private int _filecount = _files.Count;
        public int FileCount
        {
            get => _filecount;
            set
            {
                _filecount = value;
                OnPropertyChanged(nameof(FileCount));
            }
        }

        public FileDataSource()
        {
        }
        
        public IEnumerable<FileInfoClass> AllFileList
        {
            get => _files;
        }
        public IEnumerable<FileInfoClass> DllFileList
        {
            get => _dllFiles;
        }
        public IEnumerable<FileInfoClass> ExeFileList
        {
            get => _exeFiles;
        }

        public static void AddFile(FileInfoClass file)
        {
            _files.Add(file);
            
            if (file.FileName.EndsWith(".dll"))
            {
                _dllFiles.Add(file);
            }
            else if (file.FileName.EndsWith(".exe"))
            {
                _exeFiles.Add(file);
                file.FileCount++;
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
