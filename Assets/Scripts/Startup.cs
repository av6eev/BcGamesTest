using GameScenes.UI.EnterNicknamePanel;
using Input;
using Loader.Object;
using Loader.Scene;
using LoadingScreen;
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
            new LoadingScreenModel(false)
        );

        _gameModel.EnterNicknamePanelModel = new EnterNicknamePanelModel();
        _gameModel.LoadScenesModel = new LoadScenesModel(new AddressableSceneLoadWrapper(_gameModel));

        if (PlayerPrefs.GetInt("first_init") == 0)
        {
            new FirstInitializer().Initialize(_gameModel);
        }
        
        _presenters.Add(new SceneManagementModelsCollectionPresenter(_gameModel, (SceneManagementModelsCollection)_gameModel.SceneManagementModelsCollection));
        _presenters.Add(new InputPresenter(_gameModel, (InputModel) _gameModel.InputModel, InputView));
        _presenters.Init();
        
        _gameModel.SceneManagementModelsCollection.Load(SceneConst.Ui);
        _gameModel.EnterNicknamePanelModel.Show();

        await _gameModel.EnterNicknamePanelModel.ConfirmAwaiter;
        
        _gameModel.EnterNicknamePanelModel.Hide();
        _gameModel.LoadingScreenModel.Show();
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
