using UnityEngine;

namespace Discovery.Minigames.Platformer
{
    public class PlayerScoreManager : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space] private FloatVariable score;
        [SerializeField, Header("Config"), Space] private int amountGivenOnCollect;
        [SerializeField] private string powerUpTag = "PowerUp";

        private void Awake()
        {
           score.Require(this); 
        }

        private void Start()
        {
#if UNITY_EDITOR
            score.value = 0;
#endif
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(powerUpTag)) return;
            Debug.Log("Increased Score");
            score.value += amountGivenOnCollect;
        }


    }
}