using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConsoleAuthServerThuvvik.DAL
{
    public class MySqlManager
    {
        private MySqlConnection _conn;


        public MySqlManager(String pServerAddress, String pPortNumber, String pDatabaseName, String pUserName, String pPassword)
        {
            createConnection(pServerAddress, pPortNumber, pDatabaseName, pUserName, pPassword);
        }
        
        private void createConnection(String pServerAddress, String pPortNumber, String pDatabaseName, String pUserName, String pPassword) 
        {
            _conn = new MySqlConnection(String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",pServerAddress,pPortNumber,pDatabaseName,pUserName,pPassword));
        }

        // connect to Mysql database
        private void connect()
        {
            if ((_conn!=null) && (_conn.State != ConnectionState.Open))
                _conn.Open();
        }

        // disconnect from Mysql database
        private void disconnect()
        {
            if ((_conn != null) && (_conn.State != ConnectionState.Closed))
                _conn.Close();
        }

        // query database for multiple row result
        public DataTable queryMultipleRows(String pQuery) 
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                MySqlDataAdapter da = new MySqlDataAdapter(pQuery, _conn);
                da.Fill(dt);
            }
            finally
            {
                disconnect();
            }
            return dt;
        }

        //query insert
        public void queryCommand(String pQuery)
        {
            
            try
            {
                connect();
                MySqlCommand com = new MySqlCommand(pQuery, _conn);
                com.ExecuteNonQuery();
            }
            finally
            {
                disconnect();
            }
        }
    }
}
