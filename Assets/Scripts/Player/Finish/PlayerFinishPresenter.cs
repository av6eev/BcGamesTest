using Presenter;
using UnityEngine;
using Utilities;

namespace Player.Finish
{
    public class PlayerFinishPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerFinishPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _gameModel.LevelModel.IsFinished.OnChanged += HandleFinish;
        }

        public void Dispose()
        {
            _gameModel.LevelModel.IsFinished.OnChanged -= HandleFinish;
        }

        private void HandleFinish(bool newValue, bool oldValue)
        {
            if (!newValue) return;
            
            _view.StatusRoot.SetActive(false);
            _model.Reset(false);
            
            PlayerPrefs.SetString(SaveKeys.PlayerSavedMoney, _model.SavedMoney.Value.ToString());
        }
    }
}