using System.Collections.Generic;
using UnityEngine;

namespace Code.Model
{
    [CreateAssetMenu (fileName = "QuestItemConfig", order = 7, menuName = "Config/QuestItemConfig")]
    public class QuestItemConfig:ScriptableObject
    {
        public int QuestID;
        public List<int> ItemID;
    }
}