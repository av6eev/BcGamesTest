using Level;
using Level.Manager;
using SceneManagement;

namespace GameScenes.Level
{
    public class LevelScenePresenter : BaseGameScenePresenter
    {
        private readonly GameModel _gameModel;
        private readonly LevelSceneView _view;

        public LevelScenePresenter(GameModel gameModel, LevelSceneView view) : base(gameModel, view)
        {
            _gameModel = gameModel;
            _view = view;
        }

        protected override void AfterInit()
        {
            _gameModel.SceneManagementModelsCollection.SetCurrentSceneId(SceneConst.Level);

            _gameModel.LevelManager = new LevelManagerView();
        }

        protected override void AfterDispose()
        {
        }
    }
}