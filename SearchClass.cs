using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WPF5
{
    class SearchClass
    {
        public string Path;
        public IEnumerable<string> dllFiles;
        public IEnumerable<string> exeFiles;

        public SearchClass() { }
        public SearchClass(string path)
        {
            Path = path;
        }

        public void StartSearch(string dir, string file)
        {
            var allFiles = GetAllFiles(dir, file);
            dllFiles = allFiles.Where(s => s.EndsWith(".dll"));
            exeFiles = allFiles.Where(s => s.EndsWith(".exe"));
        }

        public void WriteFile(string dir)
        {
            var dllSavePath = @"C:\Users\byk11\Desktop\" + dir[0] + "_dll.txt";
            var exeSavePath = @"C:\Users\byk11\Desktop\" + dir[0] + "_exe.txt";

            using (StreamWriter outputFile = new StreamWriter(dllSavePath))
            {
                foreach (var dllFile in dllFiles)
                {
                    outputFile.WriteLine(dllFile);
                }
            }

            using (StreamWriter outputFile = new StreamWriter(exeSavePath))
            {
                foreach (var exeFile in exeFiles)
                {
                    outputFile.WriteLine(exeFile);
                }
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
