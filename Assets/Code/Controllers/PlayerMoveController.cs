using Code.Controllers.Interfaces;
using Code.Model;
using Code.Utils;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class PlayerMoveController:IExecute
    {
        private class PlayerMoveParameters
        {
            public readonly float WalkSpeed;
            public readonly float AnimationSpeed;
            public readonly float JumpForce;
            public readonly float MovingTreshold;
            public readonly float FlyTreshold;
            public readonly float GroundLevel;
            public readonly float Gravitation;
            
            public PlayerMoveParameters(PlayerConfig config)
            {
                WalkSpeed = config.WalkSpeed;
                AnimationSpeed = config.AnimationSpeed;
                JumpForce = config.JumpForce;
                MovingTreshold = config.MovingTreshold;
                FlyTreshold = config.FlyTreshold;
                GroundLevel = config.GroundLevel;
                Gravitation = config.Gravitation;
            }
        }

        private PlayerMoveParameters _playerMoveParameters;
        private PlayerView _player;
        private SpriteAnimator _spriteAnimator;
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightMove = Vector3.right;
        private Vector3 _leftMove = Vector3.left;
        private Vector3 _upMove = Vector3.up;
        private float _yVelocity;
        private float _xAxisInput;
        private bool _doJump;
        
        public PlayerMoveController(PlayerConfig config, PlayerView playerView, SpriteAnimator spriteAnimator)
        {
            _playerMoveParameters = new PlayerMoveParameters(config);
            _player = playerView;
            _spriteAnimator = spriteAnimator;
        }

        private bool IsGround()
        {
            return _player.transform.position.y <= _playerMoveParameters.GroundLevel + float.Epsilon && _yVelocity <= 0;
        }

        private void GoSideAway(float deltaTime)
        {
            if (_xAxisInput < 0)
            {
                _player.transform.position += _leftMove * _playerMoveParameters.WalkSpeed * deltaTime;
                _player.transform.localScale = _leftScale;
            }
            else
            {
                _player.transform.position += _rightMove * _playerMoveParameters.WalkSpeed * deltaTime;
                _player.transform.localScale = _rightScale;
            }
        }
        
        public void Execute(float deltaTime)
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool goSideWay = Mathf.Abs(_xAxisInput) > _playerMoveParameters.MovingTreshold;
            if (IsGround())
            {
                if (goSideWay) GoSideAway(deltaTime);
                _spriteAnimator.StartAnimation(_player.SpriteRenderer,goSideWay?Track.Walk:Track.Idle,_playerMoveParameters.AnimationSpeed, true);
                if (_doJump&&_yVelocity==0)
                {
                    _yVelocity = _playerMoveParameters.JumpForce;
                }
                else if (_yVelocity<0)
                {
                    _yVelocity = 0;
                    _player.transform.position =
                        _player.transform.position.Change(y: _playerMoveParameters.GroundLevel);
                }
            }
            else
            {
                if (goSideWay) GoSideAway(deltaTime);
                if (Mathf.Abs(_yVelocity) > _playerMoveParameters.FlyTreshold)
                {
                    _spriteAnimator.StartAnimation(_player.SpriteRenderer,Track.Jump, _playerMoveParameters.AnimationSpeed, true);
                }
                _yVelocity += _playerMoveParameters.Gravitation * deltaTime;
                _player.transform.position += _upMove * _yVelocity * deltaTime;
            }
        }
    }
}