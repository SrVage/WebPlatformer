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
            var playerView = CreatePlayer();
            var turrel = CreateTurrel();
            var PlayerHealthController = new PlayerHealthController(new PlayerHealth(3), playerView);
            var PlayerController = new PlayerMoveController(playerConfig, playerView, SpriteAnimator, PlayerHealthController);
            controllers.Add(PlayerController);
            var TurrelAimingController = new TurrelAiming(turrel, playerView);
            controllers.Add(TurrelAimingController);
            var bulletController = new BulletController(turrel, playerView.transform);
            controllers.Add(bulletController);
        }

        private PlayerView CreatePlayer()
        {
            return GameObject.Instantiate(Resources.Load<GameObject>("Player"), Vector3.zero, Quaternion.identity)
                .GetComponent<PlayerView>();
        }
        
        private TurrelView CreateTurrel()
        {
            return GameObject.Instantiate(Resources.Load<GameObject>("turrel"), new Vector3(6.6f, 2.8f, 0), Quaternion.Euler(new Vector3(0,0,180)))
                .GetComponent<TurrelView>();
        }
    }
}