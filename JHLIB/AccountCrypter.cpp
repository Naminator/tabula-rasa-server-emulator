#include<Windows.h>
#include<stdio.h>

//#include "AccountHasherArray.h"
#include "AccountCrypter.h"

unsigned char DecArray1[0x38] =
{
	0x39,0x31,0x29,0x21,0x19,0x11,0x09,0x01,0x3A,0x32,0x2A,0x22,0x1A,0x12,0x0A,0x02,
	0x3B,0x33,0x2B,0x23,0x1B,0x13,0x0B,0x03,0x3C,0x34,0x2C,0x24,0x3F,0x37,0x2F,0x27,
	0x1F,0x17,0x0F,0x07,0x3E,0x36,0x2E,0x26,0x1E,0x16,0x0E,0x06,0x3D,0x35,0x2D,0x25,
	0x1D,0x15,0x0D,0x05,0x1C,0x14,0x0C,0x04
};

unsigned char DecArray2_CEA3D0[0x10] =
{
	0x80,0x40,0x20,0x10,0x08,0x04,0x02,0x01
};

unsigned char DecArray3[0x10] =
{
	0x01,0x02,0x04,0x06,0x08,0x0A,0x0C,0x0E,0x0F,0x11,0x13,0x15,0x17,0x19,0x1B,0x1C
};

unsigned char DecArray4_CEA180[48] =
{
	0x0E,0x11,0x0B,0x18,0x01,0x05,0x03,0x1C,0x0F,0x06,0x15,0x0A,0x17,0x13,0x0C,0x04,0x1A,0x08,0x10,0x07,0x1B,0x14,0x0D,0x02,0x29,0x34,0x1F,0x25,0x2F,0x37,0x1E,0x28,0x33,0x2D,0x21,0x30,0x2C,0x31,0x27,0x38,0x22,0x35,0x2E,0x2A,0x32,0x24,0x1D,0x20
};

unsigned char DecArray5_CEA3B0[32] =
{
	0x10,0x07,0x14,0x15,0x1D,0x0C,0x1C,0x11,0x01,0x0F,0x17,0x1A,0x05,0x12,0x1F,0x0A,0x02,0x08,0x18,0x0E,0x20,0x1B,0x03,0x09,0x13,0x0D,0x1E,0x06,0x16,0x0B,0x04,0x19
};

unsigned int DecArray6_CEA3F0[4] =
{
	8,4,2,1
};

struct _DecStruct1T
{
	unsigned char D1[6];
};

struct _DecStruct2T
{
	unsigned char D1[64];
};

struct _DecStruct3T
{
	unsigned char D1[1024];
};

