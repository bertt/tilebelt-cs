namespace Tilebelt
{
    public class Tile
    {
        public Tile()
        {
        }

        public Tile (int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
