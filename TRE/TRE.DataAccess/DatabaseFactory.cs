using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

using TRE.DataAccess.Common;

namespace TRE.DataAccess
{
    // This class will be obsolete when replaced by myBATIS
    public class DatabaseFactory
    {
        static DatabaseFactory _instance = null;
        static readonly object _padlock = new Object();

        public static DatabaseFactory Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                        _instance = new DatabaseFactory();

                    return _instance;
                }
            }
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
            if (!_processing)
            {
                _processing = true;
                while (_databaseQueue.Count < _databaseBufferCount)
                {
                    this.AddDbConnection(Config.GetConnectionString());
                }
            }
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
                    db = new MySqlConnection(Config.GetConnectionString());
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
