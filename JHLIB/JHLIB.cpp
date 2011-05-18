// JHLIB.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "JHLIB.h"


//// This is an example of an exported variable
//JHLIB_API int nJHLIB=0;
//
//// This is an example of an exported function.
//JHLIB_API int fnJHLIB(void)
//{
//	return 42;
//}
//
//// This is the constructor of a class that has been exported.
//// see JHLIB.h for the class definition
//CJHLIB::CJHLIB()
//{
//	return;
//}

// The keywords and parameter types must match the above extern
// declaration.
extern int __cdecl Add (int a, int b) {

    // This is part of the DLL, so we can call any function we want
    // in the C++. The parameters can have any names we want to give
    // them and they don't need to match the extern declaration.

	return a + b;
}


