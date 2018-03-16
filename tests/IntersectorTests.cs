using NUnit.Framework;
using Tiles.Tools;

namespace Tilebelt.Tools.Tests
{
    public class IntersectorTests
    {
        [Test]
        public void TestIntersector()
        {
            // arrange
            var from1 = new Point2(0,0);
            var to1 = new Point2(5, 5);
            var from2 = new Point2(5, 0);
            var to2 = new Point2( 0, 5);

            // act
            var intersects = Intersector.Intersects(from1, to1, from2, to2, out Point2 res3);

            // assert
            Assert.IsTrue(intersects);
        }

        [Test]
        public void TestIntersector2()
        {
            // arrange
            var from1 = new Point2(0, 0);
            var to1 = new Point2(5, 5);
            var from2 = new Point2(10, 0);
            var to2 = new Point2(10, 10);

            // act
            Point2 res;
            var intersects = Intersector.Intersects(from1, to1, from2, to2, out res);

            // assert
            Assert.IsFalse(intersects);
        }


    }
}
