using TMPro;
using UnityEngine;

namespace Discovery.Minigames.Rhythm
{
    [RequireComponent(typeof(TMP_Text))]
    public class QuestionUI : MonoBehaviour
    {
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        public void Initialize(string text)
        {
            _label.SetText(text);
        }
    }
}