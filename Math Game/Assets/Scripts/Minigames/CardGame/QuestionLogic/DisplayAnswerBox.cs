using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Discovery.Minigames.CardGame.QuestionLogic
{

    [RequireComponent(typeof(InputField))]
    public class DisplayAnswerBox : MonoBehaviour, IAnswerDisplay
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private UnityEvent<string> answered;
        [SerializeField] private UnityEvent onCompletedScaleInCallback;
        [SerializeField] private UnityEvent onCompletedScaleOutCallback;
        [SerializeField] private TMP_Text label;
        [SerializeField] private Button onClickButton;

        private InputField _inputField;

        private static readonly Dictionary<PlayerType, string> PlayerNames = new Dictionary<PlayerType, string>()
        {
            { PlayerType.One, "One" },
            { PlayerType.Two, "Two" }
        };
        
        public bool IsQuestionActive { get; private set; }

        private void Awake()
        {
            _inputField = GetComponent<InputField>();
        }

        public void InitializeText(PlayerType playerType)
        {
            label.SetText($"What is the Answer, Player {PlayerNames[playerType]}");
            onClickButton.interactable = true;
            LeanTween.scale(panel, new Vector3(1, 1, 1), 0.2f).setOnComplete(() =>
            {
                onCompletedScaleInCallback?.Invoke();
            });
            IsQuestionActive = true;

        }

        public void Check()
        {
            answered?.Invoke(_inputField.text);
            onClickButton.interactable = false;
            LeanTween.scale(panel, new Vector3(0, 0, 0), 0.2f).setOnComplete(() =>
            {
                onCompletedScaleOutCallback?.Invoke();
            });
            IsQuestionActive = false;
        }
    }
}