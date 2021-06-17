using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadShowEffects : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;
        [SerializeField] private Toggle toggle;

        private void Start()
        {
            toggle.isOn = config.showEffects;
        }
    }
}