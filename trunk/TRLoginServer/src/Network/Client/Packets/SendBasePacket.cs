﻿using System;
using System.IO;


namespace TRLoginServer.src.Network.Client.Packets
{
    public abstract class SendBasePacket
    {
        private MemoryStream vStream;

        private GameClient vClient;
        public SendBasePacket(GameClient client)
        {
            vStream = new MemoryStream();
            vClient = client;
        }

        protected void WriteBytes(byte[] value)
        {
            vStream.Write(value, 0, value.Length);
        }

        protected void WriteBytes(byte[] value, int Offset, int Length)
        {
            vStream.Write(value, Offset, Length);
        }

        protected void WriteInteger(int value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteUInt(uint value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteChar(char value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteShort(short value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteDouble(double value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void WriteByte(byte value)
        {
            vStream.WriteByte(value);
        }

        protected void WriteString(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                WriteBytes(System.Text.Encoding.Unicode.GetBytes(value));
            }

            vStream.WriteByte(0);
            vStream.WriteByte(0);
        }

        protected void WriteLong(long value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void CutBytes(byte[] value, int Offset, int Length)
        {
            vStream = null;
            vStream = new MemoryStream();
            vStream.Write(value, Offset, Length);
        }

        public byte[] ToByteArray()
        {
            return vStream.ToArray();
        }

        public long Length
        {
            get{ return vStream.Length; }
        }

        public GameClient client
        {
            get { return vClient; }
        }

        protected internal abstract void Write();
    }
}
