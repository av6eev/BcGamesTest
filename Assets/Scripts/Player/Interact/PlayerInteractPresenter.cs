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
            
            switch (objectView.Type)
            {
                case InteractObjectType.Prop:
                    break;
                case InteractObjectType.Door:
                    break;
                case InteractObjectType.FinishLine:
                    break;
                case InteractObjectType.Obstacle:
                    _model.IsCollide = true;
                    break;
                case InteractObjectType.Finish:
                    _gameModel.LevelModel.IsFinished.Value = true;
                    break;
            }

            switch (objectView.AffectType)
            {
                case InteractObjectAffectType.Positive:
                    break;
                case InteractObjectAffectType.Negative:
                    resultPrice = -resultPrice;
                    break;
                case InteractObjectAffectType.Multiplier:
                    _model.MaxMoneyMultiplier.Value = objectView.Multiplier;
                    break;
            }
            
            _model.HandlePickup(resultPrice);
            Object.Destroy(objectView.gameObject);
        }
    }
}