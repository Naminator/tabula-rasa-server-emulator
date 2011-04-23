using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace TRLoginServer.src.Utils
{
    public class ConfigFile
    {
        private FileInfo File;
        private SortedList<string, SortedList<string, string>> _topics;

        public ConfigFile(string path)
        {
            File = new FileInfo(path);
            _topics = new SortedList<string, SortedList<string, string>>();
            Reload();
        }

        public void Reload()
        {
            if (!File.Exists)
            {
                Logger.WriteLog("Unable to load the configuration file at " + File.FullName, Logger.LogType.Error);
                return;
            }

            StreamReader SR = new StreamReader(File.FullName);
            string curTopic = "";
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();

                //Few checks
                if (line.Length == 0) { continue; }
                if (line.StartsWith(";")) { continue; }

                //This is a new topic
                if (line.StartsWith("["))
                {
                    curTopic = line.Replace("[", "").Replace("]", "");
                    Logger.WriteLog("Topic added: " + curTopic, Logger.LogType.Initialize);

                    _topics.Add(curTopic, new SortedList<string, string>());
                    continue;
                }

                string value = "";

                for (int i = 1; i < line.Trim().Split('=').Length; i++)
                {
                    if (i == line.Trim().Split('=').Length - 1)
                    {
                        value += line.Trim().Split('=')[i];
                    }
                    else
                    {
                        value += line.Trim().Split('=')[i] + "=";
                    }
                }
                _topics[curTopic].Add(line.Trim().Split('=')[0], value);


            }
        }

        public string getProperty(string Topic, string Prop, string DefaultValue)
        {
            string ret = null;
            try
            {
                ret = _topics[Topic][Prop];
            }
            catch
            {
                ret = null;
                Logger.WriteLog("Trying to load unexistant property: "  + Prop + " in " + Topic, Logger.LogType.Error);
            }

            return (string.IsNullOrEmpty(ret) ? DefaultValue : ret);
        }
    }
}
