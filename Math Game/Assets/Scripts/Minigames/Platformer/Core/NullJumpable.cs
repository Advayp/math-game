namespace Discovery.Minigames.Platformer
{
    public class NullJumpable : IJumpable
    {

        public int NumberOfJumps => 0;

        public void SetJumps(int amount)
        {
        }
    }
}