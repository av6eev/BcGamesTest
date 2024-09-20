using Presenter;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerAnimatorPresenter(IGameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _model.IsReady.OnChanged += HandleReady;
            _model.OnDied.OnChanged += HandleDie;
            _gameModel.LevelModel.IsFinished.OnChanged += HandleFinish;
        }

        public void Dispose()
        {
            _model.IsReady.OnChanged -= HandleReady;
            _model.OnDied.OnChanged -= HandleDie;
            _gameModel.LevelModel.IsFinished.OnChanged -= HandleFinish;
        }

        private void HandleReady(bool newValue, bool oldValue)
        {
            Debug.Log(newValue);
            _view.Animator.SetBool("IsRunning", newValue);
        }

        private void HandleDie()
        {
            _view.Animator.SetBool("IsLose", true);
        }

        private void HandleFinish(bool newValue, bool oldValue)
        {
            _view.Animator.SetBool("IsWin", newValue);
        }
    }
}