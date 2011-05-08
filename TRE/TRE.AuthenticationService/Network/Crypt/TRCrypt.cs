using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TRE.AuthenticationService.Network.Crypt
{
    public class TREncryptor {

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StartCrypt();

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void BFDecrypt(out System.UInt32 xl, out System.UInt32 xr);

        [DllImport("TRCrypt.dll", EntryPoint = "BFEncrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void BFEncrypt(out System.UInt32 xl, out System.UInt32 xr);

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void TREncrypt(out System.Byte Data, System.UInt32 Len);

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void TRDecrypt(out System.Byte Data, System.UInt32 Len);

        public static TREncryptor Instance = null;

        //@todo Proper Singleton implementation
        public static TREncryptor Init () {
            if (Instance == null) Instance = new TREncryptor();
            return Instance;
        }

        private TREncryptor()
        {
            StartCrypt();
        }

        public void BFDecrypt(byte[] encryptedData, out byte[] decryptedData)
        {
            // to be filled
            encryptedData = null;  decryptedData = null;
        }

        public void BFEncrypt(byte[] rawData, byte[] encryptedData)
        {
            // to be filled
            rawData = null; encryptedData = null;
        }

        public void Encrypt(ref byte[] data)
        {
            int totalLen = data.Length;
            byte[] SendBuffer = new byte[1024];
            Array.Copy(data, SendBuffer, data.Length);

            //Aligning to 8 bytes
            totalLen = totalLen + ((8 - ((totalLen - 2) % 8)) % 8);

            //Generate checsum
            uint checkSum = 0;
            for(int i=0; i<(totalLen-2)/4; i++)
            {
                checkSum ^= (uint)SendBuffer[i * 4 + 2];
            }

            SendBuffer[totalLen] = (byte)checkSum;
            SendBuffer[totalLen + 4] = 0;

            totalLen += 8;

            byte[] tmpBlock = new byte[totalLen];

            Buffer.BlockCopy(SendBuffer, 0, tmpBlock, 0, totalLen);
            data = tmpBlock;

            UInt32 leftBytes;
            UInt32 rightBytes;

            //Encrypt the packet
            for (int i = 0; i < (totalLen - 2) / 8; i++)
            {
                leftBytes = BitConverter.ToUInt32(data, 2 + i * 8);
                rightBytes = BitConverter.ToUInt32(data, 2 + i * 8 + 4);

                BFEncrypt(out leftBytes, out rightBytes);

                byte[] bytes1 = BitConverter.GetBytes(leftBytes);
                byte[] bytes2 = BitConverter.GetBytes(rightBytes);

                Array.Copy(bytes1, 0, data, 2 + i * 8, bytes1.Length);
                Array.Copy(bytes2, 0, data, 2 + i * 8 + 4, bytes2.Length);
            }
        }

        public void Decrypt(out UInt32 xl, out UInt32 xr)
        {
            BFDecrypt(out xl, out xr);
        }

        public void TREncrypt(byte[] data)
        {
            
        }

        public void TRDecrypt(byte[] data)
        {

        }
    }
}
