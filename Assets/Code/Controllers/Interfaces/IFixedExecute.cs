namespace Code.Controllers.Interfaces
{
    public interface IFixedExecute:IController
    {
        void FixedExecute(float fixedDeltaTime);
    }
}