// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the JHLIB_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// JHLIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
//#ifdef JHLIB_EXPORTS
//#define JHLIB_API __declspec(dllexport)
//#else
//#define JHLIB_API __declspec(dllimport)
//#endif

//#include "windows.h"
#define DllExport   __declspec( dllexport ) 
//#define N 16

//// This class is exported from the JHLIB.dll
//class JHLIB_API CJHLIB {
//public:
//	CJHLIB(void);
//	// TODO: add your methods here.
//};

//extern JHLIB_API int nJHLIB;

//JHLIB_API int fnJHLIB(void);

// This code should be put in a header file for your C++ DLL. It declares
// an extern C function that receives two parameters and is called SimulateGameDLL.
// I suggest putting it at the top of a header file.
extern "C" {
    DllExport int __cdecl Add(int a, int b);
}


