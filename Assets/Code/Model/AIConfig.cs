using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Code.Model
{
    [Serializable]
    public class AI
    {
        public GameObject Enemy;
        [NonSerialized] public Transform EnemyTransform;
        public List<Transform> WayPoints;
        [NonSerialized] public Vector3 CurrentTarget;
        [NonSerialized] public int CurrentNumber;
        [NonSerialized] public Seeker Seeker;
        [NonSerialized] public AIPath AIPath;
    }
    [CreateAssetMenu (fileName = "AIConfig", order = 3, menuName = "Config/AIConfig")]
    public class AIConfig:ScriptableObject
    {
        [SerializeField] public AI[] _enemies;
    }
}