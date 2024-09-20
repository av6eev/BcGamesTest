using GameScenes.Level;
using Level.Road;
using Presenter;
using UnityEngine;

namespace Player
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
            _view.OnTurn += HandleTurn;
        }

        public void Dispose()
        {
            _view.OnTurn -= HandleTurn;
        }

        private void HandleTurn(Vector3 direction)
        {
            _model.IsNeedToTurn = true;
            _model.TurnDirection = direction;
        }
    }
}