using Presenter;

namespace GameScenes.UI.Settings
{
    public class SettingsPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly SettingsView _view;

        public SettingsPresenter(IGameModel gameModel, SettingsView view)
        {
            _gameModel = gameModel;
            _view = view;
        }
        
        public void Init()
        {
            _view.Show();
            
            _view.ChangeExitButtonState(false);
            _view.ChangeSettingsButtonState(true);

            _gameModel.TutorialModel.IsComplete.OnChanged += HandleTutorialComplete;
            _gameModel.LevelModel.OnRestart.OnChanged += HandleRestart;
            _gameModel.LevelModel.OnNext.OnChanged += HandleRestart;
        }

        public void Dispose()
        {
            _gameModel.TutorialModel.IsComplete.OnChanged -= HandleTutorialComplete;
            _gameModel.LevelModel.OnRestart.OnChanged -= HandleRestart;
            _gameModel.LevelModel.OnNext.OnChanged -= HandleRestart;
        }

        private void HandleRestart()
        {
            _view.Show();
        }

        private void HandleTutorialComplete(bool newValue, bool oldValue)
        {
            switch (newValue)
            {
                case true:
                    _view.ChangeExitButtonState(true);
                    _view.ChangeSettingsButtonState(false);
                    break;
                case false:
                    _view.ChangeExitButtonState(false);
                    _view.ChangeSettingsButtonState(true);
                    break;
            }
        }
    }
}