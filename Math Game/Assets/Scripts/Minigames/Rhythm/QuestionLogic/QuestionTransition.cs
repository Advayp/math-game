using System.Collections.Generic;
using UnityEngine;

namespace Discovery.Minigames.Rhythm.QuestionLogic
{
    [RequireComponent(typeof(QuestionMaker))]
    public class QuestionTransition : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space]
        private RhythmQuestionAnswerManager[] answerManagers;
        [SerializeField] private GameObject[] enableableGameObjects;

        private QuestionMaker _questionMaker;
        private readonly List<IEnableable> _enableables = new List<IEnableable>();
        
        private void Awake()
        {
            _questionMaker = GetComponent<QuestionMaker>();

            foreach (var enableableGameObject in enableableGameObjects)
            {
                var enableable = enableableGameObject.GetComponent<IEnableable>();
                if (enableable == null) continue;
                _enableables.Add(enableable);
            }
            
            foreach (var answerManager in answerManagers)
            {
                var enableable = answerManager.GetComponent<IEnableable>();
                if (enableable == null) continue;
                _enableables.Add(enableable);
            }
        }

        private void OnEnable()
        {
            foreach (var answerManager in answerManagers)
            {
                answerManager.Answered += DisableAll;
            }

            _questionMaker.Generated += EnableAll;
        }

        private void OnDisable()
        {
            foreach (var answerManager in answerManagers)
            {
                answerManager.Answered -= DisableAll;
            }

            _questionMaker.Generated -= EnableAll;
        }

        private void EnableAll()
        {
            foreach (var enableable in _enableables)
            {
                enableable.Enable();
            }
        }

        private void DisableAll()
        {
            foreach (var enableable in _enableables)
            {
                enableable.Disable();
            }
        }

    }
}