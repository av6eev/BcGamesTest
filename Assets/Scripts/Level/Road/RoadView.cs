using System;
using Player;
using UnityEngine;

namespace Level.Road
{
    public class RoadView : MonoBehaviour
    {
        [SerializeField] private bool _isNeedToHandleTurn;
        [SerializeField] private RoadTurnType TurnType;

        private void OnTriggerEnter(Collider other)
        {
            if (!_isNeedToHandleTurn) return;
            if (!other.CompareTag("Player")) return;
            
            var direction = other.transform.localEulerAngles;

            switch (TurnType)
            {
                case RoadTurnType.Right:
                    direction.y += 90f;
                    break;
                case RoadTurnType.Left:
                    direction.y -= 90f;
                    break;
            }
            
            Debug.Log(direction);
            
            other.GetComponent<PlayerView>().InvokeTurn(direction);
        }
    }
}