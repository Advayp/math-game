using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private KeyCode pauseKey;
        [SerializeField] private GameObject[] disableables;
        [SerializeField] private GameObject pausedUI;
        

        private readonly List<IEnableable[]> _enableables = new List<IEnableable[]>();
        private bool _isPaused;
        
        private void Awake()
        {
            pausedUI.Require(this);
            
            foreach (var disableable in disableables)
            {
                var enableables = disableable.GetComponents<IEnableable>();
                if (enableables.Length == 0) continue;
                _enableables.Add(enableables);
            }
        }

        private void Update()
        {
            if (!Input.GetKeyDown(pauseKey)) return;
            if (_isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }

        private void Pause()
        {
            pausedUI.SetActive(true);
           
            foreach (var enableable in _enableables.SelectMany(enableables => enableables))
            {
                enableable.Disable();
            }
            
            _isPaused = true;
        }

        private void Unpause()
        {
            pausedUI.SetActive(false);
            
            foreach (var enableable in _enableables.SelectMany(enableables => enableables))
            {
                enableable.Enable();
            }
            
            _isPaused = false;
        }
    }
}