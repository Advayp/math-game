using UnityEngine;

namespace Discovery.Minigames.CardGame.QuestionLogic
{
    public class CardAnswerQuestion : MonoBehaviour
    {
        [SerializeField] private KeyCode playerOneKey;
        [SerializeField] private KeyCode playerTwoKey;
        [SerializeField] private GameObject answerDisplay;
        
        
        private bool _hasInitialized;
        private IAnswerDisplay _answerDisplay;
        private ICheckAnswer _checkAnswer;

        private void Awake()
        {
            _answerDisplay = answerDisplay.GetComponent<IAnswerDisplay>();
            _checkAnswer = GetComponent<ICheckAnswer>();
            Debug.Log(_checkAnswer == null);
        }

        private void Update()
        {
            if (_hasInitialized == false) return;
            if (Input.GetKeyDown(playerOneKey))
            {
                HandlePlayerOne();
            }
            else if (Input.GetKeyDown(playerTwoKey))
            {
                HandlePlayerTwo();
            }
        }

        private void HandlePlayerTwo()
        {
            print("Player Two");
            _answerDisplay.InitializeText(PlayerType.Two);
            _hasInitialized = true;
        }

        private void HandlePlayerOne()
        {
            print("Player One");
            _answerDisplay.InitializeText(PlayerType.One);
            _hasInitialized = false; 
        }

        public void Initialize(int answer)
        {
            _hasInitialized = true;
            _checkAnswer.Initialize(answer);
        }
    }
}