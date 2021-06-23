using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Discovery.Managers
{

    public class RandomQuestionManager : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space] private List<Question> questions;
        [SerializeField] private GameObject questionDisplay;
        [SerializeField] private ConfigurableQuestion configurableQuestion;
        [SerializeField] private ConfigurableAnswer[] configurableAnswers;
        [SerializeField] private Timer timer;
        

        private void Awake()
        {
           questionDisplay.Require(this); 
           timer.Require(this);
        }

        public void ShowQuestion()
        {
            questionDisplay.SetActive(true);
        }

        public void HideQuestion()
        {
            questionDisplay.SetActive(false);
        }

        public void GenerateNewQuestion()
        {
            if (questions.Count == 0) return;
           
            
            foreach (var configurableAnswer in configurableAnswers)
            {
                configurableAnswer.Reset();
            }
            
            var randomIndex = new Random().Next(questions.Count);
            var randomQuestion = questions[randomIndex];
            
            timer.Start(randomQuestion.seconds);
            
            configurableQuestion.Initialize(randomQuestion);

            var randomAnswers = randomQuestion.answers;

            var correctAnswer = configurableAnswers[0];
            
            for (var i = 0; i < randomAnswers.Length; i++)
            {
                if (randomAnswers[i] == randomQuestion.correctAnswer)
                {
                    correctAnswer = configurableAnswers[i];
                }
                configurableAnswers[i].InitializeDisplayer(randomAnswers[i]);
            }
            
            configurableQuestion.Initialize(randomQuestion, correctAnswer.answerChecker);

            questions.Remove(randomQuestion);
        }

        public void UseTriesPowerUp()
        {
           configurableQuestion.answerDetermine.UseTries(); 
        }

        public void UseScorePowerUp()
        {
            configurableQuestion.scoreManager.UseScorePowerUp();
        }
        
    }
}