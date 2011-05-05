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
            RegisterPacket(new PacketType("Auth Login", 0x32, typeof(R_AuthLogin)));
        }

        private static void RegisterPacket(PacketType packet)
        {
            Logger.WriteLog("Registering new packet: Opcode: " + packet.OpCode.ToString("x4") + " Name: " + packet.Name, Logger.LogType.Initialize);
            packetList.Add(packet.OpCode, packet);
        }

        public static Type ProcessPacket(byte[] packet)
        {
            if (packetList.ContainsKey((short)packet[0]))
            {
                return packetList[(short)packet[0]].Packet;
            }
            else
            {
                Logger.WriteLog("Unknown incoming packet " + BitConverter.ToString(packet), Logger.LogType.Error);
                return null;
            }
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
