using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace TRE.AuthenticationService.Network.Client
{
    internal class FloodProtector
    {
        SortedList<EndPoint, FloodCount> _floods;
        int _maxPacketAtSecond;
        int _msecTime;

        struct FloodCount
        {
            public Stopwatch StopWatch { get; set; }
            public int PacketCount;
        }

        public FloodProtector(int MaxPacketAtSecond, int Time)
        {
            _floods = new SortedList<EndPoint, FloodCount>();
            _maxPacketAtSecond = MaxPacketAtSecond;
            _msecTime = Time;
        }

        public bool HandleFlood(EndPoint id)
        {
            if (_floods.ContainsKey(id))
            {
                FloodCount counter = _floods[id];
                counter.PacketCount++;
                _floods[id] = counter;

                if (counter.StopWatch.ElapsedMilliseconds > _msecTime)
                {
                    _floods.Remove(id);
                }
                else
                {
                    _floods.Remove(id);
                    return false;
                }
            }
            else
            {
                FloodCount counter = new FloodCount();
                counter.PacketCount = 1;
                counter.StopWatch.Start();

                _floods.Add(id, counter);

            }

            return true;
        }

       
    }
}
