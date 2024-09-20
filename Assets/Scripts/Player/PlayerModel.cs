using Reactive.Field;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public const float BaseSpeed = 5f;
        public const float SpeedMultiplier = 1.3f;
        public const float TurnSpeed = 3.5f;
        public const float SideSpeed = 1.3f;
        
        public float CurrentSpeed;

        public bool IsReady;
        public bool IsNeedToTurn;
        public Vector3 TurnDirection;

        public readonly ReactiveField<int> CurrentMoney = new();
    }
}