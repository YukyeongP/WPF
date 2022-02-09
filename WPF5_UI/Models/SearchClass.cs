using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using WPF5_UI.Model;

namespace WPF5_UI.Models
{
    public class SearchClass
    {
        public static FileInfor TargetFile { get; set; } = new FileInfor();
        public string Path { get; set; }
        public List<String> Extensions { get; set; } = new List<string>();

        public SearchClass(string path)
        {
            Path = path;
        }

        public void StartSearch(string dir, string ext)
        {
            InitExt(ext);
         //   var allFiles = GetAllFiles(dir, "*.*");

            foreach (var file in GetAllFiles(dir, "*.*"))
            {
                //TargetFile.FileName = file;
                TargetFile.AllFileNames.Add(file);
                TargetFile.AllFileCount++;

                if (file.EndsWith(".dll"))
                {
                    TargetFile.DllFileName = file;
                    TargetFile.DllFileNames.Add(file);
                    TargetFile.DllFileCount++;
                }
                else if (file.EndsWith(".exe"))
                {
                    TargetFile.ExeFileName = file;
                    TargetFile.ExeFileCount++;
                }
            }
            //TargetFile.AllFileNameList = GetAllFiles(dir, "*.*");
        }

        public static FileInfor GetInfo()
        {
            return TargetFile;
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
            var ct = 0;
            return Directory.EnumerateFiles(path, searchPattern).Union(
                Directory.EnumerateDirectories(path).SelectMany(d =>
                {
                    try
                    {
                        var fileInfo = new FileInfo(path);
                        if (d.EndsWith(".dll"))
                        {
                         //   TargetFile.DllFileName = d;
                         //  TargetFile.DllFileCount++;   
                            TargetFile.DllFileVolume += fileInfo.Length;
                        }else if (d.EndsWith(".exe"))
                        {
                          //  TargetFile.ExeFileName = d;
                           // TargetFile.ExeFileCount++;
                            TargetFile.ExeFileVolume += fileInfo.Length;
                        }
                        ct++;

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
