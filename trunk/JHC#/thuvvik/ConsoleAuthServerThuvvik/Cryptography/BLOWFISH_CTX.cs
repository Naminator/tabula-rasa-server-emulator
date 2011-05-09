using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ConsoleAuthServerThuvvik.Cryptography
{
    struct BLOWFISH_CTX 
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18)]
        public UInt32[] P;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1024)]
        public UInt32[] S;       
    };
}
