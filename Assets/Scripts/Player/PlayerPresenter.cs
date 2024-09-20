using GameScenes.Level;
using Presenter;
using Updater;

namespace Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly LevelSceneView _levelSceneView;
        private readonly PlayerView _view;

        private IUpdater _physicsUpdater;
        private readonly PresentersList _presenters = new();
        
        public PlayerPresenter(IGameModel gameModel, PlayerModel model, LevelSceneView levelSceneView)
        {
            _gameModel = gameModel;
            _model = model;
            _levelSceneView = levelSceneView;
            _view = _levelSceneView.PlayerView;
        }
        
        public void Init()
        {
            _presenters.Add(new PlayerTurnPresenter(_gameModel, _model, _view));
            _presenters.Init();
            
            _physicsUpdater = new PlayerPhysicsUpdater(_gameModel.InputModel, _model, _view, _levelSceneView.LevelManager.Levels[_levelSceneView.LevelManager.CurrentLevelIndex]);
            _gameModel.FixedUpdatersList.Add(_physicsUpdater);
        }

        public void Dispose()
        {
            _gameModel.FixedUpdatersList.Remove(_physicsUpdater);
        }
    }
}