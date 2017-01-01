using NUnit.Framework;

namespace Tilebelt.Tools.Tests
{
    public class TilebeltTests
    {
        [Test]
        public void TileBoundsTest()
        {
            // act
            var tile = new Tile(5, 10, 10);
            var bounds = tile.GetBounds();

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
        public void ChildrenTest()
        {
            // act
            var tile = new Tile(0, 0, 0);
            var tiles = tile.GetChildren();

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
            var tile = new Tile(5, 10, 10);
            var parent = tile.GetParent();

            // assert
            Assert.IsTrue(parent.X == 2);
            Assert.IsTrue(parent.Y == 5);
            Assert.IsTrue(parent.Z == 9);

            // check top tile
            tile = new Tile(0, 0, 0);
            var tile1 = tile.GetParent();
            Assert.IsTrue(tile1.X == 0);
            Assert.IsTrue(tile1.Y == 0);
            Assert.IsTrue(tile1.Z == 0);

            // check LL
            tile = new Tile(0, 1, 1);
            var tile2 = tile.GetParent();
            Assert.IsTrue(tile2.X == 0);
            Assert.IsTrue(tile2.Y == 0);
            Assert.IsTrue(tile2.Z == 0);

            // check LR
            tile = new Tile(1, 1, 1);
            var tile3 = tile.GetParent();
            Assert.IsTrue(tile3.X == 0);
            Assert.IsTrue(tile3.Y == 0);
            Assert.IsTrue(tile3.Z == 0);
        }

        [Test]
        public void QuadkeyTest()
        {
            // act
            var tile = Tilebelt.GetTileByQuadkey("00001033");
            var expectedTile = new Tile(11, 3, 8);

            // assert
            Assert.IsTrue(tile.Equals(expectedTile));
        }
    }
}
