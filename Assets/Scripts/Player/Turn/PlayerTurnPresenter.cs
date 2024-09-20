using Presenter;
using UnityEngine;

namespace Player.Turn
{
    public class PlayerTurnPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerTurnPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _model.IsNeedToTurn.OnChanged += HandleTurnStateChange;
            _view.OnTurn += HandleTurn;
        }

        public void Dispose()
        {
            _model.IsNeedToTurn.OnChanged -= HandleTurnStateChange;
            _view.OnTurn -= HandleTurn;
        }

        private void HandleTurnStateChange(bool newValue, bool oldValue)
        {
            switch (newValue)
            {
                case true:
                    _gameModel.InputModel.Disable();
                    break;
                case false:
                    _gameModel.InputModel.Enable();
                    break;
            }
        }

        private void HandleTurn(Vector3 direction)
        {
            _model.IsNeedToTurn.Value = true;
            _model.TurnDirection = direction;
        }
    }
}