unsigned char CEA1B0_DATA[16*64] =
{
	0x0E,0x04,0x0D,0x01,0x02,0x0F,0x0B,0x08,0x03,0x0A,0x06,0x0C,0x05,0x09,0x00,0x07,0x00,0x0F,0x07,0x04,0x0E,0x02,0x0D,0x01,0x0A,0x06,0x0C,0x0B,0x09,0x05,0x03,0x08,0x04,0x01,0x0E,0x08,0x0D,0x06,0x02,0x0B,0x0F,0x0C,0x09,0x07,0x03,0x0A,0x05,0x00,0x0F,0x0C,0x08,0x02,0x04,0x09,0x01,0x07,0x05,0x0B,0x03,0x0E,0x0A,0x00,0x06,0x0D,0x0F,0x01,0x08,0x0E,0x06,0x0B,0x03,0x04,0x09,0x07,0x02,0x0D,0x0C,0x00,0x05,0x0A,0x03,0x0D,0x04,0x07,0x0F,0x02,0x08,0x0E,0x0C,0x00,0x01,0x0A,0x06,0x09,0x0B,0x05,0x00,0x0E,0x07,0x0B,0x0A,0x04,0x0D,0x01,0x05,0x08,0x0C,0x06,0x09,0x03,0x02,0x0F,0x0D,0x08,0x0A,0x01,0x03,0x0F,0x04,0x02,0x0B,0x06,0x07,0x0C,0x00,0x05,0x0E,0x09,0x0A,0x00,0x09,0x0E,0x06,0x03,0x0F,0x05,0x01,0x0D,0x0C,0x07,0x0B,0x04,0x02,0x08,0x0D,0x07,0x00,0x09,0x03,0x04,0x06,0x0A,0x02,0x08,0x05,0x0E,0x0C,0x0B,0x0F,0x01,0x0D,0x06,0x04,0x09,0x08,0x0F,0x03,0x00,0x0B,0x01,0x02,0x0C,0x05,0x0A,0x0E,0x07,0x01,0x0A,0x0D,0x00,0x06,0x09,0x08,0x07,0x04,0x0F,0x0E,0x03,0x0B,0x05,0x02,0x0C,0x07,0x0D,0x0E,0x03,0x00,0x06,0x09,0x0A,0x01,0x02,0x08,0x05,0x0B,0x0C,0x04,0x0F,0x0D,0x08,0x0B,0x05,0x06,0x0F,0x00,0x03,0x04,0x07,0x02,0x0C,0x01,0x0A,0x0E,0x09,0x0A,0x06,0x09,0x00,0x0C,0x0B,0x07,0x0D,0x0F,0x01,0x03,0x0E,0x05,0x02,0x08,0x04,0x03,0x0F,0x00,0x06,0x0A,0x01,0x0D,0x08,0x09,0x04,0x05,0x0B,0x0C,0x07,0x02,0x0E,0x02,0x0C,0x04,0x01,0x07,0x0A,0x0B,0x06,0x08,0x05,0x03,0x0F,0x0D,0x00,0x0E,0x09,0x0E,0x0B,0x02,0x0C,0x04,0x07,0x0D,0x01,0x05,0x00,0x0F,0x0A,0x03,0x09,0x08,0x06,0x04,0x02,0x01,0x0B,0x0A,0x0D,0x07,0x08,0x0F,0x09,0x0C,0x05,0x06,0x03,0x00,0x0E,0x0B,0x08,0x0C,0x07,0x01,0x0E,0x02,0x0D,0x06,0x0F,0x00,0x09,0x0A,0x04,0x05,0x03,0x0C,0x01,0x0A,0x0F,0x09,0x02,0x06,0x08,0x00,0x0D,0x03,0x04,0x0E,0x07,0x05,0x0B,0x0A,0x0F,0x04,0x02,0x07,0x0C,0x09,0x05,0x06,0x01,0x0D,0x0E,0x00,0x0B,0x03,0x08,0x09,0x0E,0x0F,0x05,0x02,0x08,0x0C,0x03,0x07,0x00,0x04,0x0A,0x01,0x0D,0x0B,0x06,0x04,0x03,0x02,0x0C,0x09,0x05,0x0F,0x0A,0x0B,0x0E,0x01,0x07,0x06,0x00,0x08,0x0D,0x04,0x0B,0x02,0x0E,0x0F,0x00,0x08,0x0D,0x03,0x0C,0x09,0x07,0x05,0x0A,0x06,0x01,0x0D,0x00,0x0B,0x07,0x04,0x09,0x01,0x0A,0x0E,0x03,0x05,0x0C,0x02,0x0F,0x08,0x06,0x01,0x04,0x0B,0x0D,0x0C,0x03,0x07,0x0E,0x0A,0x0F,0x06,0x08,0x00,0x05,0x09,0x02,0x06,0x0B,0x0D,0x08,0x01,0x04,0x0A,0x07,0x09,0x05,0x00,0x0F,0x0E,0x02,0x03,0x0C,0x0D,0x02,0x08,0x04,0x06,0x0F,0x0B,0x01,0x0A,0x09,0x03,0x0E,0x05,0x00,0x0C,0x07,0x01,0x0F,0x0D,0x08,0x0A,0x03,0x07,0x04,0x0C,0x05,0x06,0x0B,0x00,0x0E,0x09,0x02,0x07,0x0B,0x04,0x01,0x09,0x0C,0x0E,0x02,0x00,0x06,0x0A,0x0D,0x0F,0x03,0x05,0x08,0x02,0x01,0x0E,0x07,0x04,0x0A,0x08,0x0D,0x0F,0x0C,0x09,0x00,0x03,0x05,0x06,0x0B
};

