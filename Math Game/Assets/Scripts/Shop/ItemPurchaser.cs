using MathGame.Core;
using MathGame.PowerUps;
using UnityEngine;

namespace MathGame.Shop
{
    public class ItemPurchaser : MonoBehaviour
    {
        [SerializeField] private FloatVariable score;

        private ICostDeterminer _costDeterminer;

        private void Start()
        {
            _costDeterminer = new CostDeterminer();
        }

        public void PurchaseTriesPowerUp(int amountToAdd)
        {
            var cost = _costDeterminer.CostForTriesPowerUp(amountToAdd);
            if (score.value < cost) return;
            score.value -= cost;
            PowerUpManager.AddTriesPowerUp(new TriesPowerUp(amountToAdd));
        }

        public void PurchaseTimePowerUp(int amountToAdd)
        {
            var cost = _costDeterminer.CostForTimePowerUp(amountToAdd);
            if (score.value < cost) return;
            score.value -= cost;
            PowerUpManager.AddTimePowerUp(new TimePowerUp(amountToAdd));
        }

        public void PurchaseScorePowerUp(int amountToAdd)
        {
            var cost = _costDeterminer.CostForScorePowerUp(amountToAdd);
            if (score.value < cost) return;
            score.value -= cost;
            PowerUpManager.AddScorePowerUp(new ScorePowerUp(amountToAdd));
        }
    }
}