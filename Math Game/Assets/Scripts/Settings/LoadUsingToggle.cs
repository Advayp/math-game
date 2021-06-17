using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadUsingToggle : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;
        [SerializeField] private Fields field;
        [SerializeField] private Toggle toggle;

        private void Start()
        {
            toggle.isOn = (bool)config.Get(field);
        }
    }
}