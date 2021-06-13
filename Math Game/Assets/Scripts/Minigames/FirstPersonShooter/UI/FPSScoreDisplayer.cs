using TMPro;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.UI
{
    public class FPSScoreDisplayer : MonoBehaviour
    {
        [SerializeField, Tooltip("The Text to Change")]
        private TMP_Text label;

        [SerializeField, Tooltip("The Score Manager to Track")]
        private FpsScoreManager scoreManager;



        private void Awake()
        {
            label = label ? label : GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnEnable()
        {
            scoreManager.Scored += UpdateText;
        }

        private void OnDisable()
        {
            scoreManager.Scored -= UpdateText;
        }

        private void UpdateText()
        {
            label.SetText($"{scoreManager.CurrentScore}");
        }
    }
}