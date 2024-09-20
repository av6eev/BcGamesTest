using GameScenes.Level;
using Presenter;

namespace Level.Restart
{
    public class LevelRestartPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _view;

        public LevelRestartPresenter(IGameModel gameModel, LevelModel model, LevelSceneView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _model.OnRestart.OnChanged += HandleRestart;
        }

        public void Dispose()
        {
            _model.OnRestart.OnChanged -= HandleRestart;
        }

        private void HandleRestart()
        {
            _model.IsFinished.Value = false;

            _gameModel.SceneManagementModelsCollection.Unload("level_scene");
            _gameModel.SceneManagementModelsCollection.Load("level_scene");
        }
    }
}