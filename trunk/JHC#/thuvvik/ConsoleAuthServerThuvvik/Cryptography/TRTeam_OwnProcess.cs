using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleAuthServerThuvvik.Communication;

namespace ConsoleAuthServerThuvvik.Cryptography
{
    public class TRTeam_OwnProcess
    {
        private Byte[] _OutputData_D1E4E8 = new Byte[128*16];
        private Byte[] _OutputData_D22D48 = new Byte[128*16];

        private Byte[] DecArrayOut3_D1ECE8 = new Byte[4096 * 4];

        private TRTeam_OwnDefaultStructures._DecStruct1T[] DecStruct1 = new TRTeam_OwnDefaultStructures._DecStruct1T[16];
        private TRTeam_OwnDefaultStructures._DecStruct2T[] DecStruct2_CEA1B0 = new TRTeam_OwnDefaultStructures._DecStruct2T[8];
        private TRTeam_OwnDefaultStructures._DecStruct3T[] DecStruct3_D1D4B0 = new TRTeam_OwnDefaultStructures._DecStruct3T[4];

        public TRTeam_OwnProcess()
        {           
            for(int i =0; i<8; i++)
                this.DecStruct2_CEA1B0[i] = StructureOperations.RawDeserialize<TRTeam_OwnDefaultStructures._DecStruct2T>(TRTeam_OwnDefaultStructures.CEA1B0_DATA, i*64);
            for (int i = 0; i < 4; i++)
                this.DecStruct3_D1D4B0[i] = new TRTeam_OwnDefaultStructures._DecStruct3T(TRTeam_OwnDefaultStructures.STRUCT_INIT);
            TRInit();
        }

        private void TRInit()
        {
            TRPrepareBasic(ref this._OutputData_D22D48, TRTeam_OwnDefaultStructures.InputData_0CEA0B8);
            TRPrepareBasic(ref this._OutputData_D1E4E8, TRTeam_OwnDefaultStructures.InputData_0CEA0F8);

            Byte[] Key64 = UnicodeEncoding.UTF8.GetBytes(new char[] {'T','E','S','T','\0','\0','\0','\0'});
            TRKeyIntegrate(Key64);
            TRKeyIntegrate2();
            TRKeyIntegrate3();
        }

        private  void TRKeyIntegrate3()
        {
	        int v4;
	        int v5;

	        for (int v1=0; v1 < 4; v1++ )
		        for (int v2=0;v2 < 256; v2++)
			        for (int v3=0;v3 < 4; v3++)
			        {
				        this.DecStruct3_D1D4B0[v1].D1[4 * v2 + v3] = 0;
			        }


	        for(int v1=0; v1 < 4; v1++ )
		        for (int v2=0;v2 < 256; v2++)
			        for (int v3=0; v3 < 32; v3++ )
			        {
				        v4 = TRTeam_OwnDefaultStructures.DecArray5_CEA3B0[v3] - 1;
				        if ( (v4 >> 3 == v1) && ((TRTeam_OwnDefaultStructures.DecArray2_CEA3D0[v4 & 7] & v2)>0) )
				        {
						    v5 = v3 & 7;
						    this.DecStruct3_D1D4B0[v1].D1[4 * v2 + (v3 >> 3)] |= TRTeam_OwnDefaultStructures.DecArray2_CEA3D0[v3 & 7];
				        }
			        }

        }

        private void TRKeyIntegrate2()
        {
	        int v0;

	        for(int v1= 0; v1 < 4; v1++)
	        {
                for(int v2= 0; v2 < 4096; v2++)
		        {
			        v0 = 16 * sub_A7D470(2 * v1, v2 >> 6);
			        DecArrayOut3_D1ECE8[4096 * v1 + v2] = Convert.ToByte(sub_A7D470(2 * v1 + 1, v2 & 0x3F) & 0xF | v0);
		        }
	        }
        }

        int sub_A7D470(int a1, int a2)
        {
            int v3;
            int v4;

            v3 = a2 & 1 | ((a2 & 0x20) >> 4);
            v4 = (a2 & 0x1F) >> 1;
            return this.DecStruct2_CEA1B0[a1].D1[16 * (a2 & 1 | ((a2 & 0x20) >> 4)) + ((a2 & 0x1F) >> 1)];
        }

