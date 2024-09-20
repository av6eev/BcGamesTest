using System;
using Interact;
using Presenter;
using UnityEngine;

namespace Player.Pickup
{
    public class PlayerPickupPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerPickupPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _view.OnPickUp += HandlePickUp;
        }

        public void Dispose()
        {
            _view.OnPickUp -= HandlePickUp;
        }

        private void HandlePickUp(InteractObjectView view)
        {
            var resultPrice = view.Price;
            switch (view.Type)
            {
                case InteractObjectType.Prop:
                    break;
                case InteractObjectType.Door:
                    break;
                case InteractObjectType.Obstacle:
                    _model.IsCollide = true;
                    break;
                default:
                    Debug.LogError($"No pickup found with type: {view.Type}");
                    break;
            }

            switch (view.AffectType)
            {
                case InteractObjectAffectType.Positive:
                    break;
                case InteractObjectAffectType.Negative:
                    resultPrice = -resultPrice;
                    break;
                case InteractObjectAffectType.Multiplier:
                    _model.MaxMoneyMultiplier.Value = view.Multiplier;
                    break;
            }
            
            _model.HandlePickup(resultPrice);
        }
    }
}