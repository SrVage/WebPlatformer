using System;
using Code.Controllers;
using Code.Model;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    private Controllers _controllers;
    [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Transform _camera;
    [SerializeField] private SliderJoint2D _sliderJoint2D;
    [SerializeField] private AIConfig _aiConfig;
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Tilemap _tilemap;
    void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _spriteAnimatorConfig, _playerConfig, _camera, _sliderJoint2D, _aiConfig, _mapGenerator, _tilemap);
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
