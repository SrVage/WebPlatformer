using System.Collections.Generic;
using Code.Controllers.Interfaces;
using Code.Model;
using UnityEngine;

namespace Code.Controllers
{
    public class EnemyPatrulController:IExecute
    {
        private List<AI> _enemies = new List<AI>();
        public EnemyPatrulController(AIConfig config)
        {
            foreach (var enemy in config._enemies)
            {
                var enemi = GameObject.Instantiate(enemy.Enemy, enemy.WayPoints[0].position, Quaternion.identity);
                var AI = new AI();
                AI.Enemy = enemi;
                AI.WayPoints = enemy.WayPoints;
            }
        }
        public void Execute(float deltaTime)
        {
            //throw new System.NotImplementedException();
        }
    }
}