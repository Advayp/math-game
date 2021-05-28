using System.Collections.Generic;
using MathGame.PowerUps;
using UnityEngine;

namespace MathGame.Core
{
    public class PowerUpManager : MonoBehaviour
    {
        private static readonly Dictionary<PowerUpType, IPowerUp> PowerUps = new Dictionary<PowerUpType, IPowerUp>();

        private void Start()
        {
            InitializePowerUps();
        }

        private static void InitializePowerUps()
        {
            PowerUps.Add(PowerUpType.Tries, new TriesPowerUp(1));
            PowerUps.Add(PowerUpType.Score, new ScorePowerUp(20));
            PowerUps.Add(PowerUpType.Time, new TimePowerUp(20));
        }

        public static void Use(PowerUpType powerUpType, ref int amount)
        {
            PowerUps[powerUpType].Use(ref amount);
        }

    }
}