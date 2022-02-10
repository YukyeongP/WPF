using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF5_UI.Models
{
    class ThreadTest
    {
        // 스레드 동기화 및 일시정지, 재시작
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private ManualResetEvent _pauseEvent = new ManualResetEvent(false);
        private Thread _thread;

        public ThreadTest(DriveInfo[] allDrives)
        {
            _thread = new Thread(new ParameterizedThreadStart(threadFunc));
            _thread.Start(allDrives[0]);
        }

        private void threadFunc(object drive)
        {
            while (_pauseEvent.WaitOne())
            {
                var drives = drive as DriveInfo;
                var rootDir = drives.RootDirectory.ToString();
                var searchClass = new SearchClass(rootDir);
                searchClass.StartSearch(rootDir, "*.dll|*.exe");
                Thread.Sleep(1000);
            }
        }

        // --------------------------------------------------------------------------------
        // 스레드 일시정지
        // --------------------------------------------------------------------------------
        public void pause()
        {
            _pauseEvent.Reset();
        }//end pause()

        // --------------------------------------------------------------------------------
        // 스레드 재시작
        // --------------------------------------------------------------------------------
        public void resume()
        {
            _pauseEvent.Set();
        }//end resume()

        // --------------------------------------------------------------------------------
        // 스레드 종료 준비, 동기화 이벤트 처리
        // --------------------------------------------------------------------------------
        public void readyEndThread()
        {
            _shutdownEvent.Set();
            _pauseEvent.Set();
        }//end endThread()
    }
}