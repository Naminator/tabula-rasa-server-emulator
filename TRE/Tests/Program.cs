using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace Tests
{
    class Program
    {
        [DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int Add(int a, int b);

        //[DllImport(@"lib\JHLIB.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //static extern int Add2(int a, int b);

        static void Main(string[] args)
        {
            DALTests.Run();

            Console.WriteLine(Add(1, 2));

            //Console.WriteLine(Add2(1, 2));

            Console.ReadKey();
        }
    }
}
