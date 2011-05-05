using System;
using System.IO;


namespace TRE.AuthenticationService.Network.Client.Packets
{
    public abstract class OutboundPacket
    {
        private MemoryStream _stream;
        private GameClient _gameClient;

        public OutboundPacket(GameClient client)
        {
            _stream = new MemoryStream();
            _gameClient = client;
        }

        protected void WriteBytes(byte[] value)
        {
            _stream.Write(value, 0, value.Length);
        }

        protected void WriteBytes(byte[] value, int Offset, int Length)
        {
            _stream.Write(value, Offset, Length);
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
            _stream.WriteByte(value);
        }

        protected void WriteString(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                WriteBytes(System.Text.Encoding.Unicode.GetBytes(value));
            }

            _stream.WriteByte(0);
            _stream.WriteByte(0);
        }

        protected void WriteLong(long value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        protected void CutBytes(byte[] value, int Offset, int Length)
        {
            _stream = null;
            _stream = new MemoryStream();
            _stream.Write(value, Offset, Length);
        }

        public byte[] ToByteArray()
        {
            return _stream.ToArray();
        }

        public long Length
        {
            get{ return _stream.Length; }
        }

        public GameClient client
        {
            get { return _gameClient; }
        }

        protected internal abstract void Write();
    }
}
