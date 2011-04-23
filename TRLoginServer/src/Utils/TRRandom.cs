// 
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
// details.
// 
// You should have received a copy of the GNU General Public License along with
// this program. If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using System.Collections.Generic;
using System.Text;

namespace TRLoginServer.src.Utils
{
    //Need Optimisation! I KNOW!
    public class TRRandom
    {
        private static Random rnd;

        static TRRandom()
        {
            rnd = new Random();
        }

        public static int Next()
        {
            return rnd.Next();
        }

        public static int Next(int maxValue)
        {
            return rnd.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return rnd.Next(minValue, maxValue);
        }

        public static byte[] NextBytes(int Length)
        {
            byte[] ret = new byte[Length];
            rnd.NextBytes(ret);
            return ret;
        }

        public static double NextDouble()
        {
            return rnd.NextDouble();
        }
    }
}
