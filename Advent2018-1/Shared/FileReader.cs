using System.Collections.Generic;
using System.IO;

namespace Advent2018.Shared
{
    public class FileReader
    {
        public List<int> GetData(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var result = new List<int>();
            foreach (var line in lines)
            {
                if (int.TryParse(line, out int lineInt))
                {
                    result.Add(lineInt);
                }
            }

            return result;
        }

        public List<string> GetDataStrings(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            return new List<string>(lines);
        }
    }
}