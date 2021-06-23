using System;
using System.Collections.Generic;
using Discovery.PowerUps;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Discovery.Shop
{
    public class DisplayPowerUpInShop : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space]
        private TMP_Text powerUpText;
        [SerializeField] private TMP_Text costText;

        [SerializeField, Header("Config"), Space]
        private int startOfRange;
        [SerializeField] private int endOfRange;
        [SerializeField] private AvailablePowerUps type;

        private readonly ICostDeterminer _costDeterminer = new CostDeterminer();

        public int Cost => CostFunctions[type](Amount);
        public int Amount { get; private set; }

        private static readonly Dictionary<AvailablePowerUps, string> PowerUpStrings = new Dictionary<AvailablePowerUps, string>()
        {
            { AvailablePowerUps.Score, "Score" },
            { AvailablePowerUps.Time, "Seconds" },
            { AvailablePowerUps.Tries, "Tries" }
        };

        private static readonly Dictionary<AvailablePowerUps, Func<int, int>> CostFunctions = new Dictionary<AvailablePowerUps, Func<int, int>>();

        private void Awake()
        {
            powerUpText.Require(this);
            costText.Require(this);
            InitializeFunctions();
        }

        private void OnEnable()
        {
            Initialize(Random.Range(startOfRange, endOfRange));
        }

        private void Initialize(int amount)
        {
            Amount = amount;
            powerUpText.SetText($"+{Amount} {PowerUpStrings[type]}");
            costText.SetText($"{CostFunctions[type](Amount)}");
        }

        private void InitializeFunctions()
        {
            CostFunctions.Add(AvailablePowerUps.Score, _costDeterminer.CostForScorePowerUp);
            CostFunctions.Add(AvailablePowerUps.Time, _costDeterminer.CostForTimePowerUp);
            CostFunctions.Add(AvailablePowerUps.Tries, _costDeterminer.CostForTriesPowerUp);
        }

    }
}