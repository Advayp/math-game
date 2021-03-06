using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.PowerUps
{
    public class HealthPowerUp : FpsPowerUp
    {
        [SerializeField] private int amountToHealFor;
        
        
        protected override void OnTouchingPlayer(GameObject player)
        {
            if (FpsQuestionManager.IsQuestionDisplaying) return;
            var healable = player.GetComponent<IHealable>();
            healable.HealFor(amountToHealFor);
            Collider.enabled = false;
            Renderer.enabled = false;   
        }   
    }
}