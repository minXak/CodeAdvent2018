using System.Collections.Generic;
using System.Linq;
using Advent2018.Shared;

namespace Advent2018.Day2
{
    public class CheckSumCalculator
    {
        public int CalculateChecksum(string filePath)
        {
            var fileReader = new FileReader();

            var data = fileReader.GetDataStrings(filePath);

            var twos = 0;
            var threes = 0;

            foreach (var item in data)
            {
                var appearence = CalculateAppearence(item);
                if (appearence.ContainsThree)
                {
                    threes++;
                }

                if (appearence.ContainsTwo)
                {
                    twos++;
                }
            }

            return twos * threes;
        }

        public Appearence CalculateAppearence(string id)
        {
            var parsedId = ParseLetters(id);

            var result = new Appearence
            {
                ContainsThree = parsedId.Any(s => s.Value == 3),
                ContainsTwo = parsedId.Any(s => s.Value == 2)
            };

            return result;
        }

        private static Dictionary<char, int> ParseLetters(string id)
        {
            var parsedId = new Dictionary<char, int>();

            foreach (var letter in id)
            {
                if (parsedId.ContainsKey(letter))
                {
                    parsedId[letter] += 1;
                }
                else
                {
                    parsedId.Add(letter, 1);
                }
            }

            return parsedId;
        }

        public struct Appearence
        {
            public bool ContainsThree;
            public bool ContainsTwo;
        }
    }
}