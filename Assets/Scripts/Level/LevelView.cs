using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> RoadElements;
        
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (playerSpawnPoint != null)
        {
            Gizmos.color = Color.magenta;
            var m = Gizmos.matrix;
            Gizmos.matrix = playerSpawnPoint.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
            Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
            Gizmos.matrix = m;
        }

        if (RoadElements.Count > 0)
        {
            for (var i = 0; i < RoadElements.Count - 1; i++)
            {
                var current = RoadElements[i].position;
                var next = RoadElements[i + 1].position;
                
                Gizmos.color = Color.black;
                Gizmos.DrawLine(current, next);
                if (i == 0) Gizmos.DrawSphere(current, 0.3f);
                Gizmos.DrawSphere(next, 0.3f);
            }
        }
    }
#endif
    }
}