using Code.Controllers.Interfaces;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class CameraController:ILateExecute
    {
        private Transform _player;
        private Transform _camera;
        
        public CameraController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        }
        public void LateExecute(float deltaTime)
        {
            _camera.position = Vector3.Lerp(_camera.position, new Vector3(_player.position.x, _player.position.y, -10), deltaTime);
        }
    }
}