using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRLoginServer.src.Utils;
using TRLoginServer.src.Network.Client.Packets.Receive;

namespace TRLoginServer.src.Network.Client.Packets
{
    public class ClientPacketProcessor
    {
        private static SortedList<short, PacketType> packetList;

        public static void Initialize()
        {
            packetList = new SortedList<short,PacketType>();
            Logger.WriteLog("Registering packets", Logger.LogType.Initialize);
        }

        private static void RegisterPacket(PacketType packet)
        {
            Logger.WriteLog("Registering new packet: Opcode: " + packet.OpCode + " Name: " + packet.Name, Logger.LogType.Initialize);
            packetList.Add(packet.OpCode, packet);
        }

        private class PacketType
        {
            public string Name { get; private set; }
            public short OpCode { get; private set; }
            public Type Packet { get; private set; }

            public PacketType(string name, short opcode, Type packet)
            {
                Name = name;
                OpCode = opcode;
                Packet = packet;
            }
        }
    }
}
