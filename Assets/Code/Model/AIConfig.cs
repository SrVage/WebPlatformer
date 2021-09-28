using System;
using UnityEngine;

namespace Code.Model
{
    [Serializable]
    public struct AI
    {
        public GameObject Enemy;
        public Transform[] WayPoints;
    }
    [CreateAssetMenu (fileName = "AIConfig", order = 3, menuName = "Config/AIConfig")]
    public class AIConfig:ScriptableObject
    {
        [SerializeField] public AI[] _enemies;
    }
}