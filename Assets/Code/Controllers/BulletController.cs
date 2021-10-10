using System.Collections.Generic;
using Code.Controllers.Interfaces;
using Code.Model;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class BulletController:IExecute
    {
        private Transform _turrel;
        private Transform _player;
        private BulletPool _bulletPool;
        private List<BulletView> _bullets = new List<BulletView>();
        private float _time;
        private bool _isActive = true;
        
        public BulletController(TurrelView turrel, Transform player, QuestConfigurator questConfigurator)
        {
            _turrel = turrel.AimTransform;
            _player = player;
            _bulletPool = new BulletPool();
            questConfigurator.UnActivateFiring += UnActivated;
        }

        private void UnActivated()
        {
            _isActive = false;
        }

        public void Execute(float deltaTime)
        {
            if (!_isActive) return;
            for (int i = 0; i<_bullets.Count;i++)
            {
                if (_bullets[i].transform.position.y < -10 || _bullets[i].Rigidbody.velocity.magnitude<0.8f)
                {
                    _bulletPool.ReturnToPool(_bullets[i]);
                    _bullets.Remove(_bullets[i]);
                }
            }
            if (_time < 2)
            {
                _time += deltaTime;
            }
            else
            {
                var bullet = _bulletPool.GetBullet();
                _bullets.Add(bullet);
                bullet.transform.position = _turrel.position;
                var distance = (_player.position - _turrel.position).magnitude;
                var direction = ((_player.position+Vector3.up*distance/10) - _turrel.position).normalized;
                bullet.Rigidbody.AddForce(direction*3, ForceMode2D.Impulse);
                _time = 0;
            }
        }
    }
}