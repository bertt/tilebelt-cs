# tilebelt

[![NuGet Status](http://img.shields.io/nuget/v/tilebelt.svg?style=flat)](https://www.nuget.org/packages/tilebelt/)

Set of tile utility functions

## Install

```
package-install tilebelt
```

## Usage
```
// get bounding box of tile
// input: tile (col, row, level)
// output: bounds [xmin, ymin, xmax, ymax] in WGS94
var bounds = Tilebelt.GetTileBounds(0, 0, 0);

// Point to tile
// input:  x, y in WGS84
// output: tile (col, row,level)
var tile = Tilebelt.PointToTile(0, 0, 10);

// GetChildren
// input: tile col, row, level
// output: 4 tiles (col, row, level)
var tiles = Tilebelt.GetChildren(0, 0, 0);

// GetParent
// input: tile col, row, level
// output: tile (col, row, level)
var tile = Tilebelt.GetParent(5,10,10);
```

## Todo

Implement other tile functions


