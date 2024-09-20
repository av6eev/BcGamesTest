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
            if (_model.IsNeedTutorial)
            {
                _view.Show();
            }
            
            _view.OnCompleted += HandleTutorialComplete;
            _gameModel.LevelModel.OnRestart.OnChanged += HandleRestart;
            _gameModel.LevelModel.OnNext.OnChanged += HandleRestart;
        }

        public void Dispose()
        {
            _view.OnCompleted -= HandleTutorialComplete;
            _gameModel.LevelModel.OnRestart.OnChanged -= HandleRestart;
            _gameModel.LevelModel.OnNext.OnChanged -= HandleRestart;
        }

        private void HandleRestart()
        {
            if (!_model.IsNeedTutorial) return;
            
            _model.Reset();
            _view.Show();
            
            _gameModel.InputModel.Enable();
        }

        private void HandleTutorialComplete()
        {
            _model.CompleteTutorial();
            _gameModel.PlayerModel.IsReady = true;
            _view.Hide();
        }
    }
}