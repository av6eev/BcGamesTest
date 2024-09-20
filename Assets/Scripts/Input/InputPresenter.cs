using Presenter;
using UnityEngine;

namespace Input
{
    public class InputPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly InputModel _model;
        private readonly InputView _view;

        public InputPresenter(IGameModel gameModel, InputModel model, InputView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }

        public void Init()
        {
            _view.Initialize();

            _model.IsEnable.OnChanged += HandleStateChange;
        }

        public void Dispose()
        {
            _view.Dispose();
            
            _model.IsEnable.OnChanged -= HandleStateChange;
        }

        private void HandleStateChange(bool newValue, bool oldValue)
        {
            var playerActionMap = _view.PlayerInputAsset.FindActionMap("Player");

            switch (newValue)
            {
                case true:
                    playerActionMap.Enable();
                    break;
                default:
                    playerActionMap.Disable();
                    break;
            }
        }
    }
}