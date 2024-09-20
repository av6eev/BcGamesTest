using Presenter;

namespace Level.Tutorial
{
    public class TutorialPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly TutorialView _view;

        public TutorialPresenter(IGameModel gameModel, TutorialView view)
        {
            _gameModel = gameModel;
            _view = view;
        }
        
        public void Init()
        {
            _view.OnCompleted += HandleTutorialComplete;
        }

        public void Dispose()
        {
            _view.OnCompleted -= HandleTutorialComplete;
        }

        private void HandleTutorialComplete()
        {
            _gameModel.LevelModel.CompleteTutorial();
            _view.Hide();
        }
    }
}