using UnityEngine;

namespace Code.QuestSystem
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}