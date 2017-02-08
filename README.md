# tilebelt

[![NuGet Status](http://img.shields.io/nuget/v/tilebelt.svg?style=flat)](https://www.nuget.org/packages/tilebelt/) [![Build status](https://ci.appveyor.com/api/projects/status/7r1ct7h78r2nkoy0?svg=true)](https://ci.appveyor.com/project/bertt/tilebelt-cs)

Set of tile utility functions written in C# for working with OpenStreetMap tiling scheme (https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames).  Inspired by the Mapbox Tilebelt library (https://github.com/mapbox/tilebelt).

## Install

```
package-install tilebelt
```

## Dependencies

.NETStandard 1.1

- System.Collections (>= 4.3.0)

- System.Runtime.Extensions (>= 4.3.0)

- System.Resources.ResourceManager (>= 4.3.0)

- System.Runtime (>= 4.3.0)

## Dependents

https://github.com/bertt/quantized-mesh-tile-cs

## Usage
```
// ------------------------------------------------------
// Tilebelt methods
// ------------------------------------------------------
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
var level = Tilebelt.GetBboxZoom(-84.72,11.17,-5.62,61.60);

// Tilebel.BboxToTile
// input: bounds [xmin, ymin, xmax, ymax] in WGS84
// output: tile, smallest tile to cover the bbox
var tile = Tilebelt.BboxToTile(-84.72,11.17,-5.62,61.60);

// ------------------------------------------------------
// Tile methods
// ------------------------------------------------------
// tile constructors
var tile = new Tile();
var tile = new Tile(5,5,10); // col, row, level 

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

// tile.Equals
// input: tile (col, row, level)
// output: boolean equals
var equals = tile1.Equals(tile2);

// tile.Quadkey()
// input: -
// output: Quadkey of tile
var quadkey = tile.Quadkey(); 
```
