using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    class Constants
    {
        int CLASSID_CHARACTERSELECTIONPOD = 3543; // classIDs are found in entityClass.pyo

        enum entityID
        {
	        selfdefStart =	100,
	        // character selection pods
	        charPodFirst,	
	        charPodLast = charPodFirst+15	
        }

    }
}
