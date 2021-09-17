using Code.Controllers;
using Code.Model;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Controllers _controllers;
    [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
    [SerializeField] private PlayerConfig _playerConfig;
    void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _spriteAnimatorConfig, _playerConfig);
        _controllers.Init();
    }

    void Update()
    {
        _controllers.Execute(Time.deltaTime);
    }
}
