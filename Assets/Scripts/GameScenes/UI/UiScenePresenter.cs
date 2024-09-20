using Level.Tutorial;
using Presenter;

namespace GameScenes.UI
{
    public class UiScenePresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly UiSceneView _view;
        
        private readonly PresentersList _presenters = new();

        public UiScenePresenter(GameModel gameModel, UiSceneView view)
        {
            _gameModel = gameModel;
            _view = view;
        }

        public void Init()
        {
            _gameModel.InputModel.Disable();
            
            _presenters.Add(new TutorialPresenter(_gameModel, _view.TutorialView));
            
            _presenters.Init();
        }

        public void Dispose()
        {
            _presenters.Dispose();
        }
    }
}