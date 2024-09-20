using GameScenes.UI.PlayerInfo;
using Presenter;

namespace GameScenes.UI.LevelInfo
{
    public class LevelInfoPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelInfoView _view;

        public LevelInfoPresenter(IGameModel gameModel, LevelInfoView view)
        {
            _gameModel = gameModel;
            _view = view;
        }
        
        public void Init()
        {
            _gameModel.PlayerModel.CurrentMoney.OnChanged += HandleMoneyChange;
            _gameModel.LevelModel.Index.OnChanged += HandleIndexChange;
        }

        public void Dispose()
        {
            _gameModel.PlayerModel.CurrentMoney.OnChanged -= HandleMoneyChange;
            _gameModel.LevelModel.Index.OnChanged -= HandleIndexChange;
        }

        private void HandleIndexChange(int newValue, int oldValue)
        {
            _view.CurrentLevelText.text = newValue.ToString();
        }

        private void HandleMoneyChange(int newValue, int oldValue)
        {
            _view.CurrentMoneyText.text = newValue.ToString();
        }
    }
}