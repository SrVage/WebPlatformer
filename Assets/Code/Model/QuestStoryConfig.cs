using System.Collections.Generic;
using UnityEngine;

namespace Code.Model
{
    [CreateAssetMenu (fileName = "QuestStoryConfig", order = 6, menuName = "Config/QuestStoryConfig")]
    public class QuestStoryConfig:ScriptableObject
    {
        public List<QuestConfig> Quest;
        public StoryType StoryType;
    }

    public enum StoryType
    {
        Once = 0,
        Repeat = 1
    }
}