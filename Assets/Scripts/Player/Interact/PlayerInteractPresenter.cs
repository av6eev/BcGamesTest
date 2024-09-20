using Interact;
using Presenter;
using UnityEngine;

namespace Player.Pickup
{
    public class PlayerInteractPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerInteractPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _view.OnInteract += HandleInteract;
        }

        public void Dispose()
        {
            _view.OnInteract -= HandleInteract;
        }

        private void HandleInteract(InteractObjectView objectView)
        {
            var resultPrice = objectView.Price;
            var isProp = false;
            
            switch (objectView.Type)
            {
                case InteractObjectType.Prop:
                    isProp = true;
                    break;
                case InteractObjectType.Door:
                    isProp = true;
                    break;
                case InteractObjectType.FinishLine:
                    break;
                case InteractObjectType.Obstacle:
                    isProp = true;
                    _model.IsCollide = true;
                    break;
                case InteractObjectType.Finish:
                    _gameModel.LevelModel.IsFinished.Value = true;
                    break;
            }

            switch (objectView.AffectType)
            {
                case InteractObjectAffectType.Positive:
                    if (isProp)
                    {
                        _model.UpdateStatus(.1f);
                    }
                    break;
                case InteractObjectAffectType.Negative:
                    resultPrice = -resultPrice;
                    if (isProp)
                    {
                        _model.UpdateStatus(-.1f);
                    }
                    break;
                case InteractObjectAffectType.Multiplier:
                    _model.MaxMoneyMultiplier.Value = objectView.Multiplier;
                    break;
            }
            
            _model.HandlePickup(resultPrice);
        }
    }
}