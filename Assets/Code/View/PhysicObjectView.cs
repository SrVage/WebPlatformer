using UnityEngine;

namespace Code.View
{
    public class PhysicObjectView:LevelObjectView
    {
        public Rigidbody2D Rigidbody;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}