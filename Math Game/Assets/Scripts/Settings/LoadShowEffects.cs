using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadShowEffects : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Toggle toggle;

        private void Start()
        {
            toggle.isOn = config.showEffects;
        }
    }
}