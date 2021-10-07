using System;
using UnityEngine;

namespace Code.View
{
    public class QuestViewObject:LevelObjectView
    {
        public int ID => _id;
        public event Action<LevelObjectView> OnPlayerContact; 
        [SerializeField] private int _id;
        [SerializeField] private Color _completeColor;

        private Color _startColor;

        private void Awake()
        {
            _startColor = SpriteRenderer.color;
        }

        public void ProcessActivate()
        {
            SpriteRenderer.color = _startColor;
        }

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completeColor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var arg = other.GetComponent<LevelObjectView>();
            OnPlayerContact?.Invoke(arg);
        }
    }
}