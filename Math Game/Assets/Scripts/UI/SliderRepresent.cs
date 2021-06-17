using System;
using TMPro;
using UnityEngine;

namespace Discovery.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class SliderRepresent : MonoBehaviour
    {

        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        public void SetText(float single)
        {
            _label.SetText($"{Mathf.RoundToInt(single)}");
        }
    }
}