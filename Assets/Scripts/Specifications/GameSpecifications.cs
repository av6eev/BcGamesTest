using Awaiter;
using Level.Specification;
using Loader.Object;
using Specification.Scene;
using Specifications.Collection;
using Specifications.LoadWrapper;

namespace Specifications
{
    public class GameSpecifications : IGameSpecifications
    {
        public ISpecificationsCollection<SceneSpecification> SceneSpecifications { get; } = new SpecificationsCollection<SceneSpecification>();
        public ISpecificationsCollection<LevelSpecification> LevelSpecifications { get; } = new SpecificationsCollection<LevelSpecification>();

        public readonly CustomAwaiter LoadAwaiter = new();
        
        public GameSpecifications(ILoadObjectsModel loadObjectsModel)
        {
            Load(loadObjectsModel);
        }

        private async void Load(ILoadObjectsModel loadObjectsModel)
        {
            await new LoadSpecificationsWrapper<SceneSpecification>(loadObjectsModel, "scenes", SceneSpecifications).LoadAwaiter;
            await new LoadSpecificationsWrapper<LevelSpecification>(loadObjectsModel, "levels", LevelSpecifications).LoadAwaiter;

            LoadAwaiter.Complete();
        }
    }
}