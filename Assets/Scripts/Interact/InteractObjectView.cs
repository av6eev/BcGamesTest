using Player;
using UnityEngine;

namespace Interact
{
    public class InteractObjectView : MonoBehaviour
    {
        public InteractObjectType Type;
        public InteractObjectAffectType AffectType;
        public int Price;
        public int Multiplier;
        public Animator Animator;
        public string TriggerKey;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            other.GetComponent<PlayerView>().InvokePickUp(this);
            PlayAnimation();
            
            if (Type != InteractObjectType.Door)
            {
                Destroy(gameObject);    
            }
            else
            {
                Destroy(gameObject, .5f);
            }
        }

        private void PlayAnimation()
        {
            if (Animator != null)
            {
                Animator.SetTrigger(TriggerKey);
            }
        }
    }
}