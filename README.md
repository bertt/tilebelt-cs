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
// get bounding box of tile
var bounds = Tilebelt.GetTileBounds(0, 0, 0);

// Point to tile
var tile = Tilebelt.PointToTile(0, 0, 10);

// GetChildren
var tiles = Tilebelt.GetChildren(0, 0, 0);

// GetParent
var tile = Tilebelt.GetParent(5,10,10);

```

## Todo

Implement other tile functions


