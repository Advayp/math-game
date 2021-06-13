using TMPro;
using UnityEngine;

namespace Discovery
{
    public class Timer : MonoBehaviour
    {
        [HideInInspector]
        public float timeRemaining;

        public bool IsComplete => Mathf.FloorToInt(timeRemaining % 60) <= 0;

        private TMP_Text _timerText;
        private bool _hasTimerStarted;

        private void Start()
        {
            _timerText = GetComponent<TMP_Text>();
            _hasTimerStarted = false;
        }

        private void Update()
        {
            if (_hasTimerStarted == false) return;
            timeRemaining = Mathf.Clamp(timeRemaining - Time.deltaTime, 0, float.MaxValue);
            DisplayTime(timeRemaining);
        }

        private void DisplayTime(float timeToDisplay)
        {
            var minutes = Mathf.FloorToInt(timeToDisplay / 60);
            var seconds = Mathf.FloorToInt(timeToDisplay % 60);

            _timerText.SetText($"{(minutes * 60) + seconds}");
        }

        public void Start(float time)
        {
            timeRemaining = time;
            _hasTimerStarted = true;
        }

        public void Resume()
        {
            _hasTimerStarted = true;
        }
        
        public void Stop()
        {
            _hasTimerStarted = false;
        }

        public void UseTimePowerUp()
        {
            PowerUpManager.UseTime(ref timeRemaining);
        }
    }
}