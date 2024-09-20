using Input;
using Level;
using Level.Tutorial;
using Loader.Object;
using Loader.Scene;
using LoadingScreen;
using Player;
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
    PlayerModel PlayerModel { get; }
    LevelModel LevelModel { get; }
    TutorialModel TutorialModel { get; }
}