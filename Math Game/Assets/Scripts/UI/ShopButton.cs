using UnityEngine;

namespace MathGame.UI
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private GameObject timerLogo;
        [SerializeField] private GameObject shopUI;
        [SerializeField] private GameObject backToQuestionButton;
        [SerializeField] private GameObject goToShopButton;

        private void Awake()
        {
           shopUI.SetActive(false);
           backToQuestionButton.SetActive(false);
        }

        public void GoToShop()
        {
            timerLogo.SetActive(false);
            timer.Stop();
            timer.gameObject.SetActive(false);
            shopUI.SetActive(true);
            backToQuestionButton.SetActive(true);
            goToShopButton.SetActive(false);
        }

        public void HideShop()
        {
            timerLogo.SetActive(true);
            goToShopButton.SetActive(true);
            timer.gameObject.SetActive(true);
            shopUI.SetActive(false);
            backToQuestionButton.SetActive(false);
        }
    }
}
