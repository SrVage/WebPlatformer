using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Code.Controllers.Interfaces;
using Code.Model;
using Pathfinding;
using UnityEngine;

namespace Code.Controllers
{
    public class EnemyPatrulController:IExecute
    {
        private List<AI> _enemies = new List<AI>();
        private Transform _target;
        public EnemyPatrulController(AIConfig config, Transform target)
        {
            _target = target;
            foreach (var enemy in config._enemies)
            {
                var enemi = GameObject.Instantiate(enemy.Enemy, enemy.WayPoints[0].position, Quaternion.identity);
                var AI = new AI();
                AI.Enemy = enemi;
                AI.WayPoints = enemy.WayPoints;
                AI.EnemyTransform = enemi.transform;
                AI.CurrentTarget = AI.WayPoints[0].position;
                AI.CurrentNumber = 0;
                AI.Seeker = enemi.GetComponent<Seeker>();
                AI.AIPath = enemi.GetComponent<AIPath>();
                _enemies.Add(AI);
            }
        }
        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (Vector3.Distance(_target.position, _enemies[i].EnemyTransform.position) < 3)
                {
                    _enemies[i].Seeker.StartPath(_enemies[i].EnemyTransform.position, _target.position);
                    _enemies[i].AIPath.maxSpeed = 3;
                }
                else
                {
                    _enemies[i].AIPath.maxSpeed = 1;
                    if ((_enemies[i].EnemyTransform.position - _enemies[i].CurrentTarget).magnitude > 0.5f)
                    {
                        /*_enemies[i].EnemyTransform.position =
                                                Vector3.Lerp(_enemies[i].EnemyTransform.position, _enemies[i].CurrentTarget, deltaTime);*/
                    }
                    else
                    {
                        _enemies[i].CurrentNumber = (_enemies[i].CurrentNumber + 1) % _enemies[i].WayPoints.Count;
                        _enemies[i].CurrentTarget = _enemies[i].WayPoints[_enemies[i].CurrentNumber].position;
                        _enemies[i].Seeker.StartPath(_enemies[i].EnemyTransform.position, _enemies[i].CurrentTarget);
                        
                    }
                }
            }
        }
    }
}