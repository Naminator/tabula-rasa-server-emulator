// 
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
// details.
// 
// You should have received a copy of the GNU General Public License along with
// this program. If not, see <http://www.gnu.org/licenses/>.
// 
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using TRLoginServer.src.Utils;

namespace TRLoginServer.src.Network.Client.Packets
{
    public abstract class ReceiveBasePacket
    {
        private byte[] _Packet;
        private int _Offset;

        private GameClient _Client;
        public ReceiveBasePacket(GameClient client, byte[] packet)
        {
            _Client = client;
            _Packet = packet;
            _Offset = 1;
            Read();
        }

        public int Offset
        {
            get { return _Offset; }
            set { _Offset = value; }
        }

        public int ReadInteger()
        {
            int result = BitConverter.ToInt32(_Packet, _Offset);
            _Offset += 4;
            return result;
        }

        public byte ReadByte()
        {
            byte result = _Packet[_Offset];
            _Offset += 1;
            return result;
        }

        public byte[] ReadBytes(int Length)
        {
            byte[] result = new byte[Length];
            Array.Copy(_Packet, _Offset, result, 0, Length);
            _Offset += Length;
            return result;
        }

        public short ReadShort()
        {
            short result = BitConverter.ToInt16(_Packet, _Offset);
            _Offset += 2;
            return result;
        }

        public double ReadDouble()
        {
            double result = BitConverter.ToDouble(_Packet, _Offset);
            _Offset += 8;
            return result;
        }

        public string ReadString()
        {
            string result = "";
            try
            {
                result = System.Text.Encoding.Unicode.GetString(_Packet, _Offset, _Packet.Length - _Offset);
                int idx = result.IndexOf((char)0x00);
                if (!(idx == -1))
                {
                    result = result.Substring(0, idx);
                }
                _Offset += (result.Length * 2) + 2;
            }
            catch (Exception ex)
            {
                Logger.WriteLog("while reading string from packet, " + ex.Message + " " + ex.StackTrace, Logger.LogType.Error);
            }
            return result;
        }

        public GameClient Client
        {
            get { return _Client; }
        }

        public byte[] Packet
        {
            get { return _Packet; }
        }

        public abstract void Read();
        public abstract void Run();
    }
}