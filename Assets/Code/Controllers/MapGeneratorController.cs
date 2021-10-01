using System;
using Code.Controllers.Interfaces;
using Code.Model;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Controllers
{
    public class MapGeneratorController:IInitializible
    {
        private Tilemap _tilemap;
        private Tile _tileGround;
        private int _widthMap;
        private int _heightMap;
        private int _factorSmooth;
        private int _randomFillPercent;
        private bool[,] _map;
        
        public MapGeneratorController(MapGenerator mapGenerator, Tilemap ground)
        {
            _tilemap = ground;
            _tileGround = mapGenerator._tileGround;
            _widthMap = mapGenerator._widthMap;
            _heightMap = mapGenerator._heightMap;
            _factorSmooth = mapGenerator._factorSmooth;
            _randomFillPercent = mapGenerator._randomFillPercent;
            _map = new bool[_widthMap, _heightMap];
        }
        public void Init()
        {
            GenerateMap();
            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }
            DrawMap();
        }

        private void GenerateMap()
        {
            var random = new System.Random(DateTime.Now.GetHashCode());
            for (int x = 0; x < _widthMap; x++)
            {
                for (int y = 0; y < _heightMap; y++)
                {
                    if (y == 0)
                    {
                        _map[x, y] = true;
                    }
                    else
                    {
                        _map[x, y] = random.Next(0, 100) < _randomFillPercent;
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (int x = 0; x < _widthMap; x++)
            {
                for (int y = 0; y < _heightMap; y++)
                {
                    int neighborhoodCount = NeighborhoodCount(x, y);
                    if (neighborhoodCount > 4)
                    {
                        _map[x, y] = true;
                    }
                    else if (neighborhoodCount<2)
                    {
                        _map[x, y] = false;
                    }
                }
            }
        }

        private int NeighborhoodCount(int cellX, int cellY)
        {
            int count = 0;
            for (int x = cellX-1; x <= cellX+1; x++)
            {
                for (int y = cellY-1; y <= cellY+1; y++)
                {
                    if (x > 0 && x < _widthMap && y > 0 && y < _heightMap)
                    {
                        if (x != cellX && y != cellY)
                            count += _map[x, y] ? 1 : 0;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void DrawMap()
        {
            if (_map==null) return;
            for (int x = 0; x < _widthMap; x++)
            {
                for (int y = 0; y < _heightMap; y++)
                {
                    var position = new Vector3Int(-_widthMap / 2 + x, -_heightMap / 2 + y, 0);
                    if (_map[x, y])
                    {
                        _tilemap.SetTile(position, _tileGround);
                    }
                }
            }
        }
    }
}