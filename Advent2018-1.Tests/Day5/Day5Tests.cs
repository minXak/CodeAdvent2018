using Advent2018.Day5;
using Xunit;

namespace Advent2018.Tests.Day5
{
    public class Day5Tests
    {
        [Theory]
        [InlineData("aabAAB",6)]
        [InlineData("aA", 0)]
        [InlineData("Aa", 0)]
        [InlineData("abAB", 4)]
        [InlineData("abBA", 0)]
        [InlineData("dabAcCaCBAcCcaDA", 10)]
        public void PolymerProblem_StringInput(string input, int length)
        {
            var polymerProblem = new PolymerProblem();

            var result = polymerProblem.GetUnitCountBase(input);

            Assert.Equal(length, result);
        }

        [Fact]
        public void PolymerProblem_Final_FileInput()
        {
            var polymerProblem = new PolymerProblem();

            var result = polymerProblem.GetUnitCount(Day5Consts.Input1Path);

            Assert.Equal(9562, result);
        }
    }
}