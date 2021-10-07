using System;
using UnityEngine.PlayerLoop;

namespace Code.QuestSystem
{
    public interface IQuest:IDisposable
    {
        event EventHandler<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}