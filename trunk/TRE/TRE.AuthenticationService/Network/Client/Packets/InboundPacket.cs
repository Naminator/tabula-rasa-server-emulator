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

using TRE.DataAccess.Common;

namespace TRE.AuthenticationService.Network.Client.Packets
{
    public abstract class InboundPacket
    {
        public GameClient GameClient { get; private set; }
        public byte[] Data { get; private set; }
        public int Offset { get; set; }

        public InboundPacket(GameClient client, byte[] data)
        {
            this.GameClient = client;
            this.Data = data;
            this.Offset = 1;

            this.Read();
        }

        public abstract void Read();
        public abstract void Run();

        public int ReadInteger()
        {
            int result = BitConverter.ToInt32(this.Data, this.Offset);
            this.Offset += 4;
            return result;
        }

        public byte ReadByte()
        {
            byte result = this.Data[this.Offset];
            this.Offset += 1;
            return result;
        }

        public byte[] ReadBytes(int Length)
        {
            byte[] result = new byte[Length];
            Array.Copy(this.Data, this.Offset, result, 0, Length);
            this.Offset += Length;
            return result;
        }

        public short ReadShort()
        {
            short result = BitConverter.ToInt16(this.Data, this.Offset);
            this.Offset += 2;
            return result;
        }

        public double ReadDouble()
        {
            double result = BitConverter.ToDouble(this.Data, this.Offset);
            this.Offset += 8;
            return result;
        }

        public string ReadString()
        {
            string result = string.Empty;
            //try
            //{
            result = System.Text.Encoding.Unicode.GetString(this.Data, this.Offset, this.Data.Length - this.Offset);
            int idx = result.IndexOf((char)0x00);
            if (!(idx == -1))
            {
                result = result.Substring(0, idx);
            }
            this.Offset += (result.Length * 2) + 2;
            //}
            //catch (Exception ex)
            //{
            //Logger.WriteLog("while reading string from packet, " + ex.Message + " " + ex.StackTrace, Logger.LogType.Error);
            //}
            return result;
        }


    }
}