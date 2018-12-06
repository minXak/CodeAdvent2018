using System.Linq;

namespace Advent2018._1
{
    public class Day1
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