using System;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace WPF5_UI.Models
{
    class SearchClass2
    {
        public string Path { get; set; }
        public List<String> Extensions { get; set; } = new List<string>();

        public static FileInfoClass TargetFile { get; set; } = new FileInfoClass();
        public static FileInfoClass GetTargetFileInfo()
        {
            return TargetFile;
        }

        //public static ObservableCollection<FileInfoClass> TargetFiles { get; set; } = new ObservableCollection<FileInfoClass>();
        //public static ObservableCollection<FileInfoClass> GetTargetFilesInfo()
        //{
        //    return TargetFiles;
        //}

        //public static FileDataSource TargetFileList { get; set; } = new FileDataSource();

        public SearchClass2(string path)
        {
            Path = path;
        }

        public void StartSearch(string dir, string ext)
        {
            object lockObject = new object();
            InitExt(ext);
            var allFiles = GetAllFiles(dir, "*.*");
            FileInfo fileInfo;
            
            try
            {
                foreach (var file in allFiles)
                {
                    fileInfo = new FileInfo(file);
                    TargetFile.FileSize = fileInfo.Length;
                    TargetFile.FileName = file; 
                    
                    DispatcherService.Invoke((Action)(() =>
                    {
                        lock (lockObject)
                        { 
                          //  TargetFiles.Add(TargetFile);
                            FileDataSource.AddFile(TargetFile);
                            TargetFile = new FileInfoClass();
                        }
                    }));
                }
            } catch
            {
            }
        }

        private void InitExt(string ext)
        {
            ext = ext.Replace("*", "");

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
    }

}
