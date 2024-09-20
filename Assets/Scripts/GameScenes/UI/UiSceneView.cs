using GameScenes.UI.LevelInfo;
using GameScenes.UI.PlayerInfo;
using GameScenes.UI.Settings;
using GameScenes.UI.Windows.Lose;
using GameScenes.UI.Windows.Win;
using Level.Tutorial;
using LocationBuilder;

namespace GameScenes.UI
{
    public class UiSceneView : LocationSceneView
    {
        public TutorialView TutorialView;
        public SettingsView SettingsView;
        public PlayerInfoView PlayerInfoView;
        public LevelInfoView LevelInfoView;
        public LoseWindowView LoseWindowView;
        public WinWindowView WinWindowView;
    }
}