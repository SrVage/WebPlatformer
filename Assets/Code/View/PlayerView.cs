using System;
using UnityEngine;

namespace Code.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView:MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Rigidbody2D Rigidbody;
        public CompositeCollider2D Collider;

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Rigidbody = GetComponent<Rigidbody2D>();
            Collider = GetComponent<CompositeCollider2D>();
        }
    }
}