using System;
using System.Collections.Generic;

namespace Tiles.Tools
{
    public class Tile
    {
        public Tile()
        {
            Properties = new Dictionary<string, object>();
        }

        public Tile(int X, int Y, int Z): this()
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Dictionary<string, object> Properties { get; set; }

        public override bool Equals(Object tile)
        {
            Tile otherTile = tile as Tile;
            if (otherTile == null)
                return false;
            else
                return otherTile.X == X && otherTile.Y == Y && otherTile.Z == Z;
        }

        public double[] Center()
        {
            var bounds = Bounds();
            var lon = bounds[0] + (bounds[2] - bounds[0]) / 2;
            var lat = bounds[1] + (bounds[3] - bounds[1]) / 2;
            return new double[2] { lon, lat };
        }

        public double[] Bounds()
        {
            var x0 = TileToLon(X, Z);
            var x1 = TileToLon(X + 1, Z);
            var y0 = TileToLat(Y + 1, Z);
            var y1 = TileToLat(Y, Z);

            return new double[4] { x0, y0, x1, y1 };
        }

        public List<Tile> Children()
        {
            var t1 = new Tile(X * 2, Y * 2, Z + 1);
            var t2 = new Tile(X * 2 + 1, Y * 2, Z + 1);
            var t3 = new Tile(X * 2 + 1, Y * 2 + 1, Z + 1);
            var t4 = new Tile(X * 2, Y * 2 + 1, Z + 1);
            return new List<Tile>() { t1, t2, t3, t4 };
        }

        public Point2 BoundsLL()
        {
            var bounds = Bounds();
            return new Point2 (bounds[0], bounds[1]);
        }

        public Point2 BoundsUL()
        {
            var bounds = Bounds();
            return new Point2(bounds[0], bounds[3]);
        }

        public Point2 BoundsUR()
        {
            var bounds = Bounds();
            return new Point2(bounds[2], bounds[3]);
        }

        public Point2 BoundsLR()
        {
            var bounds = Bounds();
            return new Point2 (bounds[2], bounds[1] );
        }


        public Tile Parent()
        {
            return new Tile(X >> 1, Y >> 1, Z > 0 ? Z - 1 : Z);
        }

        public List<Tile> Siblings()
        {
            var parentTile = Parent();
            return parentTile.Children();
        }

        public bool Intersects(Point2 from, Point2 to)
        {
            Point2 res;
            var result = (Intersector.Intersects(BoundsLL(), BoundsUL(), from, to, out res)) ||
                (Intersector.Intersects(BoundsUL(), BoundsUR(), from, to, out res)) ||
                (Intersector.Intersects(BoundsUR(), BoundsLR(), from, to, out res)) ||
                (Intersector.Intersects(BoundsLL(), BoundsLR(), from, to, out res));

            return result;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public string Quadkey()
        {
            var index = string.Empty;
            for (var z = Z; z > 0; z--)
            {
                var b = 0;
                var mask = 1 << (z - 1);
                if ((X & mask) != 0) b++;
                if ((Y & mask) != 0) b += 2;
                index += b.ToString();
            }
            return index;
        }

        public override string ToString()
        {
            return $"col={X},row={Y},level={Z}";
        }

        private double TileToLon(int x, int level)
        {
            return x * 360 / GetNumberOfTiles() - 180;
        }

        private double TileToLat(int y, int level)
        {
            double r2d = 180 / Math.PI;
            var n = Math.PI - 2 * Math.PI * y / Math.Pow(2, level);
            return r2d * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
            // was before: return y * 180 / GetNumberOfTiles(level) - 90;
        }

        private double GetNumberOfTiles()
        {
            return Math.Pow(2, Z);
        }
    }
}
