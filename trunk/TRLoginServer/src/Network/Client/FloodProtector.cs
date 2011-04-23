using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace TRLoginServer.src.Network.Client
{
    class FloodProtector
    {
        private SortedList<EndPoint, FloodCount> floods;
        private int maxPacketAtSecond;
        private int msecTime;

        public FloodProtector(int MaxPacketAtSecond, int Time)
        {
            floods = new SortedList<EndPoint, FloodCount>();
            maxPacketAtSecond = MaxPacketAtSecond;
            msecTime = Time;
        }

        public bool HandleFlood(EndPoint id)
        {
            if (floods.ContainsKey(id))
            {
                FloodCount counter = floods[id];
                counter.PacketCount++;
                floods[id] = counter;

                if (counter.StopWatch.ElapsedMilliseconds > msecTime)
                {
                    floods.Remove(id);
                }
                else
                {
                    floods.Remove(id);
                    return false;
                }
            }
            else
            {
                FloodCount counter = new FloodCount();
                counter.PacketCount = 1;
                counter.StopWatch.Start();

                floods.Add(id, counter);

            }

            return true;
        }

        struct FloodCount
        {
            public Stopwatch StopWatch { get; set; }
            public int PacketCount;
        }
    }
}
