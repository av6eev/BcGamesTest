using Presenter;

namespace Level.Tutorial
{
    public class TutorialPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly TutorialModel _model;
        private readonly TutorialView _view;

        public TutorialPresenter(IGameModel gameModel, TutorialModel model, TutorialView view)
        {
            _gameModel = gameModel;
            _model = model;
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
            _model.CompleteTutorial();
            _view.Hide();
        }
    }
}