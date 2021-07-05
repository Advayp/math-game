using TMPro;
using UnityEngine;

namespace Discovery.Minigames.CardGame.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DisplayWinningPlayer : MonoBehaviour
    {
        [SerializeField] private AddToScore scoreManager;
        [SerializeField] private TimeManager timeManager;
        
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
            timeManager.RoundOver += UpdateLabel;
        }

        private void OnDisable()
        {
            timeManager.RoundOver -= UpdateLabel;
        }

        private void UpdateLabel()
        {
            _label.SetText(scoreManager.WinningPlayer);
        }

    }
}