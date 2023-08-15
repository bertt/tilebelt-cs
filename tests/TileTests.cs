using NUnit.Framework;

namespace Tiles.Tools.Tests;

public class TileTests
{
    [Test]
    public void ToStringTest()
    {
        // arrange
        var tile = new Tile(0, 0, 0);
        var expected = "col=0,row=0,level=0";

        // act
        var s= tile.ToString();

        // assert
        Assert.IsTrue(expected == s);
    }

    [Test]
    public void CenterTest()
    {
        //arrange
        var tile = new Tile(0, 0, 0);

        // act
        var center = tile.Center();

        // assert
        Assert.IsTrue(center[0] == 0);
        Assert.IsTrue(center[1] == 0);
    }

    [Test]
    public void IntersectorTest1()
    {
        // arrange
        var from = new Point2(5.24774, 52.04771);
        var to = new Point2(5.26747, 52.03216);
        var tile = new Tile(8431, 5408, 14);

        // act
        var res = Intersector.Intersects(tile.BoundsLL(), tile.BoundsUL(), from, to, out Point2 res1);

        // assert
        Assert.IsTrue(res);
    }


    [Test]
    public void IntersectorTest()
    {
        // arrange
        var tile = new Tile(8431, 5408, 14);
        var l0 = new Point2(5.24774, 52.04771);
        var l1 = new Point2(5.26747, 52.03216);

        // act
        var res = tile.Intersects(l0, l1);

        // assert
        Assert.IsTrue(res);
    }

    [Test]
    public void TestIntersects()
    {
        //arrange
        var tile = new Tile(5, 10, 10);
        var from = new Point2 ( -178.3, 84.70 );
        var to = new Point2 ( -177.9, 84.73 );

        // act
        var result = tile.Intersects(from, to);

        Assert.IsTrue(result);
    }

    [Test]
    public void TestIntersects2()
    {
        //arrange
        var tile = new Tile(5, 10, 10);
        var bounds = tile.Bounds();
        var from = new Point2 ( 0, 0 );
        var to = new Point2 ( 1, 1 );

        // act
        var result = tile.Intersects(from, to);

        Assert.IsFalse(result);
    }


    [Test]
    public void TestProperties()
    {
        //arrange
        var tile = new Tile(5, 10, 10);

        // act 
        tile.Properties.Add("test", 5);

        // assert
        Assert.IsTrue((int)tile.Properties["test"] == 5);
    }

    [Test]
    public void OtherCenterTest()
    {
        //arrange
        var tile = new Tile(5, 10, 10);

        // act
        var center = tile.Center();

        // assert
        Assert.IsTrue(center[0] == -178.06640625);
        Assert.IsTrue(center[1] == 84.722218027997442);
    }

    [Test]
    public void ChildrenTest()
    {
        // act
        var tile = new Tile(0, 0, 0);
        var tiles = tile.Children();

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
        var parent = tile.Parent();

        // assert
        Assert.IsTrue(parent.X == 2);
        Assert.IsTrue(parent.Y == 5);
        Assert.IsTrue(parent.Z == 9);

        // check top tile
        tile = new Tile(0, 0, 0);
        var tile1 = tile.Parent();
        Assert.IsTrue(tile1.X == 0);
        Assert.IsTrue(tile1.Y == 0);
        Assert.IsTrue(tile1.Z == 0);

        // check LL
        tile = new Tile(0, 1, 1);
        var tile2 = tile.Parent();
        Assert.IsTrue(tile2.X == 0);
        Assert.IsTrue(tile2.Y == 0);
        Assert.IsTrue(tile2.Z == 0);

        // check LR
        tile = new Tile(1, 1, 1);
        var tile3 = tile.Parent();
        Assert.IsTrue(tile3.X == 0);
        Assert.IsTrue(tile3.Y == 0);
        Assert.IsTrue(tile3.Z == 0);
    }

    [Test]
    public void QuadkeyTest()
    {
        // act
        var tile = Tilebelt.QuadkeyToTile("00001033");
        var expectedTile = new Tile(11, 3, 8);

        // assert
        Assert.IsTrue(tile.Equals(expectedTile));
    }

    [Test]
    public void TileBoundsTest()
    {
        // act
        var tile = new Tile(5, 10, 10);
        var bounds = tile.Bounds();

        // assert
        Assert.IsTrue(bounds[0] == -178.2421875);
        Assert.IsTrue(bounds[1] == 84.7060489350415);
        Assert.IsTrue(bounds[2] == -177.890625);
        Assert.IsTrue(bounds[3] == 84.73838712095339);
    }

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
