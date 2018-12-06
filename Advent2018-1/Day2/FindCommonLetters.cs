using System;
using System.Text;
using Advent2018.Shared;

namespace Advent2018.Day2
{
    public class FindCommonLetters
    {
        public string FindIncerception(string filePath)
        {
            var fileReader = new FileReader();
            var items = fileReader.GetDataStrings(filePath);

            for (var i = 0; i < items.Count-1; i++)
            {
                for (var y = i + 1; y < items.Count; y++)
                {
                    var interception = this.Intercept(items[i], items[y]);
                    if (interception != "")
                    {
                        return interception;
                    }
                }
            }

            return "";
        }

        public string Intercept(string input1, string input2)
        {
            bool firstStrike = false;
            var stringBuilder = new StringBuilder();

            var output = "";

            for (var i=0; i <input1.Length; i++)
            {
                if (input1[i] != input2[i])
                {
                    if (firstStrike)
                    {
                        return "";
                    }

                    firstStrike = true;
                }
                else
                {
                    stringBuilder.Append(input1[i]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}