struct _DecStruct1T DecStruct1[16];
struct _DecStruct2T *DecStruct2_CEA1B0 = (struct _DecStruct2T*)CEA1B0_DATA;//[16];

struct _DecStruct3T DecStruct3_D1D4B0[4];

unsigned char DecArrayOut1_D23548[0x38];
unsigned char DecArrayOut2_D1E4B0[0x38]; //Only written D1E4B0
unsigned char DecArrayOut3_D1ECE8[4096*4]; //This is huge and important

unsigned char InputData_0CEA0B8[0x40] =
{
	0x3A,0x32,0x2A,0x22,0x1A,0x12,0x0A,0x02,0x3C,0x34,0x2C,0x24,0x1C,0x14,0x0C,0x04,0x3E,0x36,0x2E,0x26,0x1E,0x16,0x0E,0x06,0x40,0x38,0x30,0x28,0x20,0x18,0x10,0x08,
	0x39,0x31,0x29,0x21,0x19,0x11,0x09,0x01,0x3B,0x33,0x2B,0x23,0x1B,0x13,0x0B,0x03,0x3D,0x35,0x2D,0x25,0x1D,0x15,0x0D,0x05,0x3F,0x37,0x2F,0x27,0x1F,0x17,0x0F,0x07
};

unsigned char InputData_0CEA0F8[0x40] =
{
	0x28,0x08,0x30,0x10,0x38,0x18,0x40,0x20,0x27,0x07,0x2F,0x0F,0x37,0x17,0x3F,0x1F,0x26,0x06,0x2E,0x0E,0x36,0x16,0x3E,0x1E,0x25,0x05,0x2D,0x0D,0x35,0x15,0x3D,0x1D,
	0x24,0x04,0x2C,0x0C,0x34,0x14,0x3C,0x1C,0x23,0x03,0x2B,0x0B,0x33,0x13,0x3B,0x1B,0x22,0x02,0x2A,0x0A,0x32,0x12,0x3A,0x1A,0x21,0x01,0x29,0x09,0x31,0x11,0x39,0x19
};

unsigned char OutputData_D1E4E8[128*16];
unsigned char OutputData_D22D48[128*16];

int __cdecl CryptInit_PrepareBasic(unsigned __int8 *Output, unsigned __int8 *Input)
{
  int result; // eax@9
  signed int v3; // [sp+14h] [bp-4h]@1
  signed int v4; // [sp+4h] [bp-14h]@3
  signed int v5; // [sp+10h] [bp-8h]@5
  signed int v6; // [sp+Ch] [bp-Ch]@17
  int v7; // [sp+8h] [bp-10h]@21

  v3 = 0;
  while ( v3 < 16 )
  {
    v4 = 0;
    while ( v4 < 16 )
    {
      v5 = 0;
      while ( v5 < 8 )
        *(&Output[128 * v3] + 8 * v4 + v5++) = 0;
      ++v4;
    }
    result = v3++ + 1;
  }
  v3 = 0;
  while ( v3 < 16 )
  {
    v4 = 0;
    while ( v4 < 16 )
    {
      v5 = 0;
      while ( v5 < 64 )
      {
        v6 = Input[v5] - 1;
        if ( v6 >> 2 == v3 )
        {
          if ( DecArray6_CEA3F0[v6 & 3] & v4 )
          {
            v7 = v5 & 7;
            *(&Output[128 * v3] + 8 * v4 + (v5 >> 3)) |= (unsigned char)(DecArray2_CEA3D0[v5 & 7]);
          }
        }
        ++v5;
      }
      result = v4++ + 1;
    }
    ++v3;
  }
  return result;
}


