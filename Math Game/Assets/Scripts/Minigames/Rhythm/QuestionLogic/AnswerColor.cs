using UnityEngine;

namespace Discovery.Minigames.Rhythm.QuestionLogic
{
    public class AnswerColor : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space]
        private QuestionMaker questionMaker;
        [SerializeField] private RhythmQuestionAnswerManager[] answerManagers;

        [SerializeField, Header("Config"), Space]
        private Color colorWhenCorrect;
        [SerializeField] private Color colorWhenWrong;
        [SerializeField] private Color defaultColor;


        private void Awake()
        {
           questionMaker.Require(this); 
        }

        private void OnEnable()
        {
            SubscribeToEvents();
        }


        private void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeToEvents()
        {
            questionMaker.Generated += ResetAllColors;

            foreach (var answerManager in answerManagers)
            {
                answerManager.Answered += ChangeAllColors;
            }
        }

        private void UnsubscribeFromEvents()
        {
            questionMaker.Generated -= ResetAllColors;

            foreach (var answerManager in answerManagers)
            {
                answerManager.Answered -= ChangeAllColors;
            }
        }

        private void ChangeAllColors()
        {
            foreach (var answerManager in answerManagers)
            {
                if (answerManager.IsCorrect)
                {
                    answerManager.ChangeTextColor(colorWhenCorrect);
                    continue;
                }
                answerManager.ChangeTextColor(colorWhenWrong);
            }
        }

        private void ResetAllColors()
        {
            foreach (var answerManager in answerManagers)
            {
                answerManager.ChangeTextColor(defaultColor);
            }
        }

    }
}