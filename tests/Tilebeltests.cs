using NUnit.Framework;

namespace Tiles.Tools.Tests;

public class TilebeltTests
{
    [Test]
    public void TestIssue1()
    {
        // see https://github.com/bertt/tilebelt-cs/issues/1
        var bbox = new double[] { -180, 41.1850968, 180, 82.0586232 };
        var tile = Tilebelt.BboxToTile(bbox);
        Assert.That(tile.Z == 0 && tile.X == 0 && tile.Y==0);
    }

    [Test]
    public void GetTilesOnLevelTests()
    {
        var tiles = Tilebelt.GetTilesOnLevel(new double[] { 5.116882, 51.926908, 5.770226, 52.156874 }, 10);
        Assert.That(tiles.ToList().Count == 6);
    }

    [Test]
    public void QuadkeyToTile()
    {
        var t = new Tile(8131, 5243, 13);
        var key = t.Quadkey();
        Assert.That(key == "3131113222033");

        // var key = "3131113222033";
        var tile = Tilebelt.QuadkeyToTile(key);
        Assert.That(tile.Z == 13);
        Assert.That(tile.X == 8131);
        Assert.That(tile.Y == 5243);
    }

    [Test]
    public void BboxToTileBig()
    {
        // arrange
        var bbox = new double[] { -84.72656249999999,
                        11.178401873711785,
                        -5.625,
                        61.60639637138628 };

        var expectedTile = new Tile(1, 1, 2);

        // act
        var tile = Tilebelt.BboxToTile(bbox);

        // assert
        Assert.That(tile.Equals(expectedTile));
    }

    [Test]
    public void BboxToTileNoArea()
    {
        // arrange
        var bbox = new double[] { -84,
            11,
            -84,
            11 };

        var expectedTile = new Tile(71582788, 125964677, 28);

        // act
        var tile = Tilebelt.BboxToTile(bbox);

        // assert
        Assert.That(tile.Equals(expectedTile));
    }

    [Test]
    public void BboxToTileDc()
    {
        // arrange
        var bbox = new double[] { -77.04615354537964,
            38.899967510782346,
            -77.03664779663086,
            38.90728142481329 };

        var expectedTile = new Tile(9371, 12534, 15);

        // act
        var tile = Tilebelt.BboxToTile(bbox);

        // assert
        Assert.That(tile.Equals(expectedTile));
    }



    [Test]
    public void BboxToTileCrossingLatLon()
    {
        // arrange
        var bbox = new double[] { -10, -10, 10, 10 };

        var expectedTile = new Tile(0, 0, 0);

        // act
        var tile = Tilebelt.BboxToTile(bbox);

        // assert
        Assert.That(tile.Equals(expectedTile));
    }

    [Test]
    public void BBoxToTileCrossMeridian()
    {
        // arrange
        var bbox = new double[] { -0.000001, -85, 1000000, 85 };

        var expectedTile = new Tile(0, 0, 0);

        // act
        var tile = Tilebelt.BboxToTile(bbox);

        // assert
        Assert.That(tile.Equals(expectedTile));
    }



    [Test]
    public void PointToTileTest()
    {
        // act
        var tile = Tilebelt.PointToTile(0, 0, 10);

        // assert
        Assert.That(tile.Z == 10);
        Assert.That(tile.X == 512);
        Assert.That(tile.Y == 512);
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
        Assert.That(tile.X == 292);
        Assert.That(tile.Y == 391);
        Assert.That(tile.Z == 10);
        Assert.That(quadkey == expectedQuadkey);
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
        Assert.That(p == expectedResult);
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
        Assert.That(level == expectedLevel);
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
        Assert.That(level == expectedLevel);
    }
}
