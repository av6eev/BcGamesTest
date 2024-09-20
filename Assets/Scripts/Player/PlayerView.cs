using System;
using System.Collections.Generic;
using Interact;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public event Action<Vector3> OnTurn;
        public event Action<InteractObjectView> OnInteract; 
        
        public Rigidbody Rigidbody;
        
        public GameObject StatusRoot;
        public Image FillBar;
        public TextMeshProUGUI StatusText;
        
        public List<GameObject> Skins;
        public Animator Animator;
        
        private int _skinIndex = 0;
        
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
        
        public void SetDefaultSkin()
        {
            _skinIndex = 0;

            for (var i = 0; i < Skins.Count; i++)
            {
                if (i == 0) 
                {
                    Skins[i].SetActive(true);
                    continue;
                }
                
                Skins[i].SetActive(false);
            }
        } 
        
        public void UpgradeSkin(bool isPositive)
        {
            if (isPositive)
            {
                if (Skins[_skinIndex + 1] == null) return;
            
                Skins[_skinIndex].SetActive(false);
                _skinIndex++;
                Skins[_skinIndex].SetActive(true);
            }
            else
            {
                if (Skins[_skinIndex - 1] == null) return;
            
                Skins[_skinIndex].SetActive(false);
                _skinIndex--;
                Skins[_skinIndex].SetActive(true);
            }
            
        } 
    }
}