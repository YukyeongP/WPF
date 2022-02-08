using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WPF5
{
    class SearchClass
    {
        public string Path { get; set; }
        public IEnumerable<string> AllFiles;
        public List<String> Extensions { get; set; } = new List<string>();

        public SearchClass(string path)
        {
            Path = path;
        }

        private void InitExt(string ext)
        {
            ext = ext.Replace("*", "").Replace(".","");

            if (ext.Contains('|'))
            {
                Extensions = ext.Split('|').ToList();
            }
            else
            {
                Extensions.Add(ext); 
            }
        }

        public void StartSearch(string dir, string ext)
        {
            InitExt(ext);
            AllFiles = GetAllFiles(dir, "*.*");
        }

        public void WriteFile(string dir)
        {
            var originPath = @"D:\Output\";
            for (int i = 0; i < Extensions.Count; i++)
            {
                var savePath = originPath + dir[0] + "_" + Extensions[i] + ".txt";
                using (StreamWriter outputFile = new StreamWriter(savePath))
                {
                    var ct = 0;
                    foreach (var files in AllFiles.Where(s => s.EndsWith(Extensions[i])))
                    {
                        ct++;
                        outputFile.WriteLine(files);
                        if (ct == 1000) break;
                    }
                }
            }
        }

        public void CollectFiles(ConcurrentBag<string> bag)
        {
            object collectFilesLock = new object();
            var savePath = @"D:\Output\AllFile.txt";

            lock (collectFilesLock)
            {
                for (int i = 0; i < Extensions.Count; i++)
                {
                    using (StreamWriter outputFile = new StreamWriter(savePath))
                    {
                        var ct = 0;
                        foreach (var files in AllFiles.Where(s => s.EndsWith(Extensions[i])))
                        {
                            ct++;
                            bag.Add(files);
                            if (ct == 1000) break;
                        }
                    }
                }
            }
            File.WriteAllLines(savePath, bag);
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
