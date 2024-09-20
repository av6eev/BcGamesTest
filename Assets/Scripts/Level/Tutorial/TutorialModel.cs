using Awaiter;
using Reactive.Field;

namespace Level.Tutorial
{
    public class TutorialModel
    {
        private readonly bool _isNeedTutorial;
        
        public readonly ReactiveField<bool> IsComplete = new();
        public CustomAwaiter TutorialCompleteAwaiter = new();

        public TutorialModel(bool isNeedTutorial)
        {
            _isNeedTutorial = isNeedTutorial;
            if (_isNeedTutorial) return;
            
            IsComplete.Value = true;
            TutorialCompleteAwaiter.Complete();
        }

        public void CompleteTutorial()
        {
            IsComplete.Value = true;
            TutorialCompleteAwaiter.Complete();
        }
        
        public void Reset()
        {
            if (!_isNeedTutorial) return;

            IsComplete.Value = default;
            TutorialCompleteAwaiter = new CustomAwaiter();
        }
    }
}