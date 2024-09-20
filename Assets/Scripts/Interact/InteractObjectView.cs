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

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            other.GetComponent<PlayerView>().InvokePickUp(this);
        }
    }
}