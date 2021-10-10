using System;
using Code.QuestSystem.Model;
using UnityEngine;

namespace Code.View
{
    public class QuestConfigurator:MonoBehaviour
    {
        public Action UnActivateFiring;
        [SerializeField] private QuestViewObject _questView;
        private Quest _quest;

        private void Start()
        {
            _quest = new Quest(_questView, new SwitchQuestModel());
            _quest.Reset();
        }

        private void OnDestroy()
        {
            _quest.Dispose();
        }

        public void UnActiveFiring()
        {
            UnActivateFiring?.Invoke();
        }
    }
}