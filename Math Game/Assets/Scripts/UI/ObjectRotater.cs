using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery.UI
{
    public class ObjectRotater : MonoBehaviour
    {
        [FormerlySerializedAs("moveSpeed"), SerializeField] 
        private float rotateSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));
        }
    }
}