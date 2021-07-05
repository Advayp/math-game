namespace Discovery.Minigames.CardGame
{
    public static class DeterminePlayer
    { 
        static DeterminePlayer()
        {
            CurrentPlayer = PlayerType.One;
        }


        public static PlayerType CurrentPlayer;
    }
}