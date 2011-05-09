using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ConsoleAuthServerThuvvik.Communication
{
    /// <summary>
    /// Found here  http://www.i-programmer.info/programming/c/1255-inside-c-data-structs.html?start=3
    /// As to gain time. for Serialize@ thuvvik 20110507 0149
    /// 
    /// found here http://bytes.com/topic/c-sharp/answers/249770-byte-structure
    /// As to gain time. For Deserialize method @thuvvik 20110507 2030
    /// </summary>
    public static class StructureOperations
    {
        public static byte[] RawSerialize(object anything) 
        { 
            int rawsize = Marshal.SizeOf(anything); 
            byte[] rawdata = new byte[rawsize]; 
            GCHandle handle = GCHandle.Alloc(rawdata, GCHandleType.Pinned); 
            Marshal.StructureToPtr(anything, handle.AddrOfPinnedObject(), false); 
            handle.Free(); 
            return rawdata; 
        }

        // other method found with Byte[] input parameter 
        // better than stream @thuvvik 20110507 2030
        //public static T ReadStruct<T>(FileStream fs)
        //{
        //    byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
        //    fs.Read(buffer, 0, Marshal.SizeOf(typeof(T)));
        //    GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        //    T temp = (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        //    handle.Free();
        //    return temp;
        //}

        public static T RawDeserialize<T>(byte[] rawData, int position)
        {
            int rawsize = Marshal.SizeOf(typeof(T));
            if (rawsize > rawData.Length)
                return default(T);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawData, position, buffer, rawsize);
            T retobj = (T) Marshal.PtrToStructure(buffer, typeof(T));
            Marshal.FreeHGlobal(buffer);
            return retobj;
        }

    }
}
