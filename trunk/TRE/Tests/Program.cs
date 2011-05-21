using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

using JHLIB;

namespace JHLIBTests
{

    class Program
    {
        
        static void Main(string[] args)
        {
            //DALTests.Run();

            Console.WriteLine(string.Format("Test JHLIB.AccountCrypter : {0}",
                JHLIB.AccountCrypter.Test() ? "passed" : "failed"
                ));

            Console.WriteLine(string.Format("Test JHLIB.Blowfish : {0}",
                JHLIB.Blowfish.Test() ? "passed" : "failed"
                ));


            Console.ReadKey();
        }
    }
}
