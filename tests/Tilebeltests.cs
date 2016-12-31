using NUnit.Framework;

namespace Tilebelt.Tools.Tests
{
    public class TilebeltTests
    {
        [Test]
        public void TileBoundsTest()
        {
            // act
            var bounds = Tilebelt.GetTileBounds(5, 10, 10);

            // assert
            Assert.IsTrue(bounds[0] == -178.2421875);
            Assert.IsTrue(bounds[1] == 84.7060489350415);
            Assert.IsTrue(bounds[2] == -177.890625);
            Assert.IsTrue(bounds[3] == 84.73838712095339);
        }

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
        public void ChildrenTest()
        {
            // act
            var tiles = Tilebelt.GetChildren(0, 0, 0);

            // assert
            Assert.IsTrue(tiles.Count == 4);
            Assert.IsTrue(tiles[0].Z == 1);
            Assert.IsTrue(tiles[0].X == 0);
            Assert.IsTrue(tiles[0].Y == 0);
        }

        [Test]
        public void ParentTest()
        {
            // act
            var tile = Tilebelt.GetParent(5,10,10);

            // assert
            Assert.IsTrue(tile.X == 2);
            Assert.IsTrue(tile.Y == 5);
            Assert.IsTrue(tile.Z == 9);
        }
    }
}
