using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame.Core
{
    public class ScoreDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_score")]
        [SerializeField] private FloatVariable score;

        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            AnswerManager.Scored += UpdateLabel;
#if UNITY_EDITOR
            score.value = 0;
#endif
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
            _label.SetText($"Score: {score.value}");
        }
    }
}