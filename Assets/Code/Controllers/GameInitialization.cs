using Code.Model;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, SpriteAnimatorConfig spriteAnimatorConfig, PlayerConfig playerConfig)
        {
            var SpriteAnimator = new SpriteAnimator(spriteAnimatorConfig);
            controllers.Add(SpriteAnimator);
            var PlayerController = new PlayerMoveController(playerConfig, CreatePlayer(), SpriteAnimator);
            controllers.Add(PlayerController);
        }

        private PlayerView CreatePlayer()
        {
            return GameObject.Instantiate(Resources.Load<GameObject>("Player"), Vector3.zero, Quaternion.identity)
                .GetComponent<PlayerView>();
        }
    }
}