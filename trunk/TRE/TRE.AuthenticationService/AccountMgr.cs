using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.AuthenticationService
{
    public class AccountMgr
    {
        public class ACCOUNTINFO
        {
	        string Name; // char[16];
	        string Password; // char[16];
	        ulong UniqueID;
	        char PrivilgeLevel;
        };

        public int Init()
        {
            return 0;
        }

        //Returns the internal FUID
        public UInt64 NewAccount(string Name, string Password)
        {
            return 0;
        }

        public int GetInformationByLogin(char name, char password, ACCOUNTINFO ai)
        {
            return 1;
        }

    }
}
