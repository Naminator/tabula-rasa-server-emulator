using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAuthServerThuvvik.Cryptography
{
    public class TRTeam_BlowFishProcess
    {
        BLOWFISH_CTX _ctx;
        public TRTeam_BlowFishProcess()
        {
            BFInit();
        }

        private void BFInit()
        {
            _ctx = new BLOWFISH_CTX();
            _ctx.P = new UInt32[18];
            _ctx.S = new UInt32[1024];

            // Convertir chaque groupe de 4 bytes (depuis BF_Transformed ou sdata) en Uint32 
            // à ranger dans P ou S (respectivement)

            for (int i = 0; i < 18; i++)
                _ctx.P[i] = BitConverter.ToUInt32(TRTeam_BlowFishDefaultStructures.BF_PTransformed, i * 4);

            for (int i = 0; i < 1024; i++)
                _ctx.S[i] = BitConverter.ToUInt32(TRTeam_BlowFishDefaultStructures.sdata, i * 4);
        }

        public void BFDecrypt(ref UInt32 pxL,ref UInt32 pxR)
        {
            UInt32 xL;
            UInt32 xR;
            UInt32 temp;
            
            xL = pxL;
            xR = pxR;

            for (uint i = TRTeam_BlowFishDefaultStructures.N + 1; i > 1; i--) 
            {
                xL = xL ^ _ctx.P[i];
                xR = F(xL) ^ xR;
		        temp = xL;
                xL = xR;
		        xR = temp;
            }

            temp = xL;
            xL = xR;
            xR = temp;
            xR = xR ^ _ctx.P[1];
            xL = xL ^ _ctx.P[0];

	        pxL = xL;
            pxR = xR;
        }

       public void BFEncrypt(ref UInt32 pxL,ref UInt32 pxR)
        {
	        UInt32 xL;
            UInt32 xR;
            UInt32 temp;

	        xL = pxL;
            xR = pxR;

            for (int i = 0; i < TRTeam_BlowFishDefaultStructures.N; i++) 
	        {
                xL = xL ^ _ctx.P[i];
                xR = F(xL) ^ xR;

                temp = xL;
                xL = xR;
                xR = temp;
	        }
            temp = xL;
            xL = xR;
            xR = temp;

            xR = xR ^ _ctx.P[TRTeam_BlowFishDefaultStructures.N];
            xL = xL ^ _ctx.P[TRTeam_BlowFishDefaultStructures.N + 1];
            pxL = xL;
            pxR = xR;
        }

        private UInt32 F(UInt32 x)
        {
	        uint a, b, c, d;
	        UInt32  y;

	        d = (uint)(x & 0xFF);
	        x >>= 8;
	        c = (uint)(x & 0xFF);
	        x >>= 8;
	        b = (uint)(x & 0xFF);
	        x >>= 8;
            a = (uint)(x & 0xFF);
            y = _ctx.S[0 * 256 + a] + _ctx.S[1 * 256 + b];
            y = y ^ _ctx.S[2 * 256 + c];
            y = y + _ctx.S[3 * 256 + d];

	        return y;
        }
    }
}
