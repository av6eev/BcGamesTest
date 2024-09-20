using System;
using Reactive.Event;
using Reactive.Field;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerModel
    {
        public readonly ReactiveEvent OnDied = new();
        
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
        public readonly ReactiveField<int> SavedMoney = new(PlayerPrefs.GetString(SaveKeys.PlayerSavedMoney, string.Empty) == string.Empty ? 0 : Convert.ToInt32(PlayerPrefs.GetString(SaveKeys.PlayerSavedMoney)));
        public readonly ReactiveField<int> MaxMoneyMultiplier = new();
        
        public void HandlePickup(int price)
        {
            var delta = CurrentMoney.Value + price;

            if (delta <= 0)
            {
                CurrentMoney.Value = 0;
                OnDied?.Invoke();
            }
            else
            {
                CurrentMoney.Value = delta;
            }
        }

        public int GetTotalMoneyPerLevel()
        {
            return CurrentMoney.Value * MaxMoneyMultiplier.Value;
        }
        
        public void CalculateSavedMoney()
        {
            SavedMoney.Value += GetTotalMoneyPerLevel();
        }

        public void Reset(bool isResetMoney)
        {
            IsReady = false;
            IsNeedToTurn.Value = false;
            IsCollide = false;
            CurrentSpeed = 0;
            TurnDirection = Vector3.zero;

            if (!isResetMoney) return;
            
            MaxMoneyMultiplier.Value = 0;
            CurrentMoney.Value = 0;
        }
    }
}