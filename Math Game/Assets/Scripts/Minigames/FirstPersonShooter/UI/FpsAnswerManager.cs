using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Discovery.Minigames.FirstPersonShooter.UI
{
    [RequireComponent(typeof(InputField))]
    public class FpsAnswerManager : MonoBehaviour
    {
        [SerializeField] private Answer correctAnswer;

        [Space, SerializeField, Tooltip("The response to when the user types in the correct answer")]
        private UnityEvent response;

        [SerializeField, Tooltip("The Response when the user types in a wrong answer")]
        private UnityEvent responseToWrongAnswer;

        private InputField _field;

        private void Awake()
        {
            _field = GetComponent<InputField>();
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                _field.Select();
            }
        }

        public void Enter()
        {
            if (_field.text == correctAnswer.value)
            {
                response?.Invoke();
                _field.text = string.Empty;
                return;
            }

            responseToWrongAnswer.Invoke();
        }
    }
}