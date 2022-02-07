using System;
using System.IO;

namespace WPF5
{
    class Program
    {
        public string Path;

        static void Main(string[] args)
        {
            var allDrives = DriveInfo.GetDrives();
            var rootDir = allDrives[0].RootDirectory.ToString();

            var a = new SearchClass(rootDir);
            a.StartSearch(rootDir, "*.*");
            a.WriteFile(rootDir);
        }
    }
}
