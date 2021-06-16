using System;
using UnityEngine;

namespace Discovery.Minigames.Rhythm.ScoreLogic
{
    public class RhythmScoreManager : MonoBehaviour
    {
        [SerializeField] private FloatVariable score;
        [SerializeField] private int amountToAddToScore;
        [SerializeField] private RhythmQuestionAnswerManager[] answerManagers;

        public event Action<int> Scored;

        private void Start()
        {
#if UNITY_EDITOR
            score.value = 0;
            OnScored();
#endif
        }

        private void OnEnable()
        {
            for (var i = answerManagers.Length - 1; i >= 0; i--)
            {
                answerManagers[i].AnsweredCorrectly += AddToScore;
            }
        }

        private void OnDisable()
        {
            for (var i = answerManagers.Length - 1; i >= 0; i--)
            {
                answerManagers[i].AnsweredCorrectly -= AddToScore;
            }
        }

        private void AddToScore()
        {
            score.value += amountToAddToScore;
            OnScored();
        }

        private void OnScored()
        {
            Scored?.Invoke(score.value);
        }

    }
}