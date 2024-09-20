using Presenter;

namespace GameScenes.UI.PlayerInfo
{
    public class PlayerInfoPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerInfoView _view;

        public PlayerInfoPresenter(IGameModel gameModel, PlayerInfoView view)
        {
            _gameModel = gameModel;
            _view = view;
        }
        
        public void Init()
        {
            HandleMoneyUpdate(_gameModel.PlayerModel.SavedMoney.Value, 0);
            _view.Show();
            
            _gameModel.LevelModel.OnRestart.OnChanged += HandleRestart;
            _gameModel.LevelModel.OnNext.OnChanged += HandleRestart;
            _gameModel.PlayerModel.SavedMoney.OnChanged += HandleMoneyUpdate;
        }

        public void Dispose()
        {
            _gameModel.LevelModel.OnRestart.OnChanged -= HandleRestart;
            _gameModel.LevelModel.OnNext.OnChanged -= HandleRestart;
            _gameModel.PlayerModel.SavedMoney.OnChanged -= HandleMoneyUpdate;
        }

        private void HandleRestart()
        {
            _view.Show();
        }

        private void HandleMoneyUpdate(int newValue, int oldValue)
        {
            if (!_gameModel.LevelModel.IsFinished.Value) return;

            _view.BalanceMoneyText.text = newValue.ToString();
        }
    }
}