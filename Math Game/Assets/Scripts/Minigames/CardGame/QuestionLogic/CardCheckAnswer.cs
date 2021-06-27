using UnityEngine;
using UnityEngine.Events;

namespace Discovery.Minigames.CardGame.QuestionLogic
{

    public class CardCheckAnswer : MonoBehaviour, ICheckAnswer
    {
        [SerializeField] private UnityEvent responseToCorrect;
        [SerializeField] private UnityEvent responseToWrong;

        private int _answer;

        public void Initialize(int answer)
        {
            _answer = answer;
        }

        public void Check(string text)
        {
            if (!int.TryParse(text, out var number))
            {
                responseToWrong?.Invoke();
                return;
            }

            if (number == _answer)
            {
                print("Correct!");
                responseToCorrect?.Invoke();
                return;
            }
            print("Incorrect!");
            responseToWrong?.Invoke();
        }
    }
}