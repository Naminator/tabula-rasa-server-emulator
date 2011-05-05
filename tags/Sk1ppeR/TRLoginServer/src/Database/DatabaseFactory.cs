using System;
using System.Collections.Generic;
using System.Text;

using TRLoginServer.src;
using TRLoginServer.src.Utils;

using MySql.Data.MySqlClient;

namespace TRLoginServer.src.Database
{
    public class DatabaseFactory
    {
        static DatabaseFactory instance = null;
        static readonly object padlock = new Object();

        public static DatabaseFactory Instance
        {
            get { lock (padlock) { if (instance == null)instance = new DatabaseFactory(); return instance; } }
        }

        private int _databaseBufferCount = 10;
        private Queue<MySqlConnection> _databaseQueue;

        public DatabaseFactory()
        {
            _databaseQueue = new Queue<MySqlConnection>();
        }

        public void Initialize()
        {
            Logger.WriteLog("Initialize Database Connection Pool...", Logger.LogType.Initialize);
            System.Threading.ThreadPool.QueueUserWorkItem(ProcessDatabaseQueue);
        }

        private void AddDbConnection(string ConnectionStrig)
        {
            try
            {
                MySqlConnection db = new MySqlConnection(ConnectionStrig);
                db.Open();
                _databaseQueue.Enqueue(db);
            }
            catch (MySqlException e)
            {
                Logger.WriteLog(e.Message, Logger.LogType.Error);
            }
            
        }

        private bool _processing = false;
        public void ProcessDatabaseQueue(Object obj)
        {
            if (_processing) { return; }
            _processing = true;
            while (_databaseQueue.Count < _databaseBufferCount)
            {
                AddDbConnection(MakeConnectionString());
            }
        }

        private string MakeConnectionString()
        {
            string connString = "";

            StringBuilder connectionBuilder = new StringBuilder();

            connectionBuilder.Append("SERVER=" + Config.DatabaseHost + ";");
            connectionBuilder.Append("DATABASE=" + Config.DatabaseName + ";");
            connectionBuilder.Append("UID=" + Config.DatabaseUser + ";");
            connectionBuilder.Append("PASSWORD=" + Config.DatabasePassword + ";");

            connString = connectionBuilder.ToString();

            return connString;
        }

        public MySqlConnection GetDBConnection()
        {
            try
            {
                MySqlConnection db;
                if (_databaseQueue.Count > 0)
                {
                    db = _databaseQueue.Dequeue();
                    System.Threading.ThreadPool.QueueUserWorkItem(ProcessDatabaseQueue);
                }
                else
                {
                    db = new MySqlConnection(MakeConnectionString());
                    db.Open();
                }

                return db;
            }
            catch (MySqlException e)
            {
                MySqlConnection db = new MySqlConnection();
                Logger.WriteLog(e.Message, Logger.LogType.Error);
                db.Dispose();

                return db;
            }
        }
    }
}
