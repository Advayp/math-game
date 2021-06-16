using UnityEngine;
using Random = UnityEngine.Random;

namespace Discovery.Minigames.Rhythm.QuestionLogic
{
    public class QuestionMaker : MonoBehaviour
    {

        [SerializeField, Header("Dependencies"), Space]
        private QuestionUI questionDisplay;
        [SerializeField] private RhythmQuestionAnswerManager[] answerManagers;

        [SerializeField, Header("Config"), Space]
        private float delay;
        [SerializeField] private bool useDelayed;

        public delegate void GenerateHandler();

        public event GenerateHandler Generated;

        private void Awake()
        {
            questionDisplay.Require(this);
        }

        private void Start()
        {
            GenerateNewQuestion();
        }

        private void OnEnable()
        {
            foreach (var answerManager in answerManagers)
            {
                if (useDelayed)
                {
                    answerManager.Answered += GenerateNewQuestionDelayed;
                    continue;
                }
                answerManager.Answered += GenerateNewQuestion;
            }
        }

        private void OnDisable()
        {
            foreach (var answerManager in answerManagers)
            {
                if (useDelayed)
                {
                    answerManager.Answered -= GenerateNewQuestionDelayed;
                    continue;
                }
                answerManager.Answered -= GenerateNewQuestion;
            }
        }


        public void GenerateNewQuestion()
        {
            IQuestionGenerator questionGenerator = new StandardQuestionGenerator();
            var correctAnswer = questionGenerator.Answer;
            questionDisplay.Initialize(questionGenerator.GetQuestion());

            var randomIndex = Random.Range(0, answerManagers.Length - 1);

            for (var i = 0; i < answerManagers.Length; i++)
            {
                if (randomIndex != i)
                {
                    var randomAnswer = Random.Range(1, 100);
                    if (randomAnswer == correctAnswer)
                    {
                        randomAnswer++;
                    }
                    answerManagers[i].Initialize(randomAnswer, correctAnswer);
                    continue;
                }

                answerManagers[i].Initialize(correctAnswer, correctAnswer);
            }
            
            Generated?.Invoke();
        }

        private void GenerateNewQuestionDelayed()
        {
            Invoke(nameof(GenerateNewQuestion), delay);
        }

    }
}