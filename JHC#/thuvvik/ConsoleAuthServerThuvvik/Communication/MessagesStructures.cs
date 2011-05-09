using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace ConsoleAuthServerThuvvik.Communication
{

    // TR_WORD = unsigned short => ushort
    // TR_DWORD unsigned int    => uint
    // TR_BYTE = unsigned char  => Int32

    public static class OPCode     
    {
        public const Int32 AuthEAB = 0x02;
        public const Int32 AuthE = 0x01;
        public const Int32 AuthH = 0x00;
        public const Int32 AuthL = 0x00;
        public const Int32 AuthLO = 0x03;
        public const Int32 AuthRSL = 0x05;
        public const Int32 AuthSLE = 0x04;
        public const Int32 AuthSS = 0x02;
        public const Int32 AuthLP = 0x0C;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AuthHello // By Server
	{
        public ushort PacketLength;		// 0x0B
        public Int32 OPCode;			// 0x00
        public uint Unknown1;			// 0xDEAD0E01
        public uint Unknown2;			// 0x00
	};

    
	public struct AuthLogin // By Client
	{
        public ushort PacketLength;		// 0x32
        public Byte OPCode;				// 0x00
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30)]
        public Byte[] UserData;		    // Custom Encryption
        public UInt32 GameID;				// 0x08 hardcoded
        public ushort CDKey;				// 0x01 hardcoded
	};

    // ToDo: find payStat, remainTime, quotaTime, warnFlag, loginFlag
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct AuthLoginOk // By Server
    {
        public ushort PacketLength;		// 0x28
        public Int32 OPCode;				// 0x03
        public uint Unknown1;			// Used in ServerlistRequest and ServerRequest
        public uint Unknown2;			// Used in ServerlistRequest and ServerRequest
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;
        public uint Unknown6;
        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;
        public Int32 Unknown10;
    };
    
}