void __cdecl CryptInit_Keyintegrate(unsigned char *Key) //sub_A7D2D0
{
//	fsdf optimize this!
  int result; // eax@3
  int v2; // [sp+4h] [bp-10h]@1
  int v3; // [sp+Ch] [bp-8h]@3
  int v4; // [sp+8h] [bp-Ch]@3
  int v6; // [sp+0h] [bp-14h]@15

  v2 = 0;
  for(int i=0; i<56; i++)//while ( v2 < 56 )
  {
    v3 = DecArray1[i] - 1;
    v4 = v3 & 7;
    DecArrayOut1_D23548[i] = (DecArray2_CEA3D0[v3 & 7] & Key[v3 >> 3]) != 0;
    //result = v2++ + 1;
  }

  for(int i=0; i<16; i++)
	  memset((void*)&DecStruct1[i], 0x00, sizeof(struct _DecStruct1T));

  for(int i=0; i<16; i++)//while ( v5 < 16 )
  {
    for(int i2=0; i2<56; i2++)//while ( v2 < 56 )
    {
      v3 = i2 + DecArray3[i];
      if ( v3 >= (((i2 >= 28) - 1) & 0xFFFFFFE4) + 56 )
        v6 = v3 - 28;
      else
        v6 = v3;
      result = v6;
      DecArrayOut2_D1E4B0[i2] = DecArrayOut1_D23548[v6];//byte_D23548[v6];
    }
    for(int i2=0; i2<48; i2++)//while ( v2 < 48 )
    {
      //result = v2;
	  if( DecArray4_CEA180[i2] == 0 )
		  __debugbreak(); //Should not happen
      if ( DecArrayOut2_D1E4B0[DecArray4_CEA180[i2]-1] )
        DecStruct1[i].D1[i2>>3] += DecArray2_CEA3D0[i2 & 7];
    }
  }
}

/*** SUB ******/

int __cdecl sub_A7D470(int a1, int a2)
{
  int v3; // [sp+4h] [bp-4h]@1
  int v4; // [sp+0h] [bp-8h]@1

  v3 = a2 & 1 | ((a2 & 0x20) >> 4);
  v4 = (a2 & 0x1F) >> 1;
  return DecStruct2_CEA1B0[a1].D1[16 * (a2 & 1 | ((a2 & 0x20) >> 4)) + ((a2 & 0x1F) >> 1)];//*(&DecStruct2_CEA1B0[64 * a1] + 16 * (a2 & 1 | ((a2 & 0x20) >> 4)) + ((a2 & 0x1F) >> 1));
}


void __cdecl CryptInit_Keyintegrate_Part2()
{
  int v0; // ebx@5
  signed int v1; // [sp+8h] [bp-4h]@1
  signed int v2; // [sp+4h] [bp-8h]@3

  v1 = 0;
  while ( v1 < 4 )
  {
    v2 = 0;
    while ( v2 < 4096 )
    {
      v0 = 16 * sub_A7D470(2 * v1, v2 >> 6);
      DecArrayOut3_D1ECE8[4096 * v1 + v2] = sub_A7D470(2 * v1 + 1, v2 & 0x3F) & 0xF | (unsigned char)v0;
	  //*(&byte_D1ECE8[4096 * v1] + v2) = sub_A7D470(2 * v1 + 1, v2 & 0x3F) & 0xF | (_BYTE)v0;
      ++v2;
    }
    ++v1;
  }
}

