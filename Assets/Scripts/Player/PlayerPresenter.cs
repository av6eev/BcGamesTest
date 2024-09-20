using Player.Die;
using Player.Finish;
using Player.Interact;
using Player.Sound;
using Player.Status;
using Player.Turn;
using Presenter;
using Updater;

namespace Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        private IUpdater _physicsUpdater;
        private readonly PresentersList _presenters = new();
        
        public PlayerPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _model.CurrentMoney.Value = 0;
            
            _presenters.Add(new PlayerTurnPresenter(_gameModel, _model, _view));
            _presenters.Add(new PlayerInteractPresenter(_gameModel, _model, _view));
            _presenters.Add(new PlayerDiePresenter(_gameModel, _model, _view));
            _presenters.Add(new PlayerFinishPresenter(_gameModel, _model, _view));
            _presenters.Add(new PlayerStatusPresenter(_gameModel, _model, _view));
            _presenters.Add(new PlayerAnimatorPresenter(_gameModel, _model, _view));
            _presenters.Add(new PlayerSoundPresenter(_gameModel, _model, _view));
            _presenters.Init();
            
            _physicsUpdater = new PlayerPhysicsUpdater(_gameModel.InputModel, _model, _view);
            _gameModel.FixedUpdatersList.Add(_physicsUpdater);
        }

        public void Dispose()
        {
            _presenters.Dispose();
            _presenters.Clear();
            
            _gameModel.FixedUpdatersList.Remove(_physicsUpdater);
        }
    }
}