using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputView : MonoBehaviour
    {
        public InputActionAsset PlayerInputAsset;

        public void Initialize()
        {
            PlayerInputAsset.Enable();
        }

        public void Dispose()
        {
            PlayerInputAsset.Disable();
        }
    }
}