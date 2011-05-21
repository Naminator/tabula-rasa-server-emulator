using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace JHLIB
{
    public unsafe class Blowfish
    {

        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Blowfish_Init(void* key, int keyLen);

        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Blowfish_Encrypt(uint* clearDWORD, uint *encryptedDWORD);

        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Blowfish_Decrypt(uint* encryptedDWORD, uint* clearDWORD);

        private static bool initialized = false;
        private static object cs = new object();

        //public struct BLOWFISH_CTX {
        //    uint[] P; //[16 + 2];
        //    uint[][] S; //[4][256];
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public struct BLOWFISH_CTX
        //{
        //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18)]
        //    public UInt32[] P;
        //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1024)]
        //    public UInt32[] S;
        //};

        //private static BLOWFISH_CTX BlowfishContext;
        
        private static void Init(string key)
            {
                try
                {
                    lock (cs) { // thread safety
                        //if (!initialized)
                        //{
                            IntPtr keyPtr = Marshal.StringToHGlobalAuto(key);

                            Blowfish_Init(IntPtr.Zero.ToPointer(), 0);

                            initialized = true;
                        //}
                    }
                    
                }
                catch (Exception)
                {
                    throw;
                }
                
            }

        //public static string Encrypt(string clearData, string key)
        //{
        //    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        //    Byte[] bytes = encoding.GetBytes(clearData);

        //    Byte[] encbytes = Encrypt(bytes, key);

        //    return encoding.GetString(encbytes);
        //}

        public static void Encrypt(byte[] bytes, string key)
        {
            // byte[] result = new byte[
            for (int p = 0; p < bytes.Length / 8; p++)
            {
                // Encrypt every dword
                uint dword1 = BitConverter.ToUInt32(bytes, p*8);
                uint dword2 = BitConverter.ToUInt32(bytes, (p*8)+4);
                
                Encrypt(dword1, dword2, key);
            }
        }

        // Safe Wrapper methods
        public static void Encrypt(uint dword1, uint dword2, string key) //string clearData, string key)
        {
            Init(key);

            //IntPtr clearDataPtr = Marshal.StringToHGlobalAuto(clearData); 
            //IntPtr clearDWORDPtr = Marshal.AllocHGlobal(2); // DWORD
            //Marshal.WriteInt32(clearDWORDPtr, clearDWORD);
                
            //UInt32 encryptedDWORD = 0x0000;
            //IntPtr encryptedDWORDPtr = Marshal.AllocHGlobal(2); // DWORD
            //Marshal.PtrToStructure(encryptedDWORDPtr, encryptedDWORD);

            //Blowfish_Encrypt(clearDWORDPtr.ToPointer(), encryptedDWORDPtr.ToPointer());
            // encryptedDWORD; // = 0x0000;

            //IntPtr encryptedDWORDPtr = Marshal.AllocHGlobal(4);
            //uint* ptr = (uint*)encryptedDWORDPtr.ToPointer();
            Blowfish_Encrypt((uint*)dword1, (uint*)dword2);

            //UInt32 encryptedDWORD = *ptr;

            //return encryptedDWORD;
        }

        //// Safe Wrapper methods
        //public static string Decrypt(byte[] encryptedData, string key)
        //{
        //    Init(key);

        //    IntPtr encryptedPtr = Marshal.StringToHGlobalAuto(encryptedData);

        //    IntPtr clearDataPtr = Marshal.AllocHGlobal(encryptedData.Length - 4);

        //    Blowfish_Decrypt(encryptedPtr.ToPointer(), clearDataPtr.ToPointer());

        //    return Marshal.PtrToStringAuto(clearDataPtr);
        //}

        public static bool Test()
        {
            bool passed = false;

            try
            {
                /*
                 * 	for(int p=0; p<(TotalLen-2)/8; p++)
	{
		Blowfish_Encrypt(&BlowfishContext, (unsigned long*)&SendBuffer[p*8+2], (unsigned long*)&SendBuffer[6 + p*8]);
	}*/
                string test = "I am your friend";
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(test);

                
                Encrypt(bytes, "");
                

                //passed = string.Compare(rawData, decryptedData) == 0;

            }
            catch (Exception)
            {
                throw;
            }

            return passed;

        }

    }
    //    // Marshal.PtrToStringAnsi(
    //    class Blowfish
    //    {
    //        public struct BLOWFISH_CTX {
    //          uint[] P; //[16 + 2];
    //          uint[][] S; //[4][256];
    //        }

    //        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
    //// (BLOWFISH_CTX *ctx, unsigned char *key, int keyLen)
    //        public static extern int Blowfish_Init(int a, int b);

    //        Blowfish_Init(BLOWFISH_CTX *ctx, unsigned char *key, int keyLen);
    //    Blowfish_InitOrg(BLOWFISH_CTX *ctx, unsigned char *key, int keyLen);
    //    Blowfish_Encrypt(BLOWFISH_CTX *ctx, uint xl, uint xr);
    //    Blowfish_Decrypt(BLOWFISH_CTX *ctx, uint xl, uint xr);

    //    }
}



