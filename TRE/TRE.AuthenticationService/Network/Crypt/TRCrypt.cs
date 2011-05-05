using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TRE.AuthenticationService.Network.Crypt
{
    class TREncryptor {

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StartCrypt();

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void BFDecrypt(out System.UInt32 xl, out System.UInt32 xr);

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void BFEncrypt(out System.UInt32 xl, out System.UInt32 xr);

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void TREncrypt(out System.Byte Data, System.UInt32 Len);

        [DllImport("TRCrypt.dll", EntryPoint = "StartCrypt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void TRDecrypt(out System.Byte Data, System.UInt32 Len);

        public static TREncryptor Instance = null;

        public TREncryptor Init () {
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

        public void TREncrypt(byte[] data)
        {
            
        }

        public void TRDecrypt(byte[] data)
        {

        }

        /*
         * static void Main(string[] args)
        {
            // Init cryptography arrays
            StartCrypt();
            // get the packet somewhere
            byte[] packet = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
            // our two unsigned longs
            System.UInt32 index1;
            System.UInt32 index2;
            // packet size
            int size = 0x32;
            // lets loop!
            for (int i = 0; i < (size - 2) / 8; i++)
            {
                // get the unsigned long from the bytes
                index1 = BitConverter.ToUInt32(packet, 2 + i * 8);
                index2 = BitConverter.ToUInt32(packet, 2 + i * 8 + 4);
                // decrypt the pointers
                BFDecrypt(out index1, out index2);
                // turn the unsigned longs into bytes
                byte[] bytes1 = BitConverter.GetBytes(index1);
                byte[] bytes2 = BitConverter.GetBytes(index2);
                // replace the bytes already decrypted
                Array.Copy(bytes1, 0, packet, 2 + i * 8, bytes1.Length);
                Array.Copy(bytes2, 0, packet, 2 + i * 8 + 4, bytes2.Length);
            }
        }
         */

    }
}
