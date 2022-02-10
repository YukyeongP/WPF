//SearchClass.cs

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WPF5_UI.Models
{
    public class SearchClass
    {
        public string Path { get; set; }
        // public List<String> Extensions { get; set; } = new List<string>();

        public static FileInfoClass TargetFile { get; set; } = new FileInfoClass();
        public static FileInfoClass GetTargetFileInfo()
        {
            return TargetFile;
        }

        public static ConcurrentBag<FileInfoClass> TargetFiles { get; } = new ConcurrentBag<FileInfoClass>();
        public static ConcurrentBag<FileInfoClass> GetTargetFilesInfo()
        {
            return TargetFiles;
        }

        public SearchClass(string path)
        {
            Path = path;
        }

        public void StartSearch(string dir, string ext)
        {
            //InitExt(ext);
            var allFiles = GetAllFiles(dir, "*.*");
            FileInfo fileInfo;

            try
            {
                foreach (var file in allFiles)
                {
                    fileInfo = new FileInfo(file);
                    TargetFile.FileSize = fileInfo.Length;
                    TargetFile.FileName = file;
                    TargetFiles.Add(TargetFile);
                }
            }
            catch (Exception e)
            {
            }
        }

        /*
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
        */

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