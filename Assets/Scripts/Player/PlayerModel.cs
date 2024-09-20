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
        public Vector3 TurnDirection;

        public bool IsReady;
        public bool IsCollide;
        public readonly ReactiveField<bool> IsNeedToTurn = new();
        public readonly ReactiveField<int> CurrentMoney = new();
        public readonly ReactiveField<int> MaxMoneyMultiplier = new();

        public void HandlePickup(int price)
        {
            CurrentMoney.Value += price;

            if (CurrentMoney.Value <= 0)
            {
                CurrentMoney.Value = 0;
            }
        }
    }
}