using UnityEngine;

namespace Discovery.Minigames.CardGame.CardLogic
{
    public class ShowFlipStatus : MonoBehaviour
    {
        [SerializeField] private CardManager manager;
        [SerializeField] private GameObject icon;
        
        private void Update()
        {
            icon.SetActive(manager.CanPressSpace);
        }
    }
}