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
using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using TRLoginServer.src.Utils;
using System.Security.Cryptography;

namespace TRLoginServer.src.Network.Crypt
{
    public class CryptEngine
    {
        private bool updatedKey = true;
        private byte[] key;
        private BlowfishCipher cipher;

        public CryptEngine()
        {
            string realKey = @"[;'.]94-31==-%&@";
            string hex = "";
            foreach (char c in realKey)
            {
                int temp = c;
                hex += String.Format("{0:x2}", System.Convert.ToUInt32(temp.ToString()));
            }

            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            updateKey(bytes);

            cipher = new BlowfishCipher(key);
        }

        public void updateKey(byte[] key)
        {
            this.key = key;
        }

        public void Decrypt(byte[] data)
        {   
            cipher.Decrypt(data);
        }

        public byte[] Encrypt(byte[] data)
        {
            Array.Resize(ref data, data.Length + 4);
            Array.Resize(ref data, (data.Length + 8) - data.Length % 8);
            cipher.Encrypt(data);
            
            return data;
        }

        private bool VerifyChecksum(byte[] Data)
        {
            long chksum = 0;
            for (int i = 0; i < (Data.Length - 4); i += 4)
                chksum ^= BitConverter.ToUInt32(Data, i);
            return 0 == chksum;
        }

        private void AppendChecksum(byte[] Data)
        {
            uint chksum = 0;
            int count = Data.Length - 8;
            int i;
            for (i = 0; i < count; i += 4)
                chksum ^= BitConverter.ToUInt32(Data, i);
            Array.Copy(BitConverter.GetBytes(chksum), 0, Data, i, 4);
        }

        private void EncXORPass(byte[] Data, uint Key)
        {
            int stop = Data.Length - 8;
            uint ecx = Key;
            uint edx;

            for (int i = 4; i < stop; i += 4)
            {
                edx = BitConverter.ToUInt32(Data, i);
                ecx += edx;
                edx ^= ecx;
                Array.Copy(BitConverter.GetBytes(edx), 0, Data, i, 4);
            }
            Array.Copy(BitConverter.GetBytes(ecx), 0, Data, stop, 4);
        }

        public static string MD5Encryption(string Data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Data);
            data = x.ComputeHash(data);
            string ret = "";

            for (int i = 0; i < data.Length; i++) //XOR hash
                data[i] ^= 0x03;
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }
    }
}