using System.Collections.Generic;
using System.Linq;
using Discovery.PowerUps;
using UnityEngine;

namespace Discovery
{
    public class PowerUpManager : MonoBehaviour
    {
        private static readonly Dictionary<PowerUpType, IPowerUp<int>> PowerUps = new Dictionary<PowerUpType, IPowerUp<int>>();

        private static readonly List<IPowerUp<int>> TriesPowerUps = new List<IPowerUp<int>>();
        private static readonly List<IPowerUp<int>> ScorePowerUps = new List<IPowerUp<int>>();
        private static readonly List<IPowerUp<float>> TimePowerUps = new List<IPowerUp<float>>();
        
        public static IPowerUp<int> RecentTriesPowerUp => TriesPowerUps.Count == 0 ? null : TriesPowerUps.Last();
        public static IPowerUp<int> RecentScorePowerUp => ScorePowerUps.Count == 0 ? null : ScorePowerUps.Last();
        public static IPowerUp<float> RecentTimePowerUp => TimePowerUps.Count == 0 ? null : TimePowerUps.Last();

        private void Start()
        {
            AddScorePowerUp(new ScorePowerUp(2));
        }

        public static void UseScore(ref int amount)
        {
            PowerUps[PowerUpType.Score].Use(ref amount);
            ScorePowerUps.Remove(PowerUps[PowerUpType.Score]);
            PowerUps.Remove(PowerUpType.Score);
            
            // Adds a new PowerUp back after we remove the key
            if (ScorePowerUps.Count > 0)
            {
                PowerUps.Add(PowerUpType.Score, ScorePowerUps[ScorePowerUps.Count - 1]);
            }
        }

        public static void UseTries(ref int amount)
        {
            if (PowerUps.ContainsKey(PowerUpType.Tries) == false) return;
            PowerUps[PowerUpType.Tries].Use(ref amount);
            TriesPowerUps.Remove(PowerUps[PowerUpType.Tries]);
            PowerUps.Remove(PowerUpType.Tries);
            if (TriesPowerUps.Count > 0)
            {
                PowerUps.Add(PowerUpType.Tries, TriesPowerUps.Last());
            }
            
        }

        public static void UseTime(ref float amount)
        {
            if (TimePowerUps.Count == 0) return;
            TimePowerUps.Last().Use(ref amount);
            TimePowerUps.Remove(TimePowerUps.Last());
        }

        public static void AddTriesPowerUp(TriesPowerUp powerUp)
        {
            TriesPowerUps.Add(powerUp);
            if (PowerUps.ContainsKey(PowerUpType.Tries))
            {
                PowerUps[PowerUpType.Tries] = powerUp;
                return;
            }
            PowerUps.Add(PowerUpType.Tries, powerUp);
        }

        public static void AddScorePowerUp(ScorePowerUp powerUp)
        {
            ScorePowerUps.Add(powerUp);
            if (PowerUps.ContainsKey(PowerUpType.Score))
            {
                PowerUps[PowerUpType.Score] = powerUp;
                return;
            }
            PowerUps.Add(PowerUpType.Score, powerUp);
        }

        public static void AddTimePowerUp(TimePowerUp powerUp)
        {
            TimePowerUps.Add(powerUp);
        }

    }
}