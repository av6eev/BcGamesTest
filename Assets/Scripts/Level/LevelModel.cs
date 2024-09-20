using Level.Specification;
using Reactive.Event;
using Reactive.Field;
using Utilities.Model;

namespace Level
{
    public class LevelModel : IModel
    {
        public readonly ReactiveEvent OnNext = new();
        public readonly ReactiveEvent OnRestart = new();

        public readonly ReactiveField<string> Id = new();
        public readonly ReactiveField<bool> IsFinished = new();

        public LevelSpecification Specification { get; private set; }

        public LevelModel(string initialId)
        {
            Id.Value = initialId;
        }
        
        public void SetSpecification(LevelSpecification specification)
        {
            Specification = specification;
        }
        
        public void Next()
        {
            OnNext?.Invoke();            
        }

        public void Restart()
        {
            OnRestart?.Invoke();
        }
    }
}