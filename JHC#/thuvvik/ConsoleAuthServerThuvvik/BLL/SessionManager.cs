using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAuthServerThuvvik.BLL
{
    public class SessionManager
    {
        private uint _timeOut = 50000;

        public SessionManager(uint pTimeOut)
        {
            _timeOut = pTimeOut;
        }

        public SessionManager()
        {
        }

    }
}
