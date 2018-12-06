using Advent2018.Shared;
using Xunit;

namespace Advent2018.Tests.Day1
{
    public class Day1Tests
    {
        [Fact]
        public void ReadInput_ResultLengthAsExpected()
        {
            var testDataLineCount = 996;
            var fileReader = new FileReader();

            var result = fileReader.GetData(Day1Consts.Input1Path);
            
            Assert.Equal(testDataLineCount, result.Count);
        }

        [Fact]
        public void ReadInput_Small_ResultLengthAsExpected()
        {
            var testDataLineCount = 8;
            var fileReader = new FileReader();

            var result = fileReader.GetData(Day1Consts.Input1PathSmall);

            Assert.Equal(testDataLineCount, result.Count);
        }

        [Fact]
        public void CalculateFrequency_Small_ResultFrequencyAsExpected()
        {
            var expectedFrequency = -9;
            var day1 = new Advent2018.Day1.FrequencyCalculator();

            var result = day1.CalculateFrequency(Day1Consts.Input1PathSmall);

            Assert.Equal(expectedFrequency, result);
        }

        [Fact]
        public void CalculateFrequency_ResultFrequencyAsExpected()
        {
            var expectedFrequency = 599;
            var day1 = new Advent2018.Day1.FrequencyCalculator();

            var result = day1.CalculateFrequency(Day1Consts.Input1Path);

            Assert.Equal(expectedFrequency, result);
        }
    }
}