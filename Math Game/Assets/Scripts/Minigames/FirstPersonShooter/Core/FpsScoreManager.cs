using System;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter
{
    //TODO: Make this class work with multiple enemies
    public class FpsScoreManager : MonoBehaviour
    {
        [SerializeField] private FloatVariable score;
        [SerializeField] private int scoreGivenOnDeath;

        public event Action Scored;

        public float CurrentScore => score.value;
        
        private void Awake()
        {
#if UNITY_EDITOR
            score.value = 0;
#endif
        }

        private void OnEnable()
        {
            EnemyHealth.OnDeath += AddToScore;
        }

        private void OnDisable()
        {
            EnemyHealth.OnDeath -= AddToScore;
        }

        private void AddToScore()
        {
            score.value += scoreGivenOnDeath;
            Scored?.Invoke();
        }
    }
}