using Reactive.Event;
using Reactive.Field;
using UnityEngine;

namespace Input
{
    public interface IInputModel
    {
        ReactiveEvent OnDebugPanelToggle { get; }
        ReactiveField<bool> IsEnable { get; }
        Vector2 SideInput { get; }
        void Enable();
        void Disable();
    }
}