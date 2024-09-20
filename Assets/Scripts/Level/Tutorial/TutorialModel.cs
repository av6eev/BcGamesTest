using Awaiter;
using Reactive.Field;

namespace Level.Tutorial
{
    public class TutorialModel
    {
        public readonly bool IsNeedTutorial;
        
        public readonly ReactiveField<bool> IsComplete = new();
        public CustomAwaiter TutorialCompleteAwaiter = new();

        public TutorialModel(bool isNeedTutorial)
        {
            IsNeedTutorial = isNeedTutorial;
            if (IsNeedTutorial) return;
            
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
            if (!IsNeedTutorial) return;

            IsComplete.Value = default;
            TutorialCompleteAwaiter = new CustomAwaiter();
        }
    }
}