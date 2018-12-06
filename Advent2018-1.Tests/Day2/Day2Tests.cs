using Advent2018.Day2;
using Xunit;

namespace Advent2018.Tests.Day2
{
    public class Day2Tests
    {
        [Theory]
        [InlineData("abcdef", false, false)]
        [InlineData("bababc", true, true)]
        [InlineData("abbcde", true, false)]
        [InlineData("abcccd", false, true)]
        [InlineData("aabcdd", true, false)]
        [InlineData("abcdee", true, false)]
        [InlineData("ababab", false, true)]
        [InlineData("abababab", false, false)]
        public void CalculateAppearence_SmallInputs(string input, bool expectedTwos, bool expcetedThrees)
        {
            var day2 = new CheckSumCalculator();

            var result = day2.CalculateAppearence(input);

            Assert.Equal(expectedTwos, result.ContainsTwo);
            Assert.Equal(expcetedThrees, result.ContainsThree);
        }

        [Theory]
        [InlineData("icxjubroqtunzeyzpomfksahgw", true, false)]
        [InlineData("icxjvbrogturleyzxdmfksahgw", true, false)]
        public void CalculateAppearence_LiveInputs(string input, bool expectedTwos, bool expcetedThrees)
        {
            var day2 = new CheckSumCalculator();

            var result = day2.CalculateAppearence(input);

            Assert.Equal(expectedTwos, result.ContainsTwo);
            Assert.Equal(expcetedThrees, result.ContainsThree);
        }

        [Fact]
        public void CalculateCheckSum_Small()
        {
            var expectedResult = 12;
            var day2 = new CheckSumCalculator();

            var result = day2.CalculateChecksum(Day2Consts.Input1PathSmall);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateCheckSum_Big()
        {
            var expectedResult = 6888;
            var day2 = new CheckSumCalculator();

            var result = day2.CalculateChecksum(Day2Consts.Input1Path);

            Assert.Equal(expectedResult, result);
        }
    }
}