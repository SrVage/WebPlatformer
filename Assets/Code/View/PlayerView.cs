using System;
using UnityEngine;

namespace Code.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView:PhysicObjectView
    {
        public event Action Hit;
        
        public CompositeCollider2D Collider;

        private void Awake()
        {
            Collider = GetComponent<CompositeCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<BulletView>())
            {
                Hit.Invoke();
            }
        }
    }
}