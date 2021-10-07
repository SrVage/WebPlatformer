using System;
using Code.View;

namespace Code.QuestSystem
{
    public sealed class Quest:IQuest
    {
        private readonly QuestViewObject _view;
        private readonly IQuestModel _model;
        private bool _active;

        public Quest(QuestViewObject view, IQuestModel model)
        {
            _view = view!=null ? view: throw new ArgumentNullException();
            _model = model!=null ? model: throw new ArgumentNullException();
        }

        private void OnContact(LevelObjectView arg)
        {
            var completed = _model.TryComplete(arg.gameObject);
            if (completed) Complete();
        }

        private void Complete()
        {
            if (_active) return;
            _active = false;
            IsCompleted = true;
            _view.OnPlayerContact -= OnContact;
            _view.ProcessComplete();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}