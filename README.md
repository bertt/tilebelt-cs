# tilebelt

[![NuGet Status](http://img.shields.io/nuget/v/tilebelt.svg?style=flat)](https://www.nuget.org/packages/tilebelt/)

Set of tile utility functions, inspired on the MapBox Tilebelt library (https://github.com/mapbox/tilebelt)

## Install

```
package-install tilebelt
```

## Dependencies

NETStandard.Library 1.6.1 https://www.nuget.org/packages/NETStandard.Library/

## Usage
```
// ------------------------------------------------------
// Tilebelt methods
// ------------------------------------------------------
// Tilebelt.PointToTile
// input:  x, y in WGS84
// output: tile (col, row,level)
var tile = Tilebelt.PointToTile(0, 0, 10);

// Tilebelt.GetTileByQuadkey
// input: quadkey
// output: Tile (col, row, level)

// ------------------------------------------------------
// Tile methods
// ------------------------------------------------------

// Tile.GetBounds - get bounding box of tile
// input: -
// output: bounds [xmin, ymin, xmax, ymax] in WGS94
var bounds = tile.GetBounds();

// Tile.GetChildren
// input: -
// output: 4 children tiles (col, row, level)
var tiles = tile.GetChildren(0, 0, 0);

// Tile.GetParent
// input: -
// output: parent tile (col, row, level)
var parentTile = tile.GetParent();

// Tile.GetSiblings
// input: -
// out: 4 siblings tiles
var siblings = tile.GetSiblings();

// Tile.Equals
// input: tile (col, row, level)
// output: boolean equals
var equals = tile1.Equals(tile2);

// Tile.Quadkey()
// input: -
// Output: Quadkey of tile
var quadkey = tile.Quadkey(); 
```
## Todo

Implement other tile functions


