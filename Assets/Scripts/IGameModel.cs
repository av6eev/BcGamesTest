using GameScenes.UI.EnterNicknamePanel;
using Input;
using Level.Manager;
using Loader.Object;
using Loader.Scene;
using LoadingScreen;
using SceneManagement.Collection;
using Specifications;
using Updater;

public interface IGameModel : IBaseGameModel
{
    IUpdatersList UpdatersList { get; }
    IUpdatersList FixedUpdatersList { get; }
    IUpdatersList LateUpdatersList { get; }
    
    ILoadScenesModel LoadScenesModel { get; }
    ILoadObjectsModel LoadObjectsModel { get; }
    
    ISceneManagementModelsCollection SceneManagementModelsCollection { get; }
    IGameSpecifications Specifications { get; }
    IInputModel InputModel { get; }
    ILoadingScreenModel LoadingScreenModel { get; }
    EnterNicknamePanelModel EnterNicknamePanelModel { get; }
    LevelManagerView LevelManager { get; }
}