using System;
using UnityEngine;

namespace Code.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView:MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}