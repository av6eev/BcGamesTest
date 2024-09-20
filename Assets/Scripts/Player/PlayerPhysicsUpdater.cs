using Input;
using Level;
using UnityEngine;
using Updater;

namespace Player
{
    public class PlayerPhysicsUpdater : IUpdater
    {
        private const float CollideBreakTime = .8f;
        
        private readonly IInputModel _inputModel;
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        private float _currentRotation;
        private float _collideBreakTimer;
        
        public PlayerPhysicsUpdater(IInputModel inputModel, PlayerModel model, PlayerView view)
        {
            _inputModel = inputModel;
            _model = model;
            _view = view;
        }
        
        public void Update(float deltaTime)
        {
            if (!_model.IsReady) return;

            Move(deltaTime);
            Turn(deltaTime);
        }

        private void Move(float deltaTime)
        {
            float speed;

            if (_model.IsCollide)
            {
                speed = 1f;
                
                _collideBreakTimer += deltaTime;
                if (_collideBreakTimer >= CollideBreakTime)
                {
                    _collideBreakTimer = 0;
                    _model.IsCollide = false;
                }
            }
            else if (_model.IsNeedToTurn.Value)
            {
                speed = 1f;
            }
            else
            {
                speed = PlayerModel.BaseSpeed;
            }
            
            _model.CurrentSpeed = Mathf.Lerp(_model.CurrentSpeed, speed, .2f);
            
            var direction = new Vector3(_inputModel.SideInput.x * PlayerModel.SideSpeed, 0, _model.CurrentSpeed) * deltaTime;
            _view.Move(direction);
        }

        private void Turn(float deltaTime)
        {
            if (!_model.IsNeedToTurn.Value) return;
            
            var rotation = Vector3.Lerp(_view.transform.localEulerAngles, _model.TurnDirection, PlayerModel.TurnSpeed * deltaTime);
            _view.Rotate(rotation);

            if (Mathf.Abs(_view.transform.localEulerAngles.y - _model.TurnDirection.y) < 1f)
            {
                _model.IsNeedToTurn.Value = false;
                _model.TurnDirection = Vector3.zero;
            }
        }
    }
}