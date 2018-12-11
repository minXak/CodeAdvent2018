using System.Collections.Generic;

namespace Advent2018.Day4
{
    public class GuardStats
    {
        public GuardStats()
        {
            this.MinutesAsleepCounter = new Dictionary<int, int>();
        }

        public int GuardId { get; set; }
        public int TotalMinutesAsleep { get; set; }
        public Dictionary<int, int> MinutesAsleepCounter { get; set; }
    }
}