        private void TRKeyIntegrate(Byte[] Key64)
        {
	        //int v2;
	        int v3;
	        int v4;
	        int v6;

            Byte[] DecArrayOut1_D23548 = new Byte[56];//[0x38];
            Byte[] DecArrayOut2_D1E4B0 = new Byte[56];//[0x38];

	        //v2 = 0;
	        for(int i=0; i<56; i++)
	        {
		        v3 = TRTeam_OwnDefaultStructures.DecArray1[i] - 1;
		        v4 = v3 & 7;
		        DecArrayOut1_D23548[i] = Convert.ToByte((TRTeam_OwnDefaultStructures.DecArray2_CEA3D0[v3 & 7] & Key64[v3 >> 3]) != 0);
	        }

	        for(int i=0; i<16; i++)
	        {
                TRTeam_OwnDefaultStructures._DecStruct1T ds = new TRTeam_OwnDefaultStructures._DecStruct1T(TRTeam_OwnDefaultStructures.STRUCT_INIT);
                //ds.D1 = new Byte[6];
		        DecStruct1[i] = ds;
	        }

	        for(int i=0; i<16; i++)
	        {
		        for(int i2=0; i2<56; i2++)
		        {
			        v3 = i2 + TRTeam_OwnDefaultStructures.DecArray3[i];
                    if ( v3 >= ( (int)( (((i2 >= 28)?1:0) - 1) & 0xFFFFFFE4) + 56) )
			        {
				        v6 = v3 - 28;
			        }
			        else
			        {
				        v6 = v3;
			        }
			        DecArrayOut2_D1E4B0[i2] = DecArrayOut1_D23548[v6];
		        }

                for (int i2 = 0; i2 < 48; i2++)
                {
                    if (TRTeam_OwnDefaultStructures.DecArray4_CEA180[i2] == 0)
                    {
                        //__debugbreak(); //Should not happen
                    }
                    if (DecArrayOut2_D1E4B0[TRTeam_OwnDefaultStructures.DecArray4_CEA180[i2] - 1]>0)
                    {
                        DecStruct1[i].D1[i2 >> 3] += TRTeam_OwnDefaultStructures.DecArray2_CEA3D0[i2 & 7];
                    }
                }
	        }
        }

        private void TRPrepareBasic(ref Byte[] pOutput, Byte[] pInput)
        {
            // initialize Byte array (all to 0)
            pOutput = new Byte[128*16];	        
           
            //TODO : convert Bitwise OR/ AND/ RIGHT to "understandable" algorithm
            // @thuvvik 20110508 0137
            for(int v3 = 0; v3 < 16; v3++)         
	            for (int v4 = 0;v4 < 16; v4++)
			        for( int v5 = 0; v5 < 64; v5++)
			        {        
                        int v6 = pInput[v5] - 1;
				        if ((v6 >> 2 == v3) && ((TRTeam_OwnDefaultStructures.DecArray6_CEA3F0[v6 & 3] & v4)>0))
				        {
						    int v7 = v5 & 7;
                            pOutput[(128 * v3) + 8 * v4 + (v5 >> 3)] |= TRTeam_OwnDefaultStructures.DecArray2_CEA3D0[(v5 & 7)];
				        }
			        }
        }

        // userData here is Byte[30]
        public void decrypt(ref Byte[] userData, int length)
        {
            // bitwise and(not 7)
            length &= ~7;
            sub_A7E190_1(ref userData, length, 0);
        }

        // userData here is Byte[30]
        private void sub_A7E190_1(ref Byte[] userData, int length, int state)
        {
            Byte[] partialData = new Byte[8];
	        
            int i = 0;
            // extract an 8 bytes "word"
            for (int j = 0; j < 8; j++)
                partialData[j] = userData[j];

            while (length > 0)
	        {
                // decrypt the 8bytes "word"
                thuvvikTest(ref partialData, state);

                // put decrypted "word" back into userData array
                for (int j = 0; j < 8; j++)
                    userData[i*8+j] = partialData[j];
                i++;
                length -= 8;

                // get next 8bytes "word"
                for (int j = 0; j < 8; j++)
                    // userData Length = 30 or 4 mot x8 bytes = 32.. manque 2 bytes, mis à 0
                    partialData[j] = (i*8+j<userData.Length)?userData[i*8+j]:Convert.ToByte(0); 

	        }
        }

