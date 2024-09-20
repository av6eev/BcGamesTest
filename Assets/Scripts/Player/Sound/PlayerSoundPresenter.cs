using Interact;
using Presenter;
using Sound;

namespace Player.Sound
{
    public class PlayerSoundPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerSoundPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _view.OnInteract += HandleInteract;
            _model.OnDied.OnChanged += HandleDie;
        }

        public void Dispose()
        {
            _view.OnInteract -= HandleInteract;
            _model.OnDied.OnChanged -= HandleDie;
        }

        private void HandleDie()
        {
            SoundManager.Instance.Play(SoundsTypes.Lose);
        }

        private void HandleInteract(InteractObjectView objectView)
        {
            switch (objectView.Type)
            {
                case InteractObjectType.Prop:
                    SoundManager.Instance.Play(objectView.AffectType == InteractObjectAffectType.Negative ? SoundsTypes.RemoveMoney : SoundsTypes.CollectMoney);
                    break;
                case InteractObjectType.Door:
                    switch (objectView.AffectType)
                    {
                        case InteractObjectAffectType.Positive:
                            SoundManager.Instance.Play(SoundsTypes.CollectMoney);
                            break;
                        case InteractObjectAffectType.Negative:
                            SoundManager.Instance.Play(SoundsTypes.RemoveMoney);
                            break;
                        case InteractObjectAffectType.Multiplier:
                            SoundManager.Instance.Play(SoundsTypes.MultiplyMoney);
                            break;
                    }
                    break;
                case InteractObjectType.Obstacle:
                    SoundManager.Instance.Play(SoundsTypes.HitObstacle);
                    break;
                case InteractObjectType.FinishLine:
                    break;
                case InteractObjectType.Finish:
                    SoundManager.Instance.Play(SoundsTypes.Win);
                    break;
            }
        }
    }
}