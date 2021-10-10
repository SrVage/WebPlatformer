using UnityEngine;

namespace Code.QuestSystem.Interfaces
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}