using GameScenes.Level;
using Presenter;

namespace Level.Next
{
    public class LevelNextPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _sceneView;

        public LevelNextPresenter(IGameModel gameModel, LevelModel model, LevelSceneView sceneView)
        {
            _gameModel = gameModel;
            _model = model;
            _sceneView = sceneView;
        }
        
        public void Init()
        {
            _model.OnNext.OnChanged += HandleNext;
        }

        public void Dispose()
        {
            _model.OnNext.OnChanged -= HandleNext;
        }

        private void HandleNext()
        {
            _model.IsFinished.Value = false;

            _gameModel.SceneManagementModelsCollection.Unload("level_scene");
            _gameModel.SceneManagementModelsCollection.Load("level_scene");
        }
    }
}