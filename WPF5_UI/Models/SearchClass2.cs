using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF5_UI.Models
{
    class SearchClass2 : INotifyPropertyChanged
    {
        public string Path { get; set; }
        public List<String> Extensions { get; set; } = new List<string>();

        private string _allFileName;
        public string AllFileName 
        {
            get => _allFileName;
            set
            {
                _allFileName = value;
                //AllFileCount++;
                OnPropertyChanged(nameof(AllFileName));
            }
        }

        private int _allFileCount=0;
        public int AllFileCount
        {
            get => _allFileCount;
            set
            {
                _allFileCount = value;
                OnPropertyChanged(nameof(AllFileCount));
            }
        }

        public SearchClass2(string path)
        {
            Path = path;
        }

        public void StartSearch(string dir, string ext)
        {
            InitExt(ext);
            foreach (var file in GetAllFiles(dir, "*.*"))
            {
                AllFileName = file;
                AllFileCount++;

                //if (fileName.EndsWith(".dll"))
                //{
                //    DllFileList.ToList().Add(fileName);
                //    DllFileVolume += fileName.ToString().Length;
                //    DllFileCount++;
                //}
                //else if (fileName.EndsWith(".exe"))
                //{
                //    ExeFileList.ToList().Add(fileName);
                //    ExeFileVolume += fileName.ToString().Length;
                //    ExeFileCount++;
                //}
            }
//            AllFileNameList = GetAllFiles(dir, "*.*");

            //foreach (var fileName in AllFileNameList)
            //{
            //    AllFileVolume += fileName.ToString().Length;
            //    AllFileCount++;
            //}
        }

        private void InitExt(string ext)
        {
            ext = ext.Replace("*", "").Replace(".", "");

            if (ext.Contains('|'))
            {
                Extensions = ext.Split('|').ToList();
            }
            else
            {
                Extensions.Add(ext);
            }
        }

        private IEnumerable<String> GetAllFiles(string path, string searchPattern)
        {
            
            return Directory.EnumerateFiles(path, searchPattern).Union(
                Directory.EnumerateDirectories(path).SelectMany(d =>
                {
                    try
                    {
                        return GetAllFiles(d, searchPattern);
                    }
                    catch (Exception e)
                    {
                        return Enumerable.Empty<String>();
                    }
                }));
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
