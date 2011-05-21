#define DllExport   __declspec( dllexport ) 

extern "C" {
	//Unknown Crypt (Accountdata)
	DllExport void __cdecl Tabula_CryptInit();
	DllExport void __cdecl Tabula_Encrypt(unsigned char *Data, unsigned int Len);
	DllExport void __cdecl Tabula_Decrypt(unsigned char *Data, unsigned int Len);
}