using Code.Model;
using Code.View;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Controllers
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, SpriteAnimatorConfig spriteAnimatorConfig,
            PlayerConfig playerConfig, Transform camera, SliderJoint2D sliderJoint2D, AIConfig aiConfig,MapGenerator mapGenerator, Tilemap ground, QuestConfigurator questConfigurator)
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
            var bulletController = new BulletController(turrel, playerView.transform, questConfigurator);
            controllers.Add(bulletController);
            var CameraController = new CameraController(playerView.transform, camera);
            controllers.Add(CameraController);
            var LiftController = new LiftController(sliderJoint2D);
            controllers.Add(LiftController);
            var AI = new EnemyPatrulController(aiConfig, playerView.transform);
            controllers.Add(AI);
            controllers.Add(new MapGeneratorController(mapGenerator, ground));
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