        // partial data here si Byte[8]
        private void thuvvikTest(ref Byte[] partialData, int state)
        {
	        Byte[] v5 = new Byte[128 + 8];
            Byte[] v7 = new Byte[8];

            sub_A7D8D0_3(ref partialData, this._OutputData_D22D48,ref v5);


            for (int v4 = 0; v4 < 16; v4++)
            {
                sub_A7DC90_3(v4, state, ref v5);
            }

            // VAX:little-endian bit order
	        v7[0] = v5[132]; 
	        v7[1] = v5[133];
	        v7[2] = v5[134]; 
	        v7[3] = v5[135];
	        v7[4] = v5[128];
	        v7[5] = v5[129];
	        v7[6] = v5[130];
	        v7[7] = v5[131];

            sub_A7D8D0_3(ref v7, this._OutputData_D1E4E8, ref partialData);
        }

        //int __cdecl CryptManager::sub_A7DC90_3(int idx, unsigned char *m, unsigned char *m2)
        // pV5 = Byte[128+8] (definition in thuvvikTest() @ thuvvik 20110509 1409
        private void sub_A7DC90_3(int idxRound, int state, ref Byte[] pV5)
        {
            int idxStart = idxRound * 8;
            Byte[] v6 = new Byte[6];

            sub_A7DA60_4(pV5, idxRound, state, ref v6);
                       
            // copie pV5[4]-pV5[7] dans pv5[8]-pv5[17].. hors idxStart pour pv5
            // simple permutation fin demi-mot précédent devient début mot suivant.
            // mot = 8 bytes.
            // @thuvvik 20110509 1419
            for (int iCopy = 4; iCopy < 8; iCopy++)
                pV5[idxStart + (iCopy + 4)] = pV5[idxStart + iCopy];

            for (int iCopy = 0; iCopy < 4; iCopy++)
                pV5[(idxStart + 12) + iCopy] = Convert.ToByte(pV5[idxStart + iCopy] ^ v6[iCopy]);
        }

        // pV5 = Byte[128+8]
        // idxRound + state.. as to choose between encrypt(state = 1) or decrypt (state =0)
        // pV6 = Byte[6] => array to fill
        //int __cdecl CryptManager::sub_A7DA60_4(unsigned __int8 *d, int idx, unsigned __int8 *a3)
        // @thuvvik 20110509 1432
        private void sub_A7DA60_4(byte[] pV5, int idxRound, int state, ref byte[] pV6)
        {
            int idxOrder = (state==0)? 15 - idxRound : idxRound;
            int idxStart = idxRound * 8 + 4; // mid-word, of the calling word @thuvvik20110509 1438

            Byte[] v4 = this.DecStruct1[idxOrder].D1;
            Byte[] v5 = new Byte[6];
            Byte[] v8 = new Byte[6];
            Byte[] a2 = new Byte[4];

            sub_A7D5E0_5(pV5, idxStart, ref v5);

            for (int iCopy = 0; iCopy < 6; iCopy++)
                v8[iCopy] = Convert.ToByte(v4[iCopy] ^ v5[iCopy]);

            sub_A7D4B0(v8,ref  a2);

            sub_A7D790(a2, ref pV6);

        }

        // int __cdecl CryptManager::sub_A7D790(unsigned __int8 *a1, unsigned __int8 *a2)
        private void sub_A7D790(byte[] a1, ref byte[] pV6)
        {
            Byte[] v3 = new Byte[6];
            Byte[] v4 = new Byte[6];
            Byte[] v6 = new Byte[6];

            for (int iClear = 0; iClear < 4; iClear++)
                pV6[iClear] = 0;
 
            for( int iRound=0; iRound < 4; iRound++ )
            {
                int temp =4 * a1[iRound];
                pV6[0] = Convert.ToByte(pV6[0] | this.DecStruct3_D1D4B0[iRound].D1[temp]);
                pV6[1] = Convert.ToByte(pV6[1] | this.DecStruct3_D1D4B0[iRound].D1[temp+1]);
                pV6[2] = Convert.ToByte(pV6[2] | this.DecStruct3_D1D4B0[iRound].D1[temp+2]);
                pV6[3] = Convert.ToByte(pV6[3] | this.DecStruct3_D1D4B0[iRound].D1[temp+3]);
            }
        }

