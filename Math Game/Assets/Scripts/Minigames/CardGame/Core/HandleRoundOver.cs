using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Discovery.Minigames.CardGame
{
    public class HandleRoundOver : MonoBehaviour
    {
        [SerializeField] private TimeManager timeManager;
        [SerializeField] private List<GameObject> objectsToReset;
        [SerializeField] private UnityEvent roundCompleted;
        

        private List<IResetable> _resetables;

        private void Awake()
        {
            _resetables = new List<IResetable>();
            foreach (var objectToReset in objectsToReset)
            {
                _resetables.Add(objectToReset.GetComponent<IResetable>());
            }
        }

        private void OnEnable()
        {
            timeManager.RoundOver += ShowRoundOverUI;
        }

        private void OnDisable()
        {
            timeManager.RoundOver -= ShowRoundOverUI;
        }

        private void ShowRoundOverUI()
        {
            roundCompleted?.Invoke();
        }

        public void Reset()
        {
            foreach (var resetable in _resetables)
            {
                resetable.Reset();
            }
        }
    }
}