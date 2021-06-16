using TMPro;
using UnityEngine;

namespace Discovery.Minigames.Rhythm.ScoreLogic
{
    [RequireComponent(typeof(TMP_Text))]
    public class RhythmScoreDisplayer : MonoBehaviour
    {
        [SerializeField, Tooltip("The Score Manager To Track")] private RhythmScoreManager scoreManager;

        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            scoreManager.Scored += UpdateText;
        }

        private void OnDisable()
        {
            scoreManager.Scored -= UpdateText;
        }

        private void UpdateText(int newValue)
        {
            _label.SetText(newValue.ToString());
        }
    }
}