using UnityEngine;

namespace Discovery.Minigames.Platformer
{
    public class SpeedPowerUp : MonoBehaviour
    {
        [SerializeField] private float speedToChangeTo;
        [SerializeField] private GameObject player;

        private IControllable _controllable;
        
        private void Awake()
        {
           player.Require(this);

           _controllable = player.GetComponent<IControllable>() ?? new NullControllable();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name != player.name) return;

            _controllable.SetSpeed(speedToChangeTo);
            
            Destroy(gameObject);
        }


    }

}