using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Discovery.Minigames.Rhythm
{
    public class QuestionMaker : MonoBehaviour
    {

        [SerializeField] private QuestionUI questionDisplay;
        [SerializeField] private RhythmQuestionAnswerManager[] answerManagers;

        private void OnEnable()
        {
            foreach (var answerManager in answerManagers)
            {
                answerManager.Answered += UpdateQuestionUI;
            }
        }

        private void OnDisable()
        {
            foreach (var answerManager in answerManagers)
            {
                answerManager.Answered -= UpdateQuestionUI;
            }
        }

        private void Start()
        {
           UpdateQuestionUI(); 
        }

        public void UpdateQuestionUI()
        {
            var questionGenerator = new StandardQuestionGenerator();
            questionDisplay.Initialize(questionGenerator.GetQuestion());

            var randomIndex = Random.Range(0, answerManagers.Length - 1);

            for (var i = 0; i < answerManagers.Length; i++)
            {
                if (randomIndex != i)
                {
                    answerManagers[i].Initialize(Random.Range(1, 100), questionGenerator.Answer);
                    continue;
                }
                
                answerManagers[i].Initialize(questionGenerator.Answer, questionGenerator.Answer);
            }
        }


    }
}