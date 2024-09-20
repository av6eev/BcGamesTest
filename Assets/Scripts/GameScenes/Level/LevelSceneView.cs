using Level.Manager;
using Player;
using UnityEngine;

namespace GameScenes.Level
{
    public class LevelSceneView : BaseGameSceneView
    {
        public LevelManagerView LevelManager;
        public Transform LevelRoot;
        public PlayerView PlayerView;
    }
}