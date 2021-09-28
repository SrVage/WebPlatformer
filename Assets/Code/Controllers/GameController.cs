using System;
using Code.Controllers;
using Code.Model;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Controllers _controllers;
    [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Transform _camera;
    [SerializeField] private SliderJoint2D _sliderJoint2D;
    [SerializeField] private AIConfig _aiConfig;
    void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _spriteAnimatorConfig, _playerConfig, _camera, _sliderJoint2D, _aiConfig);
        _controllers.Init();
    }

    void Update()
    {
        _controllers.Execute(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _controllers.FixedExecute(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        _controllers.LateExecute(Time.deltaTime);
    }
}
