using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Level.Tutorial
{
    public class TutorialView : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnCompleted;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnCompleted?.Invoke();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}