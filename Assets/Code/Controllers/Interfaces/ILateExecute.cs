namespace Code.Controllers.Interfaces
{
    public interface ILateExecute:IController
    {
        public void LateExecute(float deltaTime);
    }
}