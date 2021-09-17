using UnityEngine;

namespace Code.Model
{
    [CreateAssetMenu (fileName = "PlayerConfig", order = 2, menuName = "Config/PlayerConfig")]
    public class PlayerConfig:ScriptableObject
    {
        public float WalkSpeed;
        public float AnimationSpeed;
        public float JumpForce;
        public float MovingTreshold;
        public float FlyTreshold;
        public float GroundLevel;
        public float Gravitation;
    }
}