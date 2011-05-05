using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

using TRE.DataAccess.Common;

namespace TRE.AuthenticationService
{
    public class DeadlockDetector
    {
        static DeadlockDetector instance = null;
        static readonly object padlock = new Object();

        public static DeadlockDetector Instance
        {
            get { lock (padlock) { if (instance == null) { instance = new DeadlockDetector(); } return instance; } }
        }

        public Timer deadLock;

        public DeadlockDetector()
        {
            deadLock = new System.Threading.Timer(new TimerCallback(Detect), null, 0, 500);
            Logger.WriteLog("Initialized Deadlock Detector...", Logger.LogType.Initialize);
        }

        public static void Detect(object obj)
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach(ProcessThread thread in currentProcess.Threads)
            {
                if (thread.ThreadState == System.Diagnostics.ThreadState.Terminated ||
                    thread.ThreadState == System.Diagnostics.ThreadState.Unknown) //:O
                {
                    Logger.WriteLog("Deadlock detection at " + thread.Id + "," + thread.StartAddress, Logger.LogType.Error);
                }
            }
        }
    }
}
