using System.Collections.Generic;
using Level.Road;
using UnityEngine;

namespace Level
{
    public class LevelView : MonoBehaviour
    {
        public Transform PlayerSpawnPoint;
        [SerializeField] private List<RoadView> RoadElements;
        private int _nextElementIndex = 1;
        
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (PlayerSpawnPoint != null)
        {
            Gizmos.color = Color.magenta;
            var m = Gizmos.matrix;
            Gizmos.matrix = PlayerSpawnPoint.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
            Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
            Gizmos.matrix = m;
        }

        if (RoadElements.Count > 0)
        {
            for (var i = 0; i < RoadElements.Count - 1; i++)
            {
                var current = RoadElements[i].transform.position;
                var next = RoadElements[i + 1].transform.position;
                
                Gizmos.color = Color.black;
                Gizmos.DrawLine(current, next);
                if (i == 0) Gizmos.DrawSphere(current, 0.3f);
                Gizmos.DrawSphere(next, 0.3f);
            }
        }
    }
#endif
        
        public float GetNextTurn(Vector3 position)
        {
            var forward = RoadElements[_nextElementIndex].transform.position - position;
            
            if (forward.magnitude < 0.1f)
            {
                _nextElementIndex += 1;
            }
            
            return Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg;
        }
    }
}