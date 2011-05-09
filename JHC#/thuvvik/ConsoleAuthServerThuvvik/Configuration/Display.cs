using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAuthServerThuvvik.Configuration
{
    public static class Display
    {
        public static void displayMessage(String pMessage)
        {
            Console.Out.WriteLine(pMessage);
        }

        public static void displayMessage( String pKey, String pValue)
        {
            displayMessage(String.Format("{0} = {1}", pKey, pValue));
        }

        

        public static void waitForChar(char letterExpected)
        {
            while (true)
            {
                char[] buffer = new char[1];
                Console.In.Read(buffer, 0, 1);
                if (buffer[0].Equals(letterExpected))
                    break;
            }
        }
    }
}
