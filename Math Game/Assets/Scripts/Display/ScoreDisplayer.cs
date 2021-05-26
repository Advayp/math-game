using UnityEngine;
using TMPro;
using MathGame.Core;

namespace MathGame.Display
{
    public class ScoreDisplayer : MonoBehaviour
    {
        [SerializeField] private FloatVariable _score;
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            AnswerManager.Scored += UpdateLabel;
            _score.Value = 0;
        }

        private void OnDestroy()
        {
            AnswerManager.Scored -= UpdateLabel;
        }

        private void OnDisable()
        {
            AnswerManager.Scored -= UpdateLabel;
        }

        private void OnEnable()
        {
            AnswerManager.Scored += UpdateLabel;
        }

        public void UpdateLabel()
        {
            _label.SetText($"Score: {_score.Value}");
        }
    }
}