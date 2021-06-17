using UnityEngine;

namespace Discovery.Minigames.Platformer.PowerUps
{
    public class JumpPowerUp : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space] private GameObject player;
        [SerializeField, Header("Config"), Space] private int numberOfJumpsGiven;

        private IJumpable _jumpable;

        private void Awake()
        {
            player.Require(this);
            _jumpable = player.GetComponent<IJumpable>() ?? new NullJumpable();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name != player.gameObject.name) return;

            if (_jumpable.NumberOfJumps == 0)
            {
                return;
            }
            
            _jumpable.SetJumps(numberOfJumpsGiven);
            
            Destroy(gameObject);
        }
    }   
}