using Reactive.Event;
using Reactive.Field;
using UnityEngine;

namespace Input
{
    public class InputModel : IInputModel
    {
        public ReactiveEvent OnDebugPanelToggle { get; } = new();

        public ReactiveField<bool> IsEnable { get; } = new(true);
        public Vector2 SideInput { get; set; }

        public void Enable()
        {
            IsEnable.Value = true;
        }

        public void Disable()
        {
            IsEnable.Value = false;
        }
    }
}