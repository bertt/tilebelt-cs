using System;

namespace Tilebelt
{
    public class Tile
    {
        public Tile()
        {
        }

        public Tile(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override bool Equals(Object tile)
        {
            Tile otherTile = tile as Tile;
            if (otherTile == null)
                return false;
            else
                return otherTile.X == X && otherTile.Y == Y && otherTile.Z == Z;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }
    }
}
