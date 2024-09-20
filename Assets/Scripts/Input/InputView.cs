using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Input
{
    public class InputView : MonoBehaviour
    {
        public event Action<Vector2> OnTouchDelta;
        
        public InputActionAsset PlayerInputAsset;
        public PlayerInput PlayerInput;

        public void Initialize()
        {
            TouchSimulation.Enable();
            PlayerInput.SwitchCurrentControlScheme(InputSystem.devices.First(element => element == Touchscreen.current));
            PlayerInputAsset.Enable();
            
            PlayerInputAsset["TouchDelta"].performed += HandleTouchInput;
            PlayerInputAsset["TouchDelta"].canceled += HandleTouchInput;
        }

        public void Dispose()
        {
            PlayerInputAsset.Disable();
            
            PlayerInputAsset["TouchDelta"].performed -= HandleTouchInput;
            PlayerInputAsset["TouchDelta"].canceled += HandleTouchInput;
        }

        private void HandleTouchInput(InputAction.CallbackContext ctx)
        {
            OnTouchDelta?.Invoke(ctx.ReadValue<Vector2>());
        }
    }
}