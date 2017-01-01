using NUnit.Framework;

namespace Tilebelt.Tools.Tests
{
    public class TileTests
    {
        [Test]
        public void EqualTest()
        {
            // arrange 
            var tile1 = new Tile(5, 10, 10);
            var tile2 = new Tile(5, 10, 10);

            // act
            var equals = tile1.Equals(tile2);

            // assert
            Assert.IsTrue(equals);
        }

        [Test]
        public void SiblingsTest()
        {
            // arrange 
            var tile1 = new Tile(5, 10, 10);

            // act
            var tiles = tile1.Siblings();

            // assert
            Assert.IsTrue(tiles.Count == 4);
            Assert.IsTrue(tiles[0].X == 4);
            Assert.IsTrue(tiles[0].Z == 10);
            Assert.IsTrue(tiles[0].Z == 10);
        }

        [Test]
        public void EqualNullTest()
        {
            // arrange 
            var tile1 = new Tile(5, 10, 10);

            // act
            var equals = tile1.Equals(null);

            // assert
            Assert.IsTrue(!equals);
        }

        [Test]
        public void HashcodeTest()
        {
            // arrange 
            var tile1 = new Tile(5, 10, 10);

            // act
            var hashcode = tile1.GetHashCode();

            // assert
            Assert.IsTrue(hashcode>0);
        }

        [Test]
        public void QuadKeyTest()
        {
            // arrange 
            var tile1 = new Tile(11, 3, 8);

            // act
            var quadkey = tile1.Quadkey();

            // assert
            Assert.IsTrue(quadkey == "00001033");
        }

        [Test]
        public void TestQuadkey03()
        {
            // arrange
            var quadkey = "03";
            var expectedTile = new Tile(1, 1, 2);

            // act
            var tile = Tilebelt.QuadkeyToTile(quadkey);

            // assert
            Assert.IsTrue(tile.Equals(expectedTile));
        }

        [Test]
        public void PointAndTileBackAndForth()
        {
            // arrange
            var tile = Tilebelt.PointToTile(10, 10, 10);

            // arrange
            var quadkey = tile.Quadkey();
            var tile1 = Tilebelt.QuadkeyToTile(quadkey);

            // act
            Assert.IsTrue(tile.Equals(tile1));
        }
    }
}
