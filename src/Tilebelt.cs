using System;

namespace Tilebelt.Tools
{
    public class Tilebelt
    {
        private static double d2r = Math.PI / 180;

        public static Tile PointToTile(double lon, double lat, int z)
        {
            var tileFraction = pointToTileFraction(lon, lat, z);
            var tile = new Tile();
            tile.X = (int)Math.Floor(tileFraction[0]);
            tile.Y = (int)Math.Floor(tileFraction[1]);
            tile.Z = z;
            return tile;
        }

        public static Tile GetTileByQuadkey(string quadkey)
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
            return new double[] { x, y, z };
        }
    }
}
