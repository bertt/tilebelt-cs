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
    }
}