        // int __cdecl CryptManager::sub_A7D4B0(unsigned __int8 *a1, unsigned __int8 *a2)
        private void sub_A7D4B0(byte[] v8, ref byte[] a2)
        {
            Byte a = v8[0];
            Byte b = v8[1];
            Byte c = v8[2];
            Byte d = v8[3];
            Byte e = v8[4];
            Byte f = v8[5];


            a2[0] = this.DecArrayOut3_D1ECE8[((b >> 4) & 0xF | (16 * a)) & 0xFFF];
            a2[1] = this.DecArrayOut3_D1ECE8[0x1000 + ((c | (b << 8)) & 0xFFF)];
            a2[2] = this.DecArrayOut3_D1ECE8[0x2000 + (((e >> 4) & 0xF | (16 * d)) & 0xFFF)];
            a2[3] = this.DecArrayOut3_D1ECE8[0x3000 + ((f | (e << 8)) & 0xFFF)];
        }

        // int __cdecl CryptManager::sub_A7D5E0_5(unsigned __int8 *p1, unsigned __int8 *p2)
        // int idxStart = idxRound * 8 + 4;
        private void sub_A7D5E0_5(byte[] pV5, int idxStart, ref byte[] v5)
        {
            Byte a = pV5[idxStart];
            Byte b = pV5[idxStart + 1];
            Byte c = pV5[idxStart + 2];
            Byte d = pV5[idxStart + 3];
            
            v5[0] = Convert.ToByte(((a & 0x18) >> 3) | (((a & 0xF8) >> 1) | ((d & 1) << 7)) );
            v5[1] =  Convert.ToByte(((b & 0xE0) >> 5) |  ( (8 * (a & 1)) | (((b & 0x80) >> 3) |  (32 * (a & 7)))));
            v5[2] =  Convert.ToByte(((c & 0x80) >> 7) |  ( (2 * (b & 0x1F)) |  (8 * (b & 0x18))));
            v5[3] =  Convert.ToByte(((c & 0x18) >> 3) |  ( ((c & 0xF8) >> 1) |  ((b & 1) << 7)));
            v5[4] =  Convert.ToByte(((d & 0xE0) >> 5) |  ( (8 * (c & 1)) |  ( ((d & 0x80) >> 3) |  (32 * (c & 7)))));
            v5[5] =  Convert.ToByte(((a & 0x80) >> 7) |  ( (2 * (d & 0x1F)) |  (8 * (d & 0x18))));        
        }

        //int __cdecl CryptManager::sub_A7D8D0_3(unsigned __int8 *DataP, unsigned __int8 *B_, unsigned __int8 *Out)
        // pOut is                      new Byte[128 + 8]
        // pOutputData_D22D48  is       new Byte[128*16];
        // partialData is               new Byte[8];
        private void sub_A7D8D0_3(ref Byte[] partialData, byte[] pOutputData_D22D48, ref byte[] pOut)
        {
	        Byte[] v5 = new Byte[128 + 8];
            Byte[] v6 = new Byte[8];
	        
            Byte v8;
            Byte v9;

            // normally it's unnecessary (in case of...)
            // @thuvvik 20110508 2354
            for (int iv5 = 0; iv5 < 8; iv5++)
                pOut[iv5] = 0;
            
	        v6 = partialData;
            int j = 0;

	        for(int v7=0; v7 < 16 ; v7 += 2)
	        {
                for(int iv5=0; iv5<8; iv5++)
		            v5[iv5] = pOut[iv5];

                int iv8 = (128 * v7) + 8 * ((v6[j] >> 4) & 0xF);
		        v8 = pOutputData_D22D48[iv8];
                int iv9 = (128 * (v7 + 1)) + 8 * (v6[j] & 0xF);
		        v9 = pOutputData_D22D48[iv9];

		        for(int v4 = 0;  v4 < 8; v4++ )
		        {
                    pOut[v4] = Convert.ToByte(v5[v4] |(v9 | v8));
                    iv8++;
                    v8 = pOutputData_D22D48[iv8];
                    iv9++;
                    v9 = pOutputData_D22D48[iv9];
		        }
                j++;
	        }
        }

    }
}
