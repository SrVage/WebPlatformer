using System.Numerics;
using Code.Controllers.Interfaces;
using Code.View;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Code.Controllers
{
    public class TurrelAiming:IExecute
    {
        private Transform _turrelTransform;
        private Transform _aimTransform;
        public TurrelAiming(TurrelView view, PlayerView playerView)
        {
            _turrelTransform = view.transform;
            _aimTransform = playerView.transform;
        }
        public void Execute(float deltaTime)
        {
            if (Vector3.Distance(_turrelTransform.position, _aimTransform.position) < 8 && _aimTransform.position.x<_turrelTransform.position.x)
            {
                var distance = (_aimTransform.position - _turrelTransform.position).magnitude;
                var aiming = ((_aimTransform.position+Vector3.up*distance/10) - _turrelTransform.position).normalized;
                var angle = Vector3.Angle(aiming, Vector3.up);
                var axis = Vector3.Cross(aiming, Vector3.up);
                _turrelTransform.rotation = Quaternion.AngleAxis(Mathf.Clamp((180 - angle),50,90), axis);
                
            }
        }
    }
}