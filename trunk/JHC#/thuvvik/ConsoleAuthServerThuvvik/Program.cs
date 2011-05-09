using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleAuthServerThuvvik.Configuration;
using ConsoleAuthServerThuvvik.DAL;
using System.Data;
using ConsoleAuthServerThuvvik.BLL;

namespace ConsoleAuthServerThuvvik
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.displayMessage(" ==============================================================================");
            Display.displayMessage(" ==============================================================================");
            Display.displayMessage("                                 Infinite Rasa                                 ");
            Display.displayMessage("                             Authentication Server                             ");
            Display.displayMessage("  Version 0.3 C#                                       http://infiniterasa.com/");
            Display.displayMessage(" ==============================================================================");
            Display.displayMessage(" Loading...");

            // Load .ini file as configuration
            IniParser iniparser = loadAndDisplayConfiguration();

            UserManager.dbTest(iniparser);

            ThreadManager tm = new ThreadManager();
            tm.createAndActivateNewClientWaiter();

            // wait for letter 'q', as to quit.
            Display.displayMessage("\n\nTapez 'q' pour Quitter");
            Display.waitForChar('q');
            tm.serverRunning = false;
            tm.joinAllThreads();

            //exit after all is terminated.
        }

        /// <summary>
        /// Load an ".ini" file into an IniParser object.
        /// And display configuration to Console reader
        /// </summary>
        /// <returns>Configuration file loaded, and organized.</returns>
        private static IniParser loadAndDisplayConfiguration()
        {
            // load file
            IniParser iniparser = new IniParser("config.ini");

            // display configuration to console reader
            foreach (String section in iniparser.getSections())
            {
                Display.displayMessage(String.Format("\n[{0}]", section));
                String[] keyNames = iniparser.EnumSection(section);
                foreach (String key in keyNames)
                {
                    Display.displayMessage(key, iniparser.GetSetting(section, key));
                }
            }

            return iniparser;
        }
    }
}
