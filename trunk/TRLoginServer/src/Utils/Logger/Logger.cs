using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace TRLoginServer.src.Utils
{
    public class Logger
    {
        public Logger()
        {

        }

        public enum LogType
        {
            Debug,
            AI,
            Network,
            Error,
            Test,
            Initialize,
            None
        }

        public static void WriteLog(string message, LogType type)
        {
            switch (type)
            {
                case LogType.AI:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[AI] " + message);
                    break;
                case LogType.Debug:
                    if (Config.DebugMode)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[Debug] " + message);
                    }
                    break;
                case LogType.Network:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[Network] " + message);
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[Error] " + message);
                    break;
                case LogType.Test:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[Test] " + message);
                    break;
                case LogType.Initialize:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("[Initialize] " + message);
                    break;
                case LogType.None:
                    Console.WriteLine(message);
                    break;
            }

            Console.ResetColor();
        }
    }
}
