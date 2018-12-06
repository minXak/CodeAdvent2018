using System.Linq;
using Advent2018.Shared;

namespace Advent2018.Day1
{
    public class FrequencyCalculator
    {
        public int CalculateFrequency(string fileInput)
        {
            var fileReader = new FileReader();
            var data = fileReader.GetData(fileInput);

            var result = data.Sum();
            return result;
        }
    }
}