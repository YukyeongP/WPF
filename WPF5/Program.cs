using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace WPF5
{
    class Program
    {
        //private BlockingCollection<string> myBC;
        //public BlockingCollection<string> ProgramBc { get { return myBC; } }

        static void Main(string[] args)
        {
            var allDrives = DriveInfo.GetDrives(); 
            ConcurrentBag<string> bag = new ConcurrentBag<string>();

            foreach (DriveInfo drive in allDrives)
            { 
                var thread = new Thread(new ParameterizedThreadStart(Working));
                thread.Start(drive);
                //bag.Add();
            }

        }

        public static void Working(object drive)
        {
            var drives = drive as DriveInfo;
            var rootDir = drives.RootDirectory.ToString();
            var searchClass = new SearchClass(rootDir);

            searchClass.StartSearch(rootDir, "*.dll|*.exe");
            //searchClass.WriteFile(rootDir);

            //////////
            var bag = searchClass.CollectFiles2();
        }
    }
}
