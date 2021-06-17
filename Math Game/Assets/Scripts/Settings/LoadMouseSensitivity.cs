﻿using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadMouseSensitivity : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;
        [SerializeField] private Slider slider;

        private void Start()
        {
            slider.value = config.mouseSensitivity;
        }
    }
}