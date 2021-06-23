using System;
using TMPro;
using UnityEngine;

namespace Discovery.PowerUps
{

    [Serializable]
    public enum AvailablePowerUps
    {
        Time,
        Score,
        Tries
    }

    public class PowerUpDisplayer : MonoBehaviour
    {

        [SerializeField] private TMP_Text powerUpText;
        [SerializeField] private AvailablePowerUps powerUpType;


        public void UpdateText()
        {
            powerUpText.SetText(GetTextValue(powerUpType));
        }

        // There is a much better way of doing this
        private static string GetTextValue(AvailablePowerUps type)
        {
            if (type == AvailablePowerUps.Score)
            {
                var powerUp = PowerUpManager.RecentScorePowerUp;
                return powerUp == null ? "" : $"x{powerUp.GetInfo()} Score";
            }
            if (type == AvailablePowerUps.Tries)
            {
                var powerUp = PowerUpManager.RecentTriesPowerUp;
                return powerUp == null ? "" : $"+{powerUp.GetInfo()} Tries";
            }
            else
            {
                var powerUp = PowerUpManager.RecentTimePowerUp;
                return powerUp == null ? "" : $"+{powerUp.GetInfo()} Seconds";
            }
        }
    }
}