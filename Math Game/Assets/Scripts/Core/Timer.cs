using TMPro;
using UnityEngine;

namespace MathGame.Core
{
    public class Timer : MonoBehaviour
    {
        public float TimeRemaining;
        public bool IsComplete => Mathf.FloorToInt(TimeRemaining % 60) <= 0;

        private TMP_Text _timerText;
        private bool _hasTimerStarted = false;

        private void Start()
        {
            _timerText = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_hasTimerStarted == false) return;
            TimeRemaining = Mathf.Clamp(TimeRemaining - Time.deltaTime, 0, float.MaxValue);
            DisplayTime(TimeRemaining);
        }

        private void DisplayTime(float timeToDisplay)
        {
            var minutes = Mathf.FloorToInt(timeToDisplay / 60);
            var seconds = Mathf.FloorToInt(timeToDisplay % 60);

            _timerText.SetText($"{minutes:00}:{seconds:00}");
        }

        public void StartTimer(float time)
        {
            TimeRemaining = time;
            _hasTimerStarted = true;
        }

        public void StopTimer()
        {
            _hasTimerStarted = false;
        }
    }
}