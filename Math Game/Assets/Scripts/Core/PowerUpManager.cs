using System;
using System.Collections.Generic;
using MathGame.PowerUps;
using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame.Core
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private FloatVariable score;
        [SerializeField] private ScoreDisplayer scoreDisplayer;

        private static readonly Dictionary<PowerUpType, IPowerUp<int>> PowerUps = new Dictionary<PowerUpType, IPowerUp<int>>();

        private static readonly List<IPowerUp<int>> TriesPowerUps = new List<IPowerUp<int>>();
        private static readonly List<IPowerUp<int>> ScorePowerUps = new List<IPowerUp<int>>();
        private static readonly List<IPowerUp<float>> TimePowerUps = new List<IPowerUp<float>>();

        public static IPowerUp<int> RecentTriesPowerUp => TriesPowerUps.Count == 0 ? null : TriesPowerUps[TriesPowerUps.Count - 1];

        private static IPowerUp<int> RecentScorePowerUp => ScorePowerUps.Count == 0 ? null : ScorePowerUps[ScorePowerUps.Count - 1];
        public static IPowerUp<float> RecentTimePowerUp => TimePowerUps.Count == 0 ? null : TimePowerUps[TimePowerUps.Count - 1];

        private void Start()
        {
            AddScorePowerUp(new ScorePowerUp(20));
        }

        public static void Use(PowerUpType powerUpType, ref int amount)
        {
            if (PowerUps.Keys.Count == 0) return;
            PowerUps[powerUpType].Use(ref amount);
            if (powerUpType == PowerUpType.Score)
            {
                ScorePowerUps.Remove(PowerUps[powerUpType]);
                return;
            }
            TriesPowerUps.Remove(PowerUps[powerUpType]);
        }

        public static void UseTime(ref float amount)
        {
            if (TimePowerUps.Count == 0) return;
            TimePowerUps[TimePowerUps.Count].Use(ref amount);
            TimePowerUps.Remove(TimePowerUps[TimePowerUps.Count]);
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

        public void UseScorePowerUp()
        {
            RecentScorePowerUp.Use(ref score.value);
            scoreDisplayer.UpdateLabel();
        }
    }
}