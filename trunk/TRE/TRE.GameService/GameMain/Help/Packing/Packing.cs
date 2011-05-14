using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal struct containerStackEntry
    {
        internal char type; //'t' tuple, 'd' dict
        // general
        internal int startOffset;
        internal int subelements;

        // dict info

        // tuple info
        //int tupleSize;
    }

    internal struct pyMarshalString
    {
        internal byte[] buffer; // [1024];
        internal int idx;
        internal containerStackEntry[] containerStack; //[16];
        internal int stackIdx;
    }

    internal struct pyUnmarshalContainer
    {
        internal char type; // 'd' - dict, 't' - tuple
        internal uint size;
        internal uint subelementsLeft;
    }

    internal struct pyUnmarshalString
    {
        internal string buffer;
        internal int idx;
        internal int len;
        internal bool unpackErrorEncountered;
        internal pyUnmarshalContainer[] containerStack; //[16];
        internal int stackIndex;
    }

    internal class Packing
    {

        /*
            Helper for creating and parsing PyMarshal Strings without having Python.
            Also this should be much faster than the original Python methods.
        */

        // new marshal packing lib

        internal void pym_init(pyMarshalString pms)
        {
        }

        internal void pym_tuple_begin(pyMarshalString pms)
        {
        }
        internal void pym_tuple_end(pyMarshalString pms)
        {
        }

        internal void pym_list_begin(pyMarshalString pms)
        {
        }
        internal void pym_list_end(pyMarshalString pms)
        {
        }

        internal void pym_dict_begin(pyMarshalString pms)
        {
        }
        internal void pym_dict_end(pyMarshalString pms)
        {
        }
        internal void pym_dict_addKey(pyMarshalString pms, string s)
        {
        }

        internal void pym_addInt(pyMarshalString pms, int value)
        {
        }
        internal void pym_addString(pyMarshalString pms, string s)
        {
        }
        internal void pym_addUnicode(pyMarshalString pms, string s)
        {
        }
        internal void pym_addNoneStruct(pyMarshalString pms)
        {
        }
        internal void pym_addBool(pyMarshalString pms, bool b)
        {
        }
        internal void pym_addFloat(pyMarshalString pms, float value)
        {
        }

        internal string pym_getData(pyMarshalString pms)
        {
            return null;
        }
        internal uint pym_getLen(pyMarshalString pms)
        {
            return 0;
        }

        // new marshal unpacking lib

        

        internal void pym_init(pyUnmarshalString pms, string rawData, int len)
        {
        }

        internal bool pym_unpackTuple_begin(pyUnmarshalString pms)
        {
            return false;
        }
        internal bool pym_unpackDict_begin(pyUnmarshalString pms)
        {
            return false;
        }
        internal int pym_getContainerSize(pyUnmarshalString pms)
        {
            return 0;
        }
        internal int pym_unpackInt(pyUnmarshalString pms)
        {
            return 0;
        }
        internal long pym_unpackLongLong(pyUnmarshalString pms)
        {
            return 0;
        }
        internal int pym_unpackUnicode(pyUnmarshalString pms, string dst, int limit)
        {
            return 0;
        }
        internal float pym_unpackFloat(pyUnmarshalString pms)
        {
            return 0f;
        }
        internal bool pym_unpackNoneStruct(pyUnmarshalString pms)
        {
            return false;
        }

        internal bool pym_unpack_isNoneStruct(pyUnmarshalString pms)
        {
            return false;
        }
    }
}
