using TMPro;
using UnityEngine;

namespace Discovery.Minigames.CardGame
{
    public class MinutesTimer : MonoBehaviour
    {
        [HideInInspector]
        public float timeRemaining;

        public bool IsComplete
        {
            get {
                var minutes = Mathf.FloorToInt(timeRemaining / 60);
                var seconds = Mathf.FloorToInt(timeRemaining % 60);

                return minutes == 0 && seconds == 0;
            }
        }
        
        
        private bool _hasTimerStarted;
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            if (_hasTimerStarted == false) return;
            timeRemaining = Mathf.Clamp(timeRemaining - Time.deltaTime, 0, float.MaxValue);
            DisplayTime();
        }

        private void DisplayTime()
        {
            var minutes = Mathf.FloorToInt(timeRemaining / 60);
            var seconds = Mathf.Floor(timeRemaining % 60);
            
            _label.SetText($"{minutes}:{seconds:00}");
        }

        public void StartTimer(float seconds)
        {
            timeRemaining = seconds;
            _hasTimerStarted = true;
        }

        public void StopTimer()
        {
            _hasTimerStarted = false;
        }
        
    }
}