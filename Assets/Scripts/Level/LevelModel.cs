using Awaiter;
using Reactive.Field;
using Utilities.Model;

namespace Level
{
    public class LevelModel : IModel
    {
        private readonly bool _isNeedTutorial;
        
        public readonly ReactiveField<bool> IsTutorialPassed = new();
        public CustomAwaiter TutorialCompleteAwaiter = new();

        public LevelModel(bool isNeedTutorial)
        {
            _isNeedTutorial = isNeedTutorial;
            if (_isNeedTutorial) return;
            
            IsTutorialPassed.Value = true;
            TutorialCompleteAwaiter.Complete();
        }

        public void CompleteTutorial()
        {
            IsTutorialPassed.Value = true;
            TutorialCompleteAwaiter.Complete();
        }

        public void Reset()
        {
            if (!_isNeedTutorial) return;

            IsTutorialPassed.Value = default;
            TutorialCompleteAwaiter = new CustomAwaiter();
        }
    }
}