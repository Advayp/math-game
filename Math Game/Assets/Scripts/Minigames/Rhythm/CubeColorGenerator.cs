using System.Collections;
using UnityEngine;

namespace Discovery.Minigames.Rhythm
{
    public class CubeColorGenerator : MonoBehaviour
    {
        [SerializeField] private Color[] colors;
        [SerializeField] private float delay;

        private WaitForSeconds _delayBetweenColorChange;
        private MeshRenderer _renderer;
        private IEnumerator _currentColorRoutine;
        private int _currentIndex;

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
            if (_currentColorRoutine != null)
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

    }
}