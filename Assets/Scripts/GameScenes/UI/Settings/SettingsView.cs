﻿using UnityEngine;
using UnityEngine.UI;

namespace GameScenes.UI.Settings
{
    public class SettingsView : MonoBehaviour
    {
        public Button ExitButton;
        public Button SettingsButton;

        public void ChangeExitButtonState(bool state)
        {
            ExitButton.gameObject.SetActive(state);
        }
        
        public void ChangeSettingsButtonState(bool state)
        {
            SettingsButton.gameObject.SetActive(state);
        }
    }
}