int __cdecl CryptInit_Keyintegrate_Part3() //A7D180
{
  int result; // eax@9
  signed int v1; // [sp+14h] [bp-4h]@1
  signed int v2; // [sp+4h] [bp-14h]@3
  signed int v3; // [sp+10h] [bp-8h]@5
  signed int v4; // [sp+Ch] [bp-Ch]@17
  int v5; // [sp+8h] [bp-10h]@21

  v1 = 0;
  while ( v1 < 4 )
  {
    v2 = 0;
    while ( v2 < 256 )
    {
      v3 = 0;
      while ( v3 < 4 )
        DecStruct3_D1D4B0[v1].D1[4 * v2 + v3++] = 0;//*((_BYTE *)&stru_D1D4B0[256 * v1] + 4 * v2 + v3++) = 0;
      ++v2;
    }
    result = v1++ + 1;
  }
  v1 = 0;
  while ( v1 < 4 )
  {
    v2 = 0;
    while ( v2 < 256 )
    {
      v3 = 0;
      while ( v3 < 32 )
      {
        v4 = DecArray5_CEA3B0[v3] - 1;
        if ( v4 >> 3 == v1 )
        {
          if ( DecArray2_CEA3D0[v4 & 7] & v2 )
          {
            v5 = v3 & 7;
            DecStruct3_D1D4B0[v1].D1[4 * v2 + (v3 >> 3)] |= (unsigned char)(DecArray2_CEA3D0[v3 & 7]);
			//*((_BYTE *)&stru_D1D4B0[256 * v1] + 4 * v2 + (v3 >> 3)) |= (unsigned char)(DecArray2_CEA3D0[v3 & 7]);
          }
        }
        ++v3;
      }
      result = v2++ + 1;
    }
    ++v1;
  }
  return result;
}

/***************************** Encoding *************************/
int __cdecl sub_A7D8D0_3(unsigned __int8 *DataP, unsigned __int8 *B_, unsigned __int8 *Out)
{
  int result; // eax@1
  signed int v4; // [sp+Ch] [bp-Ch]@1
  unsigned __int8 *v5; // [sp+8h] [bp-10h]@1
  unsigned __int8 *v6; // [sp+10h] [bp-8h]@4
  signed int v7; // [sp+0h] [bp-18h]@4
  unsigned __int8 *v8; // [sp+14h] [bp-4h]@6
  unsigned __int8 *v9; // [sp+4h] [bp-14h]@6

  v4 = 0;
  result = (int)Out;
  v5 = Out;
  while ( v4 < 8 )
  {
    *v5 = 0;
    result = (int)(v5++ + 1);
    ++v4;
  }
  v6 = DataP;
  v7 = 0;
  while ( v7 < 16 )
  {
    v5 = Out;
    v8 = &B_[128 * v7] + 8 * (((signed int)*v6 >> 4) & 0xF);
    v9 = &B_[128 * (v7 + 1)] + 8 * (*v6 & 0xF);
    v4 = 0;
    while ( v4 < 8 )
    {
      *v5++ |= *v9++ | *v8++;
      ++v4;
    }
    v7 += 2;
    result = (int)(v6++ + 1);
  }
  return result;
}

int __cdecl sub_A7D790(unsigned __int8 *a1, unsigned __int8 *a2)
{
  int result; // eax@1
  unsigned __int8 *v3; // [sp+8h] [bp-8h]@1
  unsigned __int8 *v4; // [sp+Ch] [bp-4h]@1
  signed int v5; // [sp+0h] [bp-10h]@1
  unsigned __int8 *v6; // [sp+4h] [bp-Ch]@3

  v3 = a2;
  *a2 = 0;
  ++v3;
  *v3++ = 0;
  *v3++ = 0;
  *v3 = 0;
  result = (int)a1;
  v4 = a1;
  v5 = 0;
 
  
  while ( v5 < 4 )
  {
    v6 = &DecStruct3_D1D4B0[v5].D1[4 * *v4];//(unsigned __int8 *)((char *)&stru_D1D4B0[1024 * v5] + 4 * *v4);
    v3 = a2;
    *a2 |= *v6++;
    ++v3;
    *v3++ |= *v6++;
    *v3++ |= *v6++;
    result = (int)v3;
    *v3 |= *v6;
    ++v5;
    ++v4;
  }
  return result;
}


int __cdecl sub_A7D4B0(unsigned __int8 *a1, unsigned __int8 *a2)
{
  unsigned __int8 *v3; // [sp+1Ch] [bp-4h]@1
  int v4; // [sp+10h] [bp-10h]@1
  unsigned int v5; // [sp+18h] [bp-8h]@1
  int v6; // [sp+0h] [bp-20h]@1
  int v7; // [sp+Ch] [bp-14h]@1
  unsigned int v8; // [sp+8h] [bp-18h]@1
  int v9; // [sp+14h] [bp-Ch]@1
  unsigned __int8 *v10; // [sp+4h] [bp-1Ch]@1

  v3 = a1;
  v4 = *a1;
  v3 = a1 + 1;
  v5 = *(a1 + 1);
  v3 = a1 + 2;
  v6 = *(a1 + 2);
  v3 = a1 + 3;
  v7 = *(a1 + 3);
  v3 = a1 + 4;
  v8 = *(a1 + 4);
  v3 = a1 + 5;
  v9 = *(a1 + 5);
  v3 = a1 + 6;
  v10 = a2;

  *a2 = DecArrayOut3_D1ECE8[(((unsigned int)v5 >> 4) & 0xF | (unsigned __int16)(16 * (unsigned short)v4)) & 0xFFF];
  ++v10;
  *v10++ = DecArrayOut3_D1ECE8[0x1000 + (((unsigned __int8)v6 | (unsigned __int16)((unsigned short)v5 << 8)) & 0xFFF)];
  *v10++ = DecArrayOut3_D1ECE8[0x2000 + ((((unsigned int)v8 >> 4) & 0xF | (unsigned __int16)(16 * (unsigned short)v7)) & 0xFFF)];
  *v10 =DecArrayOut3_D1ECE8[0x3000 + (((unsigned __int8)v9 | (unsigned __int16)((unsigned short)v8 << 8)) & 0xFFF)];
  return (int)(v10 + 1);
}


int __cdecl sub_A7D5E0_5(unsigned __int8 *p1, unsigned __int8 *p2)
{
  unsigned __int8 *v3; // [sp+Ch] [bp-8h]@1
  unsigned __int8 *v4; // [sp+4h] [bp-10h]@1
  unsigned __int8 v5; // [sp+Bh] [bp-9h]@1
  unsigned __int8 v6; // [sp+13h] [bp-1h]@1
  unsigned __int8 v7; // [sp+12h] [bp-2h]@1
  unsigned __int8 v8; // [sp+3h] [bp-11h]@1

  v3 = p2;
  v4 = p1;
  v5 = *p1;
  v4 = p1 + 1;
  v6 = *(p1 + 1);
  v4 = p1 + 2;
  v7 = *(p1 + 2);
  v4 = p1 + 3;
  v8 = *(p1 + 3);
  *v3++ = (unsigned __int8)((v5 & 0x18) >> 3) | (unsigned __int8)((unsigned __int8)((v5 & 0xF8) >> 1) | (unsigned __int8)((v8 & 1) << 7));
  *v3++ = (unsigned __int8)((v6 & 0xE0) >> 5) | (unsigned __int8)((unsigned __int8)(8 * (v5 & 1)) | (unsigned __int8)((unsigned __int8)((v6 & 0x80) >> 3) | (unsigned __int8)(32 * (v5 & 7))));
  *v3++ = (unsigned __int8)((v7 & 0x80) >> 7) | (unsigned __int8)((unsigned __int8)(2 * (v6 & 0x1F)) | (unsigned __int8)(8 * (v6 & 0x18)));
  *v3++ = (unsigned __int8)((v7 & 0x18) >> 3) | (unsigned __int8)((unsigned __int8)((v7 & 0xF8) >> 1) | (unsigned __int8)((v6 & 1) << 7));
  *v3++ = (unsigned __int8)((v8 & 0xE0) >> 5) | (unsigned __int8)((unsigned __int8)(8 * (v7 & 1)) | (unsigned __int8)((unsigned __int8)((v8 & 0x80) >> 3) | (unsigned __int8)(32 * (v7 & 7))));
  *v3 = (unsigned __int8)((v5 & 0x80) >> 7) | (unsigned __int8)((unsigned __int8)(2 * (v8 & 0x1F)) | (unsigned __int8)(8 * (v8 & 0x18)));
  return (int)(v3 + 1);
}

