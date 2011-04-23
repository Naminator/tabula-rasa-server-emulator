﻿//
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
// details.
//
// You should have received a copy of the GNU General Public License along with
// this program. If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRLoginServer.src;
using TRLoginServer.src.Utils;

namespace TRLoginServer
{
    class Program
    {

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(ExitEventHandler handler, bool add);
        private delegate bool ExitEventHandler(byte sig);
        private static ExitEventHandler _handler;

        private static TRLoginServer.src.LoginServer login;
        private static DeadlockDetector deadLock;

        static void Main(string[] args)
        {
            Console.Title = "Tabula Rasa Auth Server";
            _handler += new ExitEventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            login = new TRLoginServer.src.LoginServer();
            login.Initialize();

            deadLock = new DeadlockDetector();
            if (!login.Start())
            {
                Logger.WriteLog("Unable to start the server!", Logger.LogType.Error);
                System.Threading.Thread.Sleep(5000);
                return;
            }

            Process.GetCurrentProcess().WaitForExit();
        }

        private static bool Handler(byte sig)
        {
            Logger.WriteLog("Shutting down the server...", Logger.LogType.None);
            login.Shutdown();
            return false; //bad things happen if true :)
        }
    }
}
