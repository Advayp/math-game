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

        public void TimePowerUp(DisplayPowerUpInShop shop)
        {
            if (score.value < shop.Cost) return;
            score.value -= shop.Cost;
            PowerUpManager.AddTimePowerUp(new TimePowerUp(shop.Amount));
            OnPurchased?.Invoke();
        }

        public void TriesPowerUp(DisplayPowerUpInShop shop)
        {
            if (score.value < shop.Cost) return;
            score.value -= shop.Cost;
            PowerUpManager.AddTriesPowerUp(new TriesPowerUp(shop.Amount));
            OnPurchased?.Invoke();
        }

        public void ScorePowerUp(DisplayPowerUpInShop shop)
        {
            if (score.value < shop.Cost) return;
            score.value -= shop.Cost;
            PowerUpManager.AddScorePowerUp(new ScorePowerUp(shop.Amount));
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