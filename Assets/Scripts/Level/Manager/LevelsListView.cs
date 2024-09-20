using System.Collections.Generic;
using UnityEngine;

namespace Level.Manager
{
    [CreateAssetMenu(menuName = "Data/Lvls List")]
    public class LevelsListView : ScriptableObject
    {
        public bool randomizedLvls;
        public List<LevelView> lvls;
    }
}