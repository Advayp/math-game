using System;
using UnityEngine;

namespace Discovery.Minigames.CardGame
{

    public class TimeManager : MonoBehaviour, IResetable
    {
        [SerializeField, Tooltip("The round length in minutes.")] private float roundLength;
        [SerializeField] private MinutesTimer minutesTimer;
        

        private bool _isRoundOver;
        
        public event Action RoundOver;
        
        private void Start()
        {
           minutesTimer.StartTimer(roundLength * 60); 
        }

        private void Update()
        {
            if (!minutesTimer.IsComplete || _isRoundOver) return;
            OnRoundOver();
            _isRoundOver = true;
        }

        private void OnRoundOver()
        {
            RoundOver?.Invoke();
            print("Round Over");
        }

        public void Reset()
        {
           minutesTimer.StartTimer(roundLength * 60); 
        }
    }
}