using System.Collections.Generic;
using System.Threading.Tasks;
using Presenter;

namespace GameScenes
{
    public abstract class BaseGameScenePresenter : IPresenter
    {
        protected readonly IGameModel GameModel;
        private readonly BaseGameSceneView _view;

        protected readonly Dictionary<string, IPresenter> Presenters = new();
        
        protected BaseGameScenePresenter(IGameModel gameModel, BaseGameSceneView view)
        {
            GameModel = gameModel;
            _view = view;
        }
        
        public async void Init()
        {
            AfterInit();
            
            GameModel.LoadingScreenModel.SetMaxLoadElementsCount(Presenters.Count);

            foreach (var presenter in Presenters)
            {
                GameModel.LoadingScreenModel.UpdateScreenMessage(presenter.Key);
                GameModel.LoadingScreenModel.IncrementProgressValue();

                presenter.Value.Init();
                
                await Task.Delay(1000);
            }

            await Task.Delay(1500);
            
            GameModel.LoadingScreenModel.Hide();
            GameModel.InputModel.Enable();
        }

        public void Dispose()
        {
            GameModel.LoadingScreenModel.Show();
            GameModel.InputModel.Disable();

            foreach (var presenter in Presenters.Values)
            {
                presenter.Dispose();
            }
            
            Presenters.Clear();
            
            AfterDispose();
        }

        protected abstract void AfterInit();
        protected abstract void AfterDispose();
    }
}