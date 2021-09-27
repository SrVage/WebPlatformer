using System.Collections.Generic;
using System.Linq;
using Code.View;
using UnityEngine;

namespace Code.Model
{
    public class BulletPool
    {
        private Queue<BulletView> _bulletPool;
        private Transform _rootPool;

        public BulletPool()
        {
            _bulletPool = new Queue<BulletView>();
            if (!_rootPool)
            {
                _rootPool = new GameObject("rootPool").transform;
            }
        }

        public BulletView GetBullet()
        {
            if (_bulletPool.Count == 0)
            {
                var bullet = GameObject
                    .Instantiate(Resources.Load<GameObject>("bullet"), Vector3.zero, Quaternion.identity)
                    .GetComponent<BulletView>();
                ReturnToPool(bullet);
            }
            var bull = _bulletPool.Dequeue();
            bull.gameObject.SetActive(true);
            bull.transform.parent = null;
            return bull;
        }

        public void ReturnToPool(BulletView bullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.parent = _rootPool;
            _bulletPool.Enqueue(bullet);
        }
    }
}