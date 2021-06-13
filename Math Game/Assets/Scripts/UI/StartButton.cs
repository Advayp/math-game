using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Discovery.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class StartButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] private float fontSizeWhenHighlighted;

        private TMP_Text _label;
        private float _originalFontSize;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
            _originalFontSize = _label.fontSize;
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _label.fontSize = _originalFontSize;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _label.fontSize = fontSizeWhenHighlighted;
        }
    }
}
