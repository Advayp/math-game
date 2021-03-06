using System.Collections.Generic;
using UnityEngine;

namespace Discovery.PowerUps
{
    public class PowerUpMenuManager : MonoBehaviour
    {
        [SerializeField] private List<PowerUpDisplayer> powerUpDisplays;

        public void UpdateText()
        {
            foreach (var powerUpDisplayer in powerUpDisplays)
            {
                powerUpDisplayer.UpdateText();
            }
        }
    }
}
