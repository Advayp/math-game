using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadUsingToggle : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Field field;
        [SerializeField] private Toggle toggle;

        private void Start()
        {
            toggle.isOn = (bool)config.Get(field);
        }
    }
}