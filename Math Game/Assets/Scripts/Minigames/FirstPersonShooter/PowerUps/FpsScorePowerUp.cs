using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.PowerUps
{
    public class FpsScorePowerUp : FpsPowerUp
    {
        [SerializeField] private int scoreToGiveToPlayer;
        [SerializeField] private FpsScoreManager scoreManager;

        protected override void OnTouchingPlayer(GameObject player)
        {
            scoreManager.AddToScore(scoreToGiveToPlayer);
        }
    }
}