using Advent2018.Day4;
using Xunit;

namespace Advent2018.Tests.Day4
{
    public class Day4Tests
    {
        [Theory]
        [InlineData("[1518-11-01 00:00] Guard #10 begins shift", 10, "1518-11-01 00:00",0, ActionEnum.Begins )]
        [InlineData("[1518-11-03 00:24] falls asleep", 0, "1518-11-03 00:24", 24, ActionEnum.Sleep )]
        [InlineData("[1518-11-03 00:29] wakes up", 0, "1518-11-03 00:29", 29, ActionEnum.Wake )]
        public void LineParser_Test(string input, int guardId, string date, int minutes, ActionEnum action)
        {
            var timeRecord = new TimeRecord(input);

            Assert.Equal(guardId, timeRecord.GuardId);
            Assert.Equal(date, timeRecord.Date.ToString("yyyy-MM-dd HH:mm"));
            Assert.Equal(minutes, timeRecord.Minute);
            Assert.Equal(action, timeRecord.Action);
        }

        [Fact]
        public void GuardProblem_Small_FindHash()
        {
            var guardProblem = new GuardProblem();

            var result = guardProblem.GetBestGuardHash(Day5Consts.Input1PathSmall);
            
            Assert.Equal(240, result);
        }

        [Fact]
        public void GuardProblem_Final_FindHash()
        {
            var guardProblem = new GuardProblem();

            var result = guardProblem.GetBestGuardHash(Day5Consts.Input1Path);

            Assert.Equal(115167, result);
        }

        [Fact]
        public void GuardProblemOfAll_Small_FindHash()
        {
            var guardProblem = new GuardProblem();

            var result = guardProblem.GetBestGuardHashOfAll(Day5Consts.Input1PathSmall);

            Assert.Equal(4455, result);
        }

        [Fact]
        public void GuardProblemOfAll_Final_FindHash()
        {
            var guardProblem = new GuardProblem();

            var result = guardProblem.GetBestGuardHashOfAll(Day5Consts.Input1Path);

            Assert.Equal(32070, result);
        }
    }
}