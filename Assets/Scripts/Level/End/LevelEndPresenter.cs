using GameScenes.Level;
using Presenter;

namespace Level.End
{
    public class LevelEndPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _view;

        public LevelEndPresenter(IGameModel gameModel, LevelModel model, LevelSceneView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _model.IsFinished.OnChanged += HandleFinish;
        }

        public void Dispose()
        {
            _model.IsFinished.OnChanged -= HandleFinish;
        }

        private void HandleFinish(bool newValue, bool oldValue)
        {
            if (!newValue) return;
            
            _gameModel.InputModel.Disable();
        }
    }
}