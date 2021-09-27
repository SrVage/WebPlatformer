using System;
using UnityEngine;

namespace Code.View
{
    public class BulletView:MonoBehaviour
    {
        public Rigidbody2D Rigidbody;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}