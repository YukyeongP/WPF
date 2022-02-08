using System.IO;
using System.Threading;
using System.Collections.Concurrent;

namespace WPF5
{
    class Program
    {
        public static ConcurrentBag<string> Bag { get; set; } = new ConcurrentBag<string>();

        static void Main(string[] args)
        {
            var allDrives = DriveInfo.GetDrives(); 
            
            foreach (DriveInfo drive in allDrives)
            { 
                var thread = new Thread(new ParameterizedThreadStart(Working));
                thread.Start(drive);
            }
        }

        public static void Working(object drive)
        {
            var drives = drive as DriveInfo;
            var rootDir = drives.RootDirectory.ToString();
            var searchClass = new SearchClass(rootDir);

            searchClass.StartSearch(rootDir, "*.dll|*.exe");
            searchClass.WriteFile(rootDir);

            searchClass.CollectFiles(Bag);
        }
    }
}
