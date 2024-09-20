using System;
using Presenter;
using UnityEngine;

namespace Player.Status
{
    public class PlayerStatusPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerStatusPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _view.StatusRoot.SetActive(true);
            _view.SetDefaultSkin();
            
            HandleStatusProgress(_model.CurrentStatusProgress.Value, 0f);
            HandleStatusType(_model.CurrentStatusType.Value, PlayerStatusType.Poor);
            
            _model.CurrentStatusProgress.OnChanged += HandleStatusProgress;
            _model.CurrentStatusType.OnChanged += HandleStatusType;
        }

        public void Dispose()
        {
            _model.CurrentStatusProgress.OnChanged -= HandleStatusProgress;
            _model.CurrentStatusType.OnChanged -= HandleStatusType;
        }

        private void HandleStatusProgress(float newValue, float oldValue)
        {
            if (_gameModel.LevelModel.IsFinished.Value) return;
            
            _view.FillBar.fillAmount = newValue / 1f;
        }

        private void HandleStatusType(PlayerStatusType newValue, PlayerStatusType oldValue)
        {
            if (_gameModel.LevelModel.IsFinished.Value) return;

            var color = Color.white;
            
            switch (newValue)
            {
                case PlayerStatusType.Poor:
                    if (oldValue == PlayerStatusType.Rich)
                    {
                        _view.UpgradeSkin(false);
                    }
                    color = Color.red;
                    break;
                case PlayerStatusType.Rich:
                    _view.UpgradeSkin(oldValue == PlayerStatusType.Poor);
                    color = Color.green;
                    break;
                case PlayerStatusType.Millionaire:
                    _view.UpgradeSkin(oldValue == PlayerStatusType.Rich);            
                    color = Color.yellow;
                    break;
            }
            
            _view.StatusText.text = newValue.ToString();
            _view.StatusText.color = color;
            _view.FillBar.color = color;
        }
    }
}