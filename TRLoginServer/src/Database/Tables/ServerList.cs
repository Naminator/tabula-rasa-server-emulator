using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using TRLoginServer.src.Utils;
using TRLoginServer.src.Database;
using TRLoginServer.src.Network.Gameserver;

using MySql.Data.MySqlClient;


namespace TRLoginServer.src.Database.Tables
{
    class ServerList
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
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                byte id = dr.GetByte(0);
                short port = dr.GetInt16(3);
                string name = dr.GetString(1);
                IPAddress serverAddr = IPAddress.Parse(dr.GetString(2));
                ushort onlineUsers = dr.GetUInt16(7);
                uint dateCreated = dr.GetUInt32(4);
                bool developerOnly = Convert.ToBoolean(dr.GetByte(6));

                GameServerList.Add(name, new GameServerInfo(id, name, serverAddr, port, onlineUsers, dateCreated, developerOnly));
            }

            dr.Close();
            cmd.Dispose();
        }

        public void ReloadServerList()
        {
            //@todo - Make this thing someday
        }
    }
}
