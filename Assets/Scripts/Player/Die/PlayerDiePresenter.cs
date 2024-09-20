using Presenter;

namespace Player.Die
{
    public class PlayerDiePresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerDiePresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _model.OnDied.OnChanged += HandleDie;
        }

        public void Dispose()
        {
            _model.OnDied.OnChanged -= HandleDie;
        }

        private void HandleDie()
        {
            _model.Reset(true);
        }
    }
}