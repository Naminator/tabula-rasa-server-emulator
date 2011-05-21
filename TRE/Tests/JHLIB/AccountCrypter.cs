using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace JHLIB
{
    public unsafe class AccountCrypter
    {

        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Tabula_CryptInit();

        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Tabula_Encrypt(void* Data, uint Len);

        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Tabula_Decrypt(void* Data, uint Len);

        private static bool initialized = false;
        private static object cs = new object();

        private static void init()
        {
            try
            {
                lock (cs) // thread-safe
                {
                    if (!initialized)
                    {
                        Tabula_CryptInit();
                        initialized = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Safe Wrapper methods
        public static string Encrypt(string data)
        {
            init();

            IntPtr dataPtr = Marshal.StringToHGlobalAuto(data);

            Tabula_Encrypt(dataPtr.ToPointer(), (uint)data.Length);

            return Marshal.PtrToStringAuto(dataPtr);
        }

        // Safe Wrapper methods
        public static string Decrypt(string data)
        {
            init();

            IntPtr dataPtr = Marshal.StringToHGlobalAuto(data);

            Tabula_Decrypt(dataPtr.ToPointer(), (uint)data.Length);

            return Marshal.PtrToStringAuto(dataPtr);
        }

        public static bool Test()
        {
            bool passed = false;

            try
            {
                string rawData = "Hello World";

                string encryptedData = Encrypt(rawData);

                string decryptedData = Decrypt(encryptedData);

                passed = string.Compare(rawData, decryptedData) == 0;

            }
            catch (Exception)
            {
                throw;
            }

            return passed;
        
        }

    }

}


	
