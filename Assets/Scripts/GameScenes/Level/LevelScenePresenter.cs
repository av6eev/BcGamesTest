using Level;
using SceneManagement;

namespace GameScenes.Level
{
    public class LevelScenePresenter : BaseGameScenePresenter
    {
        private readonly GameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _view;

        public LevelScenePresenter(GameModel gameModel, LevelModel model, LevelSceneView view) : base(gameModel, view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }

        protected override void AfterInit()
        {
            _gameModel.SceneManagementModelsCollection.SetCurrentSceneId(SceneConst.Level);
        }

        protected override void AfterDispose()
        {
        }
    }
}