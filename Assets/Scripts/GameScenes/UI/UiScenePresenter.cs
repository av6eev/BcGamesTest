using GameScenes.UI.LevelInfo;
using GameScenes.UI.PlayerInfo;
using GameScenes.UI.Settings;
using GameScenes.UI.Windows.Lose;
using GameScenes.UI.Windows.Win;
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

            _gameModel.TutorialModel = new TutorialModel(true);
            
            _presenters.Add(new SettingsPresenter(_gameModel, _view.SettingsView));
            _presenters.Add(new PlayerInfoPresenter(_gameModel, _view.PlayerInfoView));
            _presenters.Add(new LevelInfoPresenter(_gameModel, _view.LevelInfoView));
            _presenters.Add(new WinWindowPresenter(_gameModel, _view.WinWindowView, _view));
            _presenters.Add(new LoseWindowPresenter(_gameModel, _view.LoseWindowView, _view));
            _presenters.Add(new TutorialPresenter(_gameModel, _gameModel.TutorialModel, _view.TutorialView));
            
            _presenters.Init();
        }

        public void Dispose()
        {
            _presenters.Dispose();
            _presenters.Clear();
        }
    }
}