using Discovery.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery
{
    public class ScoreDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_score")]
        [SerializeField]
        private FloatVariable score;

        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            AnswerManager.Scored += UpdateLabel;
            ItemPurchaser.OnPurchased += UpdateLabel;   
#if UNITY_EDITOR
            score.value = 0;
#endif
            UpdateLabel();
        }

        private void OnDestroy()
        {
            AnswerManager.Scored -= UpdateLabel;
            ItemPurchaser.OnPurchased -= UpdateLabel;
        }

        private void OnDisable()
        {
            AnswerManager.Scored -= UpdateLabel;
            ItemPurchaser.OnPurchased -= UpdateLabel;
        }

        private void OnEnable()
        {
            AnswerManager.Scored += UpdateLabel;
            ItemPurchaser.OnPurchased += UpdateLabel;
        }

        private void UpdateLabel()
        {
            _label.SetText($"{score.value}");
        }
    }
}