using Code.Controllers.Interfaces;
using Code.Model;
using Code.Utils;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class PlayerMoveController:IFixedExecute
    {
        private class PlayerMoveParameters
        {
            public readonly float WalkSpeed;
            public readonly float AnimationSpeed;
            public readonly float JumpForce;
            public readonly float MovingTreshold;
            public readonly float FlyTreshold;
            public readonly float GroundLevel;

            public PlayerMoveParameters(PlayerConfig config)
            {
                WalkSpeed = config.WalkSpeed;
                AnimationSpeed = config.AnimationSpeed;
                JumpForce = config.JumpForce;
                MovingTreshold = config.MovingTreshold;
                FlyTreshold = config.FlyTreshold;
                GroundLevel = config.GroundLevel;
            }
        }

        private PlayerMoveParameters _playerMoveParameters;
        private PlayerView _player;
        private SpriteAnimator _spriteAnimator;
        private CollisionController _collisionController;
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _upMove = Vector3.up;
        private float _yVelocity;
        private float _xAxisInput;
        private bool _doJump;
        
        public PlayerMoveController(PlayerConfig config, PlayerView playerView, SpriteAnimator spriteAnimator)
        {
            _playerMoveParameters = new PlayerMoveParameters(config);
            _player = playerView;
            _spriteAnimator = spriteAnimator;
            _collisionController = new CollisionController(_player.Collider);
        }

        private bool IsGround()
        {
            return _player.transform.position.y <= _playerMoveParameters.GroundLevel + float.Epsilon && _yVelocity <= 0;
        }

        private void GoSideAway(float fixedDeltaTime)
        {
            if (_xAxisInput < 0)
            {
                _player.Rigidbody.velocity = _player.Rigidbody.velocity.Change(x: (-1)*_playerMoveParameters.WalkSpeed*fixedDeltaTime);
                _player.transform.localScale = _leftScale;
            }
            else
            {
                _player.Rigidbody.velocity = _player.Rigidbody.velocity.Change(x: _playerMoveParameters.WalkSpeed*fixedDeltaTime);
                _player.transform.localScale = _rightScale;
            }
        }
        
        public void FixedExecute(float fixedDeltaTime)
        {
            _player.Rigidbody.velocity = _player.Rigidbody.velocity.Change(x: 0.0f);
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _yVelocity = _player.Rigidbody.velocity.y;
            _collisionController.Execute();
            bool goSideWay = Mathf.Abs(_xAxisInput) > _playerMoveParameters.MovingTreshold;
            if (_collisionController.IsGround)
            {
                if (goSideWay) GoSideAway(fixedDeltaTime);
                _spriteAnimator.StartAnimation(_player.SpriteRenderer,goSideWay?Track.Walk:Track.Idle,_playerMoveParameters.AnimationSpeed, true);
                if (_doJump&&_yVelocity==0)
                {
                    _player.Rigidbody.AddForce(_upMove*_playerMoveParameters.JumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (goSideWay) GoSideAway(fixedDeltaTime);
                if (Mathf.Abs(_yVelocity) > _playerMoveParameters.FlyTreshold)
                {
                    _spriteAnimator.StartAnimation(_player.SpriteRenderer,Track.Jump, _playerMoveParameters.AnimationSpeed, true);
                }
            }
        }
    }
}