using GameScenes.UI.EnterNicknamePanel;
using Input;
using Level.Manager;
using Loader.Object;
using Loader.Scene;
using LoadingScreen;
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
    public EnterNicknamePanelModel EnterNicknamePanelModel { get; set; }
    public LevelManagerView LevelManager { get; set; }

    public GameModel(
        IUpdatersList updatersList,
        IUpdatersList fixedUpdatersList,
        IUpdatersList lateUpdatersList,
        ILoadObjectsModel loadObjectsModel,
        ISceneManagementModelsCollection sceneManagementModelsCollection,
        IGameSpecifications specifications,
        IInputModel inputModel,
        ILoadingScreenModel loadingScreenModel)
    {
        UpdatersList = updatersList;
        FixedUpdatersList = fixedUpdatersList;
        LateUpdatersList = lateUpdatersList;
        LoadObjectsModel = loadObjectsModel;
        SceneManagementModelsCollection = sceneManagementModelsCollection;
        Specifications = specifications;
        InputModel = inputModel;
        LoadingScreenModel = loadingScreenModel;
    }
}