using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using MySql.Data.MySqlClient;

using TRE.DataAccess.Common;
using TRE.DataAccess.Entities;

namespace TRE.DataAccess
{
    // this class will be obsolete when replaced by myBATIS
    public class ServerList
    {
        static ServerList instance = null;
        static readonly object padlock = new object();

        public static ServerList Instance
        {
            get { lock (padlock) { if (instance == null)instance = new ServerList(); return instance; } }
        }

        public SortedList<string, GameServerInfo> GameServerList { get; set; }

        public ServerList()
        {
            GameServerList = new SortedList<string, GameServerInfo>();
        }

        public void Initialize()
        {
            Logger.WriteLog("Loading the server list...", Logger.LogType.Initialize);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM servers", DatabaseFactory.Instance.GetDBConnection());

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    GameServerList.Add(dr.GetString(1), new GameServerInfo()
                    {
                        ServerID = dr.GetByte(0),
                        ServerName = dr.GetString(1),
                        ServerAddr = IPAddress.Parse(dr.GetString(2)),
                        ServerPort = dr.GetInt16(3),
                        OnlineUsers = dr.GetInt16(7),
                        DateCreated = dr.GetDateTime(4),
                        DeveloperOnly = Convert.ToBoolean(dr.GetByte(6))
                    });
                }

                dr.Close();
            }
        }

        public void ReloadServerList()
        {
            //@todo - Make this thing someday
        }
    }
}
