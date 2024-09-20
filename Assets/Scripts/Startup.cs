using DG.Tweening;
using Input;
using Level;
using Loader.Object;
using Loader.Scene;
using LoadingScreen;
using Player;
using Presenter;
using SceneManagement;
using SceneManagement.Collection;
using Specifications;
using UnityEngine;
using Updater;
using Utilities.Initializer;
using Utilities.Loader.Addressable;
using Utilities.Loader.Addressable.Scene;

public class Startup : MonoBehaviour
{
    public InputView InputView;

    private readonly PresentersList _presenters = new();
    private readonly UpdatersList _updatersList = new();
    private readonly UpdatersList _fixedUpdatersList = new();
    private readonly UpdatersList _lateUpdatersList = new();
    
    private GameModel _gameModel;

    private async void Start()
    {
        Application.runInBackground = true;
        DOTween.Init();
        
        var loadObjectsModel = new LoadObjectsModel(new AddressableObjectLoadWrapper());
        var specifications = new GameSpecifications(loadObjectsModel);
        await specifications.LoadAwaiter;

        _gameModel = new GameModel
        (
            _updatersList,
            _fixedUpdatersList,
            _lateUpdatersList,
            loadObjectsModel,
            new SceneManagementModelsCollection(),
            specifications, 
            new InputModel(), 
            new LoadingScreenModel(false),
            new PlayerModel(),
            new LevelModel("1")
        );
        
        _gameModel.LoadScenesModel = new LoadScenesModel(new AddressableSceneLoadWrapper(_gameModel));
        
        if (PlayerPrefs.GetInt("first_init") == 0)
        {
            new FirstInitializer().Initialize(_gameModel);
        }
        else
        {
            _gameModel.UpdateLevelIndex("1");
        }
        
        _presenters.Add(new SceneManagementModelsCollectionPresenter(_gameModel, (SceneManagementModelsCollection)_gameModel.SceneManagementModelsCollection));
        _presenters.Add(new InputPresenter(_gameModel, (InputModel) _gameModel.InputModel, InputView));
        _presenters.Init();
        
        _gameModel.SceneManagementModelsCollection.Load(SceneConst.Ui);
        _gameModel.SceneManagementModelsCollection.Load(SceneConst.Level);
    }

    private void Update()
    {
        _updatersList.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _fixedUpdatersList.Update(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        _lateUpdatersList.Update(Time.deltaTime);
    }

    private void OnDestroy()
    {
        _presenters.Dispose();
        _presenters.Clear();

        _updatersList.Clear();
        _fixedUpdatersList.Clear();
        _lateUpdatersList.Clear();
    }
}
