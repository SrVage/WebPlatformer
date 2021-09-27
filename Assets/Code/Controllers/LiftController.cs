using Code.Controllers.Interfaces;
using UnityEngine;

namespace Code.Controllers
{
    public class LiftController:IExecute
    {
        private SliderJoint2D _sliderJoint;
        public LiftController(SliderJoint2D sliderJoint)
        {
            _sliderJoint = sliderJoint;
        }
        public void Execute(float deltaTime)
        {
            if (_sliderJoint.transform.position.x <= _sliderJoint.anchor.x - _sliderJoint.limits.min)
            {
                JointMotor2D motor2D = new JointMotor2D();
                motor2D.motorSpeed = -10;
                _sliderJoint.motor = motor2D;
            }

            if (_sliderJoint.transform.position.x >= _sliderJoint.anchor.x + _sliderJoint.limits.max)
            {
                JointMotor2D motor2D = new JointMotor2D();
                motor2D.motorSpeed = 10;
                _sliderJoint.motor = motor2D;
            }
        }
    }
}