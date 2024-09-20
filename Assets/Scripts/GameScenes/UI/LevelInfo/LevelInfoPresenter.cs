using System.Threading.Tasks;
using Presenter;
using UnityEngine;
using DG.Tweening;

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
            _view.Show();
            
            _gameModel.PlayerModel.CurrentMoney.OnChanged += HandleMoneyChange;
            _gameModel.LevelModel.Id.OnChanged += HandleIdChange;
            _gameModel.LevelModel.OnRestart.OnChanged += HandleRestart;
            _gameModel.LevelModel.IsFinished.OnChanged += HandleFinish;
            _gameModel.LevelModel.OnNext.OnChanged += HandleRestart;
        }

        public void Dispose()
        {
            _gameModel.PlayerModel.CurrentMoney.OnChanged -= HandleMoneyChange;
            _gameModel.LevelModel.Id.OnChanged -= HandleIdChange;
            _gameModel.LevelModel.OnRestart.OnChanged -= HandleRestart;
            _gameModel.LevelModel.IsFinished.OnChanged -= HandleFinish;
            _gameModel.LevelModel.OnNext.OnChanged -= HandleRestart;
        }

        private void HandleFinish(bool newValue, bool oldValue)
        {
            if (!newValue) return;
            
            _view.CurrentMoneyText.gameObject.SetActive(false);
        }

        private void HandleRestart()
        {
            _view.Show();
            _view.CurrentMoneyText.gameObject.SetActive(true);
        }

        private void HandleIdChange(string newValue, string oldValue)
        {
            _view.CurrentLevelText.text = $"Уровень: {newValue}";
        }

        private void HandleMoneyChange(int newValue, int oldValue)
        {
            var delta = newValue - oldValue;
            _view.CurrentMoneyText.text = newValue.ToString();
            
            _view.AnimateMoneyTooltip(delta);
        }
    }
}