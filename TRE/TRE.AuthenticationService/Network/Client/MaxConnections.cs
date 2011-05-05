using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

using System.Text;

using TRE.DataAccess.Common;

namespace TRE.AuthenticationService.Network.Client
{

    public class MaxConnections
    {
        private static SortedList<string, int> _connections;
        private static int _maxConnections = 100;

        public MaxConnections()
        {
            _connections = new SortedList<string, int>();
            Logger.WriteLog("Initialized MaxConnections", Logger.LogType.Initialize);
        }

        public static void AddConnection(EndPoint ipAddress)
        {
            //Fetch the IP Address
            string tempIP = ipAddress.ToString().Split(':')[0];
            if (!_connections.ContainsKey(tempIP))
            {
                _connections.Add(tempIP, 0);
            }
            else
            {
                _connections[tempIP]++;
            }
        }

        public static void Disconnect(EndPoint ipAddress)
        {
            string tempIP = ipAddress.ToString().Split(':')[0];
            if (_connections.ContainsKey(tempIP))
                _connections[tempIP]--;

            if ((_connections.ContainsKey(tempIP))
                && (_connections[tempIP] == 0))
            {
                _connections.Remove(tempIP); //No connections... remove it from the list
            }
        }

        public static bool AcceptConnection(EndPoint ipAddress)
        {
            MaxConnections.AddConnection(ipAddress);

            string tempIP = ipAddress.ToString().Split(':')[0];
            return (_connections[tempIP] <= _maxConnections);
        }
    }
}
