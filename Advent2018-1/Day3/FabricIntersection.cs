using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Shared;

namespace Advent2018.Day3
{
    public class FabricIntersection
    {
        public int GetIntersectionsCount(string filePath)
        {
            var fabrics = InitFabrics(filePath);

            var secondAppearenece = new HashSet<Point>();
            FindOverlappedPoints(fabrics, secondAppearenece);

            return secondAppearenece.Count;
        }

        private static List<Fabric> InitFabrics(string filePath)
        {
            var fileReader = new FileReader();
            var lines = fileReader.GetDataStrings(filePath);
            var fabrics = new List<Fabric>();

            foreach (var line in lines)
            {
                fabrics.Add(new Fabric(line));
            }

            return fabrics;
        }

        private static void FindOverlappedPoints(List<Fabric> fabrics, HashSet<Point> secondAppearenece)
        {
            var firstAppearenece = new HashSet<Point>();

            foreach (var fabric in fabrics)
            {
                foreach (var point in fabric.GetAllPoints())
                {
                    if (firstAppearenece.Contains(point))
                    {
                        secondAppearenece.Add(point);
                    }

                    else
                    {
                        firstAppearenece.Add(point);
                    }
                }
            }
        }
    }
}