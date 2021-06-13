using System;
using Discovery.PowerUps;
using UnityEngine;

namespace Discovery.Shop
{
    public class ItemPurchaser : MonoBehaviour
    {
        [SerializeField] private FloatVariable score;

        private ICostDeterminer _costDeterminer;

        public static event Action OnPurchased;

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
            OnPurchased?.Invoke();
        }

        public void PurchaseTimePowerUp(int amountToAdd)
        {
            var cost = _costDeterminer.CostForTimePowerUp(amountToAdd);
            if (score.value < cost) return;
            score.value -= cost;
            PowerUpManager.AddTimePowerUp(new TimePowerUp(amountToAdd));
            OnPurchased?.Invoke();
        }

        public void PurchaseScorePowerUp(int amountToAdd)
        {
            var cost = _costDeterminer.CostForScorePowerUp(amountToAdd);
            if (score.value < cost) return;
            score.value -= cost;
            PowerUpManager.AddScorePowerUp(new ScorePowerUp(amountToAdd));
            OnPurchased?.Invoke();
        }
    }
}