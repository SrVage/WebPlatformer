using System;
using System.Collections.Generic;
using Code.Controllers.Interfaces;
using Code.Model;
using UnityEngine;

namespace Code.Controllers
{
    public class SpriteAnimator: IExecute, IDisposable
    {
        private class Animation
        {
            public Track Track;
            public List<Sprite> Sprites;
            public bool Loop = false;
            public float Speed = 10;
            public float Counter = 0;
            public bool IsSleep;

            public void Update()
            {
                if (IsSleep) return;
                Counter += Time.deltaTime * Speed;
                if (Loop)
                {
                    while (Counter>Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter>Sprites.Count)
                {
                    Counter = Sprites.Count - 1;
                    IsSleep = true;
                }
            }
        }

        private SpriteAnimatorConfig _spriteAnimatorConfig;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimator(SpriteAnimatorConfig spriteAnimatorConfig)
        {
            _spriteAnimatorConfig = spriteAnimatorConfig;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, Track track, float speed, bool loop)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out Animation animation))
            {
                animation.Speed = speed;
                animation.Loop = loop;
                animation.IsSleep = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _spriteAnimatorConfig.SpriteSequences.Find(sequence => sequence.Track == track)
                        .Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _spriteAnimatorConfig.SpriteSequences.Find(sequence => sequence.Track==track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimation.ContainsKey(spriteRenderer))
            {
                _activeAnimation.Remove(spriteRenderer);
            }
        }
        
        public void Execute(float deltaTime)
        {
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Update();
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}