int __cdecl sub_A7DA60_4(unsigned __int8 *d, int idx, unsigned __int8 *a3)
{
  unsigned __int8 *v4; // [sp+Ch] [bp-14h]@1
  unsigned __int8 v5[6]; // [sp+18h] [bp-8h]@1
  unsigned __int8 *p2; // [sp+14h] [bp-Ch]@1
  unsigned __int8 a1[6]; // [sp+0h] [bp-20h]@1
  unsigned __int8 *v8; // [sp+8h] [bp-18h]@1
  unsigned __int8 a2[4]; // [sp+10h] [bp-10h]@1

  v4 = &DecStruct1[idx].D1[0];//(unsigned __int8 *)&stru_D22CE8[6 * idx];
  p2 = v5;
  v8 = a1;
  sub_A7D5E0_5(d, v5);
  *v8++ = *v4++ ^ *p2++;
  *v8++ = *v4++ ^ *p2++;
  *v8++ = *v4++ ^ *p2++;
  *v8++ = *v4++ ^ *p2++;
  *v8++ = *v4++ ^ *p2++;
  *v8++ = *v4++ ^ *p2++;
  sub_A7D4B0(a1, (unsigned __int8 *)a2); //Correct
  return sub_A7D790((unsigned __int8 *)a2, a3);

}


int __cdecl sub_A7DC90_3(int idx, unsigned char *m, unsigned char *m2)
{
  unsigned __int8 *v4; // [sp+0h] [bp-10h]@1
  unsigned __int8 *v5; // [sp+8h] [bp-8h]@1
  unsigned char v6[6]; // [sp+4h] [bp-Ch]@1 - maybe too big but thats no problem - only 4 byte size

  v4 = m2;
  v5 = m + 4;
  sub_A7DA60_4(m + 4, idx, v6); //Correct
  *v4++ = *v5++;
  *v4++ = *v5++;
  *v4++ = *v5++;
  *v4++ = *v5;
  //Correct till here
  m2[4] = m[0] ^ v6[0];
  m2[5] = m[1] ^ v6[1];
  m2[6] = m[2] ^ v6[2];
  m2[7] = m[3] ^ v6[3];

  /*v5 = m;
  v7 = v6;
  *v4++ = *v7++ ^ *m;
  ++v7;
  ++v5;
  *v4++ = *v7++ ^ *v5++;
  *v4++ = *v7++ ^ *v5++;
  *v4 = *v7 ^ *v5;*/
  return (int)(v4 + 1);
}


unsigned int __cdecl sub_A7DE00_2(unsigned char *DataP1, unsigned char *DataP2) //Decrypt
{
  unsigned int v4; // [sp+98h] [bp-4h]@1
  unsigned char v5[128+8]; // [sp+14h] [bp-88h]@3
  unsigned char v7[8];

  sub_A7D8D0_3(DataP1, OutputData_D22D48, v5);
  v4 = 0;
  while ( v4 < 16 )
  {
    sub_A7DC90_3(15 - v4, &v5[8 * v4], &v5[8 * v4 + 8]);
    ++v4;
  }
  v7[0] = v5[0x84];
  v7[1] = v5[0x85];
  v7[2] = v5[0x86];
  v7[3] = v5[0x87];
  v7[4] = v5[0x80];
  v7[5] = v5[0x81];
  v7[6] = v5[0x82];
  v7[7] = v5[0x83];
  return sub_A7D8D0_3(v7, OutputData_D1E4E8, DataP2);
}

int __cdecl sub_A7DFD0(unsigned __int8 *a1, unsigned __int8 *a2) //Encrypt
{
  unsigned char M2[128 + 8];
  //unsigned char Out[8]; // [sp+Ch] [bp-90h]@1
  int idx; // [sp+98h] [bp-4h]@1
  //unsigned char m2[128]; // [sp+14h] [bp-88h]@3
  /*char v6; // [sp+90h] [bp-Ch]@4
  char v7; // [sp+0h] [bp-9Ch]@4
  char v8; // [sp+91h] [bp-Bh]@4
  char v9; // [sp+1h] [bp-9Bh]@4
  char v10; // [sp+92h] [bp-Ah]@4
  char v11; // [sp+2h] [bp-9Ah]@4
  char v12; // [sp+93h] [bp-9h]@4
  char v13; // [sp+3h] [bp-99h]@4
  char v14; // [sp+8Ch] [bp-10h]@4
  char v15; // [sp+4h] [bp-98h]@4
  char v16; // [sp+8Dh] [bp-Fh]@4
  char v17; // [sp+5h] [bp-97h]@4
  char v18; // [sp+8Eh] [bp-Eh]@4
  char v19; // [sp+6h] [bp-96h]@4
  char v20; // [sp+8Fh] [bp-Dh]@4
  char v21; // [sp+7h] [bp-95h]@4
  char *v22; // [sp+8h] [bp-94h]@4
  char **v23; // [sp+94h] [bp-8h]@4
	*/
  unsigned char v7[8];


  sub_A7D8D0_3(a1, OutputData_D22D48, M2); //DataPointer, Magic, 8-BYTE-UNITILIZED-ARRAY

  idx = 0;
  while ( idx < 16 )
  {
    sub_A7DC90_3(idx, &M2[8 * idx], &M2[8 * idx + 8]); //IDX, 8-Array-P, 8-Array-P - Seems correct
    ++idx;
  }
  v7[0] = M2[0x84];
  v7[1] = M2[0x85];
  v7[2] = M2[0x86];
  v7[3] = M2[0x87];
  v7[4] = M2[0x80];
  v7[5] = M2[0x81];
  v7[6] = M2[0x82];
  v7[7] = M2[0x83];


  return sub_A7D8D0_3(v7, OutputData_D1E4E8, a2);
}



int __cdecl sub_A7E190_1(unsigned __int8 *Data, int Len, int State)
{
  int result; // eax@1
  unsigned __int8 *DataP; // [sp+0h] [bp-4h]@1

  result = (int)Data;
  DataP = Data;
  while ( Len > 0 )
  {
    if ( State )
      result = sub_A7DFD0(DataP, DataP);
    else
      result = sub_A7DE00_2(DataP, DataP);//sub_A7DE00(DataP, DataP);
    Len -= 8;
    DataP += 8;
  }
  return result;
}




extern void __cdecl Tabula_CryptInit()
{
	//Init base arrays
	CryptInit_PrepareBasic(OutputData_D22D48, InputData_0CEA0B8);
	CryptInit_PrepareBasic(OutputData_D1E4E8, InputData_0CEA0F8);
	//We have the super secure key hardcoded
	unsigned char Key64[8] = {'T','E','S','T',0,0,0,0};
	CryptInit_Keyintegrate(Key64); //Seems to work fully!
	CryptInit_Keyintegrate_Part2(); //Also correct
	CryptInit_Keyintegrate_Part3(); //Also correct
}

extern void __cdecl  Tabula_Encrypt(unsigned char *Data, unsigned int Len)
{
	Len &= ~7; //Round down to 8 byte alignment
	sub_A7E190_1(Data, Len, 1);
}

extern void __cdecl  Tabula_Decrypt(unsigned char *Data, unsigned int Len)
{
	Len &= ~7; //Round down to 8 byte alignment
	sub_A7E190_1(Data, Len, 0);
}