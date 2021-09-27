using System;
using Code.Model;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class PlayerHealthController
    {
        public event Action Dead;
        private PlayerHealth _playerHealth;
        public PlayerHealthController(PlayerHealth health, PlayerView playerView)
        {
            _playerHealth = health;
            playerView.Hit += Damage;
        }

        private void Damage()
        {
            if (_playerHealth.IsBlock || _playerHealth.IsDied) return;
            _playerHealth.Health--;
            Debug.Log(_playerHealth.Health);
            if (_playerHealth.Health <= 0)
            {
                _playerHealth.Health = 3;
                Dead.Invoke();
            }
        }
        
    }
}