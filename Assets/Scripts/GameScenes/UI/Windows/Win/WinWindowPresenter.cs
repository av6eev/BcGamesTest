using Presenter;

namespace GameScenes.UI.Windows.Win
{
    public class WinWindowPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly WinWindowView _view;
        private readonly UiSceneView _sceneView;

        public WinWindowPresenter(IGameModel gameModel, WinWindowView view, UiSceneView sceneView)
        {
            _gameModel = gameModel;
            _view = view;
            _sceneView = sceneView;
        }
        
        public void Init()
        {
            _view.SetupDollarsForAnimation();
            _view.Hide();
            
            _view.GetButton.onClick.AddListener(HandleGetClick);
            _gameModel.LevelModel.IsFinished.OnChanged += HandleFinish;
        }

        public void Dispose()
        {
            _view.GetButton.onClick.RemoveListener(HandleGetClick);
            _gameModel.LevelModel.IsFinished.OnChanged -= HandleFinish;
        }

        private async void HandleGetClick()
        {
            _view.PlayDollarsAnimation();
            await _view.AnimationAwaiter;
            
            _gameModel.PlayerModel.CalculateSavedMoney();
            _gameModel.UpdateLevelIndex("2");
            _gameModel.LevelModel.Next();
            
            _view.Hide();
        }

        private void HandleFinish(bool newValue, bool oldValue)
        {
            _view.TotalMoneyEarnText.text = _gameModel.PlayerModel.GetTotalMoneyPerLevel().ToString();
            _view.Show();
        }
    }
}