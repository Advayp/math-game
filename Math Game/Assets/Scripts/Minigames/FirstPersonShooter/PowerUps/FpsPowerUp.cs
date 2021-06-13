using Discovery.Minigames.FirstPersonShooter.UI;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.PowerUps
{
    public abstract class FpsPowerUp : MonoBehaviour
    {
        [SerializeField] private FloatingUI floatingUI;
        [SerializeField] private Transform model;
        [SerializeField] private float rotateSpeed = 20f;

        protected SphereCollider Collider;
        protected MeshRenderer Renderer;
        
        private void Awake()
        {
            floatingUI.Require(this);
            model.Require(this);

            Collider = GetComponent<SphereCollider>();
            Renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
           model.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime)); 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTouchingPlayer(other.gameObject);
            } 
        }

        private void OnMouseOver()
        {
           floatingUI.gameObject.SetActive(true); 
        }

        private void OnMouseExit()
        {
           floatingUI.gameObject.SetActive(false); 
        }

        protected virtual void OnTouchingPlayer(GameObject player)  
        {
            
        }   
    }
}
