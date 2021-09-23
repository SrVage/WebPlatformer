using System.Collections.Generic;
using Code.Controllers.Interfaces;

namespace Code.Controllers
{
    public sealed class Controllers:IInitializible, IExecute, IFixedExecute
    {
        private List<IInitializible> _initializibles = new List<IInitializible>();
        private List<IExecute> _executes = new List<IExecute>();
        private List<IFixedExecute> _fixedExecutes = new List<IFixedExecute>();

        public void Init()
        {
            foreach (var init in _initializibles)
            {
               init.Init();
            }
        }

        public Controllers Add(IController controllers)
        {
            if (controllers is IInitializible init)
                _initializibles.Add(init);
            if (controllers is IExecute execute)
                _executes.Add(execute);
            if (controllers is IFixedExecute fixedExecute)
                _fixedExecutes.Add(fixedExecute);
            return this;
        }

        public void Execute(float deltaTime)
        {
            foreach (var execute in _executes)
            {
                execute.Execute(deltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTIme)
        {
            foreach (var fixedExecute in _fixedExecutes)
            {
                fixedExecute.FixedExecute(fixedDeltaTIme);
            }
        }
    }
}