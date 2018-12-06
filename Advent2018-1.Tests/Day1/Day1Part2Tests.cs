using System;
using Advent2018.Day1;
using Xunit;

namespace Advent2018.Tests.Day1
{
    public class Day1Part2Tests
    {
        [Fact]
        public void FindTwiceFrequency_Small_0()
        {
            var expectedFrequency = 0;
            var day1Part2 = new FrequencyCalculatorPart2();

            var result = day1Part2.FindFrequencyReachedTwice(Day1Consts.Input1PathSmall0);
            
            Assert.Equal(expectedFrequency, result);
        }

        [Fact]
        public void FindTwiceFrequency_Small_ThrowsMaxDepth()
        {
            var day1Part2 = new FrequencyCalculatorPart2();

            var result = Assert.Throws<Exception>(() => day1Part2.FindFrequencyReachedTwice(Day1Consts.Input1PathSmallMaxDepth));

            Assert.NotNull(result);
        }

        [Fact]
        public void FindTwiceFrequency_Small_5()
        {
            var expectedFrequency = 5;
            var day1Part2 = new FrequencyCalculatorPart2();

            var result = day1Part2.FindFrequencyReachedTwice(Day1Consts.Input1PathSmall5);

            Assert.Equal(expectedFrequency, result);
        }

        [Fact]
        public void FindTwiceFrequency_Small_10()
        {
            var expectedFrequency = 10;
            var day1Part2 = new FrequencyCalculatorPart2();

            var result = day1Part2.FindFrequencyReachedTwice(Day1Consts.Input1PathSmall10);

            Assert.Equal(expectedFrequency, result);
        }

        [Fact]
        public void FindTwiceFrequency_Small_14()
        {
            var expectedFrequency = 14;
            var day1Part2 = new FrequencyCalculatorPart2();

            var result = day1Part2.FindFrequencyReachedTwice(Day1Consts.Input1PathSmall14);

            Assert.Equal(expectedFrequency, result);
        }

        [Fact]
        public void FindTwiceFrequency_Final()
        {
            var expectedFrequency = 81204;
            var day1Part2 = new FrequencyCalculatorPart2();

            var result = day1Part2.FindFrequencyReachedTwice(Day1Consts.Input1Path);

            Assert.Equal(expectedFrequency, result);
        }
    }
}