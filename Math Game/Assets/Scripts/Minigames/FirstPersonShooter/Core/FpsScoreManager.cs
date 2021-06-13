using System;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class FpsScoreManager : MonoBehaviour
    {
        [SerializeField] private FloatVariable score;

        public event Action Scored;

        public float CurrentScore => score.value;

        private void Awake()
        {
#if UNITY_EDITOR
            score.value = 0;
#endif
        }

        public void AddToScore(int amount)
        {
            score.value += amount;
            Scored?.Invoke();
        }

        public void SubtractFromScore(int amount)
        {
            score.value = Mathf.Clamp(score.value - amount, 0, int.MaxValue);
            Scored?.Invoke();
        }
    }
}