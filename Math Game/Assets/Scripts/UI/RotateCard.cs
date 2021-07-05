using UnityEngine;

namespace Discovery.UI
{
    public class RotateCard : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private Vector3 desiredRotation;


        private Vector3 _originalRotation;

        private void Start()
        {
            _originalRotation = transform.rotation.eulerAngles;
            RotateIn();
        }

        private void RotateIn()
        {
            LeanTween.rotate(gameObject, desiredRotation, duration).setOnComplete(OnComplete);
        }

        private void OnComplete()
        {
            LeanTween.rotate(gameObject, _originalRotation, duration).setDelay(1f);
        }
    }
}