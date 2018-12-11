using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Shared;

namespace Advent2018.Day4
{
    public class GuardProblem
    {
        public int GetBestGuardHash(string filePath)
        {
            var items = InitTimeRecordsOrdered(filePath);

            UpdateGuardIds(items);

            var tuple = this.GetBestGuard(items);

            return GetHash(tuple);
        }

        public int GetBestGuardHashOfAll(string filePath)
        {
            var items = InitTimeRecordsOrdered(filePath);

            UpdateGuardIds(items);

            var tuple = this.GetBestGuardOfAll(items);

            return GetHash(tuple);
        }

        private Tuple<int, int> GetBestGuardOfAll(List<TimeRecord> items)
        {
            var guardsStats = GetGuardStats(items);
            var value = guardsStats.Max(s => s.Value.MinutesAsleepCounter.Max(ss => ss.Value));
            var guardStat = guardsStats.FirstOrDefault(s => s.Value.MinutesAsleepCounter.Any(ss => ss.Value == value));
            var minute = guardStat.Value.MinutesAsleepCounter.FirstOrDefault(s => s.Value == value);
            return new Tuple<int, int>(guardStat.Key, minute.Key);
        }

        private static int GetHash(Tuple<int, int> tuple)
        {
            return tuple.Item1 * tuple.Item2;
        }

        private Tuple<int, int> GetBestGuard(List<TimeRecord> items)
        {
            var guardsStats = GetGuardStats(items);

            var statMax = GetMaxTotalMinutes(guardsStats);

            var minutesMax = GetMostOftenMinute(statMax);
            return new Tuple<int, int>(statMax.Key, minutesMax.Key);
        }

        private static KeyValuePair<int, int> GetMostOftenMinute(KeyValuePair<int, GuardStats> statMax)
        {
            var minutesCount = statMax.Value.MinutesAsleepCounter.Max(s => s.Value);
            var minutesMax = statMax.Value.MinutesAsleepCounter.FirstOrDefault(s => s.Value == minutesCount);
            return minutesMax;
        }

        private static KeyValuePair<int, GuardStats> GetMaxTotalMinutes(Dictionary<int, GuardStats> guardsStats)
        {
            var max = guardsStats.Values.Max(s => s.TotalMinutesAsleep);
            var statMax = guardsStats.FirstOrDefault(s => s.Value.TotalMinutesAsleep == max);
            return statMax;
        }

        private static Dictionary<int, GuardStats> GetGuardStats(List<TimeRecord> items)
        {
            var guardsStats = new Dictionary<int, GuardStats>();
            DateTime? lastMinuteSleep = null;
            foreach (var timeRecord in items)
            {
                if (timeRecord.Action == ActionEnum.Sleep)
                {
                    lastMinuteSleep = timeRecord.Date;
                }

                if (timeRecord.Action == ActionEnum.Wake)
                {
                    if (!lastMinuteSleep.HasValue)
                    {
                        continue;
                    }

                    AddTotalMinutes(timeRecord, lastMinuteSleep, guardsStats);

                    AddMinutesCount(lastMinuteSleep, timeRecord, guardsStats);
                }
            }

            return guardsStats;
        }

        private static void AddMinutesCount(DateTime? lastMinuteSleep, TimeRecord timeRecord, Dictionary<int, GuardStats> guardsStats)
        {
            for (var i = lastMinuteSleep.Value; i < timeRecord.Date; i = i.AddMinutes(1))
            {
                if (guardsStats[timeRecord.GuardId].MinutesAsleepCounter.ContainsKey(i.Minute))
                {
                    guardsStats[timeRecord.GuardId].MinutesAsleepCounter[i.Minute]++;
                }
                else
                {
                    guardsStats[timeRecord.GuardId].MinutesAsleepCounter.Add(i.Minute, 1);
                }
            }
        }

        private static void AddTotalMinutes(TimeRecord timeRecord, DateTime? lastMinuteSleep, Dictionary<int, GuardStats> guardsStats)
        {
            var timeSpan = timeRecord.Date - lastMinuteSleep;

            if (guardsStats.ContainsKey(timeRecord.GuardId))
            {
                guardsStats[timeRecord.GuardId].TotalMinutesAsleep += timeSpan.Value.Minutes;
            }
            else
            {
                guardsStats.Add(timeRecord.GuardId, new GuardStats
                {
                    GuardId = timeRecord.GuardId,
                    TotalMinutesAsleep = timeSpan.Value.Minutes
                });
            }
        }

        private static void UpdateGuardIds(List<TimeRecord> ordered)
        {
            int currentGuardId = 0;
            foreach (var timeRecord in ordered)
            {
                if (timeRecord.Action == ActionEnum.Begins)
                {
                    currentGuardId = timeRecord.GuardId;
                }
                else
                {
                    timeRecord.GuardId = currentGuardId;
                }
            }
        }

        private static List<TimeRecord> InitTimeRecordsOrdered(string filePath)
        {
            var fileReader = new FileReader();
            var lines = fileReader.GetDataStrings(filePath);
            var timeRecords = new List<TimeRecord>();

            foreach (var line in lines)
            {
                var timeRecord = new TimeRecord(line);
                timeRecords.Add(timeRecord);
            }

            return timeRecords.OrderBy(s => s.Date).ToList();
        }
    }
}