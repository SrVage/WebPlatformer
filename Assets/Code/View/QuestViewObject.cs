using System;
using Code.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.View
{
    public class QuestViewObject:LevelObjectView
    {
        public int ID => _id;
        public event Action<LevelObjectView> OnPlayerContact; 
        [SerializeField] private int _id;
        [SerializeField] private Sprite _completeSprite;
        private QuestConfigurator _questConfig;

        private Sprite _startSprite;

        private void Awake()
        {
            _startSprite = SpriteRenderer.sprite;
            _questConfig = Object.FindObjectOfType<QuestConfigurator>();
        }

        public void ProcessActivate()
        {
            SpriteRenderer.sprite = _startSprite;
        }

        public void ProcessComplete()
        {
            SpriteRenderer.sprite = _completeSprite;
            _questConfig.UnActivateFiring();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var arg = other.GetComponent<LevelObjectView>();
            OnPlayerContact?.Invoke(arg);
        }
    }
}