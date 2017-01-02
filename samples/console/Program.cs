using System;
using Tiles.Tools;

namespace tile_cs_sample.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tile = Tilebelt.PointToTile(0, 0, 10);
            Console.WriteLine("Tile: " + tile.ToString());
            Console.ReadLine();
        }
    }
}
