using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Discovery.Managers
{
    public class OptionMenu : MonoBehaviour
    {
        [SerializeField] private KeyCode keyToExit = KeyCode.Escape;
        [SerializeField] private GameObject[] disableables;
        [SerializeField] private UnityEvent showMenu;
        [SerializeField] private UnityEvent hideMenu;
        

        private readonly List<IEnableable[]> _enableables = new List<IEnableable[]>();
        private bool _isMenuActive;

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
            if (!_isMenuActive)
            {
                HandleExit();
                return;
            }
            HandleStart();
        }

        private void HandleExit()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            showMenu?.Invoke();
            _isMenuActive = true;
            
            foreach (var enableable in _enableables.SelectMany(enableables => enableables))
            {
                enableable.Disable();
            }
        }

        private void HandleStart()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            hideMenu?.Invoke();
            _isMenuActive = false;

            foreach (var enableable in _enableables.SelectMany(e => e))
            {
                enableable.Enable();
            }
        }
        
    }
}