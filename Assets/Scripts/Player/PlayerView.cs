using System;
using Interact;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public event Action<Vector3> OnTurn;
        public event Action<InteractObjectView> OnInteract; 
        
        public Rigidbody Rigidbody;

        public void Move(Vector3 direction)
        {
            transform.Translate(direction, Space.Self);
        }

        public void Rotate(Vector3 direction)
        {
            transform.localEulerAngles = direction;
        }

        public void InvokeTurn(Vector3 direction)
        {
            OnTurn?.Invoke(direction);
        }

        public void InvokePickUp(InteractObjectView objectView)
        {
            OnInteract?.Invoke(objectView);
        }

        public void ResetPosition(Vector3 spawnPoint)
        {
            transform.position = spawnPoint;
        }
    }
}