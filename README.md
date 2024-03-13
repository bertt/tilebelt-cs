# tilebelt

[![NuGet Status](http://img.shields.io/nuget/v/tilebelt.svg?style=flat)](https://www.nuget.org/packages/tilebelt/) [![Build status](https://ci.appveyor.com/api/projects/status/7r1ct7h78r2nkoy0?svg=true)](https://ci.appveyor.com/project/bertt/tilebelt-cs)[![NuGet](https://img.shields.io/nuget/dt/tilebelt.svg)]

Set of tile utility functions written in C# for working with OpenStreetMap tiling scheme (https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames).  Inspired by the Mapbox Tilebelt library (https://github.com/mapbox/tilebelt).

## Install

```
package-install tilebelt
```

## Dependencies

.NET 6.0

## Dependents

-

## Usage
```
// ------------------------------------------------------
// Tilebelt methods
// ------------------------------------------------------

// Tilebelt.GetTilesOnLevel
// input: bounds [xmin, ymin, xmax, ymax] in WGS84 and z-level
// output: List of tiles in bounds and on level
var tiles = Tilebelt.GetTilesOnLevel(new double[]{-84.72,11.17,-5.62,61.60}, 10);

// Tilebelt.PointToTile
// input: x, y in WGS84
// output: tile (col, row,level)
var tile = Tilebelt.PointToTile(0, 0, 10);

// Tilebelt.QuadkeyToTile
// input: quadkey
// output: Tile (col, row, level)

// Tilebelt.GetBboxZoom
// input: bounds [xmin, ymin, xmax, ymax] in WGS84
// output: zoomlevel (int)
var level = Tilebelt.GetBboxZoom(new double[]{-84.72,11.17,-5.62,61.60});

// Tilebelt.BboxToTile
// input: bounds [xmin, ymin, xmax, ymax] in WGS84
// output: tile, smallest tile to cover the bbox
var tile = Tilebelt.BboxToTile(new double[]{-84.72,11.17,-5.62,61.60});


// ------------------------------------------------------
// Tile methods
// ------------------------------------------------------
// tile constructors
var tile = new Tile();
var tile = new Tile(5,5,10); // col, row, level

// tile.Center - get center point of tile
var center = tile.Center(); 

// tile.Bounds - get bounding box of tile
// input: -
// output: bounds [xmin, ymin, xmax, ymax] in WGS84
var bounds = tile.Bounds();

// tile.Children
// input: -
// output: 4 children tiles (col, row, level)
var tiles = tile.Children();

// tile.Parent
// input: -
// output: parent tile (col, row, level)
var parentTile = tile.Parent();

// tile.Siblings
// input: -
// out: 4 siblings tiles
var siblings = tile.Siblings();

// tile.Intersects
// input: a line (2 points) 
public bool Intersects(Point2 from, Point2 to)

// tile.Equals
// input: tile (col, row, level)
// output: boolean equals
var equals = tile1.Equals(tile2);

// tile.Quadkey()
// input: -
// output: Quadkey of tile
var quadkey = tile.Quadkey(); 
```


## History

2023-08-13: v2.0 - .NET 6.0

2019-12-18: v1.0 - .NET Standard 2.0
