using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2018._1
{
    public class FileReader
    {
        public static string Input1Path = @"D:\Playground\AdventoOfCode2018\Inputs\1\input.txt";
        public static string Input1PathSmall = @"D:\Playground\AdventoOfCode2018\Inputs\1\input-small.txt";
        public static string Input1PathSmall0 = @"D:\Playground\AdventoOfCode2018\Inputs\1\input-small - 0.txt";
        public static string Input1PathSmall5 = @"D:\Playground\AdventoOfCode2018\Inputs\1\input-small - 5.txt";
        public static string Input1PathSmall10 = @"D:\Playground\AdventoOfCode2018\Inputs\1\input-small - 10.txt";
        public static string Input1PathSmall14 = @"D:\Playground\AdventoOfCode2018\Inputs\1\input-small - 14.txt";
        public static string Input1PathSmallMaxDepth = @"D:\Playground\AdventoOfCode2018\Inputs\1\input-small - maxDepth.txt";

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
    }
}