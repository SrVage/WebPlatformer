using UnityEngine;

namespace Code.Model
{
    [CreateAssetMenu (fileName = "QuestConfig", order = 5, menuName = "Config/QuestConfig")]
    public class QuestConfig:ScriptableObject
    {
        public int QuestID;
        public QuestType QuestType;
    }

    public enum QuestType
    {
        Switch = 0
    }
}