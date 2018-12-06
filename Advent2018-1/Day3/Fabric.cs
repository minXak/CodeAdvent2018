using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2018.Day3
{
    public class Fabric
    {
        public Fabric(string description)
        {
            this.ParseDescription(description);
        }

        private void ParseDescription(string description)
        {
            var numbers = Regex.Matches(description, @"\d+")
                .Select(m => m.Value)
                .ToList().Select(int.Parse).ToList();

            this.Id = numbers[0];
            this.X = numbers[1];
            this.Y = numbers[2];
            this.SizeX = numbers[3];
            this.SizeY = numbers[4];
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public bool IsOverlapping { get; set; }

        public IEnumerable<Point> GetAllPoints()
        {
            for (var i = 0; i < this.SizeX; i++)
            {
                for (var y = 0; y < this.SizeY; y++)
                {
                    yield return new Point { X = this.X + i, Y = this.Y + y };
                }
            }
        }
    }

    public struct Point
    {
        public int X;
        public int Y;
    }
}