using Input;
using Level;
using UnityEngine;
using Updater;

namespace Player
{
    public class PlayerPhysicsUpdater : IUpdater
    {
        private readonly IInputModel _inputModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;
        private readonly LevelView _levelView;

        private float _currentRotation;
        private Vector3 _velocity;

        public PlayerPhysicsUpdater(IInputModel inputModel, PlayerModel model, PlayerView view, LevelView levelView)
        {
            _inputModel = inputModel;
            _model = model;
            _view = view;
            _levelView = levelView;
        }
        
        public void Update(float deltaTime)
        {
            if (!_inputModel.IsEnable.Value) return;
            if (!_model.IsReady) return;

            Move(deltaTime);
            Turn(deltaTime);
        }

        private void Move(float deltaTime)
        {
            var speed = _model.IsNeedToTurn ? 1f : PlayerModel.BaseSpeed;
            _model.CurrentSpeed = Mathf.Lerp(_model.CurrentSpeed, speed, .2f);
            
            var direction = new Vector3(_inputModel.SideInput.x * PlayerModel.SideSpeed, 0, _model.CurrentSpeed) * deltaTime;
            _view.Move(direction);
        }

        private void Turn(float deltaTime)
        {
            if (!_model.IsNeedToTurn) return;
            
            var rotation = Vector3.Lerp(_view.transform.localEulerAngles, _model.TurnDirection, PlayerModel.TurnSpeed * deltaTime);
            _view.Rotate(rotation);

            if (Mathf.Abs(_view.transform.localEulerAngles.y - _model.TurnDirection.y) < 1f)
            {
                _model.IsNeedToTurn = false;
                _model.TurnDirection = Vector3.zero;
            }
        }
    }
}