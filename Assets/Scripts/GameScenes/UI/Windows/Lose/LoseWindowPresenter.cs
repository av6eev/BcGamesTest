using Presenter;

namespace GameScenes.UI.Windows.Lose
{
    public class LoseWindowPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LoseWindowView _view;
        private readonly UiSceneView _sceneView;

        public LoseWindowPresenter(IGameModel gameModel, LoseWindowView view, UiSceneView sceneView)
        {
            _gameModel = gameModel;
            _view = view;
            _sceneView = sceneView;
        }
        
        public void Init()
        {
            _view.Hide();
            
            _view.RestartButton.onClick.AddListener(HandleRestartClick);
            _gameModel.PlayerModel.OnDied.OnChanged += HandlePlayerDie;
        }

        public void Dispose()
        {
            _view.RestartButton.onClick.RemoveListener(HandleRestartClick);
            _gameModel.PlayerModel.OnDied.OnChanged -= HandlePlayerDie;
        }

        private void HandleRestartClick()
        {
            _view.Hide();
            _gameModel.LevelModel.Restart();
        }

        private void HandlePlayerDie()
        {
            _view.Show();
            
            _sceneView.LevelInfoView.Hide();
            _sceneView.PlayerInfoView.Hide();
            
            _gameModel.InputModel.Disable();
        }
    }
}