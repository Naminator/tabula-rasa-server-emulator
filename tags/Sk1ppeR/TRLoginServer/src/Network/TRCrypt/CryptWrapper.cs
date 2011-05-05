using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TRLoginServer.src.Network.TRCrypt
{
    public class CryptWrapper
    {
        //Doesn't work no idea why
        [DllImport("TRCrypt.dll", EntryPoint="StartCrypt")]
	    private static extern void StartCrypt();
   
	    [DllImport("TRCrypt.dll", EntryPoint="BFDecrypt")]
	    private static extern void BFDecrypt(out uint xl, out uint xr);
   
	    [DllImport("TRCrypt.dll", EntryPoint="BFEncrypt")]
        private static extern void BFEncrypt(out System.UInt32 xl, out System.UInt32 xr);
   
        [DllImport("TRCrypt.dll", EntryPoint="TREncrypt")]
        private static extern void TREncrypt(out System.Byte Data, System.UInt32 Len);
   
	    [DllImport("TRCrypt.dll", EntryPoint="TRDecrypt")]
        private static extern void TRDecrypt(out System.Byte Data, System.UInt32 Len);

        public CryptWrapper()
        {
            StartCrypt();
        }

        public void BFDecrypt(uint xl, uint xr)
        {
            BFDecrypt(out xl, out xr);
        }
    }
}
