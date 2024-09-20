using Presenter;

namespace GameScenes.UI.PlayerInfo
{
    public class PlayerInfoPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerInfoView _view;

        public PlayerInfoPresenter(IGameModel gameModel, PlayerInfoView view)
        {
            _gameModel = gameModel;
            _view = view;
        }
        
        public void Init()
        {
        }

        public void Dispose()
        {
        }
    }
}