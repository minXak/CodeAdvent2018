using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2018.Day4
{
    public class TimeRecord
    {
        public DateTime Date { get; set; }
        public int Minute { get; set; }
        public ActionEnum Action { get; set; }
        public int GuardId { get; set; }

        public TimeRecord(string line)
        {
            this.Date = DateTime.Parse(line.Substring(line.IndexOf('[')+1, line.IndexOf(']') - line.IndexOf('[') - 1));
            this.Minute = this.Date.Minute;
            this.Action = this.ParseAction(line);

            if (this.Action == ActionEnum.Begins)
            {
                this.GuardId = this.ParseGuardId(line);
            }
        }

        private int ParseGuardId(string line)
        {
            return
                Regex.Matches(line, @"#\d+")
                    .Select(m => m.Value.TrimStart('#'))
                    .ToList().Select(int.Parse).FirstOrDefault();
        }

        private ActionEnum ParseAction(string line)
        {
            if (line.Contains("wakes up"))
            {
                return ActionEnum.Wake;
            }

            if (line.Contains("falls asleep"))
            {
                return ActionEnum.Sleep;
            }

            return ActionEnum.Begins;
        }
    }
}