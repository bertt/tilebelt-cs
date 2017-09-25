namespace Tiles.Tools
{
    public class Intersector
    {
        public static bool Intersects(Point2 a0, Point2 b0, Point2 a1, Point2 b1, out Point2 clip)
        {
            double A0 = b0.Y - a0.Y;
            double B0 = a0.X - b0.X;
            double C0 = (A0 * a0.X) + (B0 * a0.Y);
            double A1 = b1.Y - a1.Y;
            double B1 = a1.X - b1.X;
            double C1 = (A1 * a1.X) + (B1 * a1.Y);
            double det = (A0 * B1) - (A1 * B0);
            if (det != 0.0)
            {
                double x = ((B1 * C0) - (B0 * C1)) / det;
                double y = ((A0 * C1) - (A1 * C0)) / det;

                var point = new Point2(x, y);
                if (point.IsOnLine(a0, b0) && point.IsOnLine(a1, b1))
                {
                    clip = point;
                    return true;
                }
            }            
            clip = default(Point2);
            return false;
        }
    }
}
