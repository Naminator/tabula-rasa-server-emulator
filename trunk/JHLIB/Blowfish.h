#define DllExport   __declspec( dllexport ) 

//Blowfish (Packets)
typedef struct {
  unsigned long P[16 + 2];
  unsigned long S[4][256];
} BLOWFISH_CTX;

extern "C" {
	DllExport void __cdecl Blowfish_Init(unsigned char *key, int keyLen);
	
	DllExport void __cdecl Blowfish_Encrypt(unsigned long *xl, unsigned long *xr);

	DllExport void __cdecl Blowfish_Decrypt(unsigned long *xl, unsigned long *xr);

}