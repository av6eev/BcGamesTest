using Level;
using Player;
using SceneManagement;
using UnityEngine;

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

        protected override async void AfterInit()
        {
            _gameModel.SceneManagementModelsCollection.SetCurrentSceneId(SceneConst.Level);
            
            _gameModel.LevelModel = new LevelModel(true);
            _gameModel.PlayerModel = new PlayerModel();
            
            Presenters.Add(new PlayerPresenter(_gameModel, _gameModel.PlayerModel, _view));
            
            await _gameModel.LevelModel.TutorialCompleteAwaiter;

            _gameModel.PlayerModel.IsReady = true;
        }

        protected override void AfterDispose()
        {
        }
    }
}