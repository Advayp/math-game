using System.Collections;
using UnityEngine;

namespace Discovery.Minigames.Rhythm.Other
{
    public class CubeColorGenerator : MonoBehaviour, IEnableable
    {
        [SerializeField] private Color[] colors;
        [SerializeField] private float delay;

        private WaitForSeconds _delayBetweenColorChange;
        private MeshRenderer _renderer;
        private IEnumerator _currentColorRoutine;
        private int _currentIndex;
        private bool _isEnabled;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            _delayBetweenColorChange = new WaitForSeconds(delay);
        }

        private void Update()
        {
            if (_currentColorRoutine != null || _isEnabled == false)
                return;
            _currentColorRoutine = ChangeColor();
            StartCoroutine(_currentColorRoutine);
        }

        private IEnumerator ChangeColor()
        {
            _renderer.material.color = colors[_currentIndex];
            _currentIndex++;
            _currentIndex %= colors.Length;
            yield return _delayBetweenColorChange;
            _currentColorRoutine = null;
        }



        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}