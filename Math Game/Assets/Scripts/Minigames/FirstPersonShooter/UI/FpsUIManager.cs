using UnityEngine;
using UnityEngine.SceneManagement;

namespace MathGame.Minigames.FirstPersonShooter.UI
{
    public class FpsUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject deathUI;
        [SerializeField, Tooltip("The player whose death to track")] private PlayerHealth playerHealth;
        

        private void OnEnable()
        {
            playerHealth.Death += ShowDeathUI;
        }

        private void OnDisable()
        {
            playerHealth.Death -= ShowDeathUI;
        }

        private void ShowDeathUI()
        {
            deathUI.SetActive(true);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}