using System;
using System.Collections.Generic;

namespace Tilebelt.Tools
{
    public class Tilebelt
    {
        private static double r2d = 180 / Math.PI;
        private static double d2r = Math.PI / 180;
        public static double[] GetTileBounds(int tx, int ty, int level)
        {
            var x0 = TileToLon(tx, level);
            var x1 = TileToLon(tx + 1, level);
            var y0 = TileToLat(ty + 1, level);
            var y1 = TileToLat(ty, level);

            return new double[4] { x0, y0, x1, y1 };
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

        public static List<Tile> GetChildren(int x, int y, int z)
        {
            var t1 = new Tile(x * 2, y * 2, z + 1);
            var t2 = new Tile(x * 2 + 1, y * 2, z + 1);
            var t3 = new Tile(x * 2 + 1, y * 2 + 1, z + 1);
            var t4 = new Tile(x * 2, y * 2 + 1, z + 1);
            return new List<Tile>() { t1, t2, t3, t4 };
        }

        public static Tile GetParent(int x, int y, int z)
        {
            // UL
            if (x % 2 == 0 && y % 2 == 0)
            {
                return new Tile(x / 2, y / 2, z);
            }
            // LL
            if ((x % 2 == 0) && (!(y % 2 == 0)))
            {
                return new Tile(x / 2, (y - 1) / 2, z - 1);
            }
            // UR
            if ((!(x % 2 == 0)) && (y % 2 == 0))
            {
                return new Tile((x - 1) / 2, y / 2, z - 1);
            }
            // LR
            return new Tile((x - 1) / 2, (y - 1) / 2, z - 1);
        }

        private static double[] pointToTileFraction(double lon, double lat, int z)
        {
            var sin = Math.Sin(lat * d2r);
            var z2 = Math.Pow(2, z);
            var x = z2 * (lon / 360 + 0.5);
            var y = z2 * (0.5 - 0.25 * Math.Log((1 + sin) / (1 - sin)) / Math.PI);
            return new double[] { x, y, z };
        }

        private static double TileToLon(int x, int level)
        {
            return x * 360 / GetNumberOfTiles(level) - 180;
        }

        private static double TileToLat(int y, int level)
        {
            var n = Math.PI - 2 * Math.PI * y / Math.Pow(2, level);
            return r2d * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
            // was before: return y * 180 / GetNumberOfTiles(level) - 90;
        }

        private static double GetNumberOfTiles(int level)
        {
            return Math.Pow(2, level);
        }
    }
}
