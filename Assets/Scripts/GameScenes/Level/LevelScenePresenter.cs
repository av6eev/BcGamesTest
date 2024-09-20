using Level;
using Player;
using SceneManagement;

namespace GameScenes.Level
{
    public class LevelScenePresenter : BaseGameScenePresenter
    {
        private readonly GameModel _gameModel;
        private readonly LevelSceneView _sceneView;

        public LevelScenePresenter(GameModel gameModel, LevelSceneView sceneView) : base(gameModel, sceneView)
        {
            _gameModel = gameModel;
            _sceneView = sceneView;
        }

        protected override void AfterInit()
        {
            _gameModel.SceneManagementModelsCollection.SetCurrentSceneId(SceneConst.Level);
            
            Presenters.Add(new PlayerPresenter(_gameModel, _gameModel.PlayerModel, _sceneView.PlayerView));
            Presenters.Add(new LevelPresenter(_gameModel, _gameModel.LevelModel, _sceneView));
        }

        protected override void AfterDispose()
        {
        }
    }
}