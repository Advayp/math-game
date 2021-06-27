using UnityEngine;

namespace Discovery.Minigames.CardGame.QuestionLogic
{
    public class CardQuestionCreator : MonoBehaviour
    {
        [SerializeField] private CardDisplayQuestion cardDisplayQuestion;
        [SerializeField] private CardDisplayQuestion cardDisplayQuestionTwo;
        
        [SerializeField] private CardAnswerQuestion answerQuestion;
        
        private RandomQuestionGenerator _questionGenerator;
        
        private void Awake()
        {
           cardDisplayQuestion.Require(this); 
        }

        private void Start()
        {
            _questionGenerator = new RandomQuestionGenerator(1, 20);
        }

        public void Display(Vector3 position)
        {
            _questionGenerator.GetRandomNumbers(out var numberOne, out var numberTwo);
            cardDisplayQuestion.Initialize(numberOne);
            cardDisplayQuestionTwo.Initialize(numberTwo);
            answerQuestion.Initialize(_questionGenerator.Answer);
        }
    }
}