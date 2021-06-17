using System;
using TMPro;
using UnityEngine;

namespace Discovery.Minigames.Platformer.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class PlatformerScoreTracker : MonoBehaviour
    {
        [SerializeField] private PlayerScoreManager scoreManager;
        
        
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            scoreManager.Scored += SetText;
        }

        private void OnDisable()
        {
            scoreManager.Scored -= SetText;
        }

        private void SetText(int amount)
        {
            _label.SetText(amount.ToString());
        }
    }
}