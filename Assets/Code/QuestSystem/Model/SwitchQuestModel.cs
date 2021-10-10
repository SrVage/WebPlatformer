using Code.QuestSystem.Interfaces;
using UnityEngine;

namespace Code.QuestSystem.Model
{
    public sealed class SwitchQuestModel:IQuestModel
    {
        private const string _targetTag = "Player";
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(_targetTag);
        }
    }
}