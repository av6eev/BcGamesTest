using Reactive.Event;
using Reactive.Field;

namespace Input
{
    public interface IInputModel
    {
        ReactiveEvent OnDebugPanelToggle { get; }
        ReactiveField<bool> IsEnable { get; }
        float TurnInput { get; }
        void Enable();
        void Disable();
    }
}