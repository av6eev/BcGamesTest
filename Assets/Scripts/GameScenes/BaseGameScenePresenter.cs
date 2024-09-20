using Presenter;

namespace GameScenes
{
    public abstract class BaseGameScenePresenter : IPresenter
    {
        protected readonly IGameModel GameModel;
        private readonly BaseGameSceneView _sceneView;

        protected readonly PresentersList Presenters = new();
        
        protected BaseGameScenePresenter(IGameModel gameModel, BaseGameSceneView sceneView)
        {
            GameModel = gameModel;
            _sceneView = sceneView;
        }
        
        public void Init()
        {
            AfterInit();
            
            Presenters.Init();
            
            GameModel.InputModel.Enable();
        }

        public void Dispose()
        {
            GameModel.InputModel.Disable();
            
            Presenters.Dispose();
            Presenters.Clear();
            
            AfterDispose();
        }

        protected abstract void AfterInit();
        protected abstract void AfterDispose();
    }
}