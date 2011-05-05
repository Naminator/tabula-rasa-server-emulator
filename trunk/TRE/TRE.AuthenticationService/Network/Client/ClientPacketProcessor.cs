using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Common;

using TRE.AuthenticationService.Network;
using TRE.AuthenticationService.Network.Client.Packets;
using TRE.AuthenticationService.Network.Client.Packets.Inbound;

namespace TRE.AuthenticationService.Network.Client
{
    

    public class ClientPacketProcessor
    {
        #region Singleton pattern implementation

        private ClientPacketProcessor() { }
        static ClientPacketProcessor _instance = null;
        public static ClientPacketProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClientPacketProcessor();
                }
                return _instance;
            }
        }

        #endregion

        internal class PacketType
        {
            public string Name { get; internal set; }
            public short OpCode { get; internal set; }
            public Type Type { get; internal set; }
        }

        SortedList<short, PacketType> _packets;

        public static void Initialize()
        {
            _instance._packets = new SortedList<short, PacketType>();
            Logger.WriteLog("Registering packets", Logger.LogType.Initialize);

            _instance.RegisterPacket(new PacketType()
            {
                Name = "Auth Login", 
                OpCode = 0x32, 
                Type = typeof(AuthLoginPacket)
            });
        }

        private void RegisterPacket(PacketType packet)
        {
            Logger.WriteLog("Registering new packet: Opcode: " + packet.OpCode.ToString("x4") + " Name: " + packet.Name, Logger.LogType.Initialize);
            _instance._packets.Add(packet.OpCode, packet);
        }

        public static Type ProcessPacket(byte[] packet)
        {
            Type type = null;

            if (_instance._packets.ContainsKey((short)packet[0]))
            {
                type = _instance._packets[(short)packet[0]].Type;
            }
            else
            {
                Logger.WriteLog("Unknown incoming packet " + BitConverter.ToString(packet), Logger.LogType.Error);
            }
            return type;
        }


        
    }
}
