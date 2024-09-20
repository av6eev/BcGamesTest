using UnityEngine;

namespace Utilities.Initializer
{
    public class FirstInitializer
    {
        public void Initialize(GameModel gameModel)
        {
            PlayerPrefs.SetInt("first_init", 1);    
        }
    }
}