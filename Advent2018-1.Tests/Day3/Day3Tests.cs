using System;
using System.Linq;
using Advent2018.Day3;
using Xunit;

namespace Advent2018.Tests.Day3
{
    public class Day3Tests
    {
        [Theory]
        [InlineData("#1 @ 1,3: 4x4", 1, 1, 3, 4, 4)]
        [InlineData("#733 @ 8,746: 28x20", 733, 8, 746, 28, 20)]
        public void LineParser_Test(string input, int expectedId, int startX, int startY, int sizeX, int sizeY)
        {
            var fabric = new Fabric(input);

            Assert.Equal(expectedId, fabric.Id);
            Assert.Equal(startX, fabric.X);
            Assert.Equal(startY, fabric.Y);
            Assert.Equal(sizeX, fabric.SizeX);
            Assert.Equal(sizeY, fabric.SizeY);
        }

        [Fact]
        public void Fabric_GetAllPoints()
        {
            var fabric = new Fabric("#1 @ 1,3: 4x4");

            var points = fabric.GetAllPoints().ToList();

            Assert.Equal(16, points.Count);
        }

        [Fact]
        public void FabricIntersection_Small_GetIntersectionNumber()
        {
            var fabricsIntersection = new FabricIntersection();

            var count = fabricsIntersection.GetIntersectionsCount(Day4Consts.Input1PathSmall);

            Assert.Equal(4, count);
        }

        [Fact]
        public void FabricIntersection_Final_GetIntersectionNumber()
        {
            var fabricsIntersection = new FabricIntersection();

            var count = fabricsIntersection.GetIntersectionsCount(Day4Consts.Input1Path);

            Assert.Equal(110195, count);
        }

        [Fact]
        public void FabricIntersection_Small_GetNonOverlappedId()
        {
            var fabricsIntersection = new FabricIntersection();

            var id = fabricsIntersection.FindNonOverlapped(Day4Consts.Input1PathSmall).FirstOrDefault().Id;

            Assert.Equal(3, id);
        }

        [Fact]
        public void FabricIntersection_Final_GetNonOverlappedId()
        {
            var fabricsIntersection = new FabricIntersection();

            var nonOverlapped = fabricsIntersection.FindNonOverlapped(Day4Consts.Input1Path);

            Assert.Single(nonOverlapped);
            Assert.Equal(894, nonOverlapped.First().Id);
        }
    }
}