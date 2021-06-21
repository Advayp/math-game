using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Discovery.Managers
{
    public class OptionMenu : MonoBehaviour
    {
        [SerializeField] private GameObject exitUI;
        [SerializeField] private KeyCode keyToExit = KeyCode.Escape;
        [SerializeField] private GameObject[] disableables;

        private readonly List<IEnableable[]> _enableables = new List<IEnableable[]>();

        private void Awake()
        {
            exitUI.Require(this);

        }

        private void Start()
        {
            foreach (var disableable in disableables)
            {
                var enableable = disableable.GetComponents<IEnableable>();
                if (enableable == null) continue;
                _enableables.Add(enableable);
            }
        }

        private void Update()
        {
            if (!Input.GetKeyDown(keyToExit)) return;
            HandleExit();
        }

        private void HandleExit()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            exitUI.SetActive(true);
            
            foreach (var enableable in _enableables.SelectMany(enableables => enableables))
            {
                enableable.Disable();
            }
        }
        
    }
}