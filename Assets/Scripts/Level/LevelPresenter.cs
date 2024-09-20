using GameScenes.Level;
using Level.End;
using Level.Next;
using Level.Restart;
using Loader.Object;
using Presenter;
using UnityEngine;

namespace Level
{
    public class LevelPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _sceneView;
        private LevelView _view;

        private readonly PresentersList _presenters = new();
        private ILoadObjectModel<GameObject> _loadObjectModel;
        
        public LevelPresenter(IGameModel gameModel, LevelModel model, LevelSceneView sceneView)
        {
            _gameModel = gameModel;
            _model = model;
            _sceneView = sceneView;
        }
        
        public async void Init()
        {
            var levelSpecification = _gameModel.Specifications.LevelSpecifications[_gameModel.LevelModel.Id.Value];
            
            _gameModel.LevelModel.Id.Value = _gameModel.CurrentLevelId;
            _gameModel.LevelModel.SetSpecification(levelSpecification);
            
            _loadObjectModel = _gameModel.LoadObjectsModel.Load<GameObject>(_gameModel.LevelModel.Specification.Id);
            await _loadObjectModel.LoadAwaiter;
            
            var component = _loadObjectModel.Result.GetComponent<LevelView>();
            _view = Object.Instantiate(component, _sceneView.LevelRoot);
            
            _presenters.Add(new LevelRestartPresenter(_gameModel, _gameModel.LevelModel, _sceneView));
            _presenters.Add(new LevelEndPresenter(_gameModel, _gameModel.LevelModel, _sceneView));
            _presenters.Add(new LevelNextPresenter(_gameModel, _gameModel.LevelModel, _sceneView));
            _presenters.Init();
        }

        public void Dispose()
        {
            _gameModel.LoadObjectsModel.Unload(_loadObjectModel);
            
            _presenters.Dispose();
            _presenters.Clear();
        }
    }
}