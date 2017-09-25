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
            double minX = Math.Min(a.X, b.X);
            double maxX = Math.Max(a.X, b.X);
            double minY = Math.Min(a.Y, b.Y);
            double maxY = Math.Max(a.Y, b.Y);
            return minX <= X && X <= maxX && minY <= Y && Y <= maxY;
        }
    }

}
