using System.Runtime.Serialization.Formatters;
using System.Text;
using Advent2018.Shared;

namespace Advent2018.Day5
{
    public class PolymerProblem
    {
        public int GetUnitCount(string filePath)
        {
            var fileParser = new FileReader();
            var input = fileParser.GetDataPlain(filePath);

            return GetUnitCountBase(input);
        }

        public int UpdatePolymer(string filePath)
        {
            var fileParser = new FileReader();
            var input = fileParser.GetDataPlain(filePath);

            return UpdatePolymerBase(input);
        }

        public int UpdatePolymerBase(string input)
        {
            var smallestNumber = int.MaxValue;
            for (var i = 0; i < 26; i++)
            {
                char symbol = (char)(i + 65);
                char lowerSymbol = char.ToLower(symbol);
                var clearedString = input.Replace(char.ToString(symbol), "");
                clearedString = clearedString.Replace(char.ToString(lowerSymbol), "");
                var stringBuilder = new StringBuilder(clearedString);
                var unitCount = GetUnitCountBase(stringBuilder.ToString());

                if (smallestNumber > unitCount)
                {
                    smallestNumber = unitCount;
                }
            }

            return smallestNumber;
        }

        public int GetUnitCountBase(string input)
        {
            var stringBuilder = new StringBuilder(input);
            for (var i = 0; i < stringBuilder.Length - 1; i += 1)
            {
                if (this.DoesReact(stringBuilder[i], stringBuilder[i + 1]))
                {
                    i = ModifyInput(stringBuilder, i);
                }
            }

            return stringBuilder.ToString().Length;
        }

        private static int ModifyInput(StringBuilder stringBuilder, int i)
        {
            stringBuilder.Remove(i, 2);
            i -= 2;
            if (i < -1)
            {
                i = -1;
            }

            return i;
        }

        private bool DoesReact(char a, char b)
        {
            return char.ToLower(a) == char.ToLower(b) && a != b;
        }
    }
}