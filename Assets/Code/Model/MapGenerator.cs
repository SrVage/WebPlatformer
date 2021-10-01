using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Model
{
    [CreateAssetMenu (fileName = "MapConfig", order = 4, menuName = "Config/MapConfig")]
    public class MapGenerator:ScriptableObject
    {
        public Tile _tileGround;
        public int _widthMap;
        public int _heightMap;
        public int _factorSmooth;
        [SerializeField] [Range(0, 100)] public int _randomFillPercent;
    }
}