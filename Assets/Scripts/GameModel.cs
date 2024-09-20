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

public class GameModel : IGameModel 
{
    public IUpdatersList UpdatersList { get; }
    public IUpdatersList FixedUpdatersList { get; }
    public IUpdatersList LateUpdatersList { get; }
    public ILoadScenesModel LoadScenesModel { get; set; }
    public ILoadObjectsModel LoadObjectsModel { get; }
    public ISceneManagementModelsCollection SceneManagementModelsCollection { get; }
    public IGameSpecifications Specifications { get; }
    public IInputModel InputModel { get; }
    public ILoadingScreenModel LoadingScreenModel { get; }
    public PlayerModel PlayerModel { get; }
    public LevelModel LevelModel { get; }
    public TutorialModel TutorialModel { get; set; }
    
    public string CurrentLevelId { get; private set; }

    public GameModel(IUpdatersList updatersList,
        IUpdatersList fixedUpdatersList,
        IUpdatersList lateUpdatersList,
        ILoadObjectsModel loadObjectsModel,
        ISceneManagementModelsCollection sceneManagementModelsCollection,
        IGameSpecifications specifications,
        IInputModel inputModel,
        ILoadingScreenModel loadingScreenModel,
        PlayerModel playerModel,
        LevelModel levelModel)
    {
        UpdatersList = updatersList;
        FixedUpdatersList = fixedUpdatersList;
        LateUpdatersList = lateUpdatersList;
        LoadObjectsModel = loadObjectsModel;
        SceneManagementModelsCollection = sceneManagementModelsCollection;
        Specifications = specifications;
        InputModel = inputModel;
        LoadingScreenModel = loadingScreenModel;
        PlayerModel = playerModel;
        LevelModel = levelModel;
    }

    public void UpdateLevelIndex(string id) => CurrentLevelId = id;
}