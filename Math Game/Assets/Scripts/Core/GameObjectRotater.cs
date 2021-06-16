using UnityEngine;

namespace Discovery
{
    public class GameObjectRotater : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed;
        [SerializeField] private Transform gameObjectToRotate;

        private void Update()
        {
           gameObjectToRotate.Rotate(Vector3.up * (Time.deltaTime * rotateSpeed)); 
        }

    }
}