using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Model
{
    public enum Track
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Jump = 3
    }
    [CreateAssetMenu (fileName = "AnimatorConfig", order = 1, menuName = "Config/AnimatorConfig")]
    public class SpriteAnimatorConfig:ScriptableObject
    {
        [Serializable]
        public class SpriteSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> SpriteSequences = new List<SpriteSequence>();
    }
}