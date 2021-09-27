using Code.Controllers.Interfaces;
using UnityEngine;

namespace Code.Controllers
{
    public class CollisionController
    {
        private const float _collisionTreshold = 0.5f;
        private ContactPoint2D[] _contactPoints = new ContactPoint2D[10];
        private int _collisionsCount;
        private readonly Collider2D _objectCollider;
        public Vector3 GroundVelocity { get; private set; }
        public bool IsGround { get; private set; }
        public bool RightCollision { get; private set; }
        public bool LeftCollision { get; private set; }
        
        public CollisionController(Collider2D objectCollider)
        {
            _objectCollider = objectCollider;
        }
        
        public void Execute()
        {
            IsGround = false;
            RightCollision = false;
            LeftCollision = false;
            _collisionsCount = _objectCollider.GetContacts(_contactPoints);
            for (int i = 0; i < _collisionsCount; i++)
            {
                var normal = _contactPoints[i].normal;
                var rigidBody = _contactPoints[i].rigidbody;
                if (normal.y > _collisionTreshold)
                {
                    IsGround = true;
                    if (rigidBody)
                        GroundVelocity = rigidBody.velocity;
                }
                if (normal.x > _collisionTreshold && rigidBody == null) LeftCollision = true;
                if (normal.x < -_collisionTreshold && rigidBody == null) RightCollision = true;
            }
        }
    }
}