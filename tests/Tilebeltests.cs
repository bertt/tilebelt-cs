using NUnit.Framework;

namespace Tilebelt.Tools.Tests
{
    public class TilebeltTests
    {
        [Test]
        public void PointToTileTest()
        {
            // act
            var tile = Tilebelt.PointToTile(0, 0, 10);

            // assert
            Assert.IsTrue(tile.Z == 10);
            Assert.IsTrue(tile.X == 512);
            Assert.IsTrue(tile.Y == 512);
        }

        [Test]
        public void PointToTileAndQuadkeyTest()
        {
            // arrange 
            var expectedQuadkey = "0320100322";
            
            // act
            var tile = Tilebelt.PointToTile(-77.03239381313323, 38.91326516559442, 10);
            var quadkey = tile.Quadkey();

            // assert
            Assert.IsTrue(tile.X == 292);
            Assert.IsTrue(tile.Y == 391);
            Assert.IsTrue(tile.Z == 10);
            Assert.IsTrue(quadkey == expectedQuadkey);
        }

        [Test]
        public void MaskTest()
        {
            // arrange
            var bbox0 = -84.72656249999999;
            var mask = 64;
            var expectedResult = 0;

            // act
            var p = ((int)bbox0 & mask);

            // assert
            Assert.IsTrue(p == expectedResult);
        }

        [Test]
        public void BboxZoom()
        {
            // arrange
            var bbox = new double[] { -84.72656249999999,
                            11.178401873711785,
                            -5.625,
                            61.60639637138628 };
            var expectedLevel = 25;

            // act
            var level = Tilebelt.GetBboxZoom(bbox);

            // assert
            Assert.IsTrue(level == expectedLevel);
        }

        [Test]
        public void BboxMaxZoom()
        {
            // arrange
            var bbox = new double[] { 0,
                            0,
                            1,
                            1};
            var expectedLevel = 28;

            // act
            var level = Tilebelt.GetBboxZoom(bbox);

            // assert
            Assert.IsTrue(level == expectedLevel);
        }

    }
}
