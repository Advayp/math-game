using TMPro;
using UnityEngine;

namespace Discovery.Minigames.CardGame.QuestionLogic
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CardDisplayQuestion : MonoBehaviour
    {
        [SerializeField] private Camera mainCam;
        
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
            mainCam = mainCam ? mainCam : Camera.main;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.SetActive(false);
            }
        }


        public void Initialize(int value)
        {
            gameObject.SetActive(true);
            _label.SetText(value.ToString());
        }
    }
}