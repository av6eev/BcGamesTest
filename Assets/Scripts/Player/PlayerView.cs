using System;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public event Action<Vector3> OnTurn; 
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
    }
}