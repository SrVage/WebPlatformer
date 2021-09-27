namespace Code.Model
{
    public class PlayerHealth
    {
        public int Health;
        public bool IsBlock;
        public bool IsDied;

        public PlayerHealth(int health)
        {
            Health = health;
            IsBlock = false;
            IsDied = false;
        }
    }
}