using System;
using System.Collections.Generic;

namespace Tiles.Tools;

public class Tilebelt
{
    private static double d2r = Math.PI / 180;

    public static List<Tile> GetTilesOnLevel(double[] extent, int level)
    {
        var res = new List<Tile>();
        var firstTile = Tilebelt.PointToTile(extent[0], extent[1], level);
        var secondTile = Tilebelt.PointToTile(extent[2], extent[3], level);
        res.Add(firstTile);
        res.Add(secondTile);

        if (Math.Abs(firstTile.X - secondTile.X) >= 1 || Math.Abs(firstTile.Y - secondTile.Y) >= 1)
        {
            var minX = Math.Min(secondTile.X, firstTile.X);
            var maxX = Math.Max(secondTile.X, firstTile.X);
            var minY = Math.Min(secondTile.Y, firstTile.Y);
            var maxY = Math.Max(secondTile.Y, firstTile.Y);

            for (var i = minX; i <= maxX; i++)
            {
                for (var j = minY; j <= maxY; j++)
                {
                    var t = new Tile(i, j, level);

                    if (!t.Equals(firstTile) && !t.Equals(secondTile))
                    {
                        res.Add(t);
                    }
                }
            }
        }
        return res;
    }


    public static int GetBboxZoom(double[] bbox)
    {
        var MAX_ZOOM = 28;
        for (var z = 0; z < MAX_ZOOM; z++)
        {
            var mask = 1 << (32 - (z + 1));
            if ((((int)bbox[0] & mask) != ((int)bbox[2] & mask)) ||
                (((int)bbox[1] & mask) != ((int)bbox[3] & mask)))
            {
                return z;
            }
        }

        return MAX_ZOOM;
    }

    public static Tile BboxToTile(double[] bbox)
    {
        // var p = bbox[0];
        var minTile = PointToTile(bbox[0], bbox[1], 32);
        var maxTile = PointToTile(bbox[2], bbox[3], 32);

        var newBbox = new double[] { minTile.X, minTile.Y, maxTile.X, maxTile.Y };

        var z = GetBboxZoom(newBbox);
        if (GetBboxZoom(bbox)==0) return new Tile(0, 0, 0);
        var x = (int)newBbox[0] >> (32 - z);
        var y = (int)newBbox[1] >> (32 - z);
        return new Tile(x, y, z);
    }

    public static Tile PointToTile(double lon, double lat, int z)
    {
        var tileFraction = pointToTileFraction(lon, lat, z);
        var tile = new Tile();
        tile.X = (int)Math.Floor(tileFraction[0]);
        tile.Y = (int)Math.Floor(tileFraction[1]);
        tile.Z = z;
        return tile;
    }

    public static Tile QuadkeyToTile(string quadkey)
    {
        var x = 0;
        var y = 0;
        var z = quadkey.Length;

        for (var i = z; i > 0; i--)
        {
            var mask = 1 << (i - 1);
            var q = quadkey[z - i];
            if (q == '1') x |= mask;
            if (q == '2') y |= mask;
            if (q == '3')
            {
                x |= mask;
                y |= mask;
            }
        }
        return new Tile(x,y,z);
    }

    private static double[] pointToTileFraction(double lon, double lat, int z)
    {
        var sin = Math.Sin(lat * d2r);
        var z2 = Math.Pow(2, z);
        var x = z2 * (lon / 360 + 0.5);
        var y = z2 * (0.5 - 0.25 * Math.Log((1 + sin) / (1 - sin)) / Math.PI);

        // wrap tile X
        x = x % z2;
        if (x < 0) x = x + z2;
        return new double[] { x, y, z };
    }
}
