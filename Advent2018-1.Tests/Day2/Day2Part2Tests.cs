using Advent2018.Day2;
using Xunit;

namespace Advent2018.Tests.Day2
{
    public class Day2Part2Tests
    {
        [Theory]
        [InlineData("fghij", "fguij", "fgij")]
        [InlineData("abcde", "axcye", "")]
        public void CalculateCommonChars(string input1, string input2, string intersection)
        {
            var day2Part2 = new FindCommonLetters();

            var result = day2Part2.Intercept(input1, input2);

            Assert.Equal(intersection, result);
        }

        [Fact]
        public void FindInterception_Small()
        {
            var expecteInterception = "fgij";
            var day2Part2 = new FindCommonLetters();

            var result = day2Part2.FindIncerception(Day2Consts.Input1PathSmallCommon);

            Assert.Equal(expecteInterception, result);
        }

        [Fact]
        public void FindInterception_Final()
        {
            var expecteInterception = "icxjvbrobtunlelzpdmfkahgs";
            var day2Part2 = new FindCommonLetters();

            var result = day2Part2.FindIncerception(Day2Consts.Input1Path);

            Assert.Equal(expecteInterception, result);
        }
    }
}