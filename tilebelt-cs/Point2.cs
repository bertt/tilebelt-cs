using System;

namespace Tiles.Tools
{
    public struct Point2
    {
        public readonly double X;
        public readonly double Y;

        public Point2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsOnLine(Point2 a, Point2 b)
        {
            double minX = Math.Round(Math.Min(a.X, b.X),9);
            double maxX = Math.Round(Math.Max(a.X, b.X),9);
            double minY = Math.Round(Math.Min(a.Y, b.Y),9);
            double maxY = Math.Round(Math.Max(a.Y, b.Y),9);

            return minX <= Math.Round(X,9) && Math.Round(X,9) <= maxX && minY <= Math.Round(Y,9) && Math.Round(Y,9) <= maxY;
        }